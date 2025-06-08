using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.Entity
{
    [Table("CV.T_Ref_Skill")]
    public class CV_Skill
    {
        [Column("SKI_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [MaxLength(64)]
        [Column("SKI_Key")]
        public string Key { get; set; }


        [Unicode(true)]
        [MaxLength(128)]
        [Column("SKI_Name")]
        public string Name { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("SKI_Detail")]
        public string? Detail { get; set; }


        [Column("FK_SkillType_Id")]
        public int Skill_TypeId { get; set; }
        public CV_SkillType? Type { get; set; }

        //public ICollection<Activity> Activities { get; }
        //    = new List<Activity>();
        public ICollection<CV_ActivitySkill> ActivitySkills { get; }
            = new List<CV_ActivitySkill>();
    }
}
