using System;
using System.Collections.Generic;

namespace ContentToolLibrary
{
    public class ContentImage
    {
        public enum ContentImageType
        {
            TFT,
            U2,
            U3
        }

        public ContentImageType ImageType { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public int Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StopDate { get; set; }

        public ContentImage(ContentImageType imageType, string name, string fullPath)
        {
            ImageType = imageType;
            Name = name;
            FullPath = fullPath;
        }
    }
}
