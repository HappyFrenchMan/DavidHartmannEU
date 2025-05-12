using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Common.Config
{
    public class AppSettingsReader
    {
        private const string APP_SETTINGS_FILE_NAME= "appSettings.json";

        public enum APP_SETTINGS_KEY
        {
            DAL_DB_FILE_NAME
        }

        public string ReadSettings(APP_SETTINGS_KEY pAPP_SETTINGS_KEY_key)
        {
            string fileName = $"{System.IO.Directory.GetCurrentDirectory()}/{APP_SETTINGS_FILE_NAME}"
            string __strAppSettingsFileText = File.ReadAllText(fileName);
            JsonNode __jsonNode = JsonNode.Parse(__strAppSettingsFileText);
            return __jsonNode[pAPP_SETTINGS_KEY_key.ToString()];

            //
            // Get value from a JsonNode.
            JsonNode temperatureNode = forecastNode["Temperature"]!;
            Console.WriteLine($"Type={temperatureNode.GetType()}");
            Console.WriteLine($"JSON={temperatureNode.ToJsonString()}");
            //output:
            //Type = System.Text.Json.Nodes.JsonValue`1[System.Text.Json.JsonElement]
            //JSON = 25
        }

    }
}
