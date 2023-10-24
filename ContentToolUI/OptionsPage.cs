using Microsoft.Extensions.Configuration;
using ContentToolLibrary;
using ContentToolLibrary.Models;

namespace ContentToolUI
{
    public partial class OptionsPage : Form
    {
        public IConfigurationRoot Config;
        public string OutputPath;
        public string CurrentContentPath;
        public string NewImagesPath;

        public OptionsPage(IConfigurationRoot config)
        {
            InitializeComponent();
            Config = config;
            OutputPath = Config["OutputDirectory"];
            CurrentContentPath = Config["CurrentContent"];
            NewImagesPath = Config["NewImages"];
            SetIcons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            defaultCurrentContentTextBox.Text = CurrentContentPath;
            defaultNewImagesTextBox.Text = NewImagesPath;
            defaultOutputTextBox.Text = OutputPath;
        }

        private void changeCurrentContentDirButton_Click(object sender, EventArgs e)
        {
            ChangeDirectory(defaultCurrentContentTextBox);
            CurrentContentPath = defaultCurrentContentTextBox.Text;
        }

        private void changeNewImagesFolderButton_Click(object sender, EventArgs e)
        {
            ChangeDirectory(defaultNewImagesTextBox);
            NewImagesPath = defaultNewImagesTextBox.Text;
        }

        private void changeOutputFolderButton_Click(object sender, EventArgs e)
        {
            ChangeDirectory(defaultOutputTextBox);
            OutputPath = defaultOutputTextBox.Text;
        }

        private void ChangeDirectory(TextBox textbox)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    textbox.Text = dialog.SelectedPath;
                }
            }
        }

        private void saveOptionsButton_Click(object sender, EventArgs e)
        {
            var settings = new SettingsModel()
            {
                CurrentContent = CurrentContentPath,
                NewImages = NewImagesPath,
                OutputDirectory = OutputPath
            };

            try
            {
                var settingsFile = $"{AppDomain.CurrentDomain.BaseDirectory}\\settings.json";
                JsonSerializationService.WriteToJsonFile(settingsFile, settings, false);

                MessageBox.Show("User settings saved. Restart application for changes to take effect.", "Informational Message", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unhandled exception: {ex.Message}", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetIcons()
        {
            changeCurrentContentDirButton.Image = Image.FromFile(".\\icons\\folder-search.png")
                .GetThumbnailImage(15, 15, null, IntPtr.Zero);
            changeCurrentContentDirButton.ImageAlign = ContentAlignment.MiddleCenter;


            changeNewImagesFolderButton.Image = Image.FromFile(".\\icons\\folder-search.png")
                .GetThumbnailImage(15, 15, null, IntPtr.Zero);
            changeNewImagesFolderButton.ImageAlign = ContentAlignment.MiddleCenter;


            changeOutputFolderButton.Image = Image.FromFile(".\\icons\\folder-search.png")
                .GetThumbnailImage(15, 15, null, IntPtr.Zero);
            changeOutputFolderButton.ImageAlign = ContentAlignment.MiddleCenter;
        }
    }
}
