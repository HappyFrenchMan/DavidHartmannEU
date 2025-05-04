using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace DHA.EntityFrameworkCore_Models.Initializer
{
    public class DHAConfig
    {
        
        public static string DbFileName()
        {
            IConfiguration _IConfig = 
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return _IConfig.GetSection("DbFileName").Value;
        }//Init

    }//class
}//namespace
