using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace ContentToolLibrary
{
    /// <summary>
    /// Handle files and directories during new content build process. Using Workspaces directory in the
    /// application's current domain to perform the necessary CRUD actions.
    /// </summary>
    public class FileHandler
    {
        public readonly string WorkSpace = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workspace");
        public readonly string WorkSpaceSbnexgen;
        private readonly string _artDirPath;
        private readonly string _sndDirPath;
        

        public FileHandler()
        {
            WorkSpaceSbnexgen = $"{WorkSpace}\\sbnexgen2";
            _artDirPath = $"{WorkSpace}\\ART";
            _sndDirPath = $"{WorkSpace}\\SND";
        }
        
        public void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }

            var dirs = dir.GetDirectories();

            foreach (var file in dir.GetFiles())
            {
                var targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (var subDir in dirs)
                {
                    var newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    
        /// <summary>
        /// Copy the current content and new images to the workspace directory to form the new
        /// content build.
        /// </summary>
        /// <param name="currentContentPath">Path to the current content used as a base for the new build</param>
        /// <param name="newImagesPath">Path to the new images to be added to the current content build</param>
        public void FormNewBuild(string currentContentPath, string newImagesPath)
        {
            CopyDirectory(currentContentPath, WorkSpaceSbnexgen, false);
            CopyDirectory(newImagesPath, WorkSpaceSbnexgen, false);

            var files = new DirectoryInfo(WorkSpaceSbnexgen).GetFiles("*.jpg");
            foreach (var file in files)
            {
                ImageCompressor.CompressImage(file.FullName);
            }
        }

        /// <summary>
        /// Split a content build into the ART and SND directories. This is needed for processing by the
        /// IGT content utility.
        /// </summary>
        /// <param name="sbnexgenPath">Path to the new content build to be split, usually a sbnexgen2 folder</param>
        public void SplitBuildIntoArtAndSnd(string sbnexgenPath)
        {
            MakeArtAndSndDirs();
            
            var dir = new DirectoryInfo(sbnexgenPath);
            var files = dir.GetFiles();

            foreach (var file in files)
            {
                var fileName = file.Name;
                var extensions = Path.GetExtension(fileName);

                if (extensions.ToLower() == ".wav")
                {
                    file.CopyTo($"{_sndDirPath}/{file.Name}");
                }

                file.CopyTo($"{_artDirPath}/{file.Name}");
            }
        }

        private void MakeArtAndSndDirs()
        {
            if (!Path.Exists(_artDirPath))
            {
                Directory.CreateDirectory(_artDirPath);
            }

            if (!Path.Exists(_sndDirPath))
            {
                Directory.CreateDirectory(_sndDirPath);
            }
        }

        public void ZipNewBuild(string outputPath, string fileName)
        {
            ZipFile.CreateFromDirectory(WorkSpace, $"{outputPath}\\{fileName}", CompressionLevel.SmallestSize, false);
        }

        /// <summary>
        /// Remove files and folders from the Workspace directory created during new content build creation
        /// </summary>
        public void CleanupWorkspace()
        {
            if (Path.Exists(_artDirPath))
            {
                Directory.Delete(_artDirPath, true);
            }
            
            if (Path.Exists(_sndDirPath))
            {
                Directory.Delete(_sndDirPath, true);
            }

            var files = new DirectoryInfo(WorkSpaceSbnexgen).GetFiles();
            foreach (var file in files)
            {
                file.Delete();
            }
        }
    }
}