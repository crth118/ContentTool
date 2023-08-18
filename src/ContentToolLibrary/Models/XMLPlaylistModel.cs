using System.Collections.Generic;
using System.Xml.Serialization;

namespace ContentToolLibrary.Models
{
    public class XMLPlaylistModel
    {
        [XmlRoot(ElementName = "playList")]
        public class Playlist
        {
            [XmlElement(ElementName = "content")]
            public List<PlaylistContent>? Content { get; set; }
            
            [XmlAttribute(AttributeName = "useNumberedJpgs")]
            public bool UseNumberedJpgs { get; set; }
            
            [XmlRoot(ElementName = "content")]
            public class PlaylistContent
            {
                [XmlAttribute(AttributeName = "path")]
                public string? Path { get; set; }
            
                [XmlAttribute(AttributeName = "width")]
                public int Width { get; set; }
            
                [XmlAttribute(AttributeName = "height")]
                public int Height { get; set; }

                [XmlAttribute(AttributeName = "tween")]
                public string Tween = "fade";
            
                [XmlAttribute(AttributeName = "duration")]
                public string? Duration { get; set; }
            }
        }
    }
}