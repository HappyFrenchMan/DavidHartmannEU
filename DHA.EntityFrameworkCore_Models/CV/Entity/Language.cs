using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.EntityFrameworkCore_Models.CV.Entity
{
    [Table("CV.T_Ref_Language")]
    public class Language
    {
        [Column("LAN_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("LAN_Code")]
        public string Code { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("LAN_Name")]
        public string Name { get; set; }

    }
}
