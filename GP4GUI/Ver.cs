
namespace GP4GUI {
    public partial class OptionsPage {
        // Seperate File So I'm More Likely To Open It And Update The Version Number. I Am Lazy
        public const string Version = "ver 2.63.279 ";


        #if DEBUG
        // quick debugging shit
        public static string TestGamedataFolder = @"C:\Users\msblob\Misc\gp4 tst\CUSA00009-patch";
        #endif 
    }
}

/*
 - [GP4_GUI]: Added Missing Check for Base Game Catagory Before Verifying the Presence of a Keystone File.

 - [libgp4]:  Removed Odd Unnecessary Check for Whether the Provided Base Game Package path is 
 
 - [GP4_GUI]: TODO: Fix Issue With GamedataFolderPathBox Immediately losing focus when clicked after the options page has been opened at least once

 - [GP4_GUI]: Deleted Verbosity Toggle, Now Simply Enabled in Debug Builds

 - [GP4_GUI]: Fixed Issue With MouseUp Events

 - [GP4_GUI]: 

 - [libgp4]:  
 */