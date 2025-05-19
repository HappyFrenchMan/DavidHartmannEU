using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DAL.Repository;

namespace DHA.BUSINESS.Service
{
    public abstract class ADALService
    {

        private static Lazy<MyDb> s_lazyMyDb = new Lazy<MyDb>(); 

        public ADALService() {}//ADALService

        internal static MyDb MyDatabase
        {
            get
            {
                return s_lazyMyDb.Value;
            }//get
        }//MyDb
    }//class
}//namespace
