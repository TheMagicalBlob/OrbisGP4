using System;
using System.IO;
using System.Linq;
using libgp4;


namespace gp4cmd;
internal class Program
{
    static void Main(string[] args)
    {
        GP4Creator gp4;
        Console.Title = "GP4 CMD";

        // Catch improper usage
        if (args == null || args.Length < 1)
        {
            Print("No Arguments Provided; Please provide at least the path to a gamedata folder.\n - If you prefer to not use the command line, you can simply drag a folder on to the application.");
            Console.ReadKey(true);
            return;
        }
        // Catch help command and print help dialogue
        if (args[0] == "-h" || args[0] == "--help")
        {
            Help();
            return;
        }

        // Initialize new GP4Creator instance
        gp4 = new() {
            LoggingMethod = Print,
            SkipEndComment = true,
            SkipIntegrityCheck = false
        };



        // Parse program args (no I don't care how disgusting this is)
        for (int i = 0; i < args.Length - 1; ++i)
        {
            switch (args[i])
            {
                //#
                //## Set boolean GP4Creator options
                //#
                case "--ignore":
                case "--nokeystone":
                case "--ignorekeystone":
                    gp4.IgnoreKeystone = true;
                    break;

                case "--absolutepaths":
                    gp4.UseAbsoluteFilePaths = true;
                    break;

                #if DEBUG
                case "--debug":
                case "--debugoutput":
                    gp4.DebugOutput = true;
                    break;
                #endif
                    
                case "--verbose":
                case "--verboseoutput":
                    gp4.VerboseOutput = true;
                    break;

                case "--skip":
                case "--skipintegritycheck":
                    gp4.SkipIntegrityCheck = true;
                    break;



                    
                //#
                //## Set non-boolean GP4Creator options
                //#
                case "--passcode":
                    gp4.Passcode = args[++i];
                    continue;

                case "--out":
                case "--ouput":
                    gp4.OutputDirectory = args[++i];
                    break;

                case "--pkg":
                case "--base":
                case "--basepkg":
                    gp4.BasePackagePath = args[++i];
                    break;

                case "--exclude":
                case "--blacklist":
                    gp4.FileBlacklist = args[i..args.Length];
                    Print($"Set Blacklist as [{string.Join(", ", gp4.FileBlacklist)}]");
                    break;


                //#
                //## Parse grouped args
                //#
                case var arg when arg[0] == '-':
                    arg = arg.ToLower();

                    
                    //#
                    //## Set boolean GP4Creator options
                    //#
                    gp4.IgnoreKeystone = arg.Any(@char => @char == 'i' || @char == 'k');
                    
                    gp4.UseAbsoluteFilePaths = arg.Contains('a');


#if DEBUG
                    gp4.DebugOutput = arg.Contains('d');
#endif
                    gp4.VerboseOutput = arg.Contains('v');


                    gp4.SkipIntegrityCheck = arg.Any(@char => @char == 's' || @char == 'c');




                    //#
                    //## Check for arguments with values, ignoring any mistakenly placed between the bool switches and final arg.
                    //#
                    var last = arg.Last();

                    switch (last)
                    {
                        case 'p':
                            gp4.Passcode = args[++i];
                            break;

                        case 'o':
                            gp4.OutputDirectory = args[++i];
                            break;

                        case 'b':
                            gp4.BasePackagePath = args[++i];
                            break;

                        case 'f':
                        case 'e': case 'x':
                            gp4.FileBlacklist = args[i..args.Length];
                            Print($"Set Blacklist as [{string.Join(", ", gp4.FileBlacklist)}]");
                            break;
                    }

                    break;


                default:
                    Print($"Invalid Argument Provided. ({args[i]})\nExiting...");
                    return;
            }
        }


        // Verify provided gamedata path
        if (!Directory.Exists(args.Last()))
        {
            Print($"\nAn invalid path was provided for the folder containing the gamedata to be processed.\n - Directory \"{args.Last()}\" does not exist.");
            Console.ReadKey(true);
            return;
        }




        //#
        //## Begin .gp4 creation
        //#
        gp4.GamedataFolder = args.Last();
        var gp4Path = gp4.CreateGP4();

        // Check whether it ended up saving the file
        if (!File.Exists(gp4Path))
        {
            Print("\n\nAn Error appears to have occured during the .gp4 creation process, as the returned file path was not valid- see above for details (if using the verbose and / or debug output options).");
        }
    }



    /// <summary> Console.WriteLine shorthand for laziness (and consistency). </summary>
    private static void Print(object output) => Console.WriteLine(output);

    private static void Help()
    {
        Array.ForEach([
            "Usage:",
            "  gp4cmd.exe [options...] {Path to Gamedata Folder}",
            "",
            "Options:",
            "   -h",
            "   --help:               |  Print this help dialogue, then exit.",
            "   ",
            "   ",
            "   ",
            "   -i, -k",
            "   --ignore",
            "   --nokeystone",
            "   --ignorekeystone      |  Avoid adding the keystone file to the .gp4's file listing when creating a base app package.",
            "   ",
            "   ",
            "   -a",
            "   --absolutepaths       |  Change the type of file paths used from relative (to the gamedata folder) to absolute.",
            "   ",
            "   ",
            #if DEBUG
            "   -d",
            "   --debug",
            "   --debugoutput         |  Enable debug-level logging messages.",
            "   ",
            "   ",
            #endif
            "   -v",
            "   --verbose",
            "   --verboseoutput       |  Enable verbose logging.",
            "   ",
            "   ",
            "   -s, -c",
            "   --skip",
            "   --skipintegritycheck  |  Skip running various checks on the parsed gamedata before .gp4 creation.",
            "   ",
            "   ",
            "   -p",
            "   --passcode            |  Set the 32-char passcode attribute to be used for the created package.",
            "   ",
            "   ",
            "   -o",
            "   --out",
            "   --output              |  Set a custom output directory for the finished .gp4 project.",
            "                            --> Defaults to either the inside or outside of the provided gamedata folder, depending on whether absolute path files are enabled (false == inside)",
            "   ",
            "   ",
            "   -b",
            "   --pkg",
            "   --base",
            "   --basepkg             |  Set the path for the base application package, for use in marrying application patch packages.",
            "                            --> Defaults to the expected filename of the base package",
            "   ",
            "   ",
            "   -f, -e, -x",
            "   --exclude",
            "   --blacklist           |  Provide an array of file or folder names to exclude from the project",
            ""

        ], Print);
    }
}