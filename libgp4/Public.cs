using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
#pragma warning disable CS1587

///////////////////\\\\\\\\\\\\\\\\\\\
///# Contents:                     \\\
///--> Publicly Accessible Members \\\
///////////////////\\\\\\\\\\\\\\\\\\\


namespace libgp4 {

    public partial class GP4Creator {

        ///////////////\\\\\\\\\\\\\\\
        //--     User Options     --\\
        ///////////////\\\\\\\\\\\\\\\
        #region User Options

        /// <summary> An Array Of Parameters Parsed From The param.sfo File In The Application/Patch's System Folder (sce_sys\param.sfo)
        ///</summary>
        public SfoParser SfoParams { get; private set; }

        /// <summary> An Array Of Parameters Parsed From The playgo-chunk.dat File In The Application/Patch's System Folder (sce_sys\playgo-chunk.dat)
        ///</summary>
        public PlaygoParameters PlaygoData { get; private set; }

        /// <summary> Root Path Of The PS4 Package Project The .gp4 Is To Be Created For. (Should Contain At Least An Executable And sce_sys Folder)
        ///</summary>
        public string GamedataFolder {
            get => _GamedataFolder;
            set {
                _GamedataFolder = value;
                SfoParams = new SfoParser(this, value);
                PlaygoData = new PlaygoParameters(this, value);
            }
        }
        private string _GamedataFolder;



        /// <summary>
        /// Include The Keystone File Used For Savedata Creation/Usage In The .gp4's File Listing.
        /// <br/> Including The Original Is Recommended To Maintain Support For Savedata Created By The Original Application.
        /// <br/><br/> (True By Default)
        /// </summary>
        public bool _Keystone;

        /// <summary>
        /// The 32-bit Key Used To Encrypt The .pkg. Required For Extraction With orbis-pub-chk.
        /// <br/><br/> (No Effect On Dumping)
        /// </summary>
        public string _Passcode;

        /// <summary>
        /// An Array Containing The Names Of Any Files Or Folders That Are To Be Excluded From The .gp4 Project.
        /// </summary>
        public string[] _BlacklistedFilesOrFolders;

        /// <summary>
        /// Path To The Base Application Package The New Package Is To Be Married To.
        /// </summary>
        public string BasePackagePath {
            get => _basePackagePath;
            set {
                _basePackagePath = value.Replace("\"", string.Empty);
            }
        }
        private string _basePackagePath;

        /// <summary>
        /// Set Whether Or Not To Use Absolute Or Relative Pathnames For The .gp4 Project's File Listing 
        /// <br/><br/> (True By Default)
        /// </summary>
        public bool _AbsoluteFilePaths;

#if GUIExtras
        /// <summary>
        /// The Application's Default Name, Read From The param.sfo In The Provided Gamedata Folder.
        /// </summary>
        public string _AppTitle { get; private set; }

        /// <summary>
        /// The Various Titles Of The Application, If There Are Titles Passed The Default (e.g. Title_XX). Left null Otherwise.
        /// </summary>
        public List<string> _AppTitles { get; private set; }

        /// <summary>
        /// The Application's Intended Package Type.
        /// </summary>
        public int _AppType { get; private set; }

        /// <summary>
        /// Target Application Version.
        /// </summary>
        public string _TargetAppVer { get; private set; }

        /// <summary> Creation Date Of The param.sfo File.
        ///</summary>
        public string _SfoCreationDate { get; private set; }

        /// <summary>
        /// The PS4/Orbis SDK Version Of The Application.
        /// </summary>
        public string _SdkVersion { get; private set; }
#endif
#if Log
        /// <summary>
        /// Optional Method To Use For Logging. [Function(string s)]
        /// </summary>
        public Action<object> LoggingMethod;

        /// <summary> Set GP4 Log Verbosity.
        ///</summary>
        public bool _VerboseLogging;
#endif
        #endregion



        /////////////////\\\\\\\\\\\\\\\\\
        ///--     User Functions     --\\\
        /////////////////\\\\\\\\\\\\\\\\\
        #region User Functions

