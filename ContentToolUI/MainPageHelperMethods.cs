using ContentToolLibrary;

namespace ContentToolUI
{
    public partial class MainPage : Form
    {
        private void DrawImageListDisplay(List<ContentImage> images, FlowLayoutPanel imageTypeContainer)
        {
            int index = 0;
            foreach (var image in images)
            {
                CreateImageInfoContainer(index, image, imageTypeContainer);
                index++;
            }
        }
        
        private void SetDurationsForAll(int index, ContentImageType imageType)
        {
            var newDuration = Controls.Find($"{imageType}{ImageDurationControlName}{index}", true).First().Text;
            for (int i = 0; i <= TFTimagecount; i++)
            {
                var duration = Controls.Find($"{ContentImageType.TFT}{ImageDurationControlName}{i}", true).First();
                duration.Text = newDuration;
            }
            
            for (int i = 0; i <= U2imagecount; i++)
            {
                var duration = Controls.Find($"{ContentImageType.U2}{ImageDurationControlName}{i}", true).First();
                duration.Text = newDuration;
            }
            
            for (int i = 0; i <= U3imagecount; i++)
            {
                var duration = Controls.Find($"{ContentImageType.U3}{ImageDurationControlName}{i}", true).First();
                duration.Text = newDuration;
            }
        }

        private void SetIcons()
        {
            changeOutputDirButton.Image = Image.FromFile(".\\icons\\folder-search.png")
                .GetThumbnailImage(15, 15, null, IntPtr.Zero);
            changeOutputDirButton.ImageAlign = ContentAlignment.MiddleCenter;
            
            changeCurrentContentDirButton.Image = Image.FromFile(".\\icons\\folder-search.png")
                .GetThumbnailImage(15, 15, null, IntPtr.Zero);
            changeCurrentContentDirButton.ImageAlign = ContentAlignment.MiddleCenter;
            
            changeNewImagesDirButton.Image = Image.FromFile(".\\icons\\folder-search.png")
                .GetThumbnailImage(15, 15, null, IntPtr.Zero);
            changeNewImagesDirButton.ImageAlign = ContentAlignment.MiddleCenter;
        }
    }
}