using ContentToolLibrary.Models;

namespace ContentToolLibrary
{
    public class OutputService
    {
        public string OutputLocation { get; set; }
        private readonly string _busyAttractPlaylist = "{0}/playlist_{1}_busyAttract.xml";
        private readonly string _idleAttractPlaylist = "{0}/playlist_{1}_idleAttract.xml";
        public readonly string CompletedBuildName = "CompletedBuild.zip";
        public readonly string CompletedBuildFullPath;

        public OutputService(string outputLocation)
        {
            OutputLocation = outputLocation;
            CompletedBuildFullPath = $"{OutputLocation}\\{CompletedBuildName}";
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