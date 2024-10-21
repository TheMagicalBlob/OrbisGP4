﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static GP4GUI.Common;


namespace GP4GUI
{
    public partial class OptionsPage : Form
    {
        public OptionsPage(MainForm MainForm, Point LastPos)
        {
            InitializeComponent();
            //BorderFunc(this);
            Paint += PaintBorder;
            OptionsPageIsOpen = true;

            Location = new Point(LastPos.X + 30, LastPos.Y + 60);
            TinyVersionLabel.Text = Version;

#region Load Options
            // Restore Edited User Settings To Controls
            if(Gp4OutputDirectory != null)
                OutputPathTextBox.Text = Gp4OutputDirectory;
                    
            if(gp4.BasePackagePath != null)
                BasePackagePathTextBox.Text = gp4.BasePackagePath;

            AbsolutePathCheckBox.Checked = gp4.AbsoluteFilePaths;
            KeystoneToggleBox.Checked = gp4.Keystone;
            VerboseOutputBox.Checked = gp4.VerboseLogging;

            if(gp4.BlacklistedFilesOrFolders != null) {
                var str = gp4.BlacklistedFilesOrFolders[0];
                for(var i = 1; i< gp4.BlacklistedFilesOrFolders.Length; i++)
                    str += $",{gp4.BlacklistedFilesOrFolders[i]}";

                FilterTextBox.Text = str;
            }


            if(gp4.Passcode != "00000000000000000000000000000000")
                CustomPasscodeTextBox.Text = gp4.Passcode;
#endregion
        }


