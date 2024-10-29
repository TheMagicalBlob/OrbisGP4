using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using static GP4GUI.Common;
using System.Linq;


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
            this.VerboseOutputCheckBox = new System.Windows.Forms.CheckBox();
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
            this.SuspendLayout();
            // 
            // IgnoreKeystoneCheckBox
            // 
            this.IgnoreKeystoneCheckBox.AutoSize = true;
            this.IgnoreKeystoneCheckBox.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.IgnoreKeystoneCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.IgnoreKeystoneCheckBox.Location = new System.Drawing.Point(172, 97);
            this.IgnoreKeystoneCheckBox.Name = "IgnoreKeystoneCheckBox";
            this.IgnoreKeystoneCheckBox.Size = new System.Drawing.Size(109, 18);
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
            this.Title.Location = new System.Drawing.Point(169, 1);
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
            // VerboseOutputCheckBox
            // 
            this.VerboseOutputCheckBox.AutoSize = true;
            this.VerboseOutputCheckBox.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.VerboseOutputCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.VerboseOutputCheckBox.Location = new System.Drawing.Point(291, 97);
            this.VerboseOutputCheckBox.Name = "VerboseOutputCheckBox";
            this.VerboseOutputCheckBox.Size = new System.Drawing.Size(109, 18);
            this.VerboseOutputCheckBox.TabIndex = 6;
            this.VerboseOutputCheckBox.Text = "Verbose Output";
            this.VerboseOutputCheckBox.UseVisualStyleBackColor = true;
            this.VerboseOutputCheckBox.CheckedChanged += new System.EventHandler(this.VerboseOutputBox_CheckedChanged);
            // 
            // GP4OutputDirectoryBrowseBtn
            // 
            this.GP4OutputDirectoryBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.GP4OutputDirectoryBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GP4OutputDirectoryBrowseBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.GP4OutputDirectoryBrowseBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.GP4OutputDirectoryBrowseBtn.Location = new System.Drawing.Point(347, 34);
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
            this.BasePackagePathBrowseBtn.Location = new System.Drawing.Point(347, 62);
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
            this.FileBlacklistBrowseBtn.Location = new System.Drawing.Point(347, 127);
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
            this.TinyVersionLabel.Location = new System.Drawing.Point(1, 1);
            this.TinyVersionLabel.Name = "TinyVersionLabel";
            this.TinyVersionLabel.Size = new System.Drawing.Size(59, 12);
            this.TinyVersionLabel.TabIndex = 0;
            this.TinyVersionLabel.Text = "placeholder";
            // 
            // UseAbsolutePathsCheckBox
            // 
            this.UseAbsolutePathsCheckBox.AutoSize = true;
            this.UseAbsolutePathsCheckBox.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.UseAbsolutePathsCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.UseAbsolutePathsCheckBox.Location = new System.Drawing.Point(9, 97);
            this.UseAbsolutePathsCheckBox.Name = "UseAbsolutePathsCheckBox";
            this.UseAbsolutePathsCheckBox.Size = new System.Drawing.Size(157, 18);
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
            this.PasscodeTextBox.Location = new System.Drawing.Point(6, 155);
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
            this.FileBlacklistTextBox.Location = new System.Drawing.Point(7, 127);
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
            this.GP4OutputDirectoryTextBox.Location = new System.Drawing.Point(6, 34);
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
            this.BasePackagePathTextBox.Location = new System.Drawing.Point(6, 62);
            this.BasePackagePathTextBox.Name = "BasePackagePathTextBox";
            this.BasePackagePathTextBox.Size = new System.Drawing.Size(340, 24);
            this.BasePackagePathTextBox.TabIndex = 2;
            this.BasePackagePathTextBox.Text = "Base Game .pkg Path... (For Game Patches)";
            this.BasePackagePathTextBox.TextChanged += new System.EventHandler(this.BasePackagePathTextBox_TextChanged);
            // 
            // OptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(415, 188);
            this.Controls.Add(this.dummy);
            this.Controls.Add(this.UseAbsolutePathsCheckBox);
            this.Controls.Add(this.TinyVersionLabel);
            this.Controls.Add(this.FileBlacklistBrowseBtn);
            this.Controls.Add(this.BasePackagePathBrowseBtn);
            this.Controls.Add(this.GP4OutputDirectoryBrowseBtn);
            this.Controls.Add(this.PasscodeTextBox);
            this.Controls.Add(this.FileBlacklistTextBox);
            this.Controls.Add(this.BasePackagePathTextBox);
            this.Controls.Add(this.VerboseOutputCheckBox);
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
        /// Create And Subscriibe to Various Event Handlers for Basic Form Functionality.
        /// </summary>
        public void PostInitFormLogic()
        {
            // Stop OptionsPage Form From Being Hidden Whenever the Parent Is Clicked
            this.TopMost = true;

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
                MainForm.DropdownMenu[1].Visible = MainForm.DropdownMenu[0].Visible = false;

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
                    MainForm.DropdownMenu[1].Visible = MainForm.DropdownMenu[0].Visible = false;
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
        
        // Save Options Page Control States to Options
        public void SaveOptions()
        {
            // .gp4 Project Output Directory
            if (!GP4OutputDirectoryTextBox.IsDefault) gp4.OutputDirectory = GP4OutputDirectoryTextBox.Text;
            // Base .pkg Path
            if (!BasePackagePathTextBox.IsDefault)    gp4.BasePackagePath = BasePackagePathTextBox.Text;
            // File Filter
            if (!FileBlacklistTextBox.IsDefault)      gp4.FileBlacklist   = FileBlacklistTextBox.Text.Replace("\"", string.Empty).Split(';', '|', ',');
            // Base .pkg Path
            if (!BasePackagePathTextBox.IsDefault)    gp4.BasePackagePath = BasePackagePathTextBox.Text;
            // Package Passcode
            if (!PasscodeTextBox.IsDefault)           gp4.Passcode        = PasscodeTextBox.Text;
                
            // File Path Mode
            gp4.UseAbsoluteFilePaths = UseAbsolutePathsCheckBox.Checked;
            // Keystone Setting
            gp4.IgnoreKeystone       = IgnoreKeystoneCheckBox.Checked;
            // Verbosity
            gp4.VerboseOutput        = VerboseOutputCheckBox.Checked;

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
        

        private void VerboseOutputBox_CheckedChanged(object sender, EventArgs e) => gp4.VerboseOutput = VerboseOutputCheckBox.Checked;

        
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
        private CheckBox VerboseOutputCheckBox;
        private CheckBox UseAbsolutePathsCheckBox;
        private TextBox GP4OutputDirectoryTextBox;
        private TextBox BasePackagePathTextBox;
        private TextBox FileBlacklistTextBox;
        private TextBox PasscodeTextBox;
        private Button dummy; // I forget why this is here
        #endregion

        ///==================================\\\
    }
}
