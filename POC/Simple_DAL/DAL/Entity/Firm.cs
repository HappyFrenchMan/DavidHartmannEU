using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    [Table("T_Ref_Firm")]
    public class Firm
    {
        [Column("FIR_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("FIR_Key")]
        public string Key { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("FIR_Name")]
        public string Name { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("FIR_Sector")]
        public string Sector { get; set; }

        [Column("FK_FirmId")]
        public int CityId { get; set; }
        public Firm City { get; set; } = null;

        public override string ToString()
        {
            return $"{Name}-{Sector}";
        }//ToString
    }//class
}
