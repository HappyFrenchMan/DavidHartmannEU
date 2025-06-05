using DHA.DAL;
using DHA.DAL.Repository;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;

namespace DAH.DAL
{
    public class MyDb : AMyDbContext
    {
        private Lazy<CV_Select_Repo> _lazy_CV_SelectRepo;
        private Lazy<CV_Update_Repo> _lazy_CV_UpdateRepo;
        private Lazy<DOC_Update_Repo > _lazy_DOC_UpdateRepo;
        public CV_Select_Repo RepoCVSelect { get { return _lazy_CV_SelectRepo.Value; } }
        public CV_Update_Repo RepoCVUpdate { get { return _lazy_CV_UpdateRepo.Value; } }
        public DOC_Update_Repo RepoDOCUpdate { get { return _lazy_DOC_UpdateRepo.Value; } }

        public MyDb() : base()
        {
            _lazy_CV_SelectRepo = new Lazy<CV_Select_Repo>(() => new CV_Select_Repo(this));
            _lazy_CV_UpdateRepo = new Lazy<CV_Update_Repo>(() => new CV_Update_Repo(this));
            _lazy_DOC_UpdateRepo = new Lazy<DOC_Update_Repo>(() => new DOC_Update_Repo(this));
        }//MyDb

    }//class
}//namespace
