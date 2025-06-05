using DAH.DAL;
using DHA.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Repository
{
    public abstract class ARepo
    {
        private MyDb _myDbRef;

        protected ARepo(MyDb pMyDb)
        {
            _myDbRef = pMyDb;
        }//ARepo

        protected MyDb MyDatabase
        {
            get
            {
                return _myDbRef;
            }//get
        }//MyDatabase

        protected UpdateResult Commit_Add(object anEntity)
        {
            try
            {                
                MyDatabase.Add(anEntity);
                int __intRowsUpdated = MyDatabase.SaveChanges();

                return new UpdateResult(true, __intRowsUpdated);
            }
            catch (Exception __ex)
            {
                return new UpdateResult(__ex);
            }//catch

        }//Commit_Add

    }//class
}//namespace
