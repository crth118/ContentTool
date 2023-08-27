using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentToolUI
{
    public static class ColorScheme
    {
        public static ColorSchemeType ApplicationColorScheme { get; set; }
        public static Color FormBackColor { get; set; }
        public static Color LabelForeColor { get; set; }
        public static Color TextBoxBackColor { get; set; }
        public static Color TextBoxForeColor{ get; set; }
        public static Color ButtonForeColor { get; set; }
        public static Color ButtonBackColor { get; set; }


        public static void SetTabcorpColors()
        {
            FormBackColor = Color.AntiqueWhite;
            LabelForeColor = Color.Blue;
            TextBoxBackColor = Color.Blue;
            TextBoxForeColor = Color.WhiteSmoke;
            ButtonForeColor = Color.WhiteSmoke;
            ButtonBackColor = Color.Blue;
        }

        public static void UpdateColorControls(Control myControl)
        {
            if (myControl is TextBox)
            {
                myControl.BackColor = TextBoxBackColor;
                myControl.ForeColor = TextBoxForeColor;
            }

            if (myControl is Label)
            {
                myControl.BackColor = Color.Transparent;
                myControl.ForeColor = LabelForeColor;
            }

            if (myControl is Button)
            {
                myControl.BackColor = ButtonBackColor;
                myControl.ForeColor = ButtonForeColor;  
            }

            foreach (Control subc in myControl.Controls)
            {
                UpdateColorControls(subc);
            }
        }
    }

    public enum ColorSchemeType
    {
        Tabcorp,
        MaxSys,
        Discord,
        OldSchool
    }
}
