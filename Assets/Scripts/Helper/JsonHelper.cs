using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Helper
{
    public class JsonHelper
    {

        public static List<T> GetAsJson<T>(string root, string fileName)
        {
            return GetAsJson<T>(root + fileName);
        }

        public static List<T> GetAsJson<T>(string path)
        {
            var lines = File.ReadLines(path);
            var jsonInString = StringHelper.ConvertToString(lines);

            return JsonConvert.DeserializeObject< List<T>> (jsonInString);
        }

    }
    
}