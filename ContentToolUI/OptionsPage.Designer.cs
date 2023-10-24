namespace ContentToolUI
{
    partial class OptionsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            optionsPageContainer = new FlowLayoutPanel();
            contentToolOptionsLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            defaultCurrentContentTextBox = new TextBox();
            changeCurrentContentDirButton = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            defaultNewImagesTextBox = new TextBox();
            changeNewImagesFolderButton = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label3 = new Label();
            defaultOutputTextBox = new TextBox();
            changeOutputFolderButton = new Button();
            saveOptionsButton = new Button();
            cancelButton = new Button();
            optionsPageContainer.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // optionsPageContainer
            // 
            optionsPageContainer.Controls.Add(contentToolOptionsLabel);
            optionsPageContainer.Controls.Add(flowLayoutPanel1);
            optionsPageContainer.Controls.Add(flowLayoutPanel2);
            optionsPageContainer.Controls.Add(flowLayoutPanel3);
            optionsPageContainer.Controls.Add(saveOptionsButton);
            optionsPageContainer.Controls.Add(cancelButton);
            optionsPageContainer.Location = new Point(12, 12);
            optionsPageContainer.Name = "optionsPageContainer";
            optionsPageContainer.Size = new Size(625, 319);
            optionsPageContainer.TabIndex = 0;
            // 
            // contentToolOptionsLabel
            // 
            contentToolOptionsLabel.AutoSize = true;
            contentToolOptionsLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            contentToolOptionsLabel.Location = new Point(3, 0);
            contentToolOptionsLabel.Name = "contentToolOptionsLabel";
            contentToolOptionsLabel.Size = new Size(202, 25);
            contentToolOptionsLabel.TabIndex = 0;
            contentToolOptionsLabel.Text = "Content Tool Options";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(defaultCurrentContentTextBox);
            flowLayoutPanel1.Controls.Add(changeCurrentContentDirButton);
            flowLayoutPanel1.Location = new Point(3, 45);
            flowLayoutPanel1.Margin = new Padding(3, 20, 3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(618, 59);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(189, 17);
            label1.TabIndex = 0;
            label1.Text = "Default Current Content Folder:";
            // 
            // defaultCurrentContentTextBox
            // 
            defaultCurrentContentTextBox.Location = new Point(3, 20);
            defaultCurrentContentTextBox.Name = "defaultCurrentContentTextBox";
            defaultCurrentContentTextBox.Size = new Size(568, 23);
            defaultCurrentContentTextBox.TabIndex = 1;
            // 
            // changeCurrentContentDirButton
            // 
            changeCurrentContentDirButton.Cursor = Cursors.Hand;
            changeCurrentContentDirButton.FlatAppearance.BorderColor = Color.Black;
            changeCurrentContentDirButton.Location = new Point(577, 20);
            changeCurrentContentDirButton.Name = "changeCurrentContentDirButton";
            changeCurrentContentDirButton.Size = new Size(27, 23);
            changeCurrentContentDirButton.TabIndex = 8;
            changeCurrentContentDirButton.UseVisualStyleBackColor = true;
            changeCurrentContentDirButton.Click += changeCurrentContentDirButton_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(defaultNewImagesTextBox);
            flowLayoutPanel2.Controls.Add(changeNewImagesFolderButton);
            flowLayoutPanel2.Location = new Point(3, 117);
            flowLayoutPanel2.Margin = new Padding(3, 10, 3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(618, 59);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(169, 17);
            label2.TabIndex = 0;
            label2.Text = "Default New Images Folder:";
            // 
            // defaultNewImagesTextBox
            // 
            defaultNewImagesTextBox.Location = new Point(3, 20);
            defaultNewImagesTextBox.Name = "defaultNewImagesTextBox";
            defaultNewImagesTextBox.Size = new Size(568, 23);
            defaultNewImagesTextBox.TabIndex = 1;
            // 
            // changeNewImagesFolderButton
            // 
            changeNewImagesFolderButton.Cursor = Cursors.Hand;
            changeNewImagesFolderButton.FlatAppearance.BorderColor = Color.Black;
            changeNewImagesFolderButton.Location = new Point(577, 20);
            changeNewImagesFolderButton.Name = "changeNewImagesFolderButton";
            changeNewImagesFolderButton.Size = new Size(27, 23);
            changeNewImagesFolderButton.TabIndex = 9;
            changeNewImagesFolderButton.UseVisualStyleBackColor = true;
            changeNewImagesFolderButton.Click += changeNewImagesFolderButton_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(defaultOutputTextBox);
            flowLayoutPanel3.Controls.Add(changeOutputFolderButton);
            flowLayoutPanel3.Location = new Point(3, 189);
            flowLayoutPanel3.Margin = new Padding(3, 10, 3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(618, 59);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(137, 17);
            label3.TabIndex = 0;
            label3.Text = "Default Output Folder:";
            // 
            // defaultOutputTextBox
            // 
            defaultOutputTextBox.Location = new Point(3, 20);
            defaultOutputTextBox.Name = "defaultOutputTextBox";
            defaultOutputTextBox.Size = new Size(568, 23);
            defaultOutputTextBox.TabIndex = 1;
            // 
            // changeOutputFolderButton
            // 
            changeOutputFolderButton.Cursor = Cursors.Hand;
            changeOutputFolderButton.FlatAppearance.BorderColor = Color.Black;
            changeOutputFolderButton.Location = new Point(577, 20);
            changeOutputFolderButton.Name = "changeOutputFolderButton";
            changeOutputFolderButton.Size = new Size(27, 23);
            changeOutputFolderButton.TabIndex = 9;
            changeOutputFolderButton.UseVisualStyleBackColor = true;
            changeOutputFolderButton.Click += changeOutputFolderButton_Click;
            // 
            // saveOptionsButton
            // 
            saveOptionsButton.Location = new Point(3, 279);
            saveOptionsButton.Margin = new Padding(3, 28, 3, 3);
            saveOptionsButton.Name = "saveOptionsButton";
            saveOptionsButton.Size = new Size(100, 27);
            saveOptionsButton.TabIndex = 4;
            saveOptionsButton.Text = "Save";
            saveOptionsButton.UseVisualStyleBackColor = true;
            saveOptionsButton.Click += saveOptionsButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(109, 279);
            cancelButton.Margin = new Padding(3, 28, 3, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 27);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // OptionsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(649, 343);
            Controls.Add(optionsPageContainer);
            Name = "OptionsPage";
            Text = "MPS Content Tool - Settings";
            Load += Form1_Load;
            optionsPageContainer.ResumeLayout(false);
            optionsPageContainer.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel optionsPageContainer;
        private Label contentToolOptionsLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TextBox defaultCurrentContentTextBox;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private TextBox defaultNewImagesTextBox;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label3;
        private TextBox defaultOutputTextBox;
        private Button changeCurrentContentDirButton;
        private Button changeNewImagesFolderButton;
        private Button changeOutputFolderButton;
        private Button saveOptionsButton;
        private Button cancelButton;
    }
}