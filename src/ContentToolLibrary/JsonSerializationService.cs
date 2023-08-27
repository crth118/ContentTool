using System.IO;
using Newtonsoft.Json;

namespace ContentToolLibrary
{
    public static class JsonSerializationService
    {
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append) where T : new()
        {
            var contents = JsonConvert.SerializeObject(objectToWrite);

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(contents);
            }
        }
    }
}