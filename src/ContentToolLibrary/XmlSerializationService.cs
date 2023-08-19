using System.IO;
using System.Xml.Serialization;

namespace ContentToolLibrary
{
    public class XmlSerializationService
    {
        public void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append) where T : new()
        {
            // Add empty namespaces to avoid these showing in the XML file. The IGT program cannot process these.
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("","");

            var xml = new XmlSerializer(objectToWrite.GetType());
            var writer = new StreamWriter(filePath);
            
            xml.Serialize(writer, objectToWrite, ns);
            
            writer.Close();
        }
    }
}