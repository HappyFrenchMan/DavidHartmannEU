using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.USER.Entity
{
    [Table("USR.T_Ref_Role")]
    public class Role
    {
        [Column("ROL_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [Column("ROL_Code")]
        [MaxLength(32)]
        public string Code { get; set; }
    }//class
}//namespace
