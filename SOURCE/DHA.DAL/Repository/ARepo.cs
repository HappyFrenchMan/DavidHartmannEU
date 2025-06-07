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
        private MyDbContext _myDbCxt;

        internal ARepo(MyDbContext pMyDbCtx)
        {
            _myDbCxt = pMyDbCtx;
        }//ARepo

        internal MyDbContext MyDbCtx
        {
            get
            {
                return _myDbCxt;
            }//get
        }//MyDatabase

        public UpdateResult add_entity(object pObject)
        {
            return add_entities(new object[] { pObject });
        }//add_entity

        public UpdateResult add_entities(object[] pTabObject)
        {
            try
            {
                MyDatabase.Add(pTabObject);

                int __intRowsUpdated = MyDatabase.SaveChanges();

                return new UpdateResult(true, __intRowsUpdated);
            }//try
            catch (Exception __ex)
            {
                return new UpdateResult(__ex);
            }//catch
        }//add_entities
    }//class
}//namespace
