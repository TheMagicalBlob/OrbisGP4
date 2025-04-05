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

        // Catch improper usage
        if (args == null || args.Length < 1)
        {
            Print("No Arguments Provided; Please provide at least the path to a gamedata folder.\n - If you prefer to not use the command line, you can simply drag a folder on to the application.");
            Console.ReadKey(true);
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
                // Print help output
                case "-h":
                case "--help":
                    Help();
                    break;


                //#
                //## Set boolean GP4Creator options
                //#
                case "--ignore":
                case "--nokeystone":
                case "--ignorekeystone":
                    gp4.IgnoreKeystone = true;
                    break;

                case "--useabsolutefiles":
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
                case "--package":
                case "--basepackage":
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


        //#
        //## Verify parsed script args
        //#

        // Verify provided gamedata path
        if (!Directory.Exists(args.Last()))
        {
            Print($"An invalid path was provided for the folder containing the gamedata to be processed.\n - Directory \"{args.Last()}\" does not exist.");
            Console.ReadKey(true);
            return;
        }




        //#
        //## Begin .gp4 creation
        //#
        var gp4Path = gp4.CreateGP4();

        // Check whether it ended up saving the file
        if (!File.Exists(gp4Path))
        {
            Print("\n\nAn Error appears to have occured during the .gp4 creation process, as the returned file path was not valid- see above for details (if using the verbose and / or debug output options).");
        }
    }



    /// <summary> Console.WriteLine shorthand for laziness. </summary>
    private static void Print(object output) => Console.WriteLine(output);

    private static void Help()
    {
        #if DEBUG
        string[] helpOutput = [
            "Usage:",
            "  gp4cmd.exe [options...] {Path to Gamedata Folder}",
            "",
            "Options:",
            "   -h",
            "   --help:",
            "             Print this help dialogue, then exit.",
            "   ",
            "   ",
            "   -i, -k",
            "   --ignore",
            "   --nokeystone",
            "   --ignorekeystone",
            "   ",
            "   ",
            "   ",
            "   ",
            "   ",
            "   ",
            ""
        ];
        #else
        string[] helpOutput = [
            "Help dialogue not yet written."
        ]; 
        #endif

        Array.ForEach(helpOutput, Print);
    }
}