using Business.Model;
using Business.Service;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CityBM __cityBM =
                new CityBM() { Department = "75", CityName = "Paris", Area = "IDF", PostalCode = 75001 };
            CityService __cityService = new CityService();
            __cityService.addCity(__cityBM);
        }
    }
}