        ///########################################\\\
        ///--     Designer-Managed Functions     --\\\
        ///########################################\\\
        #region Designer Managed Functions
#pragma warning disable CS0168 // var not used
        private IContainer components = null;
        protected override void Dispose(bool disposing) {
            if(disposing) components?.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent() {
            this.KeystoneToggleBox = new System.Windows.Forms.CheckBox();
            this.Title = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.VerboseOutputBox = new System.Windows.Forms.CheckBox();
            this.OutputPathBtn = new System.Windows.Forms.Button();
            this.BasePackagePathBtn = new System.Windows.Forms.Button();
            this.FilterBrowseBtn = new System.Windows.Forms.Button();
            this.TinyVersionLabel = new System.Windows.Forms.Label();
            this.AbsolutePathCheckBox = new System.Windows.Forms.CheckBox();
            this.dummy = new System.Windows.Forms.Button();
            this.CustomPasscodeTextBox = new GP4GUI.TextBox();
            this.FilterTextBox = new GP4GUI.TextBox();
            this.BasePackagePathTextBox = new GP4GUI.TextBox();
            this.OutputPathTextBox = new GP4GUI.TextBox();
            this.SuspendLayout();
            // 
            // KeystoneToggleBox
            // 
            this.KeystoneToggleBox.AutoSize = true;
            this.KeystoneToggleBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.KeystoneToggleBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.KeystoneToggleBox.Location = new System.Drawing.Point(172, 94);
            this.KeystoneToggleBox.Name = "KeystoneToggleBox";
            this.KeystoneToggleBox.Size = new System.Drawing.Size(109, 17);
            this.KeystoneToggleBox.TabIndex = 5;
            this.KeystoneToggleBox.Text = "Ignore Keystone";
            this.KeystoneToggleBox.UseVisualStyleBackColor = true;
            this.KeystoneToggleBox.CheckedChanged += new System.EventHandler(this.KeystoneToggleBox_CheckedChanged);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Gadugi", 9.25F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.Title.Location = new System.Drawing.Point(163, 3);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(57, 17);
            this.Title.TabIndex = 0;
            this.Title.Text = "Options";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ExitBtn.Location = new System.Drawing.Point(376, 3);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(22, 22);
            this.ExitBtn.TabIndex = 7;
            this.ExitBtn.Text = "X";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // VerboseOutputBox
            // 
            this.VerboseOutputBox.AutoSize = true;
            this.VerboseOutputBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.VerboseOutputBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.VerboseOutputBox.Location = new System.Drawing.Point(290, 94);
            this.VerboseOutputBox.Name = "VerboseOutputBox";
            this.VerboseOutputBox.Size = new System.Drawing.Size(105, 17);
            this.VerboseOutputBox.TabIndex = 6;
            this.VerboseOutputBox.Text = "Verbose Output";
            this.VerboseOutputBox.UseVisualStyleBackColor = true;
            this.VerboseOutputBox.CheckedChanged += new System.EventHandler(this.LimitedOutputBox_CheckedChanged);
            // 
            // OutputPathBtn
            // 
            this.OutputPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.OutputPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OutputPathBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.OutputPathBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OutputPathBtn.Location = new System.Drawing.Point(335, 34);
            this.OutputPathBtn.Name = "OutputPathBtn";
            this.OutputPathBtn.Size = new System.Drawing.Size(60, 22);
            this.OutputPathBtn.TabIndex = 8;
            this.OutputPathBtn.Text = "Browse...";
            this.OutputPathBtn.UseVisualStyleBackColor = false;
            this.OutputPathBtn.Click += new System.EventHandler(this.OutputPathBtn_Click);
            // 
            // BasePackagePathBtn
            // 
            this.BasePackagePathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.BasePackagePathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BasePackagePathBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.BasePackagePathBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.BasePackagePathBtn.Location = new System.Drawing.Point(335, 59);
            this.BasePackagePathBtn.Name = "BasePackagePathBtn";
            this.BasePackagePathBtn.Size = new System.Drawing.Size(60, 22);
            this.BasePackagePathBtn.TabIndex = 9;
            this.BasePackagePathBtn.Text = "Browse...";
            this.BasePackagePathBtn.UseVisualStyleBackColor = false;
            this.BasePackagePathBtn.Click += new System.EventHandler(this.BasePackagePathBtn_Click);
            // 
            // FilterBrowseBtn
            // 
            this.FilterBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.FilterBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FilterBrowseBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.FilterBrowseBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FilterBrowseBtn.Location = new System.Drawing.Point(335, 123);
            this.FilterBrowseBtn.Name = "FilterBrowseBtn";
            this.FilterBrowseBtn.Size = new System.Drawing.Size(60, 22);
            this.FilterBrowseBtn.TabIndex = 10;
            this.FilterBrowseBtn.Text = "Browse...";
            this.FilterBrowseBtn.UseVisualStyleBackColor = false;
            this.FilterBrowseBtn.Click += new System.EventHandler(this.FilterBrowseBtn_Click);
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
            // AbsolutePathCheckBox
            // 
            this.AbsolutePathCheckBox.AutoSize = true;
            this.AbsolutePathCheckBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.AbsolutePathCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.AbsolutePathCheckBox.Location = new System.Drawing.Point(10, 94);
            this.AbsolutePathCheckBox.Name = "AbsolutePathCheckBox";
            this.AbsolutePathCheckBox.Size = new System.Drawing.Size(156, 17);
            this.AbsolutePathCheckBox.TabIndex = 12;
            this.AbsolutePathCheckBox.Text = "Use Absolute Path Names";
            this.AbsolutePathCheckBox.UseVisualStyleBackColor = true;
            this.AbsolutePathCheckBox.CheckedChanged += new System.EventHandler(this.AbsolutePathCheckBox_CheckedChanged);
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
            // CustomPasscodeTextBox
            // 
            this.CustomPasscodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.CustomPasscodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomPasscodeTextBox.Font = new System.Drawing.Font("Gadugi", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.CustomPasscodeTextBox.Location = new System.Drawing.Point(6, 149);
            this.CustomPasscodeTextBox.MaxLength = 32;
            this.CustomPasscodeTextBox.Name = "CustomPasscodeTextBox";
            this.CustomPasscodeTextBox.Size = new System.Drawing.Size(328, 22);
            this.CustomPasscodeTextBox.TabIndex = 4;
            this.CustomPasscodeTextBox.Text = "Add Custom .pkg Passcode Here (Defaults To All Zeros)";
            this.CustomPasscodeTextBox.TextChanged += new System.EventHandler(this.CustomPasscodeTextBox_TextChanged);
            this.CustomPasscodeTextBox.LostFocus += new System.EventHandler(this.CustomPasscodeTextBox_FocusChanged);
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.FilterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterTextBox.Font = new System.Drawing.Font("Gadugi", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FilterTextBox.Location = new System.Drawing.Point(7, 124);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(327, 22);
            this.FilterTextBox.TabIndex = 3;
            this.FilterTextBox.Text = "Blacklisted Files/Folders To Exclude, Seperated By ; or ,";
            this.FilterTextBox.TextChanged += new System.EventHandler(this.FilterTextBox_TextChanged);
            // 
            // BasePackagePathTextBox
            // 
            this.BasePackagePathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.BasePackagePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BasePackagePathTextBox.Font = new System.Drawing.Font("Gadugi", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.BasePackagePathTextBox.Location = new System.Drawing.Point(6, 60);
            this.BasePackagePathTextBox.Name = "BasePackagePathTextBox";
            this.BasePackagePathTextBox.Size = new System.Drawing.Size(328, 22);
            this.BasePackagePathTextBox.TabIndex = 2;
            this.BasePackagePathTextBox.Text = "Base Game .pkg Path... (For Game Patches)";
            this.BasePackagePathTextBox.TextChanged += new System.EventHandler(this.BasePackagePathTextBox_TextChanged);
            // 
            // OutputPathTextBox
            // 
            this.OutputPathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.OutputPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputPathTextBox.Font = new System.Drawing.Font("Gadugi", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.OutputPathTextBox.Location = new System.Drawing.Point(6, 34);
            this.OutputPathTextBox.Name = "OutputPathTextBox";
            this.OutputPathTextBox.Size = new System.Drawing.Size(328, 22);
            this.OutputPathTextBox.TabIndex = 1;
            this.OutputPathTextBox.Text = "Add A Custom .gp4 Output Directory Here...";
            this.OutputPathTextBox.TextChanged += new System.EventHandler(this.OutputPathTextBox_TextChanged);
            // 
            // OptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(402, 180);
            this.Controls.Add(this.dummy);
            this.Controls.Add(this.AbsolutePathCheckBox);
            this.Controls.Add(this.TinyVersionLabel);
            this.Controls.Add(this.FilterBrowseBtn);
            this.Controls.Add(this.BasePackagePathBtn);
            this.Controls.Add(this.OutputPathBtn);
            this.Controls.Add(this.CustomPasscodeTextBox);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.BasePackagePathTextBox);
            this.Controls.Add(this.VerboseOutputBox);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.OutputPathTextBox);
            this.Controls.Add(this.KeystoneToggleBox);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        ///========================================\\\


        private void ExitBtn_Click(object sender, EventArgs e) {
            OptionsPageIsOpen = false;
            Dispose();
        }


        ///#######################################\\\
        ///--     Options-Related Functions     --\\\
        ///#######################################\\\
        #region Options Related Functions
        private void KeystoneToggleBox_CheckedChanged(object sender, EventArgs e) => gp4.Keystone = ((CheckBox)sender).Checked;
        private void LimitedOutputBox_CheckedChanged(object sender, EventArgs e) => gp4.VerboseLogging = ((CheckBox)sender).Checked;
        private void AbsolutePathCheckBox_CheckedChanged(object sender, EventArgs e) => gp4.AbsoluteFilePaths = ((CheckBox)sender).Checked;
        private void OutputPathTextBox_TextChanged(object sender, EventArgs e)  => Gp4OutputDirectory = ((Control)sender).Text;
        private void CustomPasscodeTextBox_TextChanged(object sender, EventArgs e) => gp4.Passcode = ((Control)sender).Text;

        private void OutputPathBtn_Click(object sender, EventArgs e) {
            using(var Browser = new FolderBrowserDialog())
                if(Browser.ShowDialog() == DialogResult.OK)
                    OutputPathTextBox.Text = Browser.SelectedPath;
        }

        private void BasePackagePathTextBox_TextChanged(object sender, EventArgs e) => gp4.BasePackagePath = ((Control)sender).Text;

        private void BasePackagePathBtn_Click(object sender, EventArgs e) {
            using(var Browser = new OpenFileDialog())
                if(Browser.ShowDialog() == DialogResult.OK)
                    BasePackagePathTextBox.Text = Browser.FileName;
        }

        private void FilterBrowseBtn_Click(object sender, EventArgs e) {
            var Browser = new OpenFileDialog() {
                Multiselect = true,
                Title = "Folders Must Be Added Manually To The Text Box (Blame Microsoft)"
            };

            if(Browser.ShowDialog() == DialogResult.OK) {
                if(FilterTextBox.IsDefault)
                    ((TextBox)sender).Clear();

                foreach(string file in Browser.FileNames)
                    FilterTextBox.Text += $"{file},";
            }

            Browser.Dispose();
        }

        /* <summary>
        /// Remove Trailing Seperators To Avoid Improperly Counting Filtered Items In The Method Below.
        /// </summary>
        private void FilterTextBox_FocusLeft(object control, EventArgs _) {
            var textbox = ((TextBox)control);
            if (!textbox.IsDefault)
                textbox.Text = textbox.Text.TrimEnd(',', ';');
        }*/

        /// <summary>
        /// Parse Individual Items From Filter Text Box, And Add Them To The Blacklist
        /// </summary>
        private void FilterTextBox_TextChanged(object sender, EventArgs _) { // tst : eboot.bin, keystone, discname.txt; param.sfo
            TextBox Sender;
            if((Sender = ((TextBox)sender)).IsDefault) {
                gp4.BlacklistedFilesOrFolders = null;
                return;
            }

            StringBuilder Builder;


            // Get Amount Of Filtered Files/Paths
            var filter_strings_length = 1;
            foreach(var c in (FilterTextBox.Text.Trim(',', ';')).ToCharArray())
                if(c == ';' || c == ',')
                    filter_strings_length++;


            gp4.BlacklistedFilesOrFolders = new string[filter_strings_length];

            var buffer = Encoding.UTF8.GetBytes((FilterTextBox.Text + ';').ToCharArray());

            try {
                for(int array_index = 0, char_index = 0; array_index < gp4.BlacklistedFilesOrFolders.Length; array_index++) {
                    Builder = new StringBuilder();

                    while(buffer[char_index] != 0x3B && buffer[char_index] != 0x2C)
                        Builder.Append(Encoding.UTF8.GetString(new byte[] { buffer[char_index++] }));

                    char_index++;
                    gp4.BlacklistedFilesOrFolders[array_index] = Builder.ToString().Trim(' ');
                }
            }
            catch (IndexOutOfRangeException ex) {
                WLog($"\n{ex.StackTrace}");
#if DEBUG
                DLog($"\n{ex.StackTrace}");
#endif
            }
        }
        
        private void CustomPasscodeTextBox_FocusChanged(object sender, EventArgs e) {
            var Sender = ((TextBox)sender);
            if(!Sender.IsDefault)
                gp4.Passcode = Sender.Text;
        }

        #endregion
        ///=======================================\\\



        ///##################################\\\
        ///--     Control Declarations     --\\\
        ///##################################\\\
        #region ControlDeclarations
        private Label TinyVersionLabel;
        private Label Title;
        private Button dummy; // I forget why this is here
        private Button ExitBtn;
        private Button OutputPathBtn;
        private Button BasePackagePathBtn;
        private Button FilterBrowseBtn;
        private CheckBox KeystoneToggleBox;
        private CheckBox VerboseOutputBox;
        private CheckBox AbsolutePathCheckBox;
        private TextBox OutputPathTextBox;
        private TextBox BasePackagePathTextBox;
        private TextBox FilterTextBox;
        private TextBox CustomPasscodeTextBox;
        #endregion
        ///==================================\\\
    }
}
