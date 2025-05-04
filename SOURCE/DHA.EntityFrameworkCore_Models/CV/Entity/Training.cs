using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.EntityFrameworkCore_Models.CV.Entity
{
    [Table("CV.T_Training")]
    public class Training
    {
        [Column("TRA_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("TRA_Year")]
        public int Year { get; set; }

        [Column("FK_CityId")]
        public int? CityId { get; set; }
        public City? Location { get; set; }

        public ICollection<TrainingDetail> TrainingDetails { get; }
            = new List<TrainingDetail>();
    }//Training
}//namespace
