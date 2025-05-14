using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class FirmBM
    {

        public int ID { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Sector { get; set; }

        public CityBM CityBM { get; set; }
    }
}
