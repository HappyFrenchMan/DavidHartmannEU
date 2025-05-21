using DHA.DAL;
using DHA.DAL.Repository;
using System.Collections.Generic;

namespace DAH.DAL
{
    public class MyDb
    {
        private Db_Context _context;
        private Lazy<CV_CityRepository> _LazyCVCityRepository;
        private Lazy<CV_FirmRepository> _LazyCVFirmRepository;
        private Lazy<CV_ContractTypeRepository> _LazyContractTypeRepository;

        public MyDb()
        {
            _context = new Db_Context();

            _LazyCVCityRepository = new Lazy<CV_CityRepository>(() => new CV_CityRepository(_context) );
            _LazyCVFirmRepository = new Lazy<CV_FirmRepository>(() => new CV_FirmRepository(_context) );
            _LazyContractTypeRepository = new Lazy<CV_ContractTypeRepository>(() => new CV_ContractTypeRepository(_context));
        }//MyDatabase

        public CV_CityRepository CvCityRepo
        {
            get
            {            
                return _LazyCVCityRepository.Value;
            }
        }//cityRepo

        public CV_FirmRepository CvFirmRepo
        {
            get
            {
                return _LazyCVFirmRepository.Value;
            }
        }//firmRepo

        public CV_ContractTypeRepository CvContractTypeRepo
        {
            get
            {
                return _LazyContractTypeRepository.Value;
            }
        }//CvContractTypeRepo

    }//class
}//namespace
