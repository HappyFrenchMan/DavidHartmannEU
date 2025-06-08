using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.Entity
{
    [Table("CV.J_JobKeyRole")]
    public class CV_JobKeyRole
    {
        [Column("JRO_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("FK_JobId")]
        public int JobId { get; set; }
        public CV_Job Job { get; set; } = null!;

        [Column("FK_KeyRoleKey")]
        public string KeyRoleKey { get; set; }
        public CV_KeyRole KeyRole { get; set; } = null!;
    }//class
}
