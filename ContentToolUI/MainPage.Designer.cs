namespace ContentToolUI
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainContainer = new FlowLayoutPanel();
            headerContainer = new FlowLayoutPanel();
            currentContentLabel = new Label();
            currentContentPath = new TextBox();
            changeCurrentContentDirButton = new Button();
            newImagesLabel = new Label();
            newImagesPath = new TextBox();
            changeNewImagesDirButton = new Button();
            outputPathLabel = new Label();
            loadImagesButton = new Button();
            refreshButton = new Button();
            createContentBuildButton = new Button();
            outputPathTextBox = new TextBox();
            changeOutputDirButton = new Button();
            tftImageContainer = new FlowLayoutPanel();
            tftLabel = new Label();
            headersTFT = new FlowLayoutPanel();
            Type = new Label();
            imageNameHeader = new Label();
            durationHeader = new Label();
            label1 = new Label();
            label2 = new Label();
            u2ImageContainer = new FlowLayoutPanel();
            u2Label = new Label();
            u3ImageContainer = new FlowLayoutPanel();
            u3label = new Label();
            toolTip1 = new ToolTip(components);
            menuStrip1 = new MenuStrip();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            optionsMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            mainContainer.SuspendLayout();
            headerContainer.SuspendLayout();
            tftImageContainer.SuspendLayout();
            headersTFT.SuspendLayout();
            u2ImageContainer.SuspendLayout();
            u3ImageContainer.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mainContainer
            // 
            mainContainer.AutoSize = true;
            mainContainer.Controls.Add(headerContainer);
            mainContainer.Controls.Add(tftImageContainer);
            mainContainer.Controls.Add(u2ImageContainer);
            mainContainer.Controls.Add(u3ImageContainer);
            mainContainer.Location = new Point(6, 27);
            mainContainer.MaximumSize = new Size(1156, 0);
            mainContainer.MinimumSize = new Size(1156, 900);
            mainContainer.Name = "mainContainer";
            mainContainer.Size = new Size(1156, 900);
            mainContainer.TabIndex = 0;
            // 
            // headerContainer
            // 
            headerContainer.BorderStyle = BorderStyle.FixedSingle;
            headerContainer.Controls.Add(currentContentLabel);
            headerContainer.Controls.Add(currentContentPath);
            headerContainer.Controls.Add(changeCurrentContentDirButton);
            headerContainer.Controls.Add(newImagesLabel);
            headerContainer.Controls.Add(newImagesPath);
            headerContainer.Controls.Add(changeNewImagesDirButton);
            headerContainer.Controls.Add(outputPathLabel);
            headerContainer.Controls.Add(loadImagesButton);
            headerContainer.Controls.Add(refreshButton);
            headerContainer.Controls.Add(createContentBuildButton);
            headerContainer.Controls.Add(outputPathTextBox);
            headerContainer.Controls.Add(changeOutputDirButton);
            headerContainer.Location = new Point(3, 3);
            headerContainer.Name = "headerContainer";
            headerContainer.Size = new Size(1139, 114);
            headerContainer.TabIndex = 1;
            // 
            // currentContentLabel
            // 
            currentContentLabel.AutoSize = true;
            currentContentLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentContentLabel.Location = new Point(3, 3);
            currentContentLabel.Margin = new Padding(3, 3, 3, 0);
            currentContentLabel.Name = "currentContentLabel";
            currentContentLabel.Size = new Size(122, 21);
            currentContentLabel.TabIndex = 0;
            currentContentLabel.Text = "Current Content";
            // 
            // currentContentPath
            // 
            currentContentPath.AutoCompleteMode = AutoCompleteMode.Suggest;
            currentContentPath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            currentContentPath.Location = new Point(131, 3);
            currentContentPath.Name = "currentContentPath";
            currentContentPath.Size = new Size(842, 23);
            currentContentPath.TabIndex = 1;
            currentContentPath.TextChanged += currentContentPath_TextChange;
            // 
            // changeCurrentContentDirButton
            // 
            changeCurrentContentDirButton.Cursor = Cursors.Hand;
            changeCurrentContentDirButton.FlatAppearance.BorderColor = Color.Black;
            changeCurrentContentDirButton.Location = new Point(979, 3);
            changeCurrentContentDirButton.Margin = new Padding(3, 3, 15, 3);
            changeCurrentContentDirButton.Name = "changeCurrentContentDirButton";
            changeCurrentContentDirButton.Size = new Size(27, 23);
            changeCurrentContentDirButton.TabIndex = 7;
            changeCurrentContentDirButton.Text = "...";
            changeCurrentContentDirButton.UseVisualStyleBackColor = true;
            changeCurrentContentDirButton.Click += changeCurrentContentDir_Click;
            // 
            // newImagesLabel
            // 
            newImagesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newImagesLabel.Location = new Point(3, 41);
            newImagesLabel.Margin = new Padding(3, 12, 3, 0);
            newImagesLabel.Name = "newImagesLabel";
            newImagesLabel.Size = new Size(122, 21);
            newImagesLabel.TabIndex = 2;
            newImagesLabel.Text = "New Images";
            // 
            // newImagesPath
            // 
            newImagesPath.AutoCompleteMode = AutoCompleteMode.Suggest;
            newImagesPath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            newImagesPath.Location = new Point(131, 41);
            newImagesPath.Margin = new Padding(3, 12, 3, 3);
            newImagesPath.Name = "newImagesPath";
            newImagesPath.Size = new Size(842, 23);
            newImagesPath.TabIndex = 3;
            newImagesPath.TextChanged += newImagesPath_TextChange;
            // 
            // changeNewImagesDirButton
            // 
            changeNewImagesDirButton.Cursor = Cursors.Hand;
            changeNewImagesDirButton.FlatAppearance.BorderColor = Color.Black;
            changeNewImagesDirButton.Location = new Point(979, 41);
            changeNewImagesDirButton.Margin = new Padding(3, 12, 15, 3);
            changeNewImagesDirButton.Name = "changeNewImagesDirButton";
            changeNewImagesDirButton.Size = new Size(27, 23);
            changeNewImagesDirButton.TabIndex = 8;
            changeNewImagesDirButton.Text = "...";
            changeNewImagesDirButton.UseVisualStyleBackColor = true;
            changeNewImagesDirButton.Click += changeNewImagesDirButton_Click;
            // 
            // outputPathLabel
            // 
            outputPathLabel.Font = new Font("Segoe UI", 8F);
            outputPathLabel.Location = new Point(0, 67);
            outputPathLabel.Margin = new Padding(0, 0, 450, 0);
            outputPathLabel.Name = "outputPathLabel";
            outputPathLabel.Size = new Size(596, 14);
            outputPathLabel.TabIndex = 10;
            outputPathLabel.Text = "Output Path:";
            outputPathLabel.TextAlign = ContentAlignment.BottomRight;
            // 
            // loadImagesButton
            // 
            loadImagesButton.Cursor = Cursors.Hand;
            loadImagesButton.FlatAppearance.BorderColor = Color.Black;
            loadImagesButton.Location = new Point(3, 81);
            loadImagesButton.Margin = new Padding(3, 0, 3, 3);
            loadImagesButton.Name = "loadImagesButton";
            loadImagesButton.Size = new Size(119, 28);
            loadImagesButton.TabIndex = 4;
            loadImagesButton.Text = "Load Images";
            loadImagesButton.UseVisualStyleBackColor = true;
            loadImagesButton.Click += loadImagesButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Cursor = Cursors.Hand;
            refreshButton.Enabled = false;
            refreshButton.FlatAppearance.BorderColor = Color.Black;
            refreshButton.Location = new Point(128, 81);
            refreshButton.Margin = new Padding(3, 0, 3, 3);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(119, 28);
            refreshButton.TabIndex = 5;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // createContentBuildButton
            // 
            createContentBuildButton.BackColor = SystemColors.ActiveCaption;
            createContentBuildButton.Cursor = Cursors.Hand;
            createContentBuildButton.Enabled = false;
            createContentBuildButton.FlatAppearance.BorderColor = Color.Black;
            createContentBuildButton.Location = new Point(253, 81);
            createContentBuildButton.Margin = new Padding(3, 0, 3, 3);
            createContentBuildButton.Name = "createContentBuildButton";
            createContentBuildButton.Size = new Size(265, 28);
            createContentBuildButton.TabIndex = 6;
            createContentBuildButton.Text = "Create Content Build";
            createContentBuildButton.UseVisualStyleBackColor = false;
            createContentBuildButton.Click += createContentBuildButton_Click;
            // 
            // outputPathTextBox
            // 
            outputPathTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            outputPathTextBox.AutoCompleteSource = AutoCompleteSource.FileSystem;
            outputPathTextBox.Location = new Point(524, 83);
            outputPathTextBox.Margin = new Padding(3, 2, 3, 3);
            outputPathTextBox.Name = "outputPathTextBox";
            outputPathTextBox.Size = new Size(565, 23);
            outputPathTextBox.TabIndex = 9;
            outputPathTextBox.TextChanged += outputPathTextBox_TextChange;
            // 
            // changeOutputDirButton
            // 
            changeOutputDirButton.Cursor = Cursors.Hand;
            changeOutputDirButton.FlatAppearance.BorderColor = Color.Black;
            changeOutputDirButton.Location = new Point(1095, 83);
            changeOutputDirButton.Margin = new Padding(3, 2, 15, 3);
            changeOutputDirButton.Name = "changeOutputDirButton";
            changeOutputDirButton.Size = new Size(27, 23);
            changeOutputDirButton.TabIndex = 11;
            changeOutputDirButton.Text = "...";
            changeOutputDirButton.UseVisualStyleBackColor = true;
            changeOutputDirButton.Click += changeOutputDirButton_Click;
            // 
            // tftImageContainer
            // 
            tftImageContainer.AutoSize = true;
            tftImageContainer.BorderStyle = BorderStyle.FixedSingle;
            tftImageContainer.Controls.Add(tftLabel);
            tftImageContainer.Controls.Add(headersTFT);
            tftImageContainer.Location = new Point(3, 123);
            tftImageContainer.Margin = new Padding(3, 3, 3, 10);
            tftImageContainer.MaximumSize = new Size(1139, 0);
            tftImageContainer.MinimumSize = new Size(1139, 60);
            tftImageContainer.Name = "tftImageContainer";
            tftImageContainer.Size = new Size(1139, 60);
            tftImageContainer.TabIndex = 3;
            // 
            // tftLabel
            // 
            tftLabel.AutoSize = true;
            tftLabel.FlatStyle = FlatStyle.Flat;
            tftLabel.Font = new Font("Segoe UI", 12F);
            tftLabel.Location = new Point(3, 0);
            tftLabel.Margin = new Padding(3, 0, 1139, 0);
            tftLabel.Name = "tftLabel";
            tftLabel.Size = new Size(88, 21);
            tftLabel.TabIndex = 0;
            tftLabel.Text = "TFT Images";
            // 
            // headersTFT
            // 
            headersTFT.Controls.Add(Type);
            headersTFT.Controls.Add(imageNameHeader);
            headersTFT.Controls.Add(durationHeader);
            headersTFT.Controls.Add(label1);
            headersTFT.Controls.Add(label2);
            headersTFT.Location = new Point(0, 21);
            headersTFT.Margin = new Padding(0);
            headersTFT.Name = "headersTFT";
            headersTFT.Size = new Size(1135, 21);
            headersTFT.TabIndex = 2;
            headersTFT.Visible = false;
            // 
            // Type
            // 
            Type.Location = new Point(3, 5);
            Type.Margin = new Padding(3, 5, 3, 0);
            Type.Name = "Type";
            Type.Size = new Size(50, 15);
            Type.TabIndex = 1;
            Type.Text = "Type";
            // 
            // imageNameHeader
            // 
            imageNameHeader.Location = new Point(59, 5);
            imageNameHeader.Margin = new Padding(3, 5, 3, 0);
            imageNameHeader.Name = "imageNameHeader";
            imageNameHeader.Size = new Size(330, 15);
            imageNameHeader.TabIndex = 2;
            imageNameHeader.Text = "Image Name";
            // 
            // durationHeader
            // 
            durationHeader.AutoSize = true;
            durationHeader.Location = new Point(395, 5);
            durationHeader.Margin = new Padding(3, 5, 126, 0);
            durationHeader.Name = "durationHeader";
            durationHeader.Size = new Size(53, 15);
            durationHeader.TabIndex = 3;
            durationHeader.Text = "Duration";
            // 
            // label1
            // 
            label1.Location = new Point(577, 5);
            label1.Margin = new Padding(3, 5, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 4;
            label1.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(683, 5);
            label2.Margin = new Padding(3, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 5;
            label2.Text = "Stop Date";
            // 
            // u2ImageContainer
            // 
            u2ImageContainer.AutoSize = true;
            u2ImageContainer.BorderStyle = BorderStyle.FixedSingle;
            u2ImageContainer.Controls.Add(u2Label);
            u2ImageContainer.Location = new Point(3, 196);
            u2ImageContainer.Margin = new Padding(3, 3, 3, 10);
            u2ImageContainer.MaximumSize = new Size(1139, 0);
            u2ImageContainer.MinimumSize = new Size(1139, 60);
            u2ImageContainer.Name = "u2ImageContainer";
            u2ImageContainer.Size = new Size(1139, 60);
            u2ImageContainer.TabIndex = 4;
            // 
            // u2Label
            // 
            u2Label.AutoSize = true;
            u2Label.FlatStyle = FlatStyle.Flat;
            u2Label.Font = new Font("Segoe UI", 12F);
            u2Label.Location = new Point(3, 0);
            u2Label.Margin = new Padding(3, 0, 1139, 0);
            u2Label.Name = "u2Label";
            u2Label.Size = new Size(84, 21);
            u2Label.TabIndex = 1;
            u2Label.Text = "U2 Images";
            // 
            // u3ImageContainer
            // 
            u3ImageContainer.AutoSize = true;
            u3ImageContainer.BorderStyle = BorderStyle.FixedSingle;
            u3ImageContainer.Controls.Add(u3label);
            u3ImageContainer.Location = new Point(3, 269);
            u3ImageContainer.MaximumSize = new Size(1139, 0);
            u3ImageContainer.MinimumSize = new Size(1139, 60);
            u3ImageContainer.Name = "u3ImageContainer";
            u3ImageContainer.Size = new Size(1139, 60);
            u3ImageContainer.TabIndex = 5;
            // 
            // u3label
            // 
            u3label.AutoSize = true;
            u3label.FlatStyle = FlatStyle.Flat;
            u3label.Font = new Font("Segoe UI", 12F);
            u3label.Location = new Point(3, 0);
            u3label.Margin = new Padding(3, 0, 1139, 0);
            u3label.Name = "u3label";
            u3label.Size = new Size(84, 21);
            u3label.TabIndex = 2;
            u3label.Text = "U3 Images";
            // 
            // menuStrip1
            // 
            menuStrip1.AllowDrop = true;
            menuStrip1.BackColor = SystemColors.ControlDark;
            menuStrip1.Items.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1174, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionsMenuItem, exitToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(37, 20);
            optionsToolStripMenuItem.Text = "File";
            // 
            // optionsMenuItem
            // 
            optionsMenuItem.BackColor = SystemColors.ActiveBorder;
            optionsMenuItem.Name = "optionsMenuItem";
            optionsMenuItem.Size = new Size(180, 22);
            optionsMenuItem.Text = "Options";
            optionsMenuItem.Click += optionsMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.BackColor = SystemColors.ActiveBorder;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1174, 927);
            Controls.Add(mainContainer);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainPage";
            Text = "Form1";
            Load += MainPage_Load;
            mainContainer.ResumeLayout(false);
            mainContainer.PerformLayout();
            headerContainer.ResumeLayout(false);
            headerContainer.PerformLayout();
            tftImageContainer.ResumeLayout(false);
            tftImageContainer.PerformLayout();
            headersTFT.ResumeLayout(false);
            headersTFT.PerformLayout();
            u2ImageContainer.ResumeLayout(false);
            u2ImageContainer.PerformLayout();
            u3ImageContainer.ResumeLayout(false);
            u3ImageContainer.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel mainContainer;
        private FlowLayoutPanel headerContainer;
        private Label currentContentLabel;
        private TextBox currentContentPath;
        private Label newImagesLabel;
        private TextBox newImagesPath;
        private Button loadImagesButton;
        private FlowLayoutPanel tftImageContainer;
        private ToolTip toolTip1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel u2ImageContainer;
        private FlowLayoutPanel u3ImageContainer;
        private Label tftLabel;
        private Label u2Label;
        private Label u3label;
        private Button refreshButton;
        private Button createContentBuildButton;
        private Label Type;
        private FlowLayoutPanel headersTFT;
        private Label imageNameHeader;
        private Label durationHeader;
        private Label label1;
        private Label label2;
        private Button changeCurrentContentDirButton;
        private Button changeNewImagesDirButton;
        private TextBox outputPathTextBox;
        private Label outputPathLabel;
        private Button changeOutputDirButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem optionsMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
    }
}