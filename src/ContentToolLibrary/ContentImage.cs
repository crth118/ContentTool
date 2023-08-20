using System;
using System.Collections.Generic;

namespace ContentToolLibrary
{
    public class ContentImage
    {
        public ContentImageType ImageType { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public string Duration { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string? StartDate { get; set; }
        public string? StopDate { get; set; }
        public bool Use { get; set; } = true;

        public ContentImage(ContentImageType imageType, string name, string fullPath)
        {
            ImageType = imageType;
            Name = name;
            FullPath = fullPath;
        }
    }
}
