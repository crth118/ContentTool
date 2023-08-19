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
            // Color Scheme
            // Header Container
            //
            currentContentLabel.ForeColor = ColorScheme.Text;
            currentContentPath.ForeColor = ColorScheme.Text;
            newImagesLabel.ForeColor = ColorScheme.Text;
            newImagesPath.ForeColor = ColorScheme.Text;
            //
            ////
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            currentContentPath.Text = Importer.CurrentContentPath;
            newImagesPath.Text = Importer.NewImagesPath;
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            var images = Importer.GetAllImages();

            int index = 0;
            foreach (var image in images)
            {
                CreateImageInfoLine(index, image);
                index++;
            }
        }

        private void CreateImageInfoLine(int index, ContentImage image)
        {
            var container = new FlowLayoutPanel()
            {
                Name = "imageLineContainer" + index,
                AutoSize = false,
                Size = new Size(1136, 36),
                Visible = true,
            };

            container.Controls.Add(CreateImageInfoImageTypeBox(index, image));
            container.Controls.Add(CreateImageInfoImageNameTextBox(index, image));
            container.Controls.Add(CreateImageInfoImageDurationTextBox(index, image));
            container.Controls.Add(CreateImageInfoTurnOnDatesToggleButon(index));
            container.Controls.Add(CreateImageInfoImageStartDateTextBox(index));
            container.Controls.Add(CreateImageInfoImageStopDateTextBox(index));
            container.Controls.Add(CreateImageInfoDoNotUseToggleButton(index));

            tftImageContainer.Controls.Add(container);
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
            return new TextBox()
            {
                Name = "imageStartDateTb" + index,
                ReadOnly = true,
                BackColor = Color.DarkGray
            };
        }

        private TextBox CreateImageInfoImageStopDateTextBox(int index)
        {
            return new TextBox()
            {
                Name = "imageStopDateTb" + index,
                ReadOnly = true,
                BackColor = Color.DarkGray
            };
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
                    startDate.Text = null;

                    stopDate.BackColor = Color.DarkGray;
                    stopDate.ReadOnly = true;
                    stopDate.Text = null;
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
    }
}