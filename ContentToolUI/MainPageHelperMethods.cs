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
        
        private void SetDurationsForAll(int imageCount, int index, ContentImageType imageType)
        {
            var newDuration = Controls.Find($"{imageType}{ImageDurationControlName}{index}", true).First().Text;
            for (int i = 0; i <= imageCount; i++)
            {
                var duration = Controls.Find($"{imageType}{ImageDurationControlName}{i}", true).First();
                duration.Text = newDuration;
            }
        }
    }
}