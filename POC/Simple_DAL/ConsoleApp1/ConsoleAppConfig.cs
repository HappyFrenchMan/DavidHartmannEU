using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ConsoleAppConfig
    {
        public static void Init()
        {
            // Read db file name for Entity Framework context
            IConfiguration _IConfig =
                new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            Db_Config.SQL_LITE_FILE_NAME = _IConfig.GetSection("DbFileName").Value;
            Db_Config.EF_CORE_ENSURE_DELETED = true;
            Db_Config.EF_CORE_ENSURE_CREATED = true;
        }//Apply

    }
}
