using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using ImageMagick;

namespace ContentToolLibrary
{
    /// <summary>
    /// Performs the import of current content file, and new content images that will generate the new content build.
    /// Current content file and new images are defined by the user, by placing in a specific directory.
    /// </summary>
    public class ContentImporter
    {
        // Default ContentPaths
        public string CurrentContentPath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CurrentContent/sbnexgen2");
        public string NewImagesPath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NewImages");
        
        // .jpg images that are a part of every build
        private readonly string[] _ignoreList = { "Blank_240_160.jpg", "DR_Earn_Redeem.jpg", "DR_Exp_More.jpg", "DR_Win_Prizes.jpg" };
        public Dictionary<string, int> Resolutions { get; set; }
        public List<string> Warnings = new();

        public ContentImporter()
        {
            Resolutions = SetResolutionsDictionary();
        }
        
        public List<ContentImage> GetAllImages()
        {
            var imageList = new List<ContentImage>();

            var currentImages = new DirectoryInfo(CurrentContentPath).GetFiles("*.jpg");
            var newImages = new DirectoryInfo(NewImagesPath).GetFiles("*.jpg");
            
            AddImagesTypeList(currentImages, imageList);
            AddImagesTypeList(newImages, imageList);

            return imageList;
        }

        private void AddImagesTypeList(FileInfo[] files, List<ContentImage> imageList)
        {
            foreach (var file in files)
            {
                using (var imageFile = Image.FromFile(file.FullName))
                {
                    var height = imageFile.Height;
                    var width = imageFile.Width;
                    
                    if (IsTFTImage(height, width))
                    {
                        imageList.Add(new ContentImage(ContentImageType.TFT, file.Name));
                        continue;
                    }

                    if (IsU2Image(height, width))
                    {
                        imageList.Add(new ContentImage(ContentImageType.U2, file.Name));
                        continue;
                    }

                    if (IsU3Image(height, width))
                    {
                        imageList.Add(new ContentImage(ContentImageType.U3, file.Name));
                        continue;
                    }
                    
                    if (!_ignoreList.Contains(file.Name))
                    {
                        var msg =
                            $"{file.Name} does not match TFT, U2, or U3 resolutions. If this image is mean to be a " +
                            $"part of the new content build, resize the image to the correct resolution. Otherwise, it can " +
                            $"safely be ignored.";
                        
                        Warnings.Add(msg);
                    }
                }
            }
        }

        private bool IsTFTImage(int imageHeight, int imageWidth)
        {
            return imageHeight == Resolutions["TFT Height"] && imageWidth == Resolutions["TFT Width"];
        }
        
        private bool IsU2Image(int imageHeight, int imageWidth)
        {
            return imageHeight == Resolutions["U2 Height"] && imageWidth == Resolutions["U2 Width"];
        }
        
        private bool IsU3Image(int imageHeight, int imageWidth)
        {
            return imageHeight == Resolutions["U3 Height"] && imageWidth == Resolutions["U3 Width"];
        }

        private Dictionary<string, int> SetResolutionsDictionary()
        {
            var resolutions = new Dictionary<string, int>();
            resolutions.Add("TFT Width", 640);
            resolutions.Add("TFT Height", 240);
            resolutions.Add("U2 Width", 160);
            resolutions.Add("U2 Height", 600);
            resolutions.Add("U3 Width", 256);
            resolutions.Add("U3 Height", 1024);

            return resolutions;
        }
    }
}