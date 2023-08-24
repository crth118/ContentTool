using ContentToolLibrary;

namespace ContentToolUI
{
    public partial class MainPage : Form
    {
        // A line in the UI that represents a line in the playlist XMl container information for the respective image
        private void CreateImageInfoContainer(int index, ContentImage image, FlowLayoutPanel imageTypeContainer)
        {
            var lineContainer = new FlowLayoutPanel()
            {
                Name = ImageInfoContainer + index,
                AutoSize = false,
                Size = new Size(1136, 36),
                Visible = true,
            };

            lineContainer.Controls.Add(CreateImageTypeTextBox(index, image, image.ImageType));
            lineContainer.Controls.Add(CreateImageNameTextBox(index, image, image.ImageType));
            lineContainer.Controls.Add(CreateImageDurationTextBox(index, image, image.ImageType));
            lineContainer.Controls.Add(CreateCopyDurationButton(index, image.ImageType));
            lineContainer.Controls.Add(CreateImageUseDatesCheckBox(index, image.ImageType));
            lineContainer.Controls.Add(CreateImageDateTextBox(index, image.ImageType, ImageStartDateControlName));
            lineContainer.Controls.Add(CreateImageDateTextBox(index, image.ImageType, ImageStopDateControlName));
            lineContainer.Controls.Add(CreateDeleteImageCheckBox(index, image.ImageType));

            imageTypeContainer.Controls.Add(lineContainer);
        }
        
        private TextBox CreateImageTypeTextBox(int index, ContentImage image, ContentImageType imageType)
        {
            var box = new TextBox()
            {
                Name = imageType + ImageTypeControlName + index,
                Text = image.ImageType.ToString(),
                ReadOnly = true,
                Size = new Size(50, 23)
            };
            
            box.MouseHover += (sender, e) =>
            {
                var msg = "Type of EGM screen the image will display on";
                toolTipHelper_Hover(box, msg);
            };

            return box;
        }
        
        private TextBox CreateImageNameTextBox(int index, ContentImage image, ContentImageType imageType)
        {
            var box = new TextBox()
            {
                Name = imageType + ImageFileNameControlName + index,
                Text = image.Name,
                ReadOnly = true,
                Size = new Size(330, 23)
            };
            
            box.MouseHover += (sender, e) =>
            {
                var msg = "Image file name";
                toolTipHelper_Hover(box, msg);
            };

            return box;
        }
        
        private TextBox CreateImageDurationTextBox(int index, ContentImage image, ContentImageType imageType)
        {
            var box = new TextBox()
            {
                Name = imageType + ImageDurationControlName + index,
                Text = image.Duration,
                ReadOnly = false,
                Size = new Size(50, 23)
            };

            var validate = new ValidationService();
            box.BackColor = validate.IsValidSlideDuration(box.Text) switch
            {
                true => Color.LightGreen,
                false => Color.IndianRed
            };
            
            box.TextChanged += (sender, e) =>
            {
                box.BackColor = validate.IsValidSlideDuration(box.Text) switch
                {
                    true => Color.LightGreen,
                    false => Color.IndianRed
                };
            };
            
            box.MouseHover += (sender, e) =>
            {
                var msg = "The time image will stay on screen (mm.ss)";
                toolTipHelper_Hover(box, msg);
            };

            return box;
        }

        private TextBox CreateImageDateTextBox(int index, ContentImageType imageType, string controlName)
        {
            var box = new TextBox()
            {
                Name = imageType + controlName + index,
                ReadOnly = true,
                BackColor = Color.DarkGray
            };

            box.TextChanged += (sender, e) =>
            {
                var validate = new ValidationService();
                box.BackColor = validate.IsValidDate(box.Text) switch
                {
                    true => Color.LightGreen,
                    false => Color.IndianRed,
                };
            };

            box.MouseHover += (sender, e) =>
            {
                datesTextBox_Hover(sender, e, box);
            };

            return box;
        }
        
        private CheckBox CreateImageUseDatesCheckBox(int index, ContentImageType imageType)
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

                var startDate = Controls.Find(startDateName, true).FirstOrDefault() as TextBox;
                var stopDate = Controls.Find(stopDateName, true).FirstOrDefault() as TextBox;

                switch (checkbox.Checked)
                {
                    case true:
                        startDate.BackColor = Color.White;
                        startDate.ReadOnly = false;
                        stopDate.BackColor = Color.White;
                        stopDate.ReadOnly = false;
                        break;
                    case false:
                        startDate.BackColor = Color.DarkGray;
                        startDate.ReadOnly = true;
                        stopDate.BackColor = Color.DarkGray;
                        stopDate.ReadOnly = true;
                        break;
                }
            };
            
            checkbox.MouseHover += (sender, e) =>
            {
                var msg = "Enable/Disable start and stop dates for this image";
                toolTipHelper_Hover(checkbox, msg);
            };
            

            return checkbox;
        }
        
        private CheckBox CreateDeleteImageCheckBox(int index, ContentImageType imageType)
        {
            var checkbox = new CheckBox()
            {
                Name = imageType + DeleteImageControlName + index,
                Text = "Delete image:",
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = true,
                CheckAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(40, 4, 0, 0)
            };
            
            checkbox.MouseHover += (sender, e) =>
            {
                var msg = "Delete image from playlist";
                toolTipHelper_Hover(checkbox, msg);
            };
            
            return checkbox;
        }
        
        private Button CreateCopyDurationButton(int index, ContentImageType imageType)
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
    }
}

