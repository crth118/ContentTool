

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
        public static Color CreateBuildButtonBackColor { get; set; }
        public static Color CreateBuildButtonForeColor { get; set; }
        
        // Dark Color Scheme
        public static Color DarkBlack = Color.FromArgb(44, 47, 51);
        public static Color LightBlack = Color.FromArgb(44, 47, 51);
        public static Color MidGray = Color.FromArgb(153, 170, 181);
        public static Color PaleBlue = Color.FromArgb(114, 137, 218);
        public static Color BoneWhite = Color.FromArgb(249, 246, 238);
        
        // Light Color Scheme
        public static Color LightGray = Color.FromArgb(192, 192, 192);
        public static Color PaleYellow = Color.FromArgb(254, 250, 224);

        public static void ApplyColorScheme(Control.ControlCollection controls, ColorSchemeType colorScheme)
        {
            switch (colorScheme)
            {
                case ColorSchemeType.Dark:
                    SetDarkColorScheme();
                    break;
                case ColorSchemeType.Light:
                    SetLightColorScheme();
                    break;
            }
            
            foreach (Control c in controls)
            {
                UpdateColorControls(c);
            }
        }

        public static void SetLightColorScheme()
        {
            FormBackColor = LightGray;
            LabelForeColor = Color.Black;
            TextBoxBackColor = PaleYellow;
            TextBoxForeColor = Color.Black;
            ButtonForeColor = Color.Black;
            ButtonBackColor = LightGray;
            CreateBuildButtonForeColor = Color.WhiteSmoke;
            CreateBuildButtonBackColor = PaleBlue;
        }
        
        public static void SetDarkColorScheme()
        {
            FormBackColor = DarkBlack;
            LabelForeColor = BoneWhite;
            TextBoxBackColor = MidGray;
            TextBoxForeColor = LightBlack;
            ButtonForeColor = BoneWhite;
            ButtonBackColor = LightBlack;
            CreateBuildButtonForeColor = DarkBlack;
            CreateBuildButtonBackColor = PaleBlue;
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
        Light,
        Dark
    }
}
