using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.Entity
{
    [Table("CV.T_Training")]
    public class CV_Training
    {
        [Column("TRA_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("TRA_Year")]
        public int Year { get; set; }

        [Column("FK_CityId")]
        public int? CityId { get; set; }
        public CV_City? Location { get; set; }

        public ICollection<CV_TrainingDetail> TrainingDetails { get; }
            = new List<CV_TrainingDetail>();
    }//Training
}//namespace
