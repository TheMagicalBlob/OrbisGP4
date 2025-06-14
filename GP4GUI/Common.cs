﻿using libgp4;
using System;
using System.Drawing;
using System.Windows.Forms;


#if DEBUG
using System.Diagnostics;
#endif


namespace GP4GUI {

    /// <summary>
    /// Contains Variables &amp; Functions Used by Both the Main and Options Pages.
    /// </summary>
    public static class Common
    {
        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]
        
        //#
        //## Form Functionality Variables
        //#

        /// <summary> Boolean global to set the type of dialogue to use for the GamedataFolder path box's browse button. </summary>
        public static bool LegacyFolderSelectionDialogue = true;

        /// <summary> Return the current state of the options page. </summary>
        public static bool OptionsPageIsOpen { get => Azem.Visible; }

        /// <summary> Boolean global for keeping track of the current mouse state. </summary>
        public static bool MouseIsDown = false;


        /// <summary> Store Expected Options Form Offset
        /// </summary>
        public static Point OptionsFormLocation;

        /// <summary> Variable for Smooth Form Dragging. </summary>
        public static Point MouseDif;
        
        /// <summary> MainPage Form Pointer/Refference. </summary>
        public static MainPage Venat;
        /// <summary> OptionsPage Form Pointer/Refference. </summary>
        public static OptionsPage Azem;

        /// <summary> GP4Creator Instance for Project .gp4 File Creation. </summary>
        public static GP4Creator gp4;

        /// <summary> OutputWindow Pointer/Ref Because I'm Lazy. </summary>
        public static RichTextBox _OutputWindow;



        //#
        //## Look/Feel-Related Variables
        //#

        public static Color AppColour = Color.FromArgb(125, 183, 245);
        public static Color AppColourLight = Color.FromArgb(210, 240, 250);

        public static Pen pen = new Pen(AppColourLight); // Colouring for Border Drawing

        public static readonly Font MainFont        = new Font("Gadugi", 8.25f, FontStyle.Bold); // For the vast majority of controls; anything the user doesn't edit, really.
        public static readonly Font TextFont        = new Font("Segoe UI Semibold", 9f); // For option controls with customized contents
        public static readonly Font DefaultTextFont = new Font("Segoe UI Semibold", 9f, FontStyle.Italic); // For option controls in default states
        #endregion


        
        //==================================\\
        //--|   Function Delcarations   |---\\
        //==================================\\
        #region [Function Delcarations]

        //#
        //## Form Functionality Functions
        //#
        #region [Form Functionality Functions]

        /// <summary>
        /// Handle Form Dragging for Borderless Form.
        /// </summary>
        public static void MoveForm() {
            if(MouseIsDown)
            {
                Venat.Location = new Point(Form.MousePosition.X - MouseDif.X, Form.MousePosition.Y - MouseDif.Y);
                if (Azem != null)
                    Azem.Location = new Point(Form.MousePosition.X - MouseDif.X + (Venat.Size.Width - Azem.Size.Width)/2, Venat.Location.Y + 80);
                
                
                Venat.Update();
            }
        }

        
        /// <summary>
        /// Draw a Thin Border for the Control On-Paint
        /// </summary>
        public static void PaintBorder(object sender, PaintEventArgs e) {
            var ItemPtr = sender as Form;

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
        

        /// <summary> Create and draw a thin white line from one end of the form to the other. (placeholder code atm)
        ///</summary>
        public static void DrawSeperatorLine(object sender, PaintEventArgs @event)
        {
            var item = sender as Label;

            if (item == null)
            {
                echo("!! ERROR: Invalid control passed as Seperator line.");
                echo($"  - Control \"{item.Name}\" location: {item.Location}.");
            }
            if (item.Name == "SeperatorLine0" && item.Location != new Point(2, 20))
            {
                echo($"Seperator Line 0 Improperly positioned on {item.Parent.Name}");
            }
            if (item.Height != 15)
            {
                echo($"# WARNING: \"{item.Name}\" has an invalid height!!! (Label is {item.Height} pixels in hight)");
            }
            if (!(item.Location.X == 2 && item.Width == item.Parent.Width - 4))
            {
                echo($"Moved And Resized {item.Name} ({item.Parent.Name}).");

                item.Location = new Point(2, item.Location.Y);
                item.Width = item.Parent.Width - 4;
            }


            @event.Graphics.Clear(Color.FromArgb(18, 18, 18));
            @event.Graphics.DrawLines(pen, new Point[] {
                new Point(0, 9),
                new Point(item.Parent.Width, 9)
            });
        }
        #endregion


        //#
        //## Logging function
        //#

        /// <summary>
        /// Output Misc. Messages to the Main Output Window (the big-ass richtext box).
        /// </summary>
        internal static void Print(object str = null)
        {
#if DEBUG
            gp4.LoggingMethod(str);
            echo(str);
#endif
        }

        private static void echo(object str)
        {
            #if DEBUG
            // Debug Output
            if (!Console.IsOutputRedirected)
            {
                Console.WriteLine(str);
            }
            else
                Debug.WriteLine($"#libgp4: {str ?? "null"}");
            #endif
        }
        #endregion
    }


    
    //=====================================\\
    //---|   Custom Class Extensions   |---\\
    //=====================================\\
    #region [Custom Class Extensions]

    /// <summary>
    /// Custom RichTextBox class because bite me.
    /// </summary>
    public class RichTextBox : System.Windows.Forms.RichTextBox {

        /// <summary> Appends Text to The Currrent Text of A Text Box, Followed By The Standard Line Terminator.<br/>Scrolls To Keep The Newest Line In View. </summary>
        /// <param name="str"> The String To Output. </param>
        public void AppendLine(string str = "")
        {
            AppendText($"{str}\n");
            ScrollToCaret();
        }
    }

    /// <summary> Custom TextBox Class to Better Handle Default TextBox Contents. </summary>
    public class TextBox : System.Windows.Forms.TextBox
    {
        /// <summary> Create a new winforms TextBox control. </summary>
        public TextBox()
        {
            TextChanged += SetDefaultText; // Save the first Text assignment as the DefaultText
            Font = Common.DefaultTextFont;

            GotFocus += (sender, args) => ReadyControl();
            LostFocus += (sender, args) => ResetControl(false); // Reset control if nothing was entered, or the text is a portion of the default text
        }




        // Default Control Text to Be Displayed When "Empty".
        private string DefaultText;

        public override string Text
        {
            get => base.Text;

            set {
                base.Text = value?.Replace("\"", string.Empty);
            }
        }



        // Help Better Keep Track of Whether the User's Changed the Text, Because I'm a Moron.
        public bool IsDefault() => Text == DefaultText;

        /// <summary> Yoink Default Text From First Text Assignment (Ideally right after being created). </summary>
        private void SetDefaultText(object _, EventArgs __)
        {
            DefaultText = Text;
            Font = Common.DefaultTextFont;

            TextChanged -= SetDefaultText;
        }


        private void ReadyControl()
        {
            if(IsDefault()) {
                Clear();

                Font = Common.TextFont;
            }
        }

        public void Reset() => ResetControl(true);
        private void ResetControl(bool forceReset)
        {
            if(Text.Length < 1 || DefaultText.Contains(Text) || forceReset)
            {
                Text = DefaultText;
                Font = Common.DefaultTextFont;
            }
        }


        /// <summary> Set Control Text and State Properly (meh). </summary>
        public void Set(string text)
        {
            if (text != string.Empty && !DefaultText.Contains(text))
            {   
                Text = text;
                Font = Common.TextFont;
            }
        }
    }
    #endregion
}
