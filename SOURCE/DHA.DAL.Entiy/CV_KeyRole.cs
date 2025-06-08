using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.Entity
{
    [Table("CV.T_Ref_KeyRole")]
    public class CV_KeyRole
    {
        [Unicode(true)]
        [MaxLength(255)]
        [Column("KRO_Key")]
        [Key]
        public string Key { get; set; }

        [Unicode(true)]
        [MaxLength(255)]
        [Column("KRO_Name")]
        public string Name { get; set; }
    }
}
