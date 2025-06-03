using DHA.DAL;
using DHA.DAL.CrossRepo;
using DHA.DAL.Repository;
using System.Collections.Generic;

namespace DAH.DAL
{
    public class MyDb
    {
        private Db_Context _context;

        //repo
        private Lazy<CV_ActivityDetailRepository> _lazy_CV_ActivityDetailRepository;
        private Lazy<CV_ActivityRepository> _lazy_CV_ActivityRepository;
        private Lazy<CV_ActivitySkillRepository> _lazy_CV_ActivitySkillRepository;
        private Lazy<CV_CityRepository> _lazy_CV_CityRepository;
        private Lazy<CV_ContractTypeRepository> _lazy_CV_ContractTypeRepository;
        private Lazy<CV_ExperiencePeriodRepository> _lazy_CV_ExperiencePeriodRepository;
        private Lazy<CV_ExperienceRepository> _lazy_CV_ExperienceRepository;
        private Lazy<CV_FirmRepository> _lazy_CV_FirmRepository;
        private Lazy<CV_JobKeyRoleRepository> _lazy_CV_JobKeyRoleRepository;
        private Lazy<CV_JobRepository> _lazy_CV_JobRepository;
        private Lazy<CV_KeyRoleRepository> _lazy_CV_KeyRoleRepository;
        private Lazy<CV_LanguageSpokenRepository> _lazy_CV_LanguageSpokenRepository;
        private Lazy<CV_SkillRepository> _lazy_CV_SkillRepository;
        private Lazy<CV_SkillTypeRepository> _lazy_CV_SkillTypeRepository;
        private Lazy<CV_TrainingRepository> _lazy_CV_TrainingRepository;
        private Lazy<CV_TrainingDetailRepository> _lazy_CV_TrainingDetailRepository;
        private Lazy<DOC_DocContentTypeRepository> _lazy_DOC_DocContentTypeRepository;
        private Lazy<DOC_DocumentContentRepository> _lazy_DOC_DocumentContentRepository;
        private Lazy<DOC_LinkRepository> _lazy_DOC_LinkRepository;
        private Lazy<DOC_SubTypeDocumentRepository> _lazy_DOC_SubTypeDocumentRepository;
        private Lazy<DOC_TypeDocumentRepository> _lazy_DOC_TypeDocumentRepository;
        private Lazy<DOC_WebDocumentRepository> _lazy_DOC_WebDocumentRepository;
        private Lazy<USR_RoleRepository> _lazy_USR_RoleRepository;
        private Lazy<USR_UserRepository> _lazy_USR_UserRepository;

        //crossrepo
        private Lazy<CV_StatCR> _lazy_CVStatCR;
        private Lazy<CV_FeedCR> _lazy_CVFeedCR;

        public MyDb()
        {
            _context = new Db_Context();

            //repo
            _lazy_CV_ActivityDetailRepository = new Lazy<CV_ActivityDetailRepository>(() => new CV_ActivityDetailRepository(_context));
            _lazy_CV_ActivityRepository = new Lazy<CV_ActivityRepository>(() => new CV_ActivityRepository(_context));
            _lazy_CV_ActivitySkillRepository = new Lazy<CV_ActivitySkillRepository>(() => new CV_ActivitySkillRepository(_context));
            _lazy_CV_CityRepository = new Lazy<CV_CityRepository>(() => new CV_CityRepository(_context));
            _lazy_CV_ContractTypeRepository = new Lazy<CV_ContractTypeRepository>(() => new CV_ContractTypeRepository(_context));
            _lazy_CV_ExperiencePeriodRepository = new Lazy<CV_ExperiencePeriodRepository>(() => new CV_ExperiencePeriodRepository(_context));
            _lazy_CV_ExperienceRepository = new Lazy<CV_ExperienceRepository>(() => new CV_ExperienceRepository(_context));
            _lazy_CV_FirmRepository = new Lazy<CV_FirmRepository>(() => new CV_FirmRepository(_context));
            _lazy_CV_JobKeyRoleRepository = new Lazy<CV_JobKeyRoleRepository>(() => new CV_JobKeyRoleRepository(_context));
            _lazy_CV_JobRepository = new Lazy<CV_JobRepository>(() => new CV_JobRepository(_context));
            _lazy_CV_KeyRoleRepository = new Lazy<CV_KeyRoleRepository>(() => new CV_KeyRoleRepository(_context));
            _lazy_CV_LanguageSpokenRepository = new Lazy<CV_LanguageSpokenRepository>(() => new CV_LanguageSpokenRepository(_context));
            _lazy_CV_SkillRepository = new Lazy<CV_SkillRepository>(() => new CV_SkillRepository(_context));
            _lazy_CV_SkillTypeRepository = new Lazy<CV_SkillTypeRepository>(() => new CV_SkillTypeRepository(_context));
            _lazy_CV_TrainingDetailRepository = new Lazy<CV_TrainingDetailRepository>(() => new CV_TrainingDetailRepository(_context));
            _lazy_CV_TrainingRepository = new Lazy<CV_TrainingRepository>(() => new CV_TrainingRepository(_context));
            _lazy_DOC_DocContentTypeRepository = new Lazy<DOC_DocContentTypeRepository>(() => new DOC_DocContentTypeRepository(_context));
            _lazy_DOC_DocumentContentRepository = new Lazy<DOC_DocumentContentRepository>(() => new DOC_DocumentContentRepository(_context));
            _lazy_DOC_LinkRepository = new Lazy<DOC_LinkRepository>(() => new DOC_LinkRepository(_context));
            _lazy_DOC_SubTypeDocumentRepository = new Lazy<DOC_SubTypeDocumentRepository>(() => new DOC_SubTypeDocumentRepository(_context));
            _lazy_DOC_TypeDocumentRepository = new Lazy<DOC_TypeDocumentRepository>(() => new DOC_TypeDocumentRepository(_context));
            _lazy_DOC_WebDocumentRepository = new Lazy<DOC_WebDocumentRepository>(() => new DOC_WebDocumentRepository(_context));
            _lazy_USR_RoleRepository = new Lazy<USR_RoleRepository>(() => new USR_RoleRepository(_context));
            _lazy_USR_UserRepository = new Lazy<USR_UserRepository>(() => new USR_UserRepository(_context));

            //crossrepo
            _lazy_CVFeedCR = new Lazy<CV_FeedCR>(() => new CV_FeedCR(this));
            _lazy_CVStatCR = new Lazy<CV_StatCR>(() => new CV_StatCR(this));
        }//MyDatabase

