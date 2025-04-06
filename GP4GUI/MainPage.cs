using libgp4;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using static GP4GUI.Common;

#if DEBUG
using static GP4GUI.Testing;
#endif


namespace GP4GUI {
    public partial class MainForm : Form {
        public MainForm()
        {
            // Initialize .gp4 creator instance, and set logging method to "OutputWindow"
            gp4 = new GP4Creator {
#if DEBUG
                VerboseOutput = true,
                DebugOutput = true,
#endif
                SkipIntegrityCheck = false,
                SkipEndComment = false
            };

            
            // Initialize and Decorate Form, Then Set Event Handlers
            InitializeComponent();
            InitializeAdditionalEventHandlers();
            CreateBrowseModeDropdownMenu();
            
            // Set logging method to "OutputWindow"
            gp4.LoggingMethod = (obj) =>
            {
                OutputWindow.AppendLine($"{obj}");
                OutputWindow.Update();
            };

            // Set Form Refferences
            Venat = this;
            Azem = new OptionsPage();
#if DEBUG
            DebugOptions = new Testing(Venat, gp4, new Point(DebugOptionsBtn.Location.X, DebugOptionsBtn.Location.Y + DebugOptionsBtn.Size.Height - 2));
#else
            DebugOptionsBtn.Visible = DebugOptionsBtn.Enabled = false;
#endif

            // Set Output Box Ptr
            _OutputWindow = OutputWindow;
        }





        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        

        /// <summary>                                         deng
        /// Post-InitializeComponent Configuration. <br/><br/>
        /// Create Assign Anonomous Event Handlers to Parent and Children.
        /// </summary>
        public void InitializeAdditionalEventHandlers()
        {
            MinimizeBtn.Click      += new EventHandler((sender, e) => ActiveForm.WindowState      = FormWindowState.Minimized     );
            MinimizeBtn.MouseEnter += new EventHandler((sender, e) => ((Control)sender).ForeColor = Color.FromArgb(90, 100, 255  ));
            MinimizeBtn.MouseLeave += new EventHandler((sender, e) => ((Control)sender).ForeColor = Color.FromArgb(0 , 0  , 0    ));
            ExitBtn.Click          += new EventHandler((sender, e) => Environment.Exit(                            0             ));
            ExitBtn.MouseEnter     += new EventHandler((sender, e) => ((Control)sender).ForeColor = Color.FromArgb(230, 100, 100 ));
            ExitBtn.MouseLeave     += new EventHandler((sender, e) => ((Control)sender).ForeColor = Color.FromArgb(0  , 0  , 0   ));


            // Set Event Handlers for Form Dragging
            MouseDown += new MouseEventHandler((sender, e) => {
                MouseDif = new Point(MousePosition.X - Location.X, MousePosition.Y - Location.Y);

                MouseIsDown = true;
                DropdownMenu[1].Visible = DropdownMenu[0].Visible = false;
            });
            MouseUp   += new MouseEventHandler((sender, e) => { MouseIsDown = false; if (OptionsPageIsOpen) Azem?.BringToFront(); });
            MouseMove += new MouseEventHandler((sender, e) => MoveForm());


            // Set appropriate event handlers for the controls on the form as well
            foreach (Control Item in Controls)
            {
                if (Item.Name == "SwapBrowseModeBtn") // lazy fix to avoid the mouse down event confliciting with the button
                    continue;
                
                Item.MouseDown += new MouseEventHandler((sender, e) => {
                    MouseDif = new Point(MousePosition.X - Venat.Location.X, MousePosition.Y - Venat.Location.Y);
                    MouseIsDown = true;
                    DropdownMenu[1].Visible = DropdownMenu[0].Visible = false;
                });
                Item.MouseUp   += new MouseEventHandler((sender, e) => { MouseIsDown = false; if (OptionsPageIsOpen) Azem?.BringToFront(); });
                
                // Avoid Applying MoveForm EventHandler to Text Containters (to retain the ability to drag-select text)
                if (Item.GetType() != typeof(TextBox) && Item.GetType() != typeof(RichTextBox))
                    Item.MouseMove += new MouseEventHandler((sender, e) => MoveForm());
            }

            Paint += PaintBorder;
        }

        

