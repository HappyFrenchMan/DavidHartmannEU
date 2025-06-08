using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.Entity
{
    [Table("CV.T_ActivityDetail")]
    public class CV_ActivityDetail
    {
        [Column("ACD_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [MaxLength(255)]
        [Column("ACD_Detail")]
        public string Detail { get; set; }

        [Column("FK_ActivityId")]
        public int ActivityId { get; set; }
        public CV_Activity Activity { get; set; } = null!;
    }//class
}//namespace