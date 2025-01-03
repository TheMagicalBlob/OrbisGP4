using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using libgp4;
using static GP4GUI.Common;

namespace GP4GUI {
    public partial class OptionsPage
    {
        public const string Version = "2.67.338 "; // Easier to see, more likely to remember to update
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
                WLog($"ERROR: Provided Parent Form Was Null, Aborting Dropdown Menu Creation.");
                return;
            }
            else if (gp4 == null) {
                WLog($"ERROR: Provided GP4Creator Instance Was Null, Aborting Dropdown Menu Creation.");
                return;
            }

            
            // Variable Declarations
            TestGamedataFolder = @"C:\Users\msblob\Misc\gp4 tst\CUSA00009-app";
            TestGP4Path = @"C:\Users\msblob\Misc\gp4 tst\CUSA00009\CUSA00009-app.gp4";



            #region [DEBUG CONTROL DECLARATIONS & INITIALIZATIONS]
            // Declare Controls
            CheckBox
                VerbosityBtn,
                PackageVersionToggleBtn
            ;
            Button
                Libgp4TestBtn
            ;

            // Initialize Controls
            DebugControls = new Control[]
            {
                VerbosityBtn = new CheckBox
                {
                    AutoSize = true,
                    Font = MainFont,
                    Text = "Verbose Logging",
                    CheckState = CheckState.Checked,
                    Checked = true
                },

                PackageVersionToggleBtn = new CheckBox
                {
                    AutoSize = true,
                    Font = MainFont,
                    Text = $"{(TestGamedataFolder.Length >0? $"{("-app".Any(TestGamedataFolder.Contains)? "-> Patch" : "-> App")}" : ";_;")}",
                    Checked = !"-app".Any(TestGamedataFolder.Contains)
                },

                Libgp4TestBtn = new Button()
                {
                    AutoSize = true,
                    Font = MainFont,
                    Text = "Test GP4Reader",
                }
            };
            #endregion [DEBUG CONTROL DECLARATIONS & INITIALIZATIONS]


            #region [DEBUG CONTROL FUNCTIONS]

            // Verbosity Button Event Handler
            VerbosityBtn.CheckedChanged += (sender, e) => gp4.VerboseOutput = VerbosityBtn.Checked;
       
            // placeholder button
            PackageVersionToggleBtn.CheckedChanged += (sender, e) => {
                if (TestGamedataFolder.Contains("-app")) {
                    TestGamedataFolder = TestGamedataFolder.Replace("-app", "-patch");
                    PackageVersionToggleBtn.Text = "-> App";
                }
                else if (TestGamedataFolder.Contains("-patch")) {
                    TestGamedataFolder = TestGamedataFolder.Replace("-patch", "-app");
                    PackageVersionToggleBtn.Text = "-> Patch";
                }
                else {
                    WLog("Error, Invalid GamedataFolderPath Provided for This Function (must contain -patch | -app)");
                }
            };


            // Test GP4Creator and GP4Reader with either current gamedata folder path, or TestGamedataFolder variable
            Libgp4TestBtn.Click += (sender, e) =>
            {
                // Apply Current Options to GP4Creator Instance, and Apply Defaults to Any Left Unassigned.
                if (OptionsPageIsOpen) Azem.SaveOptions();

                if (!Directory.Exists(gp4.GamedataFolder))
                {
                    if (Directory.Exists(TestGamedataFolder)) {
                        gp4.GamedataFolder = TestGamedataFolder;
                    }
                    else {
                        WLog($"{(gp4.GamedataFolder == string.Empty ? "No" : "Invalid")} Gamedata Folder Path Provided.{(gp4.GamedataFolder.Length > 0 ? $"{gp4.GamedataFolder}" : string.Empty)}");
                        return;
                    }
                }

                gp4.OutputDirectory = @"C:\Users\msblob\gp4 tst";

                var newgp4path = gp4.CreateGP4();
                if (newgp4path == null)
                {
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
                foreach (var f in newgp4.Files)
                    WLog($"  {f}");
                WLog($"{newgp4.Subfolders.Length} Subfolders");
                foreach (var s in newgp4.Subfolders)
                    WLog($"  {s}");
                foreach (var sn in newgp4.SubfolderNames)
                    WLog($"  {sn}");


                WLog($"{newgp4.ChunkCount} Chunks");
                foreach (var c in newgp4.Chunks)
                    WLog($"  {c}");
                WLog($"{newgp4.ScenarioCount} Scenarios");
                WLog($"(Default Scenario: {newgp4.DefaultScenarioId})");
                foreach (var sc in newgp4.Scenarios)
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
                if (_cat) WLog($"Source .pkg Path: {GP4Reader.GetBasePkgPath(newgp4path)}");

                WLog($"{(files = GP4Reader.GetFileListing(newgp4path)).Length} Files");
                foreach (var f in files)
                    WLog($"  {f}");
                WLog($"{(subfolders = GP4Reader.GetFolderListing(newgp4path)).Length} Subfolders");
                foreach (var s in subfolders)
                    WLog($"  {s}");
                foreach (var sn in GP4Reader.GetFolderNames(newgp4path))
                    WLog($"  {sn}");


                WLog($"{GP4Reader.GetChunkCount(newgp4path)} Chunks");
                foreach (var c in GP4Reader.GetChunkListing(newgp4path))
                    WLog($"  {c}");
                WLog($"{GP4Reader.GetScenarioCount(newgp4path)} Scenarios");
                WLog($"(Default Scenario: {GP4Reader.GetDefaultScenarioId(newgp4path)})");
                foreach (var sc in GP4Reader.GetScenarioListing(newgp4path))
                    WLog($"Scenario {sc.Id}: Label={sc.Label} Type={sc.Type} InitialChunkCount:{sc.InitialChunkCount} Range={sc.ChunkRange}");


                WLog($"Content Id: {GP4Reader.GetContentId(newgp4path)}");
                WLog($"Passcode: {GP4Reader.GetPkgPasscode(newgp4path)}");
                WLog($".sfo Timestamp: {GP4Reader.GetTimestamp(newgp4path)}");
                WLog("================== Static Tests End ====================");
                ///=============\\\

                System.Diagnostics.Process.Start(newgp4path);
            };
            #endregion [DEBUG CONTROL FUNCTIONS]



            // Populate Debug Panel
            this.Size = Size.Empty;
            this.Location = location;
            int vert = 8, hori = 0;
            foreach (var control in DebugControls) {
                this.Controls.Add(control);
                control.Location = new Point(3, vert);
                vert += control.Height;

                if (control.Width > this.Width + 4)
                    this.Width = control.Width + 4;
                if (vert > this.Height+ 4)
                    this.Height = vert + 4;
            }

            this.Visible = this.Enabled = false;
            Venat.Controls.Add(this);
            this.BringToFront();
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
        }
    }
#endif
}

/*

 - [GP4_GUI]: 

 - [libgp4]:  

*/