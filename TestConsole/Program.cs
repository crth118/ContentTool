using System;
using System.Xml;
using System.Xml.Serialization;
using ContentToolLibrary.Models;
class class1
{
    static void Main(string[] args)
    {
        var content = new List<XMLPlaylistModel.Playlist.PlaylistContent>();
        
        var line1 = new XMLPlaylistModel.Playlist.PlaylistContent();
        var line2 = new XMLPlaylistModel.Playlist.PlaylistContent();

        line1.Path = "good_morning.jpg";
        line1.Duration = "99";
        line1.Height = 240;
        line1.Width = 999;

        line2.Duration = "99";
        line2.Height = 240;
        line2.Path = "good_morning.jpg";
        line2.Width = 999;
        
        content.Add(line1);
        content.Add(line2);
        
        var playList = new XMLPlaylistModel.Playlist();
        playList.Content = content;
        playList.UseNumberedJpgs = false;
        
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("","");

        var xml = new XmlSerializer(playList.GetType());
        xml.Serialize(Console.Out, playList, ns);
        
        Console.WriteLine();
        Console.ReadLine();
    }
}