        //repo
        public CV_ActivityDetailRepository CVActivityDetailRepository { get { return _lazy_CV_ActivityDetailRepository.Value; } }
        public CV_ActivityRepository CVActivityRepository { get { return _lazy_CV_ActivityRepository.Value; } }
        public CV_ActivitySkillRepository CVActivitySkillRepository { get { return _lazy_CV_ActivitySkillRepository.Value; } }
        public CV_CityRepository CVCityRepository { get { return _lazy_CV_CityRepository.Value; } }
        public CV_ContractTypeRepository CVContractTypeRepository { get { return _lazy_CV_ContractTypeRepository.Value; } }
        public CV_ExperiencePeriodRepository CVExperiencePeriodRepository { get { return _lazy_CV_ExperiencePeriodRepository.Value; } }
        public CV_ExperienceRepository CVExperienceRepository { get { return _lazy_CV_ExperienceRepository.Value; } }
        public CV_FirmRepository CVFirmRepository { get { return _lazy_CV_FirmRepository.Value; } }
        public CV_JobKeyRoleRepository CVJobKeyRoleRepository { get { return _lazy_CV_JobKeyRoleRepository.Value; } }
        public CV_JobRepository CVJobRepository { get { return _lazy_CV_JobRepository.Value; } }
        public CV_KeyRoleRepository CVKeyRoleRepository { get { return _lazy_CV_KeyRoleRepository.Value; } }
        public CV_LanguageSpokenRepository CVLanguageSpokenRepository { get { return _lazy_CV_LanguageSpokenRepository.Value; } }
        public CV_SkillRepository CVSkillRepository { get { return _lazy_CV_SkillRepository.Value; } }
        public CV_SkillTypeRepository CVSkillTypeRepository { get { return _lazy_CV_SkillTypeRepository.Value; } }
        public CV_TrainingRepository CVTrainingRepository { get { return _lazy_CV_TrainingRepository.Value; } }
        public CV_TrainingDetailRepository CVTrainingDetailRepository { get { return _lazy_CV_TrainingDetailRepository.Value; } }
        public DOC_DocContentTypeRepository DOCDocContentTypeRepository { get { return _lazy_DOC_DocContentTypeRepository.Value; } }
        public DOC_DocumentContentRepository DOCDocumentContentRepository { get { return _lazy_DOC_DocumentContentRepository.Value; } }
        public DOC_LinkRepository DOCLinkRepository { get { return _lazy_DOC_LinkRepository.Value; } }
        public DOC_SubTypeDocumentRepository DOCSubTypeDocumentRepository { get { return _lazy_DOC_SubTypeDocumentRepository.Value; } }
        public DOC_TypeDocumentRepository DOCTypeDocumentRepository { get { return _lazy_DOC_TypeDocumentRepository.Value; } }
        public DOC_WebDocumentRepository DOCWebDocumentRepository { get { return _lazy_DOC_WebDocumentRepository.Value; } }
        public USR_RoleRepository USRRoleRepository { get { return _lazy_USR_RoleRepository.Value; } }
        public USR_UserRepository USRUserRepository { get { return _lazy_USR_UserRepository.Value; } }

        //crossrepo
        public CV_FeedCR  CVFeedCR { get { return _lazy_CVFeedCR.Value; } }
        public CV_StatCR CVStatCR { get { return _lazy_CVStatCR.Value; } }
    }//class
}//namespace
