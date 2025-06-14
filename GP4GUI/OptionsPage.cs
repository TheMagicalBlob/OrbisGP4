using System;
using System.Linq;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using System.ComponentModel;
using static GP4GUI.Common;
#if DEBUG
//using static GP4GUI.Testing;
#endif


namespace GP4GUI
{
    public partial class OptionsPage : Form
    {
        public OptionsPage() {
            InitializeComponent();
            InitializeAdditionalEventHandlers(); // Set Event Handlers and Other Form-Related Crap
            
            Paint += PaintBorder;
            TinyVersionLabel.Text = Version; // Set Version Label
        }

        
        //=====================================\\
        //--|   Options-Related Functions   |--\\
        //=====================================\\
        #region [Options-Related Functions]
        
        /// <summary>
        /// Create and subscribe to various event handlers for additional form functionality. (fck your properties panel's event handler window, let me write code)
        /// </summary>
        public void InitializeAdditionalEventHandlers()
        {
            // Anonomously Create and Set CloseBtn Event Handler
            CloseBtn.Click += new EventHandler((sender, e) =>
            {
                // Hide OptionsPage Form
                Azem.Visible = false;    
                SaveOptions();
            });


            // Set Event Handlers for Form Dragging
            MouseDown += new MouseEventHandler((sender, e) => {
                MouseDif = new Point(MousePosition.X - Venat.Location.X, MousePosition.Y - Venat.Location.Y);
                MouseIsDown = true;
                Venat.DropdownMenu[1].Visible = Venat.DropdownMenu[0].Visible = false;

            });
            MouseUp += new MouseEventHandler((sender, e) => 
                MouseIsDown = false
            );
            MouseMove += new MouseEventHandler((sender, e) => MoveForm());

            
            foreach(Control Item in Controls)
            {
                if (Item.GetType() == typeof(Label) && Item.Name.Contains("ratorLine"))
                {
                    Item.Paint += DrawSeperatorLine;
                }
                
                Item.MouseDown += new MouseEventHandler((sender, e) => {
                    MouseDif = new Point(MousePosition.X - Venat.Location.X, MousePosition.Y - Venat.Location.Y);
                    MouseIsDown = true;
                    Venat.DropdownMenu[1].Visible = Venat.DropdownMenu[0].Visible = false;
                });
                Item.MouseUp   += new MouseEventHandler((sender, e) => 
                    MouseIsDown = false
                );
                
                // Avoid Applying MoveForm EventHandler to Text Containters (to retain the ability to drag-select text)
                if (Item.GetType() != typeof(TextBox) && Item.GetType() != typeof(RichTextBox))
                Item.MouseMove += new MouseEventHandler((sender, e) => MoveForm());
            }
        }


        /// <summary>
        /// Mirror Any Non-Default Options to GP4Creator Instance.
        /// </summary>
        public void SaveOptions()
        {
            // .gp4 Project Output Directory
            if (!GP4OutputDirectoryTextBox.IsDefault()) gp4.OutputDirectory = GP4OutputDirectoryTextBox.Text;
            else gp4.OutputDirectory = null;

            // Base .pkg Path
            if (!BasePackagePathTextBox.IsDefault())    gp4.BasePackagePath = BasePackagePathTextBox.Text;
            else                                        gp4.BasePackagePath = null;

            // File Filter
            if (!FileBlacklistTextBox.IsDefault())      gp4.FileBlacklist   = FileBlacklistTextBox.Text.Replace("\"", string.Empty).Split(';', '|', ',');
            else                                        gp4.FileBlacklist   = null;

            // Package Passcode
            if (!PasscodeTextBox.IsDefault())           gp4.Passcode        = PasscodeTextBox.Text;
            else if (gp4.Passcode != "00000000000000000000000000000000")
                                                        gp4.Passcode        = null;
                


            // File Path Mode
            gp4.UseAbsoluteFilePaths = UseAbsolutePathsCheckBox.Checked;
            // Keystone Setting
            gp4.IgnoreKeystone       = IgnoreKeystoneCheckBox.Checked;
        }



        // Check for new app version by comparing newest tag to version text
        private async void VersionCheckBtn_Click(object sender, EventArgs e)
        {
            try {
                using (var clientHandler = new HttpClientHandler())
                {
                    clientHandler.UseDefaultCredentials = true;
                    clientHandler.UseProxy = false;

                    using (var client = new HttpClient(clientHandler))
                    {
                        HttpResponseMessage reply;
                        client.DefaultRequestHeaders.Add("User-Agent", "Other"); // Set request headers to avoid error 403
                   
                        if ((reply = await client.GetAsync("https://api.github.com/repos/TheMagicalBlob/OrbisGP4/tags")).IsSuccessStatusCode)
                        {
                            var message = reply.Content.ReadAsStringAsync().Result;
                            var tag = message.Remove(message.IndexOf(',') - 1).Substring(message.IndexOf(':') + 2);
    #if DEBUG
                            Print($"Newest Tag: [{tag}]");
    #endif

                            if (tag != Version) {
                                string[]
                                    checkedVersion = tag.Split('.'),
                                    currentVersion = Version.Split('.')
                                ;
                            
                                if (checkedVersion.Length != currentVersion.Length)
                                {
                                    if (checkedVersion.Length < currentVersion.Length) {
                                        Print("Application Up-to-Date");
                                    }
                                    else
                                        Print($@"New Version Available.\nLink: https://github.com/TheMagicalBlob/OrbisGP4/releases");
                                    return;
                                }

                                for (var i = 0; i < currentVersion.Length; ++i)
                                {
                                    var currnum = currentVersion[i];
                                    var newnum = checkedVersion[i];

                                    if (int.Parse(currnum) < int.Parse(newnum)) {
                                        Print($"New Version Available. (//! print link or prompt to open in browser)");
                                        return;
                                    }
                                }
                            
                                Print("Application Up-to-Date");
                            }
                        }
                        else
                            Print($"Error checking for newest tag (Status: {reply.StatusCode})");
                    }
                }
            }
            catch (Exception dang) {
                Print($"Unable to connect to api.github");
            }
        }


