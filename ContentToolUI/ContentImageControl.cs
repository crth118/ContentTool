namespace ContentToolUI
{
    public class ContentImageControl : Control
    {
        public ContentImageControl()
        {
            Initialize();
        }

        public void Initialize()
        {
            var lineContainer = new FlowLayoutPanel()
            {
                AutoSize = false,
                Size = new Size(1136, 36),
                Visible = true,
            };
        }
        
        
    }
}