using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.Entity
{
    [Table("CV.T_Ref_SkillType")]
    public class CV_SkillType
    {
        [Column("SKT_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Unicode(true)]
        [MaxLength(128)]
        [Column("SKT_Key")]
        public string Key { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("SKT_Description")]
        public string Description { get; set; }

    }
}
