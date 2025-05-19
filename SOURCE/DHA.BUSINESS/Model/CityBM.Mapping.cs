using DHA.DAL.CV.Entity;

namespace DHA.BUSINESS.Model
{
    public partial class CityBM
    {
        public static City ToCity(CityBM cityBM)
        {
            return new City()
            {
                ID = cityBM.ID,
                Area = cityBM.Area,
                CityName = cityBM.Department,
                PostalCode = cityBM.PostalCode,
                Department = cityBM.Department
            };
        }//ToCity
    }//class
}//namespace
