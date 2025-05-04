using DHA.Common.Log4Net;

namespace DHA.Fun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            // Init Log4Net with his config file
            string __strXmlFileLog4Net = Path.Combine(Directory.GetCurrentDirectory(), "settingsLog4Net.xml");
            FileInfo __fileInfoFileLog4Net = new FileInfo(__strXmlFileLog4Net);
            sLog4NetLogger.sInitConfig(__fileInfoFileLog4Net);

            while (1==1)
            {
                sLog4NetLogger.Debug("coucou"); 
            }
        }
    }
}
