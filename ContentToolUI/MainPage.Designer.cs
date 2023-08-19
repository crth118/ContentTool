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
            tftImageContainer = new FlowLayoutPanel();
            toolTip1 = new ToolTip(components);
            mainContainer.SuspendLayout();
            headerContainer.SuspendLayout();
            SuspendLayout();
            // 
            // mainContainer
            // 
            mainContainer.Controls.Add(headerContainer);
            mainContainer.Controls.Add(tftImageContainer);
            mainContainer.Location = new Point(12, 12);
            mainContainer.Name = "mainContainer";
            mainContainer.Size = new Size(1142, 925);
            mainContainer.TabIndex = 0;
            // 
            // headerContainer
            // 
            headerContainer.Controls.Add(currentContentLabel);
            headerContainer.Controls.Add(currentContentPath);
            headerContainer.Controls.Add(newImagesLabel);
            headerContainer.Controls.Add(newImagesPath);
            headerContainer.Controls.Add(loadImagesButton);
            headerContainer.Location = new Point(3, 3);
            headerContainer.Name = "headerContainer";
            headerContainer.Size = new Size(978, 114);
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
            newImagesPath.Margin = new Padding(3, 12, 3, 3);
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
            // tftImageContainer
            // 
            tftImageContainer.Location = new Point(3, 123);
            tftImageContainer.Name = "tftImageContainer";
            tftImageContainer.Size = new Size(1136, 158);
            tftImageContainer.TabIndex = 3;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1166, 949);
            Controls.Add(mainContainer);
            Name = "MainPage";
            Text = "Form1";
            Load += MainPage_Load;
            mainContainer.ResumeLayout(false);
            headerContainer.ResumeLayout(false);
            headerContainer.PerformLayout();
            ResumeLayout(false);
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
    }
}