        // TODO: TEST THESE TWO THINGS
        /* 
        /// <summary>
        /// Add External Files To The Project's File Listing (wip, this wouldn't work the way it is lol)
        /// </summary>
        /// <param name="TargetPaths"> The Destination Paths In The Created Package. </param>
        /// <param name="OriginalPaths"> Source Paths Of The Files Being Added. </param>
        public void AddFiles(string[] TargetPaths, string[] OriginalPaths) {
            if(extra_files == null) {
                extra_files = new string[OriginalPaths.Length][];

                for(var i = 0; i < extra_files.Length; ++i) {
                    extra_files[i][0] = TargetPaths[i];
                    extra_files[i][1] = OriginalPaths[i];
                }
                return;
            }


            var buffer = extra_files;
            buffer.CopyTo(extra_files = new string[buffer.Length + OriginalPaths.Length][], 0);

            for(var i = buffer.Length; i < extra_files.Length; ++i) {
                extra_files[i][0] = TargetPaths[i];
                extra_files[i][1] = OriginalPaths[i];
            }
        }

        /// <summary>
        /// Add An External File To The Project's File Listing (wip, this wouldn't work the way it is lol)
        /// </summary>
        /// <param name="TargetPath"> The Destination Path In The Created Package. </param>
        /// <param name="OriginalPath"> Source Path Of The File Being Added. </param>
        public void AddFile(string TargetPath, string OriginalPath) {
            if(extra_files != null) {
                var buffer = extra_files;
                buffer.CopyTo(extra_files = new string[buffer.Length + 1][], 0);

                extra_files[extra_files.Length - 1][0] = OriginalPath;
                extra_files[extra_files.Length - 1][1] = TargetPath;
                return;
            }

            extra_files = new string[][] { new string[] { OriginalPath, TargetPath } };
        }
        */

        /// <summary>
        /// Build A New .gp4 Project File For The Provided Gamedata With The Current Options/Settings, And Save It In The Specified OutputDirectory.<br/><br/>
        /// First, Parses gamedata_folder\sce_sys\playgo-chunk.dat &amp; gamedata_folder\sce_sys\param.sfo For Parameters Required For .gp4 Creation,<br/>
        /// Then Saves All File/Subdirectory Paths In The Gamedata Folder
        /// </summary>
        /// 
        /// <param name="GP4OutputPath"> Folder In Which To Place The Newly Build .gp4 Project File. </param>
        /// <param name="VerifyIntegrity"> Set Whether Or Not To Abort The Creation Process If An Error Is Found That Would Cause .pkg Creation To Fail, Or Simply Log It To The Standard Console Output And/Or LogOutput(string) Action. </param>
        public string CreateGP4(string GP4OutputPath, bool VerifyIntegrity) {
#if Log
            WLog($"Starting .gp4 Creation. PKG Passcode: {_Passcode}\n", false);
            WLog($".gp4 Destination Path: {GP4OutputPath}\nSource .pkg Path: {BasePackagePath ?? "Not Applicable"}", true);
#endif


            if(GamedataFolder == null || PlaygoData == null || SfoParams == null) {
                WLog("No Valid Project Folder Was Assigned. Please Provide A Valid Project Folder On Class Ini Or Through Manual Assignment To GamedataFolder Param", false);
                return null;
            }

            // Timestamp For GP4, Same Format Sony Used Though Sony's Technically Only Tracks The Date,
            // With The Time Left As 00:00, But Imma Just Add The Time. It Doesn't Break Anything).
            var gp4_timestamp = DateTime.Now.GetDateTimeFormats()[78];

            string[] file_paths; // Array Of All Files In The Project Folder (Excluding Blacklisted Files/Directories)


            // Get The Paths Of All Project Files & Subdirectories In The Given Project Folder. 
            var file_info = new DirectoryInfo(GamedataFolder).GetFiles(".", SearchOption.AllDirectories); // The Period Is Needed To Search Every Single File/Folder Recursively, I Don't Even Know Why It Works That Way.
            file_paths = new string[file_info.Length];

            for(var index = 0; index < file_info.Length; ++index) {
                file_paths[index] = file_info[index].FullName;
            }
            file_info = null;


            if(Directory.Exists(GP4OutputPath)) {
                GP4OutputPath += $"\\{SfoParams.title_id}-{((SfoParams.category == "gd") ? "app" : "patch")}.gp4";
            }


            // Check The Parsed Data For Any Potential Errors Before Building The .gp4 With It
            if(VerifyIntegrity) {
                VerifyGP4(GamedataFolder, PlaygoData.playgo_content_id, SfoParams);
            }




            // Create Base .gp4 Elements (Up To Chunk/Scenario Data)
            var gp4 = new XmlDocument();
            var basic_elements =
                CreateBaseElements(
                    SfoParams,
                    PlaygoData,
                    gp4,
                    _Passcode,
                    BasePackagePath,
                    gp4_timestamp
            );

            // Create The Actual .go4 Structure
            BuildGp4Elements(
                gp4,
                basic_elements,
                CreateChunksElement(PlaygoData, gp4),
                CreateScenariosElement(PlaygoData, gp4),
                CreateFilesElement(PlaygoData.chunk_count, extra_files, file_paths, GamedataFolder, gp4),
                CreateRootDirectoryElement(GamedataFolder, gp4)
            );


            // Write The .go4 File To The Provided Folder / As The Provided Filename
            gp4.Save(GP4OutputPath);

#if Log
            WLog($"GP4 Creation Successful, File Saved As {GP4OutputPath}", false);
#endif
            return GP4OutputPath;
        }
        #endregion
    }
}