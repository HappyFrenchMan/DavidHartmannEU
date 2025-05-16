using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.USER.Entity
{
    [Table("USR.T_User")]
    public class User
    {
        [Column("USR_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [Column("USR_Login")]
        [MaxLength(32)]
        public string Login { get; set; }

        [Unicode(true)]
        [Column("USR_FirstName")]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Unicode(true)]
        [Column("USR_LastName")]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Column("FK_Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }//class
}//namespace
