using libgp4;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace GP4GUI {

    /// <summary> Words
    ///</summary>
    public static class Common
    {
        public static int mouse_is_down = 0;
        public static bool options_page_is_open, limit_output;
        public static string Gp4OutputDirectory;
        public static Point MouseDif;
        public static Form Options;
        public static GP4Creator gp4;
        public static RichTextBox _OutputWindow;

        public static void WLog(object str = null) => _OutputWindow.AppendLine(str.ToString());

        public static void DLog(string str = "") {
#if DEBUG
            try { Debug.WriteLine(str);
            }
            catch (Exception) { }

            try { Console.WriteLine(str);
            }
            catch (Exception) { }
#endif
        }
    }



    /// <summary> Custom TextBox Class to Better Handle Default TextBox Contents
    ///</summary>
    public class RichTextBox : System.Windows.Forms.RichTextBox {

        /// <summary> Appends Text to The Currrent Text of A Text Box, Followed By The Standard Line Terminator.<br/>Scrolls To Keep The Newest Line In View. </summary>
        /// <param name="str"> The String To Output. </param>
        public void AppendLine(string str = "") {
            if(str.Length <= 0) AppendText("\n");

            else AppendText($"{str}\n");

            ScrollToCaret();
        }
    }


    /// <summary> Custom RichTextBox Class to Better Handle Default TextBox Contents
    ///</summary>
    public class TextBox : System.Windows.Forms.TextBox {
        public TextBox() {
            
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


        private string DefaultText;
        public bool IsDefault { get; private set; }


        /// <summary> Yoink Default Text From First Text Assignment.
        ///</summary>
        void Set(object s, EventArgs e) {
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
}
