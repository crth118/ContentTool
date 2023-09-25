using System.Windows.Forms.VisualStyles;

namespace ContentToolUI
{
    public partial class MainPage : Form
    {
        private void refreshButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            MainPage_Load(sender, e);
        }
        
        private void changeCurrentContentDir_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    currentContentPath.Text = dialog.SelectedPath;
                }
            }
        }
        
        private void changeNewImagesDirButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    newImagesPath.Text = dialog.SelectedPath;
                }
            }
        }
        
        private void changeOutputDirButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    outputPathTextBox.Text = dialog.SelectedPath;
                }
            }
        }
        
        private void currentContentPath_TextChange(object sender, EventArgs e)
        {
            _importer.CurrentContentPath = currentContentPath.Text;
            SetDirectoryPathTextBoxColor(currentContentPath);
            SetLoadImagesButton();
        }

        private void newImagesPath_TextChange(object sender, EventArgs e)
        {
            _importer.NewImagesPath = newImagesPath.Text;
            SetDirectoryPathTextBoxColor(newImagesPath);
            SetLoadImagesButton();
        }

        private void outputPathTextBox_TextChange(object sender, EventArgs e)
        {
            CompletedBuildOutputPath = outputPathTextBox.Text;
            SetDirectoryPathTextBoxColor(outputPathTextBox);
            SetLoadImagesButton();
        }

        private void toolTipHelper_Hover(Control box, string message)
        {
            toolTip1.SetToolTip(box, message);
        }
        
        private void datesTextBox_Hover(object sender, EventArgs e, TextBox box)
        {
            if (box.BackColor == Color.IndianRed)
            {
                toolTip1.SetToolTip(box, "Warning: Invalid date. Must be yyyy-MM-dd");
            }
            else
            {
                toolTip1.SetToolTip(box, $"Valid format: yyyy-MM-dd");
            }
        }
        
        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            var options = new OptionsPage(Config);
            options.Show();
        }
    }
}