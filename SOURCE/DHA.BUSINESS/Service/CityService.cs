using Business.Interface;
using Business.Model;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.BUSINESS.Service
{
    public class CityService : ADALService,ICityService
    {
        public void addCity(CityBM pCityBM)
        {
            City __city = CityBM.ToCity(pCityBM);
            MyDatabase.cityRepo.Add(__city);
        }//addCity
    }//class
}//namespace
