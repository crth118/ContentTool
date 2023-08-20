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
            newImagesLabel = new Label();
            newImagesPath = new TextBox();
            loadImagesButton = new Button();
            refreshButton = new Button();
            createContentBuildButton = new Button();
            tftImageContainer = new FlowLayoutPanel();
            tftLabel = new Label();
            u2ImageContainer = new FlowLayoutPanel();
            u2Label = new Label();
            u3ImageContainer = new FlowLayoutPanel();
            u3label = new Label();
            toolTip1 = new ToolTip(components);
            mainContainer.SuspendLayout();
            headerContainer.SuspendLayout();
            tftImageContainer.SuspendLayout();
            u2ImageContainer.SuspendLayout();
            u3ImageContainer.SuspendLayout();
            SuspendLayout();
            // 
            // mainContainer
            // 
            mainContainer.AutoSize = true;
            mainContainer.Controls.Add(headerContainer);
            mainContainer.Controls.Add(tftImageContainer);
            mainContainer.Controls.Add(u2ImageContainer);
            mainContainer.Controls.Add(u3ImageContainer);
            mainContainer.Location = new Point(12, 12);
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
            headerContainer.Controls.Add(newImagesLabel);
            headerContainer.Controls.Add(newImagesPath);
            headerContainer.Controls.Add(loadImagesButton);
            headerContainer.Controls.Add(refreshButton);
            headerContainer.Controls.Add(createContentBuildButton);
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
            currentContentPath.Location = new Point(131, 3);
            currentContentPath.Margin = new Padding(3, 3, 50, 3);
            currentContentPath.Name = "currentContentPath";
            currentContentPath.Size = new Size(842, 23);
            currentContentPath.TabIndex = 1;
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
            newImagesPath.Location = new Point(131, 41);
            newImagesPath.Margin = new Padding(3, 12, 50, 3);
            newImagesPath.Name = "newImagesPath";
            newImagesPath.Size = new Size(842, 23);
            newImagesPath.TabIndex = 3;
            // 
            // loadImagesButton
            // 
            loadImagesButton.Cursor = Cursors.Hand;
            loadImagesButton.FlatAppearance.BorderColor = Color.Black;
            loadImagesButton.Location = new Point(3, 82);
            loadImagesButton.Margin = new Padding(3, 15, 3, 3);
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
            refreshButton.Location = new Point(128, 82);
            refreshButton.Margin = new Padding(3, 15, 3, 3);
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
            createContentBuildButton.Location = new Point(253, 82);
            createContentBuildButton.Margin = new Padding(3, 15, 3, 3);
            createContentBuildButton.Name = "createContentBuildButton";
            createContentBuildButton.Size = new Size(373, 28);
            createContentBuildButton.TabIndex = 6;
            createContentBuildButton.Text = "Create Content Build";
            createContentBuildButton.UseVisualStyleBackColor = false;
            createContentBuildButton.Click += createContentBuildButton_Click;
            // 
            // tftImageContainer
            // 
            tftImageContainer.AutoSize = true;
            tftImageContainer.BorderStyle = BorderStyle.FixedSingle;
            tftImageContainer.Controls.Add(tftLabel);
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
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1174, 927);
            Controls.Add(mainContainer);
            Name = "MainPage";
            Text = "Form1";
            Load += MainPage_Load;
            mainContainer.ResumeLayout(false);
            mainContainer.PerformLayout();
            headerContainer.ResumeLayout(false);
            headerContainer.PerformLayout();
            tftImageContainer.ResumeLayout(false);
            tftImageContainer.PerformLayout();
            u2ImageContainer.ResumeLayout(false);
            u2ImageContainer.PerformLayout();
            u3ImageContainer.ResumeLayout(false);
            u3ImageContainer.PerformLayout();
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
    }
}