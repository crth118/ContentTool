using System;
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
                
                [XmlElement(ElementName = "schedule")]
                public List<PlaylistSchedule>? Schedule { get; set; }

                [XmlRoot(ElementName = "schedule")]
                public class PlaylistSchedule
                {
                    [XmlAttribute(AttributeName = "type")]
                    public string? Type = "on";

                    [XmlAttribute(AttributeName = "repeatType")]
                    public string? RepeatType = "setperiod";
                    
                    [XmlAttribute(AttributeName = "startDate")]
                    public string? StartDate { get; set; }
                    
                    [XmlAttribute(AttributeName = "stopDate")]
                    public string? StopDate { get; set; }
                }
            }
        }
    }
}