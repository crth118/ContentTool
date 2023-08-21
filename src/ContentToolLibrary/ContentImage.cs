using System;
using System.Collections.Generic;

namespace ContentToolLibrary
{
    public class ContentImage
    {
        public ContentImageType ImageType { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; } = "00.08";

        public ContentImage(ContentImageType imageType, string name)
        {
            ImageType = imageType;
            Name = name;
        }
    }
}
