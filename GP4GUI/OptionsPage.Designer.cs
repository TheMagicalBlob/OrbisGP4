using System.ComponentModel;
using System.Drawing;
using System;
using System.Windows.Forms;

namespace GP4GUI
{
    public partial class OptionsPage : Form
    {
        //=====================================\\
        //--|   Designer Crap, No Touchie   |--\\
        //=====================================\\
        #region [Designer Crap, No Touchie]

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
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        


        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]

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
    }
}
