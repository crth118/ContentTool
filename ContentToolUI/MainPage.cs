using ContentToolLibrary;
using ContentToolLibrary.Models;
using ImageMagick;

namespace ContentToolUI
{
    public partial class MainPage : Form
    {
        private readonly ContentImporter _importer = new ContentImporter();
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
            CompletedBuildOutputPath = outputPathTextBox.Text;
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

        private void DrawImageListDisplay(List<ContentImage> images, FlowLayoutPanel imageTypeContainer)
        {
            int index = 0;
            foreach (var image in images)
            {
                CreateImageInfoLine(index, image, imageTypeContainer);
                index++;
            }
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

            lineContainer.Controls.Add(CreateImageInfoImageTypeBox(index, image, image.ImageType));
            lineContainer.Controls.Add(CreateImageInfoImageNameTextBox(index, image, image.ImageType));
            lineContainer.Controls.Add(CreateImageInfoImageDurationTextBox(index, image, image.ImageType));
            lineContainer.Controls.Add(CreateCopyDurationToAllButton(index, image.ImageType));
            lineContainer.Controls.Add(CreateImageInfoTurnOnDatesToggleButon(index, image.ImageType));
            lineContainer.Controls.Add(CreateImageInfoImageStartDateTextBox(index, image.ImageType));
            lineContainer.Controls.Add(CreateImageInfoImageStopDateTextBox(index, image.ImageType));
            lineContainer.Controls.Add(CreateImageInfoDoNotUseToggleButton(index, image.ImageType));

            imageTypeContainer.Controls.Add(lineContainer);
        }

        private TextBox CreateImageInfoImageTypeBox(int index, ContentImage image, ContentImageType imageType)
        {
            return new TextBox()
            {
                Name = imageType + ImageTypeControlName + index,
                Text = image.ImageType.ToString(),
                ReadOnly = true,
                Size = new Size(50, 23)
            };
        }

        private TextBox CreateImageInfoImageNameTextBox(int index, ContentImage image, ContentImageType imageType)
        {
            return new TextBox()
            {
                Name = imageType + ImageFileNameControlName + index,
                Text = image.Name,
                ReadOnly = true,
                Size = new Size(330, 23)
            };
        }

        private TextBox CreateImageInfoImageDurationTextBox(int index, ContentImage image, ContentImageType imageType)
        {
            var box = new TextBox()
            {
                Name = imageType + ImageDurationControlName + index,
                Text = image.Duration,
                ReadOnly = false,
                Size = new Size(50, 23)
            };

            var validate = new ValidationService();

            if (validate.IsValidSlideDuration(box.Text))
            {
                box.BackColor = Color.LightGreen;
            }
            else
            {
                box.BackColor = Color.IndianRed;
            }

            box.TextChanged += (sender, e) =>
            {
                if (!validate.IsValidSlideDuration(box.Text))
                {
                    box.BackColor = Color.IndianRed;
                }
                else
                {
                    box.BackColor = Color.LightGreen;
                }
            };

            return box;
        }

