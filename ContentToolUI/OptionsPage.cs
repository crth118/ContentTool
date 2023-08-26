using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContentToolUI
{
    public partial class OptionsPage : Form
    {
        public IConfigurationRoot Config;
        public string OutputPath;
        public string CurrentContentPath;
        public string NewImagesPath;

        public OptionsPage(IConfigurationRoot config)
        {
            InitializeComponent();
            Config = config;
            OutputPath = Config["OutputDirectory"];
            CurrentContentPath = Config["CurrentContent"];
            NewImagesPath = Config["NewImages"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            defaultCurrentContentTextBox.Text = CurrentContentPath;
            defaultNewImagesTextBox.Text = NewImagesPath;
            defaultOutputTextBox.Text = OutputPath;
        }

        private void changeCurrentContentDirButton_Click(object sender, EventArgs e)
        {
            ChangeDirectory(defaultCurrentContentTextBox);
            CurrentContentPath = defaultCurrentContentTextBox.Text;
        }

        private void changeNewImagesFolderButton_Click(object sender, EventArgs e)
        {
            ChangeDirectory(defaultNewImagesTextBox);
            NewImagesPath = defaultNewImagesTextBox.Text;
        }

        private void changeOutputFolderButton_Click(object sender, EventArgs e)
        {
            ChangeDirectory(defaultOutputTextBox);
            OutputPath = defaultOutputTextBox.Text;
        }

        private void ChangeDirectory(TextBox textbox)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    textbox.Text = dialog.SelectedPath;
                }
            }
        }

        private void saveOptionsButton_Click(object sender, EventArgs e)
        {
            Config["OutputDirectory"] = OutputPath;
            Config["CurrentContent"] = CurrentContentPath;
            Config["NewImages"] = NewImagesPath;
        }
    }
}
