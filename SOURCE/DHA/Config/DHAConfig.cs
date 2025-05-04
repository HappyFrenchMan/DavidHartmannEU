using DHA.Common.Log4Net;
using DHA.DAL;
using EFSC = DHA.EntityFrameworkCore_Models.EF_StaticConfiguration;
using DSC = DHA.DAL.EF_StaticConfiguration;
using System.IO;

namespace DHA.Config
{
    public class DHAConfig
    {
        
        public static void Init()
        {
            // Read db file name for Entity Framework context
            IConfiguration _IConfig = 
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            EFSC.SQL_LITE_FILE_NAME = _IConfig.GetSection("DbFileName").Value;
            DSC.SQL_LITE_FILE_NAME = _IConfig.GetSection("DbFileName").Value;

            // Init Log4Net with his config file
            string __strXmlFileLog4Net = Path.Combine(Directory.GetCurrentDirectory(), "settingsLog4Net.xml");
            FileInfo __fileInfoFileLog4Net = new FileInfo(__strXmlFileLog4Net);
            sLog4NetLogger.sInitConfig(__fileInfoFileLog4Net);
        }//Apply



    }//class
}//namespace
