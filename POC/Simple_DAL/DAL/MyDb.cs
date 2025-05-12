using DAL.Repository;

namespace DAL
{
    public class MyDb
    {
        private Db_Context _context;
        private CityRepository _cityRepository;
        private FirmRepository _firmRepository;

        public MyDb()
        {
            _context = new Db_Context();
        }//MyDatabase

        public CityRepository cityRepo
        {
            get
            {
                if (_cityRepository == null) { _cityRepository = new CityRepository(_context); }
                return _cityRepository;
            }
        }//cityRepo

        public FirmRepository firmRepo
        {
            get
            {
                if (_firmRepository == null) { _firmRepository = new FirmRepository(_context); }
                return _firmRepository;
            }
        }//firmRepo

    }//class
}//namespace
