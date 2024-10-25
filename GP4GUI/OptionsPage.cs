﻿using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using static GP4GUI.Common;


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
            this.KeystoneToggleBox = new System.Windows.Forms.CheckBox();
            this.Title = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
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
            this.KeystoneToggleBox.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.KeystoneToggleBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.KeystoneToggleBox.Location = new System.Drawing.Point(172, 97);
            this.KeystoneToggleBox.Name = "KeystoneToggleBox";
            this.KeystoneToggleBox.Size = new System.Drawing.Size(109, 18);
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
            // VerboseOutputBox
            // 
            this.VerboseOutputBox.AutoSize = true;
            this.VerboseOutputBox.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.VerboseOutputBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.VerboseOutputBox.Location = new System.Drawing.Point(291, 97);
            this.VerboseOutputBox.Name = "VerboseOutputBox";
            this.VerboseOutputBox.Size = new System.Drawing.Size(109, 18);
            this.VerboseOutputBox.TabIndex = 6;
            this.VerboseOutputBox.Text = "Verbose Output";
            this.VerboseOutputBox.UseVisualStyleBackColor = true;
            this.VerboseOutputBox.CheckedChanged += new System.EventHandler(this.VerboseOutputBox_CheckedChanged);
            // 
            // OutputPathBtn
            // 
            this.OutputPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.OutputPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OutputPathBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.OutputPathBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OutputPathBtn.Location = new System.Drawing.Point(347, 34);
            this.OutputPathBtn.Name = "OutputPathBtn";
            this.OutputPathBtn.Size = new System.Drawing.Size(62, 24);
            this.OutputPathBtn.TabIndex = 8;
            this.OutputPathBtn.Text = "Browse...";
            this.OutputPathBtn.UseVisualStyleBackColor = false;
            this.OutputPathBtn.Click += new System.EventHandler(this.OutputPathBrowseBtn_Click);
            // 
            // BasePackagePathBtn
            // 
            this.BasePackagePathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.BasePackagePathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BasePackagePathBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.BasePackagePathBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.BasePackagePathBtn.Location = new System.Drawing.Point(347, 62);
            this.BasePackagePathBtn.Name = "BasePackagePathBtn";
            this.BasePackagePathBtn.Size = new System.Drawing.Size(62, 24);
            this.BasePackagePathBtn.TabIndex = 9;
            this.BasePackagePathBtn.Text = "Browse...";
            this.BasePackagePathBtn.UseVisualStyleBackColor = false;
            this.BasePackagePathBtn.Click += new System.EventHandler(this.BasePackagePathBrowseBtn_Click);
            // 
            // FilterBrowseBtn
            // 
            this.FilterBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.FilterBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FilterBrowseBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.FilterBrowseBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FilterBrowseBtn.Location = new System.Drawing.Point(347, 127);
            this.FilterBrowseBtn.Name = "FilterBrowseBtn";
            this.FilterBrowseBtn.Size = new System.Drawing.Size(62, 24);
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
            this.AbsolutePathCheckBox.Font = new System.Drawing.Font("Gadugi", 8.25F);
            this.AbsolutePathCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.AbsolutePathCheckBox.Location = new System.Drawing.Point(9, 97);
            this.AbsolutePathCheckBox.Name = "AbsolutePathCheckBox";
            this.AbsolutePathCheckBox.Size = new System.Drawing.Size(157, 18);
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
            this.CustomPasscodeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.CustomPasscodeTextBox.Location = new System.Drawing.Point(6, 155);
            this.CustomPasscodeTextBox.MaxLength = 32;
            this.CustomPasscodeTextBox.Name = "CustomPasscodeTextBox";
            this.CustomPasscodeTextBox.Size = new System.Drawing.Size(340, 24);
            this.CustomPasscodeTextBox.TabIndex = 4;
            this.CustomPasscodeTextBox.Text = "Add Custom .pkg Passcode Here (Defaults To All Zeros)";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.FilterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.FilterTextBox.Location = new System.Drawing.Point(7, 127);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(339, 24);
            this.FilterTextBox.TabIndex = 3;
            this.FilterTextBox.Text = "Blacklisted Files/Folders To Exclude, Seperated By ; or ,";
            this.FilterTextBox.TextChanged += new System.EventHandler(this.FilterTextBox_TextChanged);
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
            // 
            // OutputPathTextBox
            // 
            this.OutputPathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.OutputPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputPathTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.OutputPathTextBox.Location = new System.Drawing.Point(6, 34);
            this.OutputPathTextBox.Name = "OutputPathTextBox";
            this.OutputPathTextBox.Size = new System.Drawing.Size(340, 24);
            this.OutputPathTextBox.TabIndex = 1;
            this.OutputPathTextBox.Text = "Add A Custom .gp4 Output Directory Here...";
            // 
            // OptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(415, 188);
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
            this.Controls.Add(this.CloseBtn);
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

        /// <summary>
        /// Create And Subscriibe to Various Event Handlers for Basic Form Functionality.
        /// </summary>
        public void PostInitFormLogic()
        {
            CloseBtn.Click += new EventHandler((sender, e) => Azem.Visible = OptionsPageIsOpen = false);
            OptionsFormLocation = new Point((Venat.Size.Width - Size.Width)/2, Location.Y + 120); // Store Expected Options Form Offset.


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
        
        
        private void AbsolutePathCheckBox_CheckedChanged(object sender, EventArgs e) => UseAbsoluteFilePaths = AbsolutePathCheckBox.Checked;

        private void KeystoneToggleBox_CheckedChanged(object sender, EventArgs e)    => IgnoreKeystone = KeystoneToggleBox.Checked;
        
        private void VerboseOutputBox_CheckedChanged(object sender, EventArgs e)     => VerboseOutput = VerboseOutputBox.Checked;



        // Choose a .gp4 Output Path Through Either a FolderBrowserDialogue, or OpenFileDialogue Instance (W/ the hackey Dummy File Method.
        private void OutputPathBrowseBtn_Click(object sender, EventArgs e)
        {
            // Use the ghastly Directory Tree Dialogue to Choose A Folder
            if (LegacyFolderSelectionDialogue) {
                using (var ShitBrowser = new FolderBrowserDialog())
                    if (ShitBrowser.ShowDialog() == DialogResult.OK)
                        OutputPathTextBox.Text = ShitBrowser.SelectedPath;
            }
            // Use The Newer "Hackey" Method
            else {
                var CrapBrowser = new OpenFileDialog() {
                    ValidateNames = false,
                    CheckPathExists = false,
                    CheckFileExists = false,
                    FileName = "Press 'Open' Once Inside The Desired Folder.",
                    Filter = "Folder Selection|*."
                };

                if (CrapBrowser.ShowDialog() == DialogResult.OK)
                    OutputPathTextBox.Text = CrapBrowser.FileName.Remove(CrapBrowser.FileName.LastIndexOf('\\'));
            }
        }



        // Search for the Base Application Package Through an OpenFileDialogue Instance.
        private void BasePackagePathBrowseBtn_Click(object sender, EventArgs e) {
            using(var Browser = new OpenFileDialog())
                if(Browser.ShowDialog() == DialogResult.OK)
                    BasePackagePathTextBox.Text = Browser.FileName;
        }


        
        // Build an Array of Files to Exclude from the .gp4 Project's File Listing From Those Selected Through an OpenFileDialogue Instance (W/ Multiselect).
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



        /// <summary>
        /// Parse Individual Items From Filter Text Box, And Add Them To The Blacklist.
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
            }
        }

        #endregion
        ///=======================================\\\



        //##################################\\
        //--     Control Declarations     --\\
        //##################################\\
        #region ControlDeclarations
        private Label TinyVersionLabel;
        private Label Title;
        private Button dummy; // I forget why this is here
        private Button CloseBtn;
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
