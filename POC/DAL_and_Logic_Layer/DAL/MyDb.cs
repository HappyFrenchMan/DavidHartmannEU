using DAL.Repository;
using System.Collections.Generic;

namespace DAL
{
    public class MyDb
    {
        private Db_Context _context;
        private Lazy<CityRepository> _LazyCityRepository;
        private Lazy<FirmRepository> _LazyFirmRepository;

        public MyDb()
        {
            _context = new Db_Context();
            _LazyCityRepository = new Lazy<CityRepository>(() => new CityRepository(_context) );
            _LazyFirmRepository = new Lazy<FirmRepository>(() => new FirmRepository(_context) );
        }//MyDatabase

        public CityRepository cityRepo
        {
            get
            {            
                return _LazyCityRepository.Value;
            }
        }//cityRepo

        public FirmRepository firmRepo
        {
            get
            {
                return _LazyFirmRepository.Value;
            }
        }//firmRepo

    }//class
}//namespace
