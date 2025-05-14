using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public partial class CityBM
    {
        public int ID { get; set; }
        public int PostalCode { get; set; }
        public string CityName { get; set; }
        public string Area { get; set; }
        public string Department { get; set; }



    }
}
