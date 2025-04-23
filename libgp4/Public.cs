
//================================\\
// Contents:                      \\
//--> Publicly Accessible Members \\
//================================\\

#define GUIExtras
#define Log

using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace libgp4 {

    public partial class GP4Creator {

        /// <summary>
        /// Initialize A New Instance Of The GP4Creator Class With Which To Build A New .gp4 Project With Various Settings.<br/>
        /// Allows For The Editing Of Various Options Before .gp4 Creation.
        /// <br/><br/> (A Valid GamedataFolder Must Be Set Prior To Creating The .gp4 Project File)
        /// </summary>
        public GP4Creator(string gamedataFolder)
        {
            // No idea what I want to do here
            GamedataFolder = gamedataFolder;
        }


        /// <summary>
        /// Initialize a new instance of the GP4Creaator class without setting the active GamedataFolder.<br/>
        /// A valid gamedata folder must be provided before .gp4 creation is started. Sfo and Playgo params will be set once one is provided
        /// </summary>
        public GP4Creator()
        {
            // No idea what I want to do here
        }




        //========================\\
        //--    User Options    --\\
        //========================\\
        #region [User Options]
        // TODO: sort these options, I can never remember what's where ffs


        /// <summary>
        /// Root Path Of The PS4 Package Project The .gp4 Is To Be Created For. (Should Contain At Least An Executable And sce_sys Folder)
        /// </summary>
        public string GamedataFolder
        {
            get => _GamedataFolder ?? string.Empty;

            set {
                if (value == null)
                {
                    _GamedataFolder = string.Empty;
                }
                else
                    _GamedataFolder = value?.TrimEnd('/', '\\');

                DPrint($"GamedataFolder => [{_GamedataFolder}]");


                if (!Directory.Exists(GamedataFolder))
                {
                    string message;

                    if (File.Exists(GamedataFolder))
                    {
                        message = $"Path \"{GamedataFolder}\" Leads to a File, Not a Folder.";
                    }
                    else if (GamedataFolder == string.Empty)
                    {
                        message = "Nothing Was Provided.";
                    }
                    else
                        message = $"Directory \"{GamedataFolder}\" Does Not Exist.";


                    throw new DirectoryNotFoundException($"Invalid Gamedata Folder Path Provided, unable to parse data in sce_sys. [{message}]");
                }

                SfoParams  = new SfoParser(this, GamedataFolder);
                PlaygoData = new PlaygoParameters(this, GamedataFolder);

                DefaultBlacklist = _DefaultBlacklist;
                DefaultBlacklist.Select(item => item = GamedataFolder + '\\' + item);
            }
        }
        private string _GamedataFolder;


        /// <summary>
        /// An Array Of Parameters Parsed From The param.sfo File In The Application/Patch's System Folder (sce_sys\param.sfo)
        /// </summary>
        public SfoParser SfoParams {
            get => _SfoParams;

            private set {
                _SfoParams = value;
                DPrint($"SfoParams => [{string.Join("\nSfoParams => ", _SfoParams)}]\n");
            }
        }
        private SfoParser _SfoParams;


        /// <summary>
        /// An Array Of Parameters Parsed From The playgo-chunk.dat File In The Application/Patch's System Folder (sce_sys\playgo-chunk.dat)
        /// </summary>
        public PlaygoParameters PlaygoData {
            get => _PlaygoData;

            private set {
                _PlaygoData = value;
                DPrint($"PlaygoData => [{string.Join("\nPlaygoData => ", _PlaygoData)}]\n");
            }
        }
        private PlaygoParameters _PlaygoData;


        
        /// <summary>
        /// Output Directory for the .gp4 Project File.
        /// </summary>
        public string OutputDirectory {
            get => _OutputDirectory ?? string.Empty;

            set {
                _OutputDirectory = value ?? string.Empty;
                DPrint($"OutputDirectory => [{_OutputDirectory}]");
            } 
        }
        private string _OutputDirectory;


        /// <summary>
        /// Full File Path That Will be Used for the .gp4 Project File.
        /// </summary>
        private string OutputPath {
            get => _OutputPath ?? string.Empty;

            set {
                _OutputPath = value ?? string.Empty;
                DPrint($"OutputDirectory => [{_OutputPath}]");
            }
        }
        private string _OutputPath;


        /// <summary>
        /// The Key Used To Encrypt The Package The Generated .gp4 Project Is For.
        /// <br/>(must be 32 characters long, required for extraction with orbis-pub-chk. no effect on dumping)
        /// </summary>
        public string Passcode {
            get => _Passcode ?? string.Empty;

            set {                     
                _Passcode = value ?? string.Empty;
                DPrint($"Passcode => [{_Passcode}]");
            }
        }
        private string _Passcode;


        /// <summary>
        /// An Array Containing The Names Of Any Files Or Folders That Are To Be Excluded From The .gp4 Project.
        /// </summary>
        public string[] FileBlacklist
        {
            get => _BlacklistedFilesOrFolders ?? Array.Empty<string>();

            set {
                _BlacklistedFilesOrFolders = value ?? Array.Empty<string>();

                DPrint($"BlacklistedFilesOrFolders => [{string.Join(", ", _BlacklistedFilesOrFolders ?? Array.Empty<string>())}]");
            }
        }
        private string[] _BlacklistedFilesOrFolders;


        /// <summary>
        /// Path To The Base Application Package The New Package Is To Be Married To.
        /// </summary>
        public string BasePackagePath {
            get => _BasePackagePath ?? string.Empty;

            set {
                _BasePackagePath = value?.Replace("\"", string.Empty);
                DPrint($"BasePackagePath => [{_BasePackagePath}]");
            }
        }
        private string _BasePackagePath;


#if GUIExtras
        /// <summary>
        /// The Application's Default Name, Read From The param.sfo In The Provided Gamedata Folder.
        /// </summary>
        public string AppTitle {
            get => _AppTitle ?? string.Empty;

            private set {
                _AppTitle = value ?? string.Empty;
                DPrint($"AppTitle => [{_AppTitle}]");
            }
        }
        private string _AppTitle;


        /// <summary>
        /// The Various Titles Of The Application, If There Are Titles Passed The Default (e.g. Title_XX). Left null Otherwise.
        /// </summary>
        public List<string> AppTitles {
            get => _AppTitles;

            private set {
                _AppTitles = value;
                DPrint($"AppTitles => [{string.Join(", ", _AppTitles)}]");
            }
        }
        private List<string> _AppTitles;


        /// <summary>
        /// The Application's Intended Package Type.
        /// </summary>
        public int AppType {
            get => _AppType;

            private set {
                _AppType = value;
                DPrint($"AppType => [{_AppType}]");
            }
        }
        private int _AppType;


        /// <summary>
        /// Target Application Version.
        /// </summary>
        public string TargetAppVer {
            get => _TargetAppVer ?? string.Empty;

            private set {
                _TargetAppVer = value ?? string.Empty;
                DPrint($"TargetAppVer => [{_TargetAppVer}]");
            }
        }
        private string _TargetAppVer;


        /// <summary>
        /// Creation Date Of The param.sfo File.
        /// </summary>
        public string SfoCreationDate {
            get => _SfoCreationDate ?? string.Empty;

            private set {
                _SfoCreationDate = value ?? string.Empty;
                DPrint($"SfoCreationDate => [{_SfoCreationDate}]");
            }
        }
        private string _SfoCreationDate;


        /// <summary>
        /// The PS4/Orbis SDK Version Of The Application.
        /// </summary>
        public string SdkVersion {
            get => _SdkVersion ?? string.Empty;

            private set {
                _SdkVersion = value ?? string.Empty;
                DPrint($"SdkVersion => [{_SdkVersion}]");
            }
        }
        private string _SdkVersion;
#endif


#if Log
        /// <summary>
        /// Optional Method To Use For Logging. [Function(string s)]
        /// </summary>
        public Action<object> LoggingMethod
        {
            get => _LoggingMethod;

            set
            {
                _LoggingMethod = value;
                DPrint($"LoggingMethod => {_LoggingMethod.Method}");
            }
        }
        private static Action<object> _LoggingMethod;
#endif


        #region [Boolean Options]
#if Log
        /// <summary>
        /// Set GP4Creator Output Verbosity.
        /// </summary>
        public bool VerboseOutput
        {
            get => _VerboseOutput;

            set {
                _VerboseOutput = value;
                DPrint($"VerboseLogging => [{_VerboseOutput}]");
            }
        }
        private bool _VerboseOutput;
#if DEBUG

        /// <summary>
        /// Further Extend Verbosity by Duplicating DLog() Messages to LoggingMethod if Provided.
        /// </summary>
        public bool DebugOutput
        {
            get => _DebugOutput;

            set {
                _DebugOutput = value;
                DPrint($"DebugLogging => [{_DebugOutput}]");
            }
        }
        private static bool _DebugOutput;
#endif
#endif

        /// <summary>
        /// [Defaults to: True]<br/><br/> 
        /// Set Whether Or Not To Use Absolute Or Relative Pathnames For The .gp4 Project's File Listing 
        /// </summary>
        public bool UseAbsoluteFilePaths
        {
            get => _AbsoluteFilePaths;

            set {
                _AbsoluteFilePaths = value;
                DPrint($"AbsoluteFilePaths => [{_AbsoluteFilePaths}]");
            }
        }
        private bool _AbsoluteFilePaths;

        /// <summary>
        /// Include The Keystone File Used For Savedata Creation/Usage In The .gp4's File Listing.
        /// <br/> Including The Original Is Recommended To Maintain Support For Savedata Created By The Original Application.
        /// <br/><br/> (True By Default)
        /// </summary>
        public bool IgnoreKeystone
        {
            get => _IgnoreKeystone;

            set {
                _IgnoreKeystone = value;
                DPrint($"IgnoreKeystone => [{_IgnoreKeystone}]");
            }
        }
        private bool _IgnoreKeystone;


        /// <summary> Skip Checking the Project Data for Possible Errors Before Beginning the Creation Process. </summary>
        public bool SkipIntegrityCheck
        {
            get => _SkipIntegrityCheck;

            set {
                _SkipIntegrityCheck = value;
                DPrint($"VerifyIntegrity => [{_SkipIntegrityCheck}]");
            }
        }
        private bool _SkipIntegrityCheck;


        /// <summary> Skip End-of-GP4 Comment W/ the Github Repo Link. </summary>
        public bool SkipEndComment
        {
            get => _SkipEndComment;

            set {
                _SkipEndComment = value;
                DPrint($"SkipEndComment => [{_SkipEndComment}]");
            }
        }
        private bool _SkipEndComment;
        #endregion
        
        #endregion [User Options]



        //============================\\
        //---|   User Functions   |---\\
        //============================\\
        #region [User Functions]

        #region WIP AddFile(s) Shit
        /*
                // TODO: TEST THESE TWO THINGS
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
                /// Add An External File To The Project's File Listing (W.I.P. ; this wouldn't work the way it is lol)
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
        #endregion


        /// <summary>
        /// Build A New .gp4 Project File For The Provided Gamedata With The Current Options/Settings, And Save It In The Specified OutputDirectory.<br/><br/>
        /// First, Parses gamedata_folder\sce_sys\playgo-chunk.dat &amp; gamedata_folder\sce_sys\param.sfo For Parameters Required For .gp4 Creation,<br/>
        /// Then Saves All File/Subdirectory Paths In The Gamedata Folder
        /// </summary>
        /// 
        /// <returns> The Absolute Path to the Created .gp4 Project File. </returns>
        public string CreateGP4()
        {
            //#
            //## GP4 Project File Creation Start
            //#
            Print($"Beginning .gp4 Project Creation.\n", false);
            
            // Create a timestamp for the .gp4 project file.
            // Uses the same format sony did, though they only tracked the date and left the time zeroed. I'm just gonna add it though, the publishing tools don't seem to care.
            string
                Second = DateTime.Now.Second.ToString(),
                Minute = DateTime.Now.Minute.ToString(),
                Hour   = DateTime.Now.Hour.ToString(),
                Day    = DateTime.Now.Day.ToString(),
                Month  = DateTime.Now.Month.ToString()
            ;
            var gp4_timestamp = $"{DateTime.Now.Year}-{Month.PadLeft(2, '0')}-{Day.PadLeft(2, '0')} {Hour.PadLeft(2, '0')}:{Minute.PadLeft(2, '0')}:{Second.PadLeft(2, '0')}";


            // Check The Parsed Data For Any Potential Errors Before Building The .gp4 With It
            ApplyDefaultsToUnsetMembers(SfoParams);


            // Verify project data
            var errors = VerifyProjectData(GamedataFolder, PlaygoData.playgo_content_id, SfoParams);
            
            if (errors.Length > 0)
            {
                Print("\n", false);
                Array.ForEach(errors, error => Print(error + '\n', false));

                Print($"\n.gp4 Creation Failed; {errors.Length} Errors Found.", false);
                return string.Empty;
            }


            

            // Check for a .gp4ignore file
            Print("Checking for .gp4ignore/.app_path/.passcode files in gamedata folder...", true);
            if (File.Exists($"{GamedataFolder}\\.gp4ignore") && FileBlacklist != null && FileBlacklist.Length < 1)
            {
                FileBlacklist = File.ReadAllLines($"{GamedataFolder}\\.gp4ignore").Select(str => str = str.Replace("\"", string.Empty)).ToArray();
                Print($"Using the {FileBlacklist.Length} blacklisted files listed in from .app_path file in gamedata folder.", true);
            }

            // Check for a .app_path file
            if(File.Exists($"{GamedataFolder}\\.app_path") && !File.Exists(BasePackagePath))
            {
                BasePackagePath = File.ReadAllText($"{GamedataFolder}\\.app_path").Replace("\"", string.Empty);
                Print($"Using Application path \"{BasePackagePath}\" from .app_path file in gamedata folder.", true);
            }

            // Check for a .passcode file
            if(File.Exists($"{GamedataFolder}\\.passcode"))
            {
                Passcode = File.ReadAllText($"{GamedataFolder}\\.passcode").Replace("\"", string.Empty);
                Print($"Using Passcode \"{Passcode}\" from .passcode file in gamedata folder.", true); // passcode passcode passcode passcode pa-
            }




            // Initialize a new XML Document instance for the .gp4 Project.
            var gp4 = new XmlDocument();

            // Create Base .gp4 Elements (Up To Chunk/Scenario Data)
            var basic_elements = CreateBaseElements
            (
                SfoParams,
                PlaygoData,
                gp4,
                Passcode,
                BasePackagePath,
                gp4_timestamp
            );


            // Create The Actual .gp4 Structure
            Print($"Building .gp4 structure.", false);
            Print($" - Start time: {DateTime.Now.Minute.ToString().PadLeft(2, '0')}:{DateTime.Now.Second.ToString().PadLeft(2, '0')}", true);
            BuildGp4Elements
            (
                gp4,
                basic_elements,
                CreateChunksElement(PlaygoData, gp4),
                CreateScenariosElement(PlaygoData, gp4),
                CreateFilesElement(PlaygoData.chunk_count, extra_files, GamedataFolder, gp4),
                CreateRootDirectoryElement(GamedataFolder, gp4)
            );
            Print($"Finished Building .gp4 Project file.", false);
            Print($" - Completion time: {DateTime.Now.Minute.ToString().PadLeft(2, '0')}:{DateTime.Now.Second.ToString().PadLeft(2, '0')}", true);
            Print("", false); // lazy formatting fix


            // Write The .gp4 File To The Provided Folder / As The Provided Filename
            Print("Saving .gp4 file to disk...", false);
            gp4.Save(OutputPath);


            Print(string.Empty, true); // Lazy output formatting fix
            Print($"GP4 Creation Successful, File Saved As\n\"{OutputPath}\"\n\n", false);

            return OutputPath;
        }
        #endregion
    }
}