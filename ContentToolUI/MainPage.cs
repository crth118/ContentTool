using ContentToolLibrary;
using ContentToolLibrary.Models;

namespace ContentToolUI
{
    public partial class MainPage : Form
    {
        private readonly ContentImporter _importer;
        public MainPage()
        {
            _importer = new ContentImporter();

            InitializeComponent();
            //// Color Scheme
            // Header Container
            //
            currentContentLabel.ForeColor = ColorScheme.Text;
            currentContentPath.ForeColor = ColorScheme.Text;
            newImagesLabel.ForeColor = ColorScheme.Text;
            newImagesPath.ForeColor = ColorScheme.Text;
            //
            ////
            // Containers
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            currentContentPath.Text = _importer.CurrentContentPath;
            newImagesPath.Text = _importer.NewImagesPath;
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            tftImageContainer.SuspendLayout();
            u2ImageContainer.SuspendLayout();
            u3ImageContainer.SuspendLayout();

            var images = _importer.GetAllImages();

            int index = 0;
            foreach (var image in images)
            {
                switch (image.ImageType)
                {
                    case ContentImageType.TFT:
                        CreateImageInfoLine(index, image, tftImageContainer);
                        break;
                    case ContentImageType.U2:
                        CreateImageInfoLine(index, image, u2ImageContainer);
                        break;
                    case ContentImageType.U3:
                        CreateImageInfoLine(index, image, u3ImageContainer);
                        break;
                }

                index++;
            }

            tftImageContainer.ResumeLayout();
            u2ImageContainer.ResumeLayout();
            u3ImageContainer.ResumeLayout();
            Cursor = Cursors.Default;

            loadImagesButton.Enabled = false;
            refreshButton.Enabled = true;
            createContentBuildButton.Enabled = true;
        }

        private void CreateImageInfoLine(int index, ContentImage image, FlowLayoutPanel imageTypeContainer)
        {
            var lineContainer = new FlowLayoutPanel()
            {
                Name = "imageLineContainer" + index,
                AutoSize = false,
                Size = new Size(1136, 36),
                Visible = true,
            };

            lineContainer.Controls.Add(CreateImageInfoImageTypeBox(index, image));
            lineContainer.Controls.Add(CreateImageInfoImageNameTextBox(index, image));
            lineContainer.Controls.Add(CreateImageInfoImageDurationTextBox(index, image));
            lineContainer.Controls.Add(CreateImageInfoTurnOnDatesToggleButon(index));
            lineContainer.Controls.Add(CreateImageInfoImageStartDateTextBox(index));
            lineContainer.Controls.Add(CreateImageInfoImageStopDateTextBox(index));
            lineContainer.Controls.Add(CreateImageInfoDoNotUseToggleButton(index));

            imageTypeContainer.Controls.Add(lineContainer);
        }

        private TextBox CreateImageInfoImageTypeBox(int index, ContentImage image)
        {
            return new TextBox()
            {
                Name = "imageTypeTb" + index,
                Text = image.ImageType.ToString(),
                ReadOnly = true,
                Size = new Size(50, 23)
            };
        }

        private TextBox CreateImageInfoImageNameTextBox(int index, ContentImage image)
        {
            return new TextBox()
            {
                Name = "imageNameTb" + index,
                Text = image.Name,
                ReadOnly = true,
                Size = new Size(300, 23)
            };
        }

        private TextBox CreateImageInfoImageDurationTextBox(int index, ContentImage image)
        {
            return new TextBox()
            {
                Name = "imageDurationTb" + index,
                Text = image.Duration,
                ReadOnly = false,
                Size = new Size(50, 23)
            };
        }

        private TextBox CreateImageInfoImageStartDateTextBox(int index)
        {
            var box = new TextBox()
            {
                Name = "imageStartDateTb" + index,
                ReadOnly = true,
                BackColor = Color.DarkGray
            };

            box.TextChanged += (sender, e) =>
            {
                var validate = new ValidationService();

                if (!validate.IsValidDate(box.Text))
                {
                    box.BackColor = Color.Red;
                }
                else
                {
                    box.BackColor = Color.LightGreen;
                }
            };

            box.MouseHover += (sender, e) =>
            {
                datesTextBox_Hover(sender, e, box);
            };

            return box;
        }

        private void datesTextBox_Hover(object sender, EventArgs e, TextBox box)
        {
            if (box.BackColor == Color.Red)
            {
                toolTip1.SetToolTip(box, "Warning: Invalid date");
            }
            else
            {
                toolTip1.SetToolTip(box, "Set start date for this content image");
            }
        }

