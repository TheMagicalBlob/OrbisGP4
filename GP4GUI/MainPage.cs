using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static GP4GUI.Common;
using libgp4;

namespace GP4GUI {
    public partial class MainForm : Form {
        public MainForm() {

            // Initialize and Decorate Form, Then Set Event Handlers
            InitializeComponent();
            PostInitFormLogic();
            CreateBrowseModeDropdownMenu();
            Paint += PaintBorder;

            // Initialize .gp4 Creator Instance, and Set Logging Method to OutputWindow
            gp4 = new GP4Creator {
                LoggingMethod = (object str) => {
                    OutputWindow.AppendLine($"#libgp4: {str}");
                    OutputWindow.Update();
                },
            };
            
            // Set Form Refferences
            Venat = this;
            Azem = new OptionsPage();

            // Set Output Box Ptr
            _OutputWindow = OutputWindow;
        }
        public static Button[] DropdownMenu = new Button[2];

/*
        private void TestBtn_Click(object sender, EventArgs e)
        {
            #if DEBUG
            gp4.VerboseOutput = true;
            gp4.OutputDirectory = @"C:\Users\msblob\gp4";
            var newgp4path = gp4.CreateGP4();
            if (newgp4path == null) {
                WLog("Error: CreateGP4() Returned Null, Aborting.");
                return;
            }


            // instance tests \\
            var newgp4 = new GP4Reader(newgp4path);

            newgp4.VerifyGP4();
            WLog("================== Instnce Tests Start ====================");
            var cat = newgp4.IsPatchProject;
            WLog($"Is Patch Project: {cat}");
            if (cat) WLog($"Source .pkg Path: {newgp4.BaseAppPkgPath}");


            WLog($"{newgp4.Files.Length} Files");
            foreach(var f in newgp4.Files)
                WLog($"  {f}");
            WLog($"{newgp4.Subfolders.Length} Subfolders");
            foreach(var s in newgp4.Subfolders)
                WLog($"  {s}");
            foreach(var sn in newgp4.SubfolderNames)
                WLog($"  {sn}");


            WLog($"{newgp4.ChunkCount} Chunks");
            foreach(var c in newgp4.Chunks)
                WLog($"  {c}");
            WLog($"{newgp4.ScenarioCount} Scenarios");
            WLog($"(Default Scenario: {newgp4.DefaultScenarioId})");
            foreach(var sc in newgp4.Scenarios)
                WLog($"Scenario {sc.Id}: Label={sc.Label} Type={sc.Type} InitialChunkCount:{sc.InitialChunkCount} Range={sc.ChunkRange}");


            WLog($"Content Id: {newgp4.ContentID}");
            WLog($"Passcode: {newgp4.Passcode}");
            WLog($".sfo Timestamp: {newgp4.Timestamp}");
            WLog("================== Instnce Tests End ====================\n\n");
            ///==============\\\


            // static tests \\
            WLog("================== Static Tests Start ====================");
            string[] files, subfolders;
            var _cat = GP4Reader.IsPatchPackage(newgp4path);
            WLog($"Is Patch Project: {_cat}");
            if(_cat) WLog($"Source .pkg Path: {GP4Reader.GetBasePkgPath(newgp4path)}");

            WLog($"{(files = GP4Reader.GetFileListing(newgp4path)).Length} Files");
            foreach(var f in files)
                WLog($"  {f}");
            WLog($"{(subfolders = GP4Reader.GetFolderListing(newgp4path)).Length} Subfolders");
            foreach(var s in subfolders)
                WLog($"  {s}");
            foreach(var sn in GP4Reader.GetFolderNames(newgp4path))
                WLog($"  {sn}");


            WLog($"{GP4Reader.GetChunkCount(newgp4path)} Chunks");
            foreach(var c in GP4Reader.GetChunkListing(newgp4path))
                WLog($"  {c}");
            WLog($"{GP4Reader.GetScenarioCount(newgp4path)} Scenarios");
            WLog($"(Default Scenario: {GP4Reader.GetDefaultScenarioId(newgp4path)})");
            foreach(var sc in GP4Reader.GetScenarioListing(newgp4path))
                WLog($"Scenario {sc.Id}: Label={sc.Label} Type={sc.Type} InitialChunkCount:{sc.InitialChunkCount} Range={sc.ChunkRange}");


            WLog($"Content Id: {GP4Reader.GetContentId(newgp4path)}");
            WLog($"Passcode: {GP4Reader.GetPkgPasscode(newgp4path)}");
            WLog($".sfo Timestamp: {GP4Reader.GetTimestamp(newgp4path)}");
            WLog("================== Static Tests End ====================");
            ///=============\\\

            System.Diagnostics.Process.Start(newgp4path);
            
            #endif
        }
*/

