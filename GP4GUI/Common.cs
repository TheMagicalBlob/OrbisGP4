using libgp4;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace GP4GUI {

    /// <summary>
    /// Contains Variables &amp; Functions Used by Both the Main and Options Pages.
    /// </summary>
    public static class Common
    {
        public static bool OptionsPageIsOpen, DropdownMenuIsOpen;
        public static string Gp4OutputDirectory;
        public static GP4Creator gp4;
        public static RichTextBox _OutputWindow;


        // Basic Debug Output Function
        public static void DLog(object str = null) {
#if DEBUG
            try {
                Debug.WriteLine(str);
            }   
            catch (Exception){}

            try {
                Console.WriteLine(str);
            }
            catch (Exception){}
#endif
        }

        // Output Misc. Messages to The Main Output Window (the big-ass text box).
#if DEBUG
        public static void WLog(object str = null) {
            _OutputWindow.AppendLine(str.ToString());
            DLog(str);
        }
#else
        public static void WLog(object str = null) => _OutputWindow.AppendLine(str.ToString());
#endif
    }


    ///################################################\\\
    ///--    Custom/"Overridden" Control Classes     --\\\
    ///################################################\\\
    #region [Custom/"Overridden" Control Classes]

    // Custom RichTextBox Class to Better Handle Default TextBox Contents
    public class RichTextBox : System.Windows.Forms.RichTextBox {

        /// <summary> Appends Text to The Currrent Text of A Text Box, Followed By The Standard Line Terminator.<br/>Scrolls To Keep The Newest Line In View. </summary>
        /// <param name="str"> The String To Output. </param>
        public void AppendLine(string str = "") {
            if(str.Length <= 0)
                AppendText("\n");
            else
                AppendText($"{str}\n");

            ScrollToCaret();
        }
    }


    // Custom TextBox Class to Better Handle Default TextBox Contents
    public class TextBox : System.Windows.Forms.TextBox {

        // Create Controll Instance
        public TextBox()
        {
            IsDefault = true;
            TextChanged += Set;

            GotFocus += (object _, EventArgs __) => {
                if(IsDefault) {
                    Font = new Font("Microsoft YaHei UI", 8.25F);
                    Clear();
                    IsDefault = false;
                }
            };

            KeyPress += (object _, KeyPressEventArgs __) => {
                if(IsDefault) {
                    Font = new Font("Microsoft YaHei UI", 8.25F);
                    Clear();
                }
            };

            Click += (object _, EventArgs __) => {
                if(IsDefault) {
                    Font = new Font("Microsoft YaHei UI", 8.25F);
                    Clear();
                }
            };

            LostFocus += (object _, EventArgs __) => {
                if(Text.Length <= 0 || Text.Trim().Length <= 0) {
                    Font = new Font("Microsoft YaHei UI", 8.25F, FontStyle.Italic);
                    Text = DefaultText;
                    IsDefault = true;
                }
            };
        }


        // Default Controll Text to Be Displayed When "Empty".
        private string DefaultText;

        // Help Better Keep Track of Whether the User's Changed the Text, Because I'm a Moron.
        public bool IsDefault { get; private set; }


        /// <summary> Yoink Default Text From First Text Assignment.
        ///</summary>
        private void Set(object s, EventArgs e) {
            DefaultText = Text;

            TextChanged -= Set;
            TextChanged += (object control, EventArgs _) => {
                if(IsDefault && Text.Length > 0) {
                    Font = new Font("Microsoft YaHei UI", 8.25F);
                    IsDefault = false;
                }
            };
        }
    }

    #endregion
    ///================================================\\\

}
