using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DHA.UTIL.appSettings
{
    // Configuration of Solution is stored in appSettings.json
    // File is copy in output folder , found at runtime in current folder
    // Each project read his own configuration in this file
    // -------------------------------------------------------
    // Key are stored in ENUM_AS_KEY
    // NAME : Project Name in UpperCase + '_' + TYPE + '_' +Name in uppercase
    // ex for string KEY  : DAL_STR_DATABASE_CONNECTION_STRING
    // ex for boolean KEY : DAL_BOOL_EF_CORE_ENSURE_CREATED (TRUE or FALSE)
    public class AppSettingsReader
    {
        private const string APP_SETTINGS_FILE_NAME = "appsettings.json";

        public enum EN_APPS_KEY
        {
            DAL_STR_DATABASE_CONNECTION_STRING,
            DAL_BOOL_EF_CORE_ENSURE_CREATED,
            DAL_BOOL_EF_CORE_ENSURE_DELETED
        }

        public static string Read(EN_APPS_KEY eNUM_AS_KEY)
        {
            // read app settings file content
            string fileName = $"{System.IO.Directory.GetCurrentDirectory()}/{APP_SETTINGS_FILE_NAME}";
            string __strAppSettingsFileText = File.ReadAllText(fileName);

            // send text stream to Json Parser
            JsonNode __jsonNodeGlobal = JsonNode.Parse(__strAppSettingsFileText);

            // read JSON Element 
            return __jsonNodeGlobal[eNUM_AS_KEY.ToString()].ToString();
        }//Read

        public static bool ReadBool(EN_APPS_KEY eNUM_AS_KEY)
        {
            string __strValue = Read(eNUM_AS_KEY);
            return __strValue  == "TRUE" || __strValue =="1";
        }//ReadBool
    }
}