        private TextBox CreateImageInfoImageStartDateTextBox(int index, ContentImageType imageType)
        {
            var box = new TextBox()
            {
                Name = imageType + ImageStartDateControlName + index,
                ReadOnly = true,
                BackColor = Color.DarkGray
            };

            box.TextChanged += (sender, e) =>
            {
                var validate = new ValidationService();

                if (!validate.IsValidDate(box.Text))
                {
                    box.BackColor = Color.IndianRed;
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
            if (box.BackColor == Color.IndianRed)
            {
                toolTip1.SetToolTip(box, "Warning: Invalid date");
            }
            else
            {
                toolTip1.SetToolTip(box, "Set start date for this content image");
            }
        }

        private TextBox CreateImageInfoImageStopDateTextBox(int index, ContentImageType imageType)
        {
            var box = new TextBox()
            {
                Name = imageType + ImageStopDateControlName + index,
                ReadOnly = true,
                BackColor = Color.DarkGray
            };

            box.TextChanged += (sender, e) =>
            {
                var validate = new ValidationService();

                if (!validate.IsValidDate(box.Text))
                {
                    box.BackColor = Color.IndianRed;
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

        private CheckBox CreateImageInfoTurnOnDatesToggleButon(int index, ContentImageType imageType)
        {
            var checkbox = new CheckBox()
            {
                Name = imageType + UseDatesCheckboxControlName + index,
                Text = "Use Dates:",
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = true,
                CheckAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(20, 4, 0, 0)
            };

            checkbox.Click += (sender, e) =>
            {
                var startDateName = imageType + ImageStartDateControlName + index;
                var stopDateName = imageType + ImageStopDateControlName + index;

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

        private CheckBox CreateImageInfoDoNotUseToggleButton(int index, ContentImageType imageType)
        {
            return new CheckBox()
            {
                Name = imageType + DeleteImageControlName + index,
                Text = "Delete image:",
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = true,
                CheckAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(40, 4, 0, 0)
            };
        }

        private Button CreateCopyDurationToAllButton(int index, ContentImageType imageType)
        {
            var button = new Button()
            {
                Image = Image.FromFile(".\\icons\\icons8-copy-100.png").GetThumbnailImage(10, 10, null, IntPtr.Zero),
                ImageAlign = ContentAlignment.MiddleCenter,
                Size = new Size(17, 17),
                Margin = new Padding(0, 5, 0, 0),
                FlatStyle = FlatStyle.Flat
            };

            button.FlatAppearance.BorderColor = Color.Gray;

            button.Click += (sender, e) =>
            {
                switch (imageType)
                {
                    case ContentImageType.TFT:
                        SetDurationsForAll(TFTimagecount, index, ContentImageType.TFT);
                        break;
                    case ContentImageType.U2:
                        SetDurationsForAll(U2imagecount, index, ContentImageType.U2);
                        break;
                    case ContentImageType.U3:
                        SetDurationsForAll(U3imagecount, index, ContentImageType.U3);
                        break;
                }
            };

            return button;
        }

        private void SetDurationsForAll(int imageCount, int index, ContentImageType imageType)
        {
            var newDuration = Controls.Find($"{imageType}{ImageDurationControlName}{index}", true).First().Text;
            for (int i = 0; i <= imageCount; i++)
            {
                var duration = Controls.Find($"{imageType}{ImageDurationControlName}{i}", true).First();
                duration.Text = newDuration;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            MainPage_Load(sender, e);
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

            var tftPlaylist = CreatePlaylistModel(tftImageCount, ContentImageType.TFT);
            var u2Playlist = CreatePlaylistModel(u2ImageCount, ContentImageType.U2);
            var u3Playlist = CreatePlaylistModel(u3ImageCount, ContentImageType.U3);

            GenerateImageTypePlaylists(ContentImageType.TFT, workspaceSbnexgen, tftPlaylist);
            GenerateImageTypePlaylists(ContentImageType.U2, workspaceSbnexgen, u2Playlist);
            GenerateImageTypePlaylists(ContentImageType.U3, workspaceSbnexgen, u3Playlist);

            // TO DO: Move this part to the back end from here.
            filehandler.SplitBuildIntoArtAndSnd(workspaceSbnexgen);
            filehandler.ZipNewBuild(CompletedBuildOutputPath);

            Cursor = Cursors.Default;
            MessageBox.Show($"Build complete.\nSaved to: {CompletedBuildOutputPath}");
        }

        /// <summary>
        /// Creates the two playlist types (busyAttract and idleAttract) for the specified image type.
        /// </summary>
        /// 
        // TO DO: Move this to the backend
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
        }

        private void newImagesPath_TextChange(object sender, EventArgs e)
        {
            _importer.NewImagesPath = newImagesPath.Text;
        }

        private void outputPathTextBox_TextChange(object sender, EventArgs e)
        {
            CompletedBuildOutputPath = outputPathTextBox.Text;
        }

    }
}