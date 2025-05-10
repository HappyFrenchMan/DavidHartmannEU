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

        private CityRepository cityRepo
        {
            get
            {
                if (_cityRepository == null) { _cityRepository = new CityRepository(_context); }
                return _cityRepository;
            }
        }
        private FirmRepository firmRepo
        {
            get
            {
                if (_firmRepository == null) { _firmRepository = new FirmRepository(_context); }
                return _firmRepository;
            }
        }

    }//class
}//namespace