        /// <summary>
        /// Toggle The OptionsPage Window for .gp4 Option Editing, and Move to New Location.
        /// </summary>
        private void ToggleOptionsWindowVisibility()
        {
            Azem.Visible = OptionsPageIsOpen ^= true;
		    Azem.Location = new Point(Venat.Location.X + (Venat.Size.Width - Azem.Size.Width)/2, Venat.Location.Y + 80);
            Azem.Update();

            DropdownMenu[1].Visible = DropdownMenu[0].Visible = false;
        }

        /// <summary>
        /// Initialize Dropdown Menu Used for Toggling of Folder Browser Method
        /// </summary>
        private void CreateBrowseModeDropdownMenu()
        {
            var extalignment = BrowseBtn.Size.Height;
            var alignment = BrowseBtn.Location;

            var ButtonSize = new Size(BrowseBtn.Size.Width + SwapBrowseModeBtn.Size.Width, 25);

            DropdownMenu[0] = new Button() {
                Font = new Font("Gadugi", 7.25f, FontStyle.Bold),
                Text = "Directory Tree*",
                BackColor = AppColour,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(alignment.X, alignment.Y + extalignment),
                Size = ButtonSize
            };
            DropdownMenu[1] = new Button() {
                Font = new Font("Gadugi", 7.25F, FontStyle.Bold),
                Text = "File Browser",
                BackColor = AppColour,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(alignment.X, alignment.Y + extalignment + DropdownMenu[0].Size.Height),
                Size = ButtonSize
            };



            // Create and Assign Event Handlers
            DropdownMenu[0].Click += (why, does) => {
                if (!LegacyFolderSelectionDialogue) {
                    DropdownMenu[0].Text += '*';
                    DropdownMenu[1].Text = DropdownMenu[1].Text.Remove(DropdownMenu[1].Text.Length-1);

                    LegacyFolderSelectionDialogue ^= true;
                }
            };
            DropdownMenu[1].Click += (my, back) => {
                if (LegacyFolderSelectionDialogue) {
                    DropdownMenu[1].Text += '*';
                    DropdownMenu[0].Text = DropdownMenu[0].Text.Remove(DropdownMenu[0].Text.Length-1);

                    LegacyFolderSelectionDialogue ^= true;
                }
            };



            // Add Controls to MainForm Control Collection
            Controls.Add(DropdownMenu[0]);
            Controls.Add(DropdownMenu[1]);

            // Ensure Controls Display Correctly
            DropdownMenu[0].Hide();
            DropdownMenu[1].Hide();
            DropdownMenu[0].BringToFront();
            DropdownMenu[1].BringToFront();
        }


        
        /// <summary>
        /// Create the .gp4 Project File.
        /// </summary>
        private void SetupAndCreateProjectFile(object sender, EventArgs e)
        {
#if DEBUG
            if (GamedataPathTextBox.IsDefault() && TestGamedataFolder.Length != 0)
            {
                gp4.GamedataFolder = TestGamedataFolder;
            }
#endif



            //#
            //## Assign Defaults/Verify Options.
            //#

            // Apply Current Options to GP4Creator Instance, and Apply Defaults to Any Left Unassigned.
            if (OptionsPageIsOpen)
            {
                Azem.SaveOptions();
            }


            // Check for Unassigned Gamedata Path Before Proceeding
            if (GamedataPathTextBox.IsDefault())
            {
#if DEBUG
                if (gp4.GamedataFolder.Remove(gp4.GamedataFolder.LastIndexOf('-')) == TestGamedataFolder.Remove(TestGamedataFolder.LastIndexOf('-')))
                {
                    Print("Using Test Gamedata Folder.");
                }
                else
#endif
                {
                    Print("Please Assign A Valid Gamedata Folder Before Building.\n");
                    return;
                }
            }
            // Read Current Gamedata Folder Path From The Text Box
            else {
                gp4.GamedataFolder = GamedataPathTextBox.Text.Replace("\"", string.Empty);
            }

            // Ensure Keystone is Present if Applicable
            if (gp4.SfoParams.category == "gd" && !gp4.IgnoreKeystone && !File.Exists($@"{gp4.GamedataFolder}\sce_sys\keystone"))
            {
                Print($"ERROR; No keystone File Found In Project Folder.\n\n");
                return;
            }




            //#
            //## Begin .gp4 Creation if all's well
            //#
            gp4.CreateGP4();
        }
        #endregion


        

        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]


