using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace OutlandSpace.Universe.Tools
{
    public class ResourceLoader<T>
    {
        private static readonly JsonSerializer Serializer = new();

        public static List<T> LoadFromFolder(string folder)
        {
            var objects = new List<T>();

            foreach (var fileContent in FilesFactory.GetFilesContentFromDirectory(folder))
            {
                objects.AddRange(JsonConvert.DeserializeObject<List<T>>(value: fileContent)!);
            }

            return objects;
        }

        public static T ParseObject(string body)
        {
            Serializer.Converters.Add(new JavaScriptDateTimeConverter());
            Serializer.NullValueHandling = NullValueHandling.Ignore;

            var result = JsonConvert.DeserializeObject<T>(value: body);

            return result;
        }
    }
}