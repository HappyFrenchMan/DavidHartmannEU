using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.CV.Entity
{
    [Table("CV.T_Activity")]
    public class Activity
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

        public ICollection<ActivityDetail> ActivityDetails { get; }
             = new List<ActivityDetail>();       

        public ICollection<ActivitySkill> ActivitySkills { get; }
             = new List<ActivitySkill>();

        [Column("FK_JobId")]
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;

        [Column("FK_ExperienceId")]
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; } = null!;
    }//class
}//namespace
