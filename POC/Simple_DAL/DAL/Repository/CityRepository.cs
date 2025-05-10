using DAL.Entity;
using DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CityRepository : Repository<City>
    {
        public  CityRepository(Db_Context pDb_Context) : base(pDb_Context) { }//CityRepository

        public void add(string pStrKey,string pStrValue)
        {
            City city = new City() { }
        }
    }//class
}//namespace
