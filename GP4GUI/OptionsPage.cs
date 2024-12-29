using System;
using System.Linq;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using System.ComponentModel;
using static GP4GUI.Common;
#if DEBUG
using static GP4GUI.DebugContents;
#endif


namespace GP4GUI
{
    public partial class OptionsPage : Form
    {
        public OptionsPage() {
            InitializeComponent();
            PostInitFormLogic(); // Set Event Handlers and Other Form-Related Crap
            
            Paint += PaintBorder;
            TinyVersionLabel.Text = Version; // Set Version Label
        }



        //######################################\\
        //--     Design-Related Functions     --\\
        //######################################\\
        #region Design-Related Functions
#pragma warning disable CS0168 // var not used
        private IContainer components = null;
        protected override void Dispose(bool disposing) {
            if(disposing) components?.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent() {
            this.IgnoreKeystoneCheckBox = new System.Windows.Forms.CheckBox();
            this.Title = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.GP4OutputDirectoryBrowseBtn = new System.Windows.Forms.Button();
            this.BasePackagePathBrowseBtn = new System.Windows.Forms.Button();
            this.FileBlacklistBrowseBtn = new System.Windows.Forms.Button();
            this.TinyVersionLabel = new System.Windows.Forms.Label();
            this.UseAbsolutePathsCheckBox = new System.Windows.Forms.CheckBox();
            this.dummy = new System.Windows.Forms.Button();
            this.PasscodeTextBox = new GP4GUI.TextBox();
            this.FileBlacklistTextBox = new GP4GUI.TextBox();
            this.GP4OutputDirectoryTextBox = new GP4GUI.TextBox();
            this.BasePackagePathTextBox = new GP4GUI.TextBox();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.VersionCheckBtn = new System.Windows.Forms.Button();
            this.DownloadSourceBtn = new System.Windows.Forms.Button();
            this.Title2 = new System.Windows.Forms.Label();
            this.CreditsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IgnoreKeystoneCheckBox
            // 
            this.IgnoreKeystoneCheckBox.AutoSize = true;
            this.IgnoreKeystoneCheckBox.Font = new System.Drawing.Font("Gadugi", 9.25F);
            this.IgnoreKeystoneCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.IgnoreKeystoneCheckBox.Location = new System.Drawing.Point(288, 94);
            this.IgnoreKeystoneCheckBox.Name = "IgnoreKeystoneCheckBox";
            this.IgnoreKeystoneCheckBox.Size = new System.Drawing.Size(121, 20);
            this.IgnoreKeystoneCheckBox.TabIndex = 5;
            this.IgnoreKeystoneCheckBox.Text = "Ignore Keystone";
            this.IgnoreKeystoneCheckBox.UseVisualStyleBackColor = true;
            this.IgnoreKeystoneCheckBox.CheckedChanged += new System.EventHandler(this.KeystoneToggleBox_CheckedChanged);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Gadugi", 9.25F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.Title.Location = new System.Drawing.Point(169, 3);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(57, 17);
            this.Title.TabIndex = 0;
            this.Title.Text = "Options";
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.CloseBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CloseBtn.Location = new System.Drawing.Point(391, 2);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(22, 22);
            this.CloseBtn.TabIndex = 7;
            this.CloseBtn.Text = "X";
            this.CloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseBtn.UseVisualStyleBackColor = false;
            // 
            // GP4OutputDirectoryBrowseBtn
            // 
            this.GP4OutputDirectoryBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.GP4OutputDirectoryBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GP4OutputDirectoryBrowseBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.GP4OutputDirectoryBrowseBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.GP4OutputDirectoryBrowseBtn.Location = new System.Drawing.Point(347, 31);
            this.GP4OutputDirectoryBrowseBtn.Name = "GP4OutputDirectoryBrowseBtn";
            this.GP4OutputDirectoryBrowseBtn.Size = new System.Drawing.Size(62, 24);
            this.GP4OutputDirectoryBrowseBtn.TabIndex = 8;
            this.GP4OutputDirectoryBrowseBtn.Text = "Browse...";
            this.GP4OutputDirectoryBrowseBtn.UseVisualStyleBackColor = false;
            this.GP4OutputDirectoryBrowseBtn.Click += new System.EventHandler(this.GP4OutputDirectoryBrowseBtn_Click);
            // 
            // BasePackagePathBrowseBtn
            // 
            this.BasePackagePathBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.BasePackagePathBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BasePackagePathBrowseBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.BasePackagePathBrowseBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.BasePackagePathBrowseBtn.Location = new System.Drawing.Point(347, 59);
            this.BasePackagePathBrowseBtn.Name = "BasePackagePathBrowseBtn";
            this.BasePackagePathBrowseBtn.Size = new System.Drawing.Size(62, 24);
            this.BasePackagePathBrowseBtn.TabIndex = 9;
            this.BasePackagePathBrowseBtn.Text = "Browse...";
            this.BasePackagePathBrowseBtn.UseVisualStyleBackColor = false;
            this.BasePackagePathBrowseBtn.Click += new System.EventHandler(this.BasePackagePathBrowseBtn_Click);
            // 
            // FileBlacklistBrowseBtn
            // 
            this.FileBlacklistBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.FileBlacklistBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FileBlacklistBrowseBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.FileBlacklistBrowseBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FileBlacklistBrowseBtn.Location = new System.Drawing.Point(347, 124);
            this.FileBlacklistBrowseBtn.Name = "FileBlacklistBrowseBtn";
            this.FileBlacklistBrowseBtn.Size = new System.Drawing.Size(62, 24);
            this.FileBlacklistBrowseBtn.TabIndex = 10;
            this.FileBlacklistBrowseBtn.Text = "Browse...";
            this.FileBlacklistBrowseBtn.UseVisualStyleBackColor = false;
            this.FileBlacklistBrowseBtn.Click += new System.EventHandler(this.FileBlacklistBrowseBtn_Click);
            // 
            // TinyVersionLabel
            // 
            this.TinyVersionLabel.AutoSize = true;
            this.TinyVersionLabel.Font = new System.Drawing.Font("Gadugi", 7F, System.Drawing.FontStyle.Bold);
            this.TinyVersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.TinyVersionLabel.Location = new System.Drawing.Point(8, 200);
            this.TinyVersionLabel.Name = "TinyVersionLabel";
            this.TinyVersionLabel.Size = new System.Drawing.Size(59, 12);
            this.TinyVersionLabel.TabIndex = 0;
            this.TinyVersionLabel.Text = "placeholder";
            // 
            // UseAbsolutePathsCheckBox
            // 
            this.UseAbsolutePathsCheckBox.AutoSize = true;
            this.UseAbsolutePathsCheckBox.Font = new System.Drawing.Font("Gadugi", 9.25F);
            this.UseAbsolutePathsCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.UseAbsolutePathsCheckBox.Location = new System.Drawing.Point(10, 94);
            this.UseAbsolutePathsCheckBox.Name = "UseAbsolutePathsCheckBox";
            this.UseAbsolutePathsCheckBox.Size = new System.Drawing.Size(177, 20);
            this.UseAbsolutePathsCheckBox.TabIndex = 12;
            this.UseAbsolutePathsCheckBox.Text = "Use Absolute Path Names";
            this.UseAbsolutePathsCheckBox.UseVisualStyleBackColor = true;
            this.UseAbsolutePathsCheckBox.CheckedChanged += new System.EventHandler(this.AbsolutePathCheckBox_CheckedChanged);
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
            // PasscodeTextBox
            // 
            this.PasscodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.PasscodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasscodeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.PasscodeTextBox.Location = new System.Drawing.Point(6, 152);
            this.PasscodeTextBox.MaxLength = 32;
            this.PasscodeTextBox.Name = "PasscodeTextBox";
            this.PasscodeTextBox.Size = new System.Drawing.Size(340, 24);
            this.PasscodeTextBox.TabIndex = 4;
            this.PasscodeTextBox.Text = "Add Custom .pkg Passcode Here (Defaults To All Zeros)";
            this.PasscodeTextBox.TextChanged += new System.EventHandler(this.PasscodeTextBox_TextChanged);
            // 
            // FileBlacklistTextBox
            // 
            this.FileBlacklistTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.FileBlacklistTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileBlacklistTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.FileBlacklistTextBox.Location = new System.Drawing.Point(7, 124);
            this.FileBlacklistTextBox.Name = "FileBlacklistTextBox";
            this.FileBlacklistTextBox.Size = new System.Drawing.Size(339, 24);
            this.FileBlacklistTextBox.TabIndex = 3;
            this.FileBlacklistTextBox.Text = "Blacklisted Files/Folders To Exclude, Seperated By ; or ,";
            this.FileBlacklistTextBox.TextChanged += new System.EventHandler(this.FileBlacklistTextBox_TextChanged);
            // 
            // GP4OutputDirectoryTextBox
            // 
            this.GP4OutputDirectoryTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.GP4OutputDirectoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GP4OutputDirectoryTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.GP4OutputDirectoryTextBox.Location = new System.Drawing.Point(6, 31);
            this.GP4OutputDirectoryTextBox.Name = "GP4OutputDirectoryTextBox";
            this.GP4OutputDirectoryTextBox.Size = new System.Drawing.Size(340, 24);
            this.GP4OutputDirectoryTextBox.TabIndex = 1;
            this.GP4OutputDirectoryTextBox.Text = "Add A Custom .gp4 Output Directory Here...";
            this.GP4OutputDirectoryTextBox.TextChanged += new System.EventHandler(this.GP4OutputDirectoryTextBox_TextChanged);
            // 
            // BasePackagePathTextBox
            // 
            this.BasePackagePathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.BasePackagePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BasePackagePathTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.BasePackagePathTextBox.Location = new System.Drawing.Point(6, 59);
            this.BasePackagePathTextBox.Name = "BasePackagePathTextBox";
            this.BasePackagePathTextBox.Size = new System.Drawing.Size(340, 24);
            this.BasePackagePathTextBox.TabIndex = 2;
            this.BasePackagePathTextBox.Text = "Base Game .pkg Path... (For Game Patches)";
            this.BasePackagePathTextBox.TextChanged += new System.EventHandler(this.BasePackagePathTextBox_TextChanged);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Gadugi", 9.25F, System.Drawing.FontStyle.Bold);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(3, 180);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(411, 17);
            this.SeperatorLine1.TabIndex = 13;
            this.SeperatorLine1.Text = "---------------------------------------------------------------------------------" +
    "";
            // 
            // VersionCheckBtn
            // 
            this.VersionCheckBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.VersionCheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VersionCheckBtn.Font = new System.Drawing.Font("Gadugi", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.VersionCheckBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.VersionCheckBtn.Location = new System.Drawing.Point(291, 229);
            this.VersionCheckBtn.Name = "VersionCheckBtn";
            this.VersionCheckBtn.Size = new System.Drawing.Size(120, 22);
            this.VersionCheckBtn.TabIndex = 14;
            this.VersionCheckBtn.Text = "check for new version";
            this.VersionCheckBtn.UseVisualStyleBackColor = false;
            this.VersionCheckBtn.Click += new System.EventHandler(this.VersionCheckBtn_Click);
            // 
            // DownloadSourceBtn
            // 
            this.DownloadSourceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.DownloadSourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadSourceBtn.Font = new System.Drawing.Font("Gadugi", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.DownloadSourceBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.DownloadSourceBtn.Location = new System.Drawing.Point(291, 263);
            this.DownloadSourceBtn.Name = "DownloadSourceBtn";
            this.DownloadSourceBtn.Size = new System.Drawing.Size(120, 22);
            this.DownloadSourceBtn.TabIndex = 15;
            this.DownloadSourceBtn.Text = "download source code";
            this.DownloadSourceBtn.UseVisualStyleBackColor = false;
            this.DownloadSourceBtn.Click += new System.EventHandler(this.DownloadSourceBtn_Click);
            // 
            // Title2
            // 
            this.Title2.AutoSize = true;
            this.Title2.Font = new System.Drawing.Font("Gadugi", 8F, System.Drawing.FontStyle.Bold);
            this.Title2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.Title2.Location = new System.Drawing.Point(178, 198);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(43, 14);
            this.Title2.TabIndex = 16;
            this.Title2.Text = "Credits";
            this.Title2.Visible = false;
            // 
            // CreditsLabel
            // 
            this.CreditsLabel.Font = new System.Drawing.Font("Gadugi", 7.5F, System.Drawing.FontStyle.Bold);
            this.CreditsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.CreditsLabel.Location = new System.Drawing.Point(8, 226);
            this.CreditsLabel.Name = "CreditsLabel";
            this.CreditsLabel.Size = new System.Drawing.Size(276, 62);
            this.CreditsLabel.TabIndex = 17;
            this.CreditsLabel.Text = "Credits:\r\n  libgp4: TheMagicalBlob, AlAzif (file blacklist)\r\n  GP4 GUI: TheMagica" +
    "lBlob\r\n\r\n  Testing: Dr.YenYen, Dantify\r\n";
            // 
            // OptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(415, 296);
            this.Controls.Add(this.CreditsLabel);
            this.Controls.Add(this.Title2);
            this.Controls.Add(this.DownloadSourceBtn);
            this.Controls.Add(this.TinyVersionLabel);
            this.Controls.Add(this.VersionCheckBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.dummy);
            this.Controls.Add(this.UseAbsolutePathsCheckBox);
            this.Controls.Add(this.FileBlacklistBrowseBtn);
            this.Controls.Add(this.BasePackagePathBrowseBtn);
            this.Controls.Add(this.GP4OutputDirectoryBrowseBtn);
            this.Controls.Add(this.PasscodeTextBox);
            this.Controls.Add(this.FileBlacklistTextBox);
            this.Controls.Add(this.BasePackagePathTextBox);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.GP4OutputDirectoryTextBox);
            this.Controls.Add(this.IgnoreKeystoneCheckBox);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Create And Subscriibe
        /// to Various Event Handlers for Basic Form Functionality.
        /// </summary>
        public void PostInitFormLogic()
        {
          /* This is far more annoying than an occasional single flicker from a form, so fuck it. Commented out.
            // Stop OptionsPage Form From Being Hidden Whenever the Parent Is Clicked
            this.TopMost = true;
          */

            // Anonomously Create and Set CloseBtn Event Handler
            CloseBtn.Click += new EventHandler((sender, e) =>
            {
                // Hide OptionsPage Form
                Azem.Visible = OptionsPageIsOpen = false;    
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
            MouseMove += new MouseEventHandler((sender, e) => DragForm());

            
            foreach(Control Item in Controls)
            {
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
                Item.MouseMove += new MouseEventHandler((sender, e) => DragForm());
            }
        }

        #endregion
        //======================================\\




        //#######################################\\
        //--     Options-Related Functions     --\\
        //#######################################\\
        #region Options Related Functions
        
        /// <summary>
        /// Mirror Any Non-Default Options to GP4Creator Instance.
        /// </summary>
        public void SaveOptions()
        {
            // .gp4 Project Output Directory
            if (!GP4OutputDirectoryTextBox.IsDefault) gp4.OutputDirectory = GP4OutputDirectoryTextBox.Text;
            else gp4.OutputDirectory = null;

            // Base .pkg Path
            if (!BasePackagePathTextBox.IsDefault)    gp4.BasePackagePath = BasePackagePathTextBox.Text;
            else                                      gp4.BasePackagePath = null;

            // File Filter
            if (!FileBlacklistTextBox.IsDefault)      gp4.FileBlacklist   = FileBlacklistTextBox.Text.Replace("\"", string.Empty).Split(';', '|', ',');
            else                                      gp4.FileBlacklist   = null;

            // Package Passcode
            if (!PasscodeTextBox.IsDefault)           gp4.Passcode        = PasscodeTextBox.Text;
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
            using (var Handler = new HttpClientHandler())
            {
                Handler.UseDefaultCredentials = true;
                Handler.UseProxy = false;


                using (var Client = new HttpClient(Handler))
                {
                    HttpResponseMessage reply;
                    Client.DefaultRequestHeaders.Add("User-Agent", "Other"); // Set Request Headers to Avoid a 403 Error
                   
                    if ((reply = await Client.GetAsync("https://api.github.com/repos/TheMagicalBlob/OrbisGP4/tags")).IsSuccessStatusCode)
                    {
                        var message = reply.Content.ReadAsStringAsync().Result;
                        var tag = message.Remove(message.IndexOf(',') - 1).Substring(message.IndexOf(':') + 2);
#if DEBUG
                        WLog($"Newest Tag: [{tag}]");
#endif

                        if (tag != Version) {
                            string[]
                                checkedVersion = tag.Split('.'),
                                currentVersion = Version.Split('.')
                            ;
                            
                            if (checkedVersion.Length != currentVersion.Length)
                            {
                                if (checkedVersion.Length < currentVersion.Length) {
                                    WLog("Application Up-to-Date");
                                }
                                else {
                                    WLog($"New Version Available. (//! print link or prompt to open in browser)");
                                }
                                return;
                            }

                            for (var i = 0; i < currentVersion.Length; ++i)
                            {
                                var currnum = currentVersion[i];
                                var newnum = checkedVersion[i];

                                if (int.Parse(currnum) < int.Parse(newnum))
                                {
                                    WLog($"New Version Available. (//! print link or prompt to open in browser)");
                                    return;
                                }
                            }
                            
                            WLog("Application Up-to-Date");
                        }
                    }
                    else
                        WLog($"Error checking for newest tag (Status: {reply.StatusCode})");
                }
            }
        }


        // Prompt user to open their default browser and download the latest source code
        private void DownloadSourceBtn_Click(object sender, EventArgs e) {
            WLog("Download Latest Source: https://github.com/TheMagicalBlob/OrbisGP4/archive/refs/heads/master.zip\nNo guarantees on stability; I just use the main branch for everything.");
            
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
            if (LegacyFolderSelectionDialogue) {
                using (var ShitBrowser = new FolderBrowserDialog())
                    if (ShitBrowser.ShowDialog() == DialogResult.OK)
                        GP4OutputDirectoryTextBox.Set(ShitBrowser.SelectedPath);
            }
            // Use The Newer "Hackey" Method
            else {
                var CrapBrowser = new OpenFileDialog() {
                    ValidateNames = false,
                    CheckPathExists = false,
                    CheckFileExists = false,
                    Title = "",
                    FileName = "Press 'Open' Once Inside The Desired Folder.",
                    Filter = "Folder Selection|*."
                };

                if (CrapBrowser.ShowDialog() == DialogResult.OK)
                    GP4OutputDirectoryTextBox.Set(CrapBrowser.FileName.Remove(CrapBrowser.FileName.LastIndexOf('\\')));
            }
        }


        // Manually Input Base Package Path
        private void BasePackagePathTextBox_TextChanged(object sender, EventArgs e) => gp4.BasePackagePath = BasePackagePathTextBox.Text;

        // Search for the Base Application Package Through an OpenFileDialogue Instance.
        private void BasePackagePathBrowseBtn_Click(object sender, EventArgs e) {
            using(var Browser = new OpenFileDialog{ Title = "Please Select the Base-Game Package You're Creating a Patch Package for." })
                if(Browser.ShowDialog() == DialogResult.OK)
                    BasePackagePathTextBox.Set(Browser.FileName);
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
        private void FileBlacklistBrowseBtn_Click(object sender, EventArgs e) {
            using (var Browser = new OpenFileDialog {
                Multiselect = true,
                Title = "Folders Must Be Added Manually To The Text Box (Blame Microsoft)"
            })

            if(Browser.ShowDialog() == DialogResult.OK)
                FileBlacklistTextBox.Set($"{string.Join(",", Browser.FileNames)}");
        }

               
        // Manually Input Package Passcode
        private void PasscodeTextBox_TextChanged(object sender, EventArgs e) => gp4.Passcode = PasscodeTextBox.Text;

        

        #endregion
        ///=======================================\\\



        //##################################\\
        //--     Control Declarations     --\\
        //##################################\\
        #region ControlDeclarations
        private Label TinyVersionLabel;
        private Label Title;
        private Button CloseBtn;
        private Button GP4OutputDirectoryBrowseBtn;
        private Button BasePackagePathBrowseBtn;
        private Button FileBlacklistBrowseBtn;
        private CheckBox IgnoreKeystoneCheckBox;
        private CheckBox UseAbsolutePathsCheckBox;
        private TextBox GP4OutputDirectoryTextBox;
        private TextBox BasePackagePathTextBox;
        private TextBox FileBlacklistTextBox;
        private TextBox PasscodeTextBox;
        private Label SeperatorLine1;
        private Button VersionCheckBtn;
        private Button DownloadSourceBtn;
        private Label Title2;
        private Label CreditsLabel;
        private Button dummy; // I forget why this is here
        #endregion

        ///==================================\\\
    }
}
