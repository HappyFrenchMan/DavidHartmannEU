using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Entity
{
    [Table("CV.J_ActivitySkill")]
    public class CV_ActivitySkill
    {
        [Column("ACS_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("FK_ActivityId")]
        public int ActivityId { get; set; }
        public CV_Activity Activity { get; set; } = null!;

        [Column("FK_SkillId")]
        public int SkillId { get; set; }        
        public CV_Skill Skill { get; set; } = null!;
    }//class
}//namespace
