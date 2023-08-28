using System.Collections.Generic;
using ContentToolLibrary.Models;

namespace ContentToolLibrary
{
    public class ContentBuilder
    {
        public string OutputLocation { get; set; }
        private readonly string _busyAttractPlaylist = "{0}/playlist_{1}_busyAttract.xml";
        private readonly string _idleAttractPlaylist = "{0}/playlist_{1}_idleAttract.xml";
        public readonly string CompletedBuildName = "CompletedBuild.zip";
        public readonly string CompletedBuildFullPath;
        public XMLPlaylistModel.Playlist? tftplaylist { get; set; }
        public XMLPlaylistModel.Playlist? u2playlist { get; set; }
        public XMLPlaylistModel.Playlist? u3playlist { get; set; }

        public ContentBuilder(string outputLocation)
        {
            OutputLocation = outputLocation;
            CompletedBuildFullPath = $"{OutputLocation}\\{CompletedBuildName}";
        }

        public void GenerateNewContentBuild(string destination)
        {
            GenerateXmlPlaylists(ContentImageType.TFT, tftplaylist, destination);
            GenerateXmlPlaylists(ContentImageType.U2, u2playlist, destination);
            GenerateXmlPlaylists(ContentImageType.U3, u3playlist, destination);
        }
        
        public void SaveCompletedBuildZip(string targetToBuild)
        {
            var fileHandler = new FileHandler();
            
            fileHandler.SplitBuildIntoArtAndSnd(targetToBuild);
            fileHandler.ZipNewBuild(OutputLocation, CompletedBuildName);
            fileHandler.CleanupWorkspace();
        }

        public void GenerateXmlPlaylists(ContentImageType imageType, XMLPlaylistModel.Playlist playlist,
            string destination)
        {
            var xml = new XmlSerializationService();

            var busyAttract = string.Format(_busyAttractPlaylist, destination, imageType);
            var idleAttract = string.Format(_idleAttractPlaylist, destination, imageType);
            
            xml.WriteToXmlFile(busyAttract, playlist, false);
            xml.WriteToXmlFile(idleAttract, playlist, false);
        }
    }
}