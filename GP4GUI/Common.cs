﻿using libgp4;
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
        // Logging Bullshit
        #region [Logging Bullshit]

#if DEBUG
        /// Output Misc. Messages to the Main Output Window (the big-ass richtext box).
        public static void WLog(object str = null) {
            _OutputWindow.AppendLine(str.ToString());
            DLog(str);
        }
#else
        public static void WLog(object str = null) => _OutputWindow.AppendLine(str.ToString());
#endif
        /// Basic Debug Output Function
        public static void DLog(object str = null) {
#if DEBUG
            try { Debug.WriteLine($"#libgp4: {str}");
            }   
            catch (Exception){}

            try { Console.WriteLine($"#libgp4: {str}");
            }
            catch (Exception){}
#endif
        }
        #endregion


        public static bool OptionsPageIsOpen = false;
        public static GP4Creator gp4;
        public static RichTextBox _OutputWindow;
        
        
        public static Point MouseDif;
        public static bool MouseIsDown = false;
        public static Form Azem, Venat;
        public static Point OptionsFormLocation;


        // Application Aesthetics-Related Variables & Functions
        # region
        public static Color AppColour = Color.FromArgb(125, 183, 245);
        public static Color AppColourLight = Color.FromArgb(210, 240, 250);

        public static Pen pen = new Pen(AppColourLight);

        public static readonly Font MainFont        = new Font("Gadugi", 8.25f, FontStyle.Bold); // Gadugi, 8.25pt, style=Bold, Italic
        public static readonly Font TextFont        = new Font("Segoe UI Semibold", 9f); // Segoe UI Semibold, 9pt, style=Bold
        public static readonly Font DefaultTextFont = new Font("Segoe UI Semibold", 9f, FontStyle.Italic); // Gadugi, 8.25pt, style=Bold, Italic

        

        //##########################\\
        //--     .gp4 Options     --\\
        //##########################\\
        #region [.gp4 Options]
        public static bool
            Verbose,
            Keystone,
            UseAbsolutePaths
        ;
        public static string
            GP4OutputDirectory,
            BasePackagePath,
            Passcode
        ;
        public static string[] BlacklistedItems;
        #endregion
        //==========================\\



        // Draw a Thin Border for the Control On-Paint \\
        public static void PaintBorder(object sender, PaintEventArgs e) {
            var ItemPtr = (Form)sender;

            Point[] Border = new Point[] {
                Point.Empty,
                new Point(ItemPtr.Width-1, 0),
                new Point(ItemPtr.Width-1, ItemPtr.Height-1),
                new Point(0, ItemPtr.Height-1),
                Point.Empty
            };

            e.Graphics.Clear(Color.FromArgb(20, 20, 20));
            e.Graphics.DrawLines(pen, Border);
        }
        #endregion
        //====\\
    }



    //################################################\\
    //--    Custom/"Overridden" Control Classes     --\\
    //################################################\\
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

            GotFocus += (bite, me) => {
                if(IsDefault) {
                    Font = Common.TextFont;
                    Clear();
                }
            };
            LostFocus += (bite, me) => {
                // Reset control if nothing different was entered
                if(Text.Trim().Length == 0 || DefaultText.Contains(Text)) {
                    Font = Common.DefaultTextFont;
                    Text = DefaultText;
                    IsDefault = true;
                }
                else {
                    IsDefault = false;
                }
            };

            Click += (bite, me) => {
                if(IsDefault) {
                    Font = Common.TextFont;
                    Clear();
                }
            };
        }


        // Default Control Text to Be Displayed When "Empty".
        private string DefaultText;

        // Help Better Keep Track of Whether the User's Changed the Text, Because I'm a Moron.
        public bool IsDefault { get; private set; }


        /// <summary> Yoink Default Text From First Text Assignment (Ideally right after being created).
        ///</summary>
        private void Set(object _, EventArgs __) {
            DefaultText = Text;
            TextChanged -= Set;
        }
    }

    #endregion
    ///================================================\\\

}