        private void OptionsBtn_Click(object sender, EventArgs _) => ToggleOptionsWindowVisibility();


        private void DebugOptionsBtn_Click(object sender, EventArgs _)
        {
#if DEBUG
            DebugOptions.Visible = DebugOptions.Enabled ^= true;
#endif
        }


        /// <summary>
        /// Wipe the Text in OutputWindow
        /// </summary>
        private void ClearLogBtn_Click(object sender, EventArgs _) => OutputWindow.Clear();

        

        /// <summary>
        /// Use The Dummy File Method To Open A Folder.
        /// </summary>
        private void BrowseBtn_Click(object sender, EventArgs _)
        {
            // Use the ghastly Directory Tree Dialogue to Choose A Folder
            if (LegacyFolderSelectionDialogue)
            {
                using (var FBrowser = new FolderBrowserDialog { Description = "Please Select the Desired Gamedata Folder" })
                {
                    if (FBrowser.ShowDialog() == DialogResult.OK) {
                        GamedataPathTextBox.Set(FBrowser.SelectedPath);
                    }
                }

            }
            // Use The Newer "Hackey" Method
            else {
                using(var Browser = new OpenFileDialog {
                    ValidateNames   = false,
                    CheckPathExists = false,
                    CheckFileExists = false,
                    Title    = "(Don't click anything IN the desired folder, this dialogue is terrible)", 
                    Filter   = "Folder Selection|*.",
                    FileName = "Press 'Open' Inside The Desired Folder."
                })
                if (Browser.ShowDialog() == DialogResult.OK)
                    GamedataPathTextBox.Set(Browser.FileName.Remove(Browser.FileName.LastIndexOf('\\')));
            }
        }



        /// <summary>
        /// Toggle Dowpdown Menu Visibility.
        /// </summary>
        private void SwapBrowseModeBtn_Click(object _, EventArgs __) => DropdownMenu[1].Visible = DropdownMenu[0].Visible ^= true;

        
        /// <summary>
        /// Verify an Existing .gp4 Project File.
        /// </summary>
        private void VerifyGP4Btn_Click(object sender, EventArgs e)
        {
            var path = string.Empty;
#if DEBUG
            path = TestGP4Path;
#else
            var browser = new OpenFileDialog {
                Title = "Please Select a .gp4 Project File."
            };

            
            if (!GamedataPathTextBox.IsDefault())
            {
                var pathboxtext = GamedataPathTextBox.Text;
                if (Directory.Exists(pathboxtext))
                    browser.InitialDirectory = pathboxtext;

                else if (File.Exists(pathboxtext))
                {
                    Print("Using .gp4 Path in Gamedata Folder Path Box Instead of Browsing.");
                    path = pathboxtext;
                }

            }

            if (path == string.Empty && browser.ShowDialog() == DialogResult.OK)
                path = browser.FileName;

#endif
            if (path != string.Empty && File.Exists(path))
                new GP4Reader(path).VerifyGP4((message) => { Print(message); });
            else
                Print("Invalid .gp4 file path provided.");
        }
        #endregion
    }
}
