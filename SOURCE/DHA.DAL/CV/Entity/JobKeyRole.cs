using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.CV.Entity
{
    [Table("CV.J_JobKeyRole")]
    public class JobKeyRole
    {
        [Column("JRO_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("FK_JobId")]
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;

        [Column("FK_KeyRoleKey")]
        public string KeyRoleKey { get; set; }
        public KeyRole KeyRole { get; set; } = null!;
    }//class
}
