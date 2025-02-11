using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GP4GUI
{
    public partial class MainForm
    {
        //#######################################\\
        //--     Basic Form Init Functions     --\\
        //#######################################\\
        #region [Basic Form Init Functions]

        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.CreateProjectFileBtn = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.OptionsBtn = new System.Windows.Forms.Button();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.dummy = new System.Windows.Forms.Button();
            this.SwapBrowseModeBtn = new System.Windows.Forms.Button();
            this.VerifyGP4Btn = new System.Windows.Forms.Button();
            this.DebugOptionsBtn = new System.Windows.Forms.Button();
            this.OutputWindow = new GP4GUI.RichTextBox();
            this.GamedataPathTextBox = new GP4GUI.TextBox();
            this.SuspendLayout();
            // 
            // CreateProjectFileBtn
            // 
            this.CreateProjectFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.CreateProjectFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CreateProjectFileBtn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.CreateProjectFileBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CreateProjectFileBtn.Location = new System.Drawing.Point(555, 114);
            this.CreateProjectFileBtn.Name = "CreateProjectFileBtn";
            this.CreateProjectFileBtn.Size = new System.Drawing.Size(100, 24);
            this.CreateProjectFileBtn.TabIndex = 3;
            this.CreateProjectFileBtn.Text = "Build New .gp4";
            this.CreateProjectFileBtn.UseVisualStyleBackColor = false;
            this.CreateProjectFileBtn.Click += new System.EventHandler(this.SetupAndCreateProjectFile);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Gadugi", 10F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.Title.Location = new System.Drawing.Point(219, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(212, 18);
            this.Title.TabIndex = 0;
            this.Title.Text = "Orbis .gp4 Project File Creator";
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MinimizeBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MinimizeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimizeBtn.Location = new System.Drawing.Point(613, 2);
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
            this.ExitBtn.Location = new System.Drawing.Point(635, 2);
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
            this.BrowseBtn.Location = new System.Drawing.Point(564, 38);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 24);
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
            this.OptionsBtn.Size = new System.Drawing.Size(66, 23);
            this.OptionsBtn.TabIndex = 9;
            this.OptionsBtn.Text = "Options...";
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
            this.ClearLogBtn.Location = new System.Drawing.Point(5, 115);
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
            this.SwapBrowseModeBtn.Location = new System.Drawing.Point(640, 38);
            this.SwapBrowseModeBtn.Name = "SwapBrowseModeBtn";
            this.SwapBrowseModeBtn.Size = new System.Drawing.Size(17, 24);
            this.SwapBrowseModeBtn.TabIndex = 16;
            this.SwapBrowseModeBtn.UseVisualStyleBackColor = false;
            this.SwapBrowseModeBtn.Click += new System.EventHandler(this.SwapBrowseModeBtn_Click);
            // 
            // VerifyGP4Btn
            // 
            this.VerifyGP4Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.VerifyGP4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VerifyGP4Btn.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Bold);
            this.VerifyGP4Btn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.VerifyGP4Btn.Location = new System.Drawing.Point(435, 114);
            this.VerifyGP4Btn.Name = "VerifyGP4Btn";
            this.VerifyGP4Btn.Size = new System.Drawing.Size(116, 24);
            this.VerifyGP4Btn.TabIndex = 17;
            this.VerifyGP4Btn.Text = "Verify Existing .gp4";
            this.VerifyGP4Btn.UseVisualStyleBackColor = false;
            this.VerifyGP4Btn.Click += new System.EventHandler(this.VerifyGP4Btn_Click);
            // 
            // DebugOptionsBtn
            // 
            this.DebugOptionsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(183)))), ((int)(((byte)(245)))));
            this.DebugOptionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DebugOptionsBtn.Font = new System.Drawing.Font("Gadugi", 7.25F, System.Drawing.FontStyle.Bold);
            this.DebugOptionsBtn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DebugOptionsBtn.Location = new System.Drawing.Point(73, 4);
            this.DebugOptionsBtn.Name = "DebugOptionsBtn";
            this.DebugOptionsBtn.Size = new System.Drawing.Size(84, 23);
            this.DebugOptionsBtn.TabIndex = 20;
            this.DebugOptionsBtn.Text = "Debug Options";
            this.DebugOptionsBtn.UseVisualStyleBackColor = false;
            this.DebugOptionsBtn.Click += new System.EventHandler(this.DebugOptionsBtn_Click);
            // 
            // OutputWindow
            // 
            this.OutputWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(10)))));
            this.OutputWindow.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.OutputWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.OutputWindow.Location = new System.Drawing.Point(5, 141);
            this.OutputWindow.MaxLength = 21474836;
            this.OutputWindow.Name = "OutputWindow";
            this.OutputWindow.ReadOnly = true;
            this.OutputWindow.Size = new System.Drawing.Size(650, 275);
            this.OutputWindow.TabIndex = 6;
            this.OutputWindow.Text = "";
            // 
            // GamedataFolderPathBox
            // 
            this.GamedataPathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.GamedataPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GamedataPathTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Italic);
            this.GamedataPathTextBox.Location = new System.Drawing.Point(5, 38);
            this.GamedataPathTextBox.Name = "GamedataFolderPathBox";
            this.GamedataPathTextBox.Size = new System.Drawing.Size(557, 24);
            this.GamedataPathTextBox.TabIndex = 2;
            this.GamedataPathTextBox.Text = "Paste The Gamedata Folder Path Here, Or Use The Browse Button...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(659, 420);
            this.Controls.Add(this.DebugOptionsBtn);
            this.Controls.Add(this.VerifyGP4Btn);
            this.Controls.Add(this.SwapBrowseModeBtn);
            this.Controls.Add(this.dummy);
            this.Controls.Add(this.ClearLogBtn);
            this.Controls.Add(this.OptionsBtn);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.OutputWindow);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.GamedataPathTextBox);
            this.Controls.Add(this.CreateProjectFileBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "GP4 Project Builder";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
