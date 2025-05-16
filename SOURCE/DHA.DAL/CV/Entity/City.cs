using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.CV.Entity
{
    [Table("CV.T_Ref_City")]
    public class City
    {
        [Column("CTY_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("CTY_PostalCode")]
        public int PostalCode { get; set; }
        
        [Unicode(true)]
        [MaxLength(128)]
        [Column("CTY_CityName")]
        public string CityName { get; set; }

        [Unicode(true)]
        [MaxLength(128)]
        [Column("CTY_Area")]
        public string Area { get; set; }

        [Unicode(true)]
        [MaxLength(128)]
        [Column("CTY_Department")]
        public string Department { get; set; }

        public override string ToString()
        {
            return $"{Area}-{Department}-{PostalCode}-{CityName}";
        }
    }
}
