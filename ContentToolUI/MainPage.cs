using ContentToolLibrary;
using ContentToolLibrary.Models;
using ImageMagick;
using Microsoft.Extensions.Configuration;

namespace ContentToolUI
{
    public partial class MainPage : Form
    {
        public IConfigurationRoot Config;
        private readonly ContentImporter _importer = new();
        private readonly string ImageInfoContainer = "imageInfoContainer";
        private readonly string ImageTypeControlName = "imageType";
        private readonly string ImageFileNameControlName = "imageName";
        private readonly string ImageDurationControlName = "imageDuration";
        private readonly string ImageStartDateControlName = "imageStartDate";
        private readonly string ImageStopDateControlName = "imageStopDate";
        private readonly string UseDatesCheckboxControlName = "useDatesCheckbox";
        private readonly string DeleteImageControlName = "deleteImage";
        private readonly string CopyDurationToAllControlName = "copyDuration";
        public string CompletedBuildOutputPath;
        public List<string> ErrorMessages { get; set; }= new();

        private int TFTimagecount { get; set; }
        private int U2imagecount { get; set; }
        private int U3imagecount { get; set; }

        public MainPage(IConfigurationRoot config)
        {
            Config = config;
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            currentContentPath.Text = Config["CurrentContent"];
            newImagesPath.Text = Config["NewImages"];
            CompletedBuildOutputPath = Config["OutputDirectory"];
            SetIcons();
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            headersTFT.Visible = true;

            TFTimagecount = -1;
            U2imagecount = -1;
            U3imagecount = -1;

            tftImageContainer.SuspendLayout();
            u2ImageContainer.SuspendLayout();
            u3ImageContainer.SuspendLayout();
            
            try
            {
                ValidateDirectories();
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
                return;
            }

            var images = _importer.GetAllImages();
            var tft = new List<ContentImage>();
            var u2 = new List<ContentImage>();
            var u3 = new List<ContentImage>();

            foreach (var image in images)
            {
                switch (image.ImageType)
                {
                    case ContentImageType.TFT:
                        tft.Add(image);
                        TFTimagecount++;
                        break;
                    case ContentImageType.U2:
                        u2.Add(image);
                        U2imagecount++;
                        break;
                    case ContentImageType.U3:
                        u3.Add(image);
                        U3imagecount++;
                        break;
                }
            }
            
            DrawImageListDisplay(tft, tftImageContainer);
            DrawImageListDisplay(u2, u2ImageContainer);
            DrawImageListDisplay(u3, u3ImageContainer);
            
            tftImageContainer.ResumeLayout();
            u2ImageContainer.ResumeLayout();
            u3ImageContainer.ResumeLayout();

            Cursor = Cursors.Default;

            loadImagesButton.Enabled = false;
            refreshButton.Enabled = true;
            createContentBuildButton.Enabled = true;
        }

        private void createContentBuildButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var filehandler = new FileHandler();
            
            filehandler.FormNewBuild(currentContentPath.Text, newImagesPath.Text);

            var tftPlaylist = CreatePlaylistModel(TFTimagecount, ContentImageType.TFT);
            var u2Playlist = CreatePlaylistModel(U2imagecount, ContentImageType.U2);
            var u3Playlist = CreatePlaylistModel(U3imagecount, ContentImageType.U3);

            var allPlaylists = new List<XMLPlaylistModel.Playlist>();
            allPlaylists.Add(tftPlaylist);
            allPlaylists.Add(u2Playlist);
            allPlaylists.Add(u3Playlist);

            var validate = new ValidationService();
            var help = validate.AreValidPlaylists(allPlaylists);
            if (!validate.AreValidPlaylists(allPlaylists))
            {
                ErrorMessages.AddRange(validate.ErrorMessages);

                var msg = $"Could not complete build. The following errors were found:\n";
                foreach (var message in ErrorMessages)
                {
                    msg += $"\n{message}";
                }

                MessageBox.Show(msg, "Oh no...", MessageBoxButtons.OK);
                return;
            }

            var contentBuider = new ContentBuilder(CompletedBuildOutputPath)
            {
                tftplaylist = tftPlaylist,
                u2playlist = u2Playlist,
                u3playlist = u3Playlist
            };
            contentBuider.GenerateNewContentBuild(filehandler.WorkSpaceSbnexgen);

            // TO DO: Move to back end
            if (Path.Exists(contentBuider.CompletedBuildFullPath))
            {
                var msg = $"{contentBuider.CompletedBuildFullPath} already exists. Do you want to override current zip?";
                var dialog = MessageBox.Show(msg, "Build already exists", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    File.Delete(contentBuider.CompletedBuildFullPath);
                    contentBuider.SaveCompletedBuildZip(filehandler.WorkSpaceSbnexgen);
                    Cursor = Cursors.Default;
                    MessageBox.Show($"Build complete.\nSaved to: {contentBuider.CompletedBuildFullPath}");
                }
                else if (dialog == DialogResult.No)
                {
                    MessageBox.Show("Build aborted.");
                    filehandler.CleanupWorkspace();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                contentBuider.SaveCompletedBuildZip(filehandler.WorkSpaceSbnexgen);
                Cursor = Cursors.Default;
                MessageBox.Show($"Build complete.\nSaved to: {contentBuider.CompletedBuildFullPath}");
            }
        }

        private XMLPlaylistModel.Playlist CreatePlaylistModel(int imageCount, ContentImageType imageType)
        {
            var content = new List<XMLPlaylistModel.Playlist.PlaylistContent>();

            for (int i = 0; i <= imageCount; i++)
            {
                var deleteImage = Controls.Find($"{imageType}{DeleteImageControlName}{i}", true).First() as CheckBox;
                var imageTypeTextBox = Controls.Find($"{imageType}{ImageTypeControlName}{i}", true).First().Text;

                if (deleteImage.Checked || imageTypeTextBox != imageType.ToString())
                {
                    continue;
                }

                var imgName = Controls.Find($"{imageType}{ImageFileNameControlName}{i}", true).First().Text;
                var duration = Controls.Find($"{imageType}{ImageDurationControlName}{i}", true).First().Text;
                var height = _importer.Resolutions[$"{imageType} Height"];
                var width = _importer.Resolutions[$"{imageType} Width"];

                var xmlEntry = new XMLPlaylistModel.Playlist.PlaylistContent()
                {
                    Path = imgName,
                    Duration = duration,
                    Height = height,
                    Width = width,
                };

                var useDates = Controls.Find($"{imageType}{UseDatesCheckboxControlName}{i}", true).First() as CheckBox;
                if (useDates.Checked)
                {
                    xmlEntry.StartDate = Controls.Find($"{imageType}{ImageStartDateControlName}{i}", true).First().Text;
                    xmlEntry.StopDate = Controls.Find($"{imageType}{ImageStopDateControlName}{i}", true).First().Text;
                }

                content.Add(xmlEntry);
            }

            var playlist = new XMLPlaylistModel.Playlist();
            playlist.Content = content;

            return playlist;
        }
    }
}