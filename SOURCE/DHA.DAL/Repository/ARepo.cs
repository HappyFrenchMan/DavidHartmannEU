using DHA.DAL.QueryResult;

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
                MyDbCtx.AddRange(pTabObject);

                int __intRowsUpdated = MyDbCtx.SaveChanges();

                return new UpdateResult(true, __intRowsUpdated);
            }//try
            catch (Exception __ex)
            {
                return new UpdateResult(__ex);
            }//catch
        }//add_entities
    }//class
}//namespace