        private TextBox CreateImageInfoImageStopDateTextBox(int index)
        {
            var box = new TextBox()
            {
                Name = "imageStopDateTb" + index,
                ReadOnly = true,
                BackColor = Color.DarkGray
            };

            box.TextChanged += (sender, e) =>
            {
                var validate = new ValidationService();

                if (!validate.IsValidDate(box.Text))
                {
                    box.BackColor = Color.Red;
                }
                else
                {
                    box.BackColor = Color.LightGreen;
                }
            };

            box.MouseHover += (sender, e) =>
            {
                datesTextBox_Hover(sender, e, box);
            };

            return box;
        }

        private CheckBox CreateImageInfoTurnOnDatesToggleButon(int index)
        {
            var checkbox = new CheckBox()
            {
                Name = "imageTurnDatesOnCb" + index,
                Text = "Use Dates:",
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = true,
                CheckAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(20, 4, 0, 0)
            };

            checkbox.Click += (sender, e) =>
            {
                var startDateName = "imageStartDateTb" + index;
                var stopDateName = "imageStopDateTb" + index;

                TextBox startDate = Controls.Find(startDateName, true).FirstOrDefault() as TextBox;
                TextBox stopDate = Controls.Find(stopDateName, true).FirstOrDefault() as TextBox;

                if (checkbox.Checked)
                {
                    startDate.BackColor = Color.White;
                    startDate.ReadOnly = false;

                    stopDate.BackColor = Color.White;
                    stopDate.ReadOnly = false;
                }
                else
                {
                    startDate.BackColor = Color.DarkGray;
                    startDate.ReadOnly = true;

                    stopDate.BackColor = Color.DarkGray;
                    stopDate.ReadOnly = true;
                }
            };

            return checkbox;
        }

        private CheckBox CreateImageInfoDoNotUseToggleButton(int index)
        {
            return new CheckBox()
            {
                Name = "doNotUseImageTb" + index,
                Text = "Delete image:",
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = true,
                CheckAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(40, 4, 0, 0)
            };
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            MainPage_Load(sender, e);
        }

        private void createContentBuildButton_Click(object sender, EventArgs e)
        {
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

            var tftPlaylist = CreatePlaylistModel(tftImageCount, ContentImageType.TFT);
            var u2Playlist = CreatePlaylistModel(u2ImageCount, ContentImageType.U2);
            var u3Playlist = CreatePlaylistModel(u3ImageCount, ContentImageType.U3);
            
            GenerateImageTypePlaylists(ContentImageType.TFT, workspaceSbnexgen, tftPlaylist);
            GenerateImageTypePlaylists(ContentImageType.U2, workspaceSbnexgen, u2Playlist);
            GenerateImageTypePlaylists(ContentImageType.U3, workspaceSbnexgen, u3Playlist);
        }

        /// <summary>
        /// Creates the two playlist types (busyAttract and idleAttract) for the specified image type.
        /// </summary>
        private void GenerateImageTypePlaylists(ContentImageType imageType, string destination, XMLPlaylistModel.Playlist playlist)
        {
            var xml = new XmlSerializationService();
            var busyAttract = $"{destination}/playList_{imageType}_busyAttract.xml";
            var idleAttract = $"{destination}/playList_{imageType}_idleAttract.xml";
            
            xml.WriteToXmlFile(busyAttract, playlist, false);
            xml.WriteToXmlFile(idleAttract, playlist, false);
        }

        private XMLPlaylistModel.Playlist CreatePlaylistModel(int imageCount, ContentImageType imageType)
        {
            var content = new List<XMLPlaylistModel.Playlist.PlaylistContent>();

            for (int i = 0; i <= imageCount; i++)
            {
                var deleteImage = Controls.Find($"doNotUseImageTb{i}", true).First() as CheckBox;
                var imageTypeTextBox = Controls.Find($"imageTypeTb{i}", true).First().Text;
                
                if (deleteImage.Checked || imageTypeTextBox != imageType.ToString())
                {
                    continue;
                }
                
                var imgName = Controls.Find($"imageNameTb{i}", true).First().Text;
                var duration = Controls.Find($"imageDurationTb{i}", true).First().Text;
                var height = _importer.Resolutions[$"{imageType} Height"];
                var width = _importer.Resolutions[$"{imageType} Width"];

                var xmlEntry = new XMLPlaylistModel.Playlist.PlaylistContent()
                {
                    Path = imgName,
                    Duration = duration,
                    Height = height,
                    Width = width,
                };
                
                var useDates = Controls.Find($"imageTurnDatesOnCb{i}", true).First() as CheckBox;
                if (useDates.Checked)
                {
                    xmlEntry.StartDate = Controls.Find($"imageStartDateTb{i}", true).First().Text;
                    xmlEntry.StopDate = Controls.Find($"imageStopDateTb{i}", true).First().Text;
                }
                
                content.Add(xmlEntry);
            }

            var playlist = new XMLPlaylistModel.Playlist();
            playlist.Content = content;

            return playlist;
        }
    }
}