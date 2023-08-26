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
    }
}