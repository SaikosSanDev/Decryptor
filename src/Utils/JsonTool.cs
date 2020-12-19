using System.IO;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Decryptor.Utils
{

    class JsonTool
    {

        public static void Serialize(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath)) File.Delete(filePath);
            StreamWriter sw = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);
            jsonSerializer.Serialize(jsonWriter, data);

            jsonWriter.Close();
            sw.Close();
        }

        public static object Deserialize(Type type, string filePath)
        {
            JObject jObject = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if(File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(sr);
                jObject = jsonSerializer.Deserialize(jsonReader) as JObject;

                jsonReader.Close();
                sr.Close();
            }
            return jObject.ToObject(type);
        }

    }

}
