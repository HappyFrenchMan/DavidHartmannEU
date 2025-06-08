using DHA.DAL;
using DHA.DAL.Repository;

namespace DAH.DAL
{
    public class MyDb
    {
        private MyDbContext _myDbContext;

        private Lazy<CV_Select_Repo> _lazy_CV_SelectRepo;
        private Lazy<CV_Update_Repo> _lazy_CV_UpdateRepo;
        private Lazy<DOC_Update_Repo > _lazy_DOC_UpdateRepo;
        public CV_Select_Repo RepoCVSelect { get { return _lazy_CV_SelectRepo.Value; } }
        public CV_Update_Repo RepoCVUpdate { get { return _lazy_CV_UpdateRepo.Value; } }
        public DOC_Update_Repo RepoDOCUpdate { get { return _lazy_DOC_UpdateRepo.Value; } }

        public MyDb()
        {
            _myDbContext = new MyDbContext();

            _lazy_CV_SelectRepo = new Lazy<CV_Select_Repo>(() => new CV_Select_Repo(_myDbContext));
            _lazy_CV_UpdateRepo = new Lazy<CV_Update_Repo>(() => new CV_Update_Repo(_myDbContext));
            _lazy_DOC_UpdateRepo = new Lazy<DOC_Update_Repo>(() => new DOC_Update_Repo(_myDbContext));
        }//MyDb

    }//class
}//namespace
