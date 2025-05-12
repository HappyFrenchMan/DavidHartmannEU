using DAL;
using DAL.Entity;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City __city =
                new City() { Department = "75", CityName = "Paris", Area = "IDF", PostalCode = 75001 };
            Firm __firm =
                new Firm() { Key="FirmA",Name= "FirmA", City=__city,Sector="Sector" };

            MyDb __myDb = new MyDb();
            __myDb.cityRepo.Add(__city);
            __myDb.firmRepo.Add(__firm);
        }
    }
}
