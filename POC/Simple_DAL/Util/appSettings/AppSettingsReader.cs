using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.appSettings
{
    // Configuration of Solution is stored in appSettings.json
    // File is copy in output folder , found at runtime in current folder
    // Each project read his own configuration in this file
    // -------------------------------------------------------
    // Key are stored in ENUM_AS_KEY
    // NAME : Project Name in UpperCase + '_' + TYPE + '_' +Name in uppercase
    // ex for string KEY  : DAL_STR_DATABASE_CONNECTION_STRING
    // ex for boolean KEY : DAL_BOOL_EF_CORE_ENSURE_CREATED (TRUE or FALSE)
    internal class AppSettingsReader
    {
        private const string APP_SETTINGS_FILE_NAME = "appSettings.json";

        public enum ENUM_AS_KEY
        {
            DAL_STR_DATABASE_CONNECTION_STRING,
            DAL_BOOL_EF_CORE_ENSURE_CREATED,
            DAL_BOOL_EF_CORE_ENSURE_DELETED
        }

        public static void ReadAppSettings(ENUM_AS_KEY eNUM_AS_KEY)
        {


        }//ReadAppSettings


    }
}
