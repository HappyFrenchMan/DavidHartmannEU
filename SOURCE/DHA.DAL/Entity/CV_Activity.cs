using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.Entity
{
    [Table("CV.T_Activity")]
    public class CV_Activity
    {
        [Column("ACT_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [MaxLength(100)]
        [Column("ACT_Code")]
        public string Code { get; set; }

        [Unicode(true)]
        [MaxLength(255)]
        [Column("ACT_ProjectName")]
        public string ProjectName { get; set; }

        [Unicode(true)]
        [MaxLength(255)]
        [Column("ACT_SubProjectName")]
        public string SubProjectName { get; set; }

        public ICollection<CV_ActivityDetail> ActivityDetails { get; }
             = new List<CV_ActivityDetail>();       

        public ICollection<CV_ActivitySkill> ActivitySkills { get; }
             = new List<CV_ActivitySkill>();

        [Column("FK_JobId")]
        public int JobId { get; set; }
        public CV_Job Job { get; set; } = null!;

        [Column("FK_ExperienceId")]
        public int ExperienceId { get; set; }
        public CV_Experience Experience { get; set; } = null!;
    }//class
}//namespace