        // Prompt user to open their default browser and download the latest source code
        private void DownloadSourceBtn_Click(object sender, EventArgs e) {
            Print("Download Latest Source: https://github.com/TheMagicalBlob/OrbisGP4/archive/refs/heads/master.zip\nNo guarantees on stability; I just use the main branch for everything.");
            
            if (MessageBox.Show(
                    "Download the latest source code through this system's default browser?\n\n(Download Will Start Automatically)",
                    "Press \"Ok\" to open in a browser, or copy the link from the Output Window.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) 
                == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://github.com/TheMagicalBlob/OrbisGP4/archive/refs/heads/master.zip");
            }
            else Azem.BringToFront();
        }


        // Manually Set .gp4 Project Output Directory
        private void GP4OutputDirectoryTextBox_TextChanged(object sender, EventArgs e) => gp4.OutputDirectory = GP4OutputDirectoryTextBox.Text;

        // Choose a .gp4 Output Path Through Either a FolderBrowserDialogue, or OpenFileDialogue Instance (W/ the hackey Dummy File Method.
        private void GP4OutputDirectoryBrowseBtn_Click(object sender, EventArgs e)
        {
            // Use the ghastly Directory Tree Dialogue to Choose A Folder
            if (LegacyFolderSelectionDialogue)
            {
                using (var ShitBrowser = new FolderBrowserDialog())
                {
                    if (ShitBrowser.ShowDialog() == DialogResult.OK)
                    {
                        GP4OutputDirectoryTextBox.Set(ShitBrowser.SelectedPath);
                    }
                }
            }
            // Use The Newer "Hackey" Method
            else {
                var CrapBrowser = new OpenFileDialog()
                {
                    ValidateNames = false,
                    CheckPathExists = false,
                    CheckFileExists = false,
                    Title = "",
                    FileName = "Press 'Open' Once Inside The Desired Folder.",
                    Filter = "Folder Selection|*."
                };

                if (CrapBrowser.ShowDialog() == DialogResult.OK)
                {
                    GP4OutputDirectoryTextBox.Set(CrapBrowser.FileName.Remove(CrapBrowser.FileName.LastIndexOf('\\')));
                }
            }
        }


        // Manually Input Base Package Path
        private void BasePackagePathTextBox_TextChanged(object sender, EventArgs e) => gp4.BasePackagePath = BasePackagePathTextBox.Text;

        // Search for the Base Application Package Through an OpenFileDialogue Instance.
        private void BasePackagePathBrowseBtn_Click(object sender, EventArgs e)
        {
            using (var Browser = new OpenFileDialog { Title = "Please Select the Base-Game Package You're Creating a Patch Package for." })
            {
                if (Browser.ShowDialog() == DialogResult.OK)
                {
                    BasePackagePathTextBox.Set(Browser.FileName);
                }
            }
        }


        private void AbsolutePathCheckBox_CheckedChanged(object sender, EventArgs e) => gp4.UseAbsoluteFilePaths = UseAbsolutePathsCheckBox.Checked;


        private void KeystoneToggleBox_CheckedChanged(object sender, EventArgs e) => gp4.IgnoreKeystone = IgnoreKeystoneCheckBox.Checked;
        
        

        // Manually Input Files to Blacklist
        private void FileBlacklistTextBox_TextChanged(object sender, EventArgs _)
        {
            var Control = sender as Control;

            if (";|,".Any(@char => Control.Text.Contains(@char) && Control.Text.Last() != @char))
                gp4.FileBlacklist = Control.Text.Split(',', ';');
        }

        // Build an Array of Files to Exclude from the .gp4 Project's File Listing From Those Selected Through an OpenFileDialogue Instance (W/ Multiselect).
        private void FileBlacklistBrowseBtn_Click(object sender, EventArgs e)
        {
            using (var Browser = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Folders Must Be Added Manually To The Text Box (Blame Microsoft)"
            })

            if (Browser.ShowDialog() == DialogResult.OK)
            {
                FileBlacklistTextBox.Set($"{string.Join(",", Browser.FileNames)}");
            }
        }

               
        // Manually Input Package Passcode
        private void PasscodeTextBox_TextChanged(object sender, EventArgs e) => gp4.Passcode = PasscodeTextBox.Text;
        #endregion
    }
}
