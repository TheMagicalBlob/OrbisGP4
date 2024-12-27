
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using libgp4;

namespace GP4GUI {
    public partial class OptionsPage
    {
        public const string Version = "2.67.313 "; // Easier to see, more likely to remember to update
    }



  #if DEBUG
    public class DebugContents : GroupBox
    {
        // Variable Declarations
        public static string TestGamedataFolder;
        public static string TestGP4Path;

        /// <summary>
        ///   Collection of Controls Specifically for Debug Functionality.
        ///</summary>
        public Control[] DebugControls { get; private set; }

        public DebugContents(Form Venat, GP4Creator gp4, Point location) {
            // Error / Improper Usage Checking
            if (Venat == null) {
                Common.WLog($"ERROR: Provided Parent Form Was Null, Aborting Dropdown Menu Creation.");
                return;
            }
            else if (gp4 == null) {
                Common.WLog($"ERROR: Provided GP4Creator Instance Was Null, Aborting Dropdown Menu Creation.");
                return;
            }


            // Variable Declarations
            TestGamedataFolder = @"C:\Users\msblob\Misc\gp4 tst\CUSA00009-app";
            TestGP4Path = @"C:\Users\msblob\Misc\gp4 tst\CUSA00009\CUSA00009-app.gp4";

            // Control Declarations
            Control
                VerbosityBtn,
                VerbosityBtn2,
                CheckForNewVersionBtn
            ;

            // Init Debug Control Collection
            DebugControls = new Control[]
            {
                VerbosityBtn = new CheckBox
                {
                    Name = "VerbosityBtn",
                    Location = new System.Drawing.Point(161, 65),
                    Size = new System.Drawing.Size(101, 17),
                    Font = new System.Drawing.Font("Gadugi", 7F),
                    Text = "Verbose Logging",
                    ForeColor = System.Drawing.Color.FromArgb(210, 240, 250),
                    CheckState = CheckState.Checked,
                    TabIndex = 18,
                    Checked = true,
                    AutoSize = true,
                    UseVisualStyleBackColor = true
                },

                VerbosityBtn2 = new CheckBox
                {
                    Name = "VerbosityBtn2",
                    Location = new System.Drawing.Point(161, 65),
                    Size = new System.Drawing.Size(101, 17),
                    Font = new System.Drawing.Font("Gadugi", 7F),
                    Text = "Verbose Logging",
                    ForeColor = System.Drawing.Color.FromArgb(210, 240, 250),
                    CheckState = CheckState.Checked,
                    TabIndex = 18,
                    Checked = true,
                    AutoSize = true,
                    UseVisualStyleBackColor = true
                },

                CheckForNewVersionBtn = new Button(){
                }
            };


            #region Function Delcarations
            // Verbosity Button Event Handler
            ((CheckBox)VerbosityBtn).CheckedChanged += (sender, e) => {
                gp4.VerboseOutput = ((CheckBox)sender).Checked;
            };
            // Verbosity Button Event Handler
            ((CheckBox)VerbosityBtn2).CheckedChanged += (sender, e) => {
                gp4.VerboseOutput = ((CheckBox)sender).Checked;
            };

            // CHK
            CheckForNewVersionBtn.Click += async (sender, e) => {
            };
            #endregion

            this.Size = new Size(70, 70);
            this.Location = location;
            int vert = 4, hori = 0;
            foreach (var control in DebugControls) {
                this.Controls.Add(control);
                control.Location = new Point(2, vert);
                vert += control.Height;

                if (control.Width > this.Width + 4)
                    this.Width = control.Width + 4;
            }

            this.Visible = this.Enabled = false;
            Venat.Controls.Add(this);
            this.BringToFront();
        }
    }
#endif
}

/*

 - [GP4_GUI]: 

 - [libgp4]:  Sorted publicly accessible libgp4 members so I don't need to seek or manually find them every time (why'd that take me so long?)

 - [libgp4]:  Extended Compression Check

 - [libgp4]:  

*/