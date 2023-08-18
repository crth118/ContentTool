using System.IO;
using ImageMagick;
using System.Drawing;

namespace ContentToolLibrary;

public static class ImageCompressor
{
    public static int MaximumSizeBytes = 9000;
        
    public static void CompressImage(string imagePath)
    {
        if (File.Exists(imagePath))
        {
            var file = new FileInfo(imagePath);
            new ImageOptimizer().Compress(file);
            file.Refresh();

            using (var image = new MagickImage(imagePath))
            {
                image.Density = new Density(72, 72);
                image.Write(imagePath);
            }
        }
    }

    public static bool IsCompressed(string imagePath)
    {
        using (var bitmap = (Bitmap)Bitmap.FromFile(imagePath))
        {
            if (bitmap.HorizontalResolution == 72 && bitmap.VerticalResolution == 72)
            {
                return true;                    
            }

            return false;
        }
    }
}