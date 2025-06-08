using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace DHA.DAL.Entity
{

    [Table("CV.T_TrainingDetail")]
    public class CV_TrainingDetail
    {
        [Column("TRD_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("TRD_Detail")]
        public string Detail { get; set; }

        [Column("FK_TrainingId")]
        public int TrainingId { get; set; } 
        public CV_Training Training { get; set; } = null!;

    }
}
