﻿#if DEBUG
using libgp4;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static GP4GUI.Common;
#endif

namespace GP4GUI {
    public partial class OptionsPage
    {
        public const string Version = "2.79.413 "; // Easier to see, more likely to remember to update
    }

    
#if DEBUG
    public class Testing : GroupBox
    {
        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        public static string TestGamedataFolder;
        public static string TestGP4Path;

        
        /// <summary>
        /// Collection of Controls Specifically for Debug Functionality.
        /// </summary>
        public Control[] DebugControls { get; private set; }
        #endregion




        /// <summary>
        /// Initialize a new instance of the Testing class, for variou- oh who the fuck am I writing this for
        /// </summary>
        public Testing(Form Venat, GP4Creator gp4, Point location)
        {
            // Error / Improper Usage Checking
            if (Venat == null) {
                Print($"ERROR: Provided Parent Form Was Null, Aborting Dropdown Menu Creation.");
                return;
            }
            else if (gp4 == null) {
                Print($"ERROR: Provided GP4Creator Instance Was Null, Aborting Dropdown Menu Creation.");
                return;
            }

            
            // Variable Declarations
            TestGamedataFolder = @"C:\Users\msblob\Misc\gp4 tst\CUSA00009-app";
            TestGP4Path = @"C:\Users\msblob\Misc\gp4 tst\CUSA00009-app.gp4";


            //#
            //## Debug Control Declarations & Intitializations
            //#
            #region [Debug Control Declarations & Intitializations]

            // Declare Controls
            CheckBox
                VerbosityBtn,
                PackageCategoryToggleBtn
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

                PackageCategoryToggleBtn = new CheckBox
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
            #endregion


            //#
            //## Debug Control Function Declarations
            //#
            #region [Debug Control Function Declarations]

            // Verbosity Button Event Handler
            VerbosityBtn.CheckedChanged += (sender, e) => gp4.VerboseOutput = VerbosityBtn.Checked;
       
            // placeholder button
            PackageCategoryToggleBtn.CheckedChanged += (sender, e) => {
                if (TestGamedataFolder.Contains("-app")) {
                    TestGamedataFolder = TestGamedataFolder.Replace("-app", "-patch");
                    PackageCategoryToggleBtn.Text = "-> App";
                }
                else if (TestGamedataFolder.Contains("-patch")) {
                    TestGamedataFolder = TestGamedataFolder.Replace("-patch", "-app");
                    PackageCategoryToggleBtn.Text = "-> Patch";
                }
                else {
                    Print("Error, Invalid GamedataFolderPath Provided for This Function (must contain -patch | -app)");
                }
            };


            // Test GP4Creator and GP4Reader with either current gamedata folder path, or TestGamedataFolder variable
            Libgp4TestBtn.Click += (sender, e) =>
            {
                // Apply Current Options to GP4Creator Instance, and Apply Defaults to Any Left Unassigned.
                if (OptionsPageIsOpen) Azem.SaveOptions();

                if (!Directory.Exists(gp4.GamedataFolder))
                {
                    if (TestGamedataFolder != null && Directory.Exists(TestGamedataFolder)) {
                        gp4.GamedataFolder = TestGamedataFolder;
                    }
                    else {
                        Print($"{(gp4.GamedataFolder == string.Empty ? "No" : "Invalid")} Gamedata Folder Path Provided.{(gp4.GamedataFolder.Length > 0 ? $"{gp4.GamedataFolder}" : string.Empty)}");
                        return;
                    }
                }

                gp4.OutputDirectory = @"C:\Users\msblob\gp4 tst";

                var newgp4path = gp4.CreateGP4();
                if (newgp4path == null)
                {
                    Print("Error: CreateGP4() Returned Null, Aborting.");
                    return;
                }


                // instance tests \\
                var newgp4 = new GP4Reader(newgp4path);

                newgp4.VerifyGP4();
                Print("================== Instnce Tests Start ====================");
                var cat = newgp4.IsPatchProject;
                Print($"Is Patch Project: {cat}");
                if (cat) Print($"Source .pkg Path: {newgp4.BaseAppPkgPath}");


                Print($"{newgp4.Files.Length} Files");
                foreach (var f in newgp4.Files)
                    Print($"  {f}");
                Print($"{newgp4.Subfolders.Length} Subfolders");
                foreach (var s in newgp4.Subfolders)
                    Print($"  {s}");
                foreach (var sn in newgp4.SubfolderNames)
                    Print($"  {sn}");


                Print($"{newgp4.ChunkCount} Chunks");
                foreach (var c in newgp4.Chunks)
                    Print($"  {c}");
                Print($"{newgp4.ScenarioCount} Scenarios");
                Print($"(Default Scenario: {newgp4.DefaultScenarioId})");
                foreach (var sc in newgp4.Scenarios)
                    Print($"Scenario {sc.Id}: Label={sc.Label} Type={sc.Type} InitialChunkCount:{sc.InitialChunkCount} Range={sc.ChunkRange}");


                Print($"Content Id: {newgp4.ContentID}");
                Print($"Passcode: {newgp4.Passcode}");
                Print($".sfo Timestamp: {newgp4.Timestamp}");
                Print("================== Instnce Tests End ====================\n\n");
                ///==============\\\


                // static tests \\
                Print("================== Static Tests Start ====================");
                string[] files, subfolders;
                var _cat = GP4Reader.IsPatchPackage(newgp4path);
                Print($"Is Patch Project: {_cat}");
                if (_cat) Print($"Source .pkg Path: {GP4Reader.GetBasePkgPath(newgp4path)}");

                Print($"{(files = GP4Reader.GetFileListing(newgp4path)).Length} Files");
                foreach (var f in files)
                    Print($"  {f}");
                Print($"{(subfolders = GP4Reader.GetFolderListing(newgp4path)).Length} Subfolders");
                foreach (var s in subfolders)
                    Print($"  {s}");
                foreach (var sn in GP4Reader.GetFolderNames(newgp4path))
                    Print($"  {sn}");


                Print($"{GP4Reader.GetChunkCount(newgp4path)} Chunks");
                foreach (var c in GP4Reader.GetChunkListing(newgp4path))
                    Print($"  {c}");
                Print($"{GP4Reader.GetScenarioCount(newgp4path)} Scenarios");
                Print($"(Default Scenario: {GP4Reader.GetDefaultScenarioId(newgp4path)})");
                foreach (var sc in GP4Reader.GetScenarioListing(newgp4path))
                    Print($"Scenario {sc.Id}: Label={sc.Label} Type={sc.Type} InitialChunkCount:{sc.InitialChunkCount} Range={sc.ChunkRange}");


                Print($"Content Id: {GP4Reader.GetContentId(newgp4path)}");
                Print($"Passcode: {GP4Reader.GetPkgPasscode(newgp4path)}");
                Print($".sfo Timestamp: {GP4Reader.GetTimestamp(newgp4path)}");
                Print("================== Static Tests End ====================");
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
