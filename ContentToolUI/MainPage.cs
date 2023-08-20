using ContentToolLibrary;
using System.Security.Cryptography.X509Certificates;

namespace ContentToolUI
{
    public partial class MainPage : Form
    {
        public ContentImporter Importer;
        public MainPage()
        {
            Importer = new ContentImporter();

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
            currentContentPath.Text = Importer.CurrentContentPath;
            newImagesPath.Text = Importer.NewImagesPath;
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            tftImageContainer.SuspendLayout();
            u2ImageContainer.SuspendLayout();
            u3ImageContainer.SuspendLayout();

            var images = Importer.GetAllImages();

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
                Name = "imageTurnDatesOnTb" + index,
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
           
        }
    }
}