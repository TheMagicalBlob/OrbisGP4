using libgp4;
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

        //###################################\\
        //--     Variable Declarations     --\\
        //###################################\\
        #region Variable Declarations
        
        //#
        //## Form Functionality Variables
        //#
        #region [Form Functionality Variables]

        //TODO: Label These
        public static bool
            LegacyFolderSelectionDialogue = true, // 
            OptionsPageIsOpen = false,            //
            MouseIsDown = false                   //
        ;


        /// <summary> Store Expected Options Form Offset
        /// </summary>
        public static Point OptionsFormLocation;

        /// <summary> Variable for Smooth Form Dragging. </summary>
        public static Point MouseDif;
        
        /// <summary> MainPage Form Pointer/Refference. </summary>
        public static MainForm Venat;
        /// <summary> OptionsPage Form Pointer/Refference. </summary>
        public static OptionsPage Azem;

        /// <summary> GP4Creator Instance for Project .gp4 File Creation. </summary>
        public static GP4Creator gp4;

        /// <summary> OutputWindow Pointer/Ref Because I'm Lazy. </summary>
        public static RichTextBox _OutputWindow;
        #endregion


        //#
        //## Look/Feel-Related Variables
        //#
        public static Color AppColour = Color.FromArgb(125, 183, 245);
        public static Color AppColourLight = Color.FromArgb(210, 240, 250);

        public static Pen pen = new Pen(AppColourLight); // Colouring for Border Drawing

        public static readonly Font MainFont        = new Font("Gadugi", 8.25f, FontStyle.Bold); // Gadugi, 8.25pt, style=Bold, Italic
        public static readonly Font TextFont        = new Font("Segoe UI Semibold", 9f); // Segoe UI Semibold, 9pt, style=Bold
        public static readonly Font DefaultTextFont = new Font("Segoe UI Semibold", 9f, FontStyle.Italic); // Gadugi, 8.25pt, style=Bold, Italic
        
        #endregion Variable Declarations
        //===================================\\



        //###################################\\
        //--     Function Declarations     --\\
        //###################################\\
        #region Function Declarations

        //#
        //## Form Functionality Functions
        //#
        #region [Form Functionality Functions]

        // Handle Form Dragging for Borderless Form
        public static void DragForm() {
            if(MouseIsDown)
            {
                Venat.Location = new Point(Form.MousePosition.X - MouseDif.X, Form.MousePosition.Y - MouseDif.Y);
                if (Azem != null)
                    Azem.Location = new Point(Form.MousePosition.X - MouseDif.X + (Venat.Size.Width - Azem.Size.Width)/2, Venat.Location.Y + 130);

                
                
                Venat.Update();
            }
        }

        
        // Draw a Thin Border for the Control On-Paint
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
        #endregion [Form Functionality Functions]


        //#
        //## Logging Bullshit
        //#
        
        /// <summary> Output Misc. Messages to the Main Output Window (the big-ass richtext box). </summary>
        public static void WLog(object str = null) {
            _OutputWindow.AppendLine(str.ToString());
#if DEBUG
            // Debug Output
            try { Debug.WriteLine($"#libgp4: {str}");
            }   
            catch (Exception){}
#endif
        }

        #endregion Function Declarations
        //===================================\\

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


    /// <summary> Custom TextBox Class to Better Handle Default TextBox Contents. </summary>
    public class TextBox : System.Windows.Forms.TextBox
    {
        /// <summary> Create New Control Instance. </summary>
        public TextBox()
        {
            IsDefault = true;

            Click += (bite, me) => ClearControl();
            GotFocus += (bite, me) => ClearControl(); // Both Events, Just-In-Case.
            TextChanged += SetDefaultText;

            // Reset control if nothing different was entered
            LostFocus += (bite, me) => {
                if(Text.Trim().Length == 0 || DefaultText.Contains(Text)) {
                    Font = Common.DefaultTextFont;
                    Text = DefaultText;
                    IsDefault = true;
                }
            };
        }
/*
        public override string Text { get { if (IsDefault) return "fag"; return _Text; } set { _Text = value; base.Text = value; } }
        private string _Text;*/


        private void ClearControl()
        {
            if(IsDefault) {
                IsDefault = false;
                Font = Common.TextFont;
                Clear();
            }
        }

        /// <summary> Yoink Default Text From First Text Assignment (Ideally right after being created). </summary>
        private void SetDefaultText(object _, EventArgs __) {
            DefaultText = Text;
            TextChanged -= SetDefaultText;
            TextChanged += (sender, e) => Text = Text.Replace("\"", string.Empty);
        }

        /// <summary> Set Control Text and State Properly (meh). </summary>
        public void Set(string text) {
            if (text != string.Empty && !DefaultText.Contains(text))
            {   
                Font = Common.DefaultTextFont;
                Text = text;
                IsDefault = false;
            }
        }






        // Default Control Text to Be Displayed When "Empty".
        private string DefaultText;

        // Help Better Keep Track of Whether the User's Changed the Text, Because I'm a Moron.
        public bool IsDefault { get; private set; }
        
    }

    #endregion
    ///================================================\\\

}