        //##########################################\\
        //--      Designer Managed Functions      --\\
        //##########################################\\
        #region Designer Managed Functions

        private IContainer components = null;
        protected override void Dispose(bool disposing) {
            if(disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.CreateProjectFileBtn = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.OptionsBtn = new System.Windows.Forms.Button();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.dummy = new System.Windows.Forms.Button();
            this.SwapBrowseModeBtn = new System.Windows.Forms.Button();
            this.OutputWindow = new GP4GUI.RichTextBox();
            this.GamedataFolderPathBox = new GP4GUI.TextBox();
            this.SuspendLayout();
            // 
            // CreateProjectFileBtn
            // 
            this.CreateProjectFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.CreateProjectFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CreateProjectFileBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.CreateProjectFileBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CreateProjectFileBtn.Location = new System.Drawing.Point(487, 80);
            this.CreateProjectFileBtn.Name = "CreateProjectFileBtn";
            this.CreateProjectFileBtn.Size = new System.Drawing.Size(50, 24);
            this.CreateProjectFileBtn.TabIndex = 3;
            this.CreateProjectFileBtn.Text = "Build";
            this.CreateProjectFileBtn.UseVisualStyleBackColor = false;
            this.CreateProjectFileBtn.Click += new System.EventHandler(this.SetupAndCreateProjectFile);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Gadugi", 9.25F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.Title.Location = new System.Drawing.Point(196, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(157, 17);
            this.Title.TabIndex = 0;
            this.Title.Text = ".gp4 Project File Creator";
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MinimizeBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MinimizeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimizeBtn.Location = new System.Drawing.Point(495, 2);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(22, 22);
            this.MinimizeBtn.TabIndex = 4;
            this.MinimizeBtn.Text = "-";
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ExitBtn.Location = new System.Drawing.Point(517, 2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(22, 22);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "X";
            this.ExitBtn.UseVisualStyleBackColor = false;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.BrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BrowseBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.BrowseBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.BrowseBtn.Location = new System.Drawing.Point(458, 38);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(65, 24);
            this.BrowseBtn.TabIndex = 7;
            this.BrowseBtn.Text = "Browse...";
            this.BrowseBtn.UseVisualStyleBackColor = false;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // OptionsBtn
            // 
            this.OptionsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.OptionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OptionsBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.OptionsBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OptionsBtn.Location = new System.Drawing.Point(4, 4);
            this.OptionsBtn.Name = "OptionsBtn";
            this.OptionsBtn.Size = new System.Drawing.Size(84, 23);
            this.OptionsBtn.TabIndex = 9;
            this.OptionsBtn.Text = "Tool Options";
            this.OptionsBtn.UseVisualStyleBackColor = false;
            this.OptionsBtn.Click += new System.EventHandler(this.ToggleOptionsWindowVisibility);
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClearLogBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.ClearLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearLogBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.ClearLogBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.ClearLogBtn.Location = new System.Drawing.Point(447, 81);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(38, 22);
            this.ClearLogBtn.TabIndex = 15;
            this.ClearLogBtn.Text = "Clear";
            this.ClearLogBtn.UseVisualStyleBackColor = false;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // dummy
            // 
            this.dummy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dummy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dummy.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.1F);
            this.dummy.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dummy.Location = new System.Drawing.Point(0, 0);
            this.dummy.Name = "dummy";
            this.dummy.Size = new System.Drawing.Size(0, 0);
            this.dummy.TabIndex = 0;
            this.dummy.UseVisualStyleBackColor = false;
            // 
            // SwapBrowseModeBtn
            // 
            this.SwapBrowseModeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.SwapBrowseModeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwapBrowseModeBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.SwapBrowseModeBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.SwapBrowseModeBtn.Location = new System.Drawing.Point(524, 38);
            this.SwapBrowseModeBtn.Name = "SwapBrowseModeBtn";
            this.SwapBrowseModeBtn.Size = new System.Drawing.Size(14, 24);
            this.SwapBrowseModeBtn.TabIndex = 16;
            this.SwapBrowseModeBtn.UseVisualStyleBackColor = false;
            this.SwapBrowseModeBtn.Click += new System.EventHandler(this.SwapBrowseModeBtn_Click);
            // 
            // OutputWindow
            // 
            this.OutputWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(10)))));
            this.OutputWindow.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.OutputWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.OutputWindow.Location = new System.Drawing.Point(5, 107);
            this.OutputWindow.MaxLength = 21474836;
            this.OutputWindow.Name = "OutputWindow";
            this.OutputWindow.ReadOnly = true;
            this.OutputWindow.Size = new System.Drawing.Size(532, 275);
            this.OutputWindow.TabIndex = 6;
            this.OutputWindow.Text = "";
            // 
            // GamedataFolderPathBox
            // 
            this.GamedataFolderPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.GamedataFolderPathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GamedataFolderPathBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.GamedataFolderPathBox.Location = new System.Drawing.Point(5, 38);
            this.GamedataFolderPathBox.Name = "GamedataFolderPathBox";
            this.GamedataFolderPathBox.Size = new System.Drawing.Size(452, 24);
            this.GamedataFolderPathBox.TabIndex = 2;
            this.GamedataFolderPathBox.Text = "Paste The Gamedata Folder Path Here, Or Use The Browse Button...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(541, 387);
            this.Controls.Add(this.SwapBrowseModeBtn);
            this.Controls.Add(this.dummy);
            this.Controls.Add(this.ClearLogBtn);
            this.Controls.Add(this.OptionsBtn);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.OutputWindow);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.GamedataFolderPathBox);
            this.Controls.Add(this.CreateProjectFileBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "GP4 Project Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        //==========================================\\

        

        //#######################################\\
        //--     Basic Form Init Functions     --\\
        //#######################################\\
        #region Basic Form Init Functions
                                                                    // deng
        /// <summary> Post-InitializeComponent Configuration.<br/><br/>
        /// Create Assign Anonomous Event Handlers to Parent and Children.
        /// </summary>
        public void PostInitFormLogic()
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
            MouseUp   += new MouseEventHandler((sender, e) => MouseIsDown = false);
            MouseMove += new MouseEventHandler((sender, e) => DragForm());

            
            foreach(Control Item in Controls)
            {
                Item.MouseDown += new MouseEventHandler((sender, e) => {
                    MouseDif = new Point(MousePosition.X - Venat.Location.X, MousePosition.Y - Venat.Location.Y);
                    MouseIsDown = true;
                    DropdownMenu[1].Visible = DropdownMenu[0].Visible = false;
                });
                Item.MouseUp   += new MouseEventHandler((sender, e) => MouseIsDown = false);
                
                // Avoid Applying MoveForm EventHandler to Text Containters (to retain the ability to drag-select text)
                if (Item.GetType() != typeof(TextBox) && Item.GetType() != typeof(RichTextBox))
                    Item.MouseMove += new MouseEventHandler((sender, e) => DragForm());
            }
        }

        

        #endregion
        //=======================================\\


        //###############################################\\
        //--     Main Form Functions and Variables     --\\
        //###############################################\\
        #region Main Form Functions & Variables


        // Wipe the Text in OutputWindow
        private void ClearLogBtn_Click(object _, EventArgs __) => OutputWindow.Clear();


        // Toggle The OptionsPage Window for .gp4 Option Editing, and Move to New Location
        private void ToggleOptionsWindowVisibility(object _, EventArgs __)
        {
            Azem.Visible = OptionsPageIsOpen ^= true;
		    Azem.Location = new Point(Venat.Location.X + (Venat.Size.Width - Azem.Size.Width)/2, Venat.Location.Y + 130);
            Azem.Update();

            DropdownMenu[1].Visible = DropdownMenu[0].Visible = false;
        }

        
        // Use The Dummy File Method To Open A Folder.
        private void BrowseBtn_Click(object _, EventArgs __)
        {
            // Use the ghastly Directory Tree Dialogue to Choose A Folder
            if (LegacyFolderSelectionDialogue)
            {
                using (var FBrowser = new FolderBrowserDialog { Description = "Please Select the Desired Gamedata Folder" })
                {
                    if (FBrowser.ShowDialog() == DialogResult.OK) {
                        GamedataFolderPathBox.Set(FBrowser.SelectedPath);
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
                    GamedataFolderPathBox.Set(Browser.FileName.Remove(Browser.FileName.LastIndexOf('\\')));
            }
        }


        // Toggle Dowpdown Menu Visibility
        private void SwapBrowseModeBtn_Click(object _, EventArgs __)
        {
            DropdownMenu[1].Visible = DropdownMenu[0].Visible ^= true;
        }


        // Initialize Dropdown Menu Used for Toggling of Folder Browser Method
        private void CreateBrowseModeDropdownMenu() {
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


        //#
        //## Create the .gp4 Project File.
        //#
        private void SetupAndCreateProjectFile(object sender, EventArgs e)
        {

            //# Print GP4Creator Options
            #if DEBUG
/*
            WLog($"\n===============================================");
            foreach (var param in typeof(GP4Creator.SfoParser).GetFields())
            WLog($"{param.Name} == {param.GetValue(gp4?.SfoParams)}");
            WLog($"===============================================\n");
*/
            #endif


            //#
            //## Assign Defaults/Verify Options.
            //#
            # region [Assign Defaults/Verify Options]

            // Apply Current Options to GP4Creator Instance, and Apply Defaults to Any Left Unassigned.
            if (OptionsPageIsOpen) Azem.SaveOptions();
            gp4.GamedataFolder = GamedataFolderPathBox.Text.Replace("\"", string.Empty);


            // Check for Unassigned Gamedata Path Before Proceeding
            if (GamedataFolderPathBox.IsDefault) {
                WLog("Please Assign A Valid Gamedata Folder Before Building.");
                return;
            }

            // Ensure Keystone is Present if Applicable
            if (!gp4.IgnoreKeystone && !File.Exists($@"{gp4.GamedataFolder}\sce_sys\keystone"))
            {
                WLog($"Error; No keystone File Found In Project Folder.\n\n");
                return;
            }


            // Verify Passcode Length
            if (gp4.Passcode.Length != 32)
            {
                WLog($"Error; Invalid Passcode Length (Should Be 32, Currently {gp4.Passcode.Length})\n\n");
                return;
            }

            #endregion [Assign Defaults/Verify Options]
            //#^


            //#
            //## Begin .gp4 Creation if all's well
            //#
            gp4.CreateGP4();
        }
        #endregion
        //===============================================\\



        //##################################\\
        //--     Control Declarations     --\\
        //##################################\\
        #region ControlDeclarations
        private TextBox GamedataFolderPathBox;
        private Button BrowseBtn;
        private Button SwapBrowseModeBtn;
        private Button CreateProjectFileBtn;
        private Button OptionsBtn;
        private Button ClearLogBtn;
        private Button MinimizeBtn;
        private Button ExitBtn;
        private Button dummy; // I forget why this is here
        private Label Title;
        private RichTextBox OutputWindow;
        #endregion
        ///==================================\\\


        private readonly Button DesignerManip; // Manipulate Designer Stupidity (Stop Creating Methods Inside Existing Code, You Fucking Moron)
    }
}
