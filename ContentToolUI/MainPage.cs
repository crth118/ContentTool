using ContentToolLibrary;
using ContentToolLibrary.Models;
using ImageMagick;

namespace ContentToolUI
{
    public partial class MainPage : Form
    {
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

        private int TFTimagecount { get; set; }
        private int U2imagecount { get; set; }
        private int U3imagecount { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }
        
        private void MainPage_Load(object sender, EventArgs e)
        {
            currentContentPath.Text = _importer.CurrentContentPath;
            newImagesPath.Text = _importer.NewImagesPath;
            CompletedBuildOutputPath = outputPathTextBox.Text;
        }
        
        private void createContentBuildButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            var filehandler = new FileHandler();
            var workspaceSbnexgen = $"{filehandler.WorkSpace}/sbnexgen2";

            // Copy current content to from contents ./workspace/sbnexgen2
            filehandler.CopyDirectory(currentContentPath.Text, workspaceSbnexgen, false);

            // Copy new images into new sbnexgen2
            filehandler.CopyDirectory(newImagesPath.Text, workspaceSbnexgen, false);

            // Compress images in the new build inside .\workspace
            var files = new DirectoryInfo(workspaceSbnexgen).GetFiles("*.jpg");
            foreach (var file in files)
            {
                ImageCompressor.CompressImage(file.FullName);
            }

            var images = _importer.GetAllImages();

            // Count images from current content and new images that will make up the new build
            int tftImageCount = -1;
            int u2ImageCount = -1;
            int u3ImageCount = -1;

            foreach (var image in images)
            {
                switch (image.ImageType)
                {
                    case ContentImageType.TFT:
                        tftImageCount++;
                        break;
                    case ContentImageType.U2:
                        u2ImageCount++;
                        break;
                    case ContentImageType.U3:
                        u3ImageCount++;
                        break;
                }
            }

            var tftPlaylist = CreatePlaylistModel(TFTimagecount, ContentImageType.TFT);
            var u2Playlist = CreatePlaylistModel(U2imagecount, ContentImageType.U2);
            var u3Playlist = CreatePlaylistModel(U3imagecount, ContentImageType.U3);
            
            var outputService = new OutputService(CompletedBuildOutputPath);
            outputService.GenerateXmlPlaylists(ContentImageType.TFT, tftPlaylist, workspaceSbnexgen);
            outputService.GenerateXmlPlaylists(ContentImageType.U2, u2Playlist, workspaceSbnexgen);
            outputService.GenerateXmlPlaylists(ContentImageType.U3, u3Playlist, workspaceSbnexgen);
            
            outputService.SaveCompletedBuildZip(workspaceSbnexgen);
            
            Cursor = Cursors.Default;
            MessageBox.Show($"Build complete.\nSaved to: {CompletedBuildOutputPath}");
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            TFTimagecount = -1;
            U2imagecount = -1;
            U3imagecount = -1;

            tftImageContainer.SuspendLayout();
            u2ImageContainer.SuspendLayout();
            u3ImageContainer.SuspendLayout();

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

            headersTFT.Visible = true;

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