using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.CV.Entity
{
    [Table("CV.T_Experience")]
    public class Experience
    {
        [Column("EXP_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [MaxLength(128)]
        [Column("EXP_Name")]
        public string Name { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("EXP_Description")]
        public string? Description { get; set; }        

        public ExperiencePeriod ExperiencePeriod { get; set; }

        [Column("FK_CityId")]
        public int CityId { get; set; }
        public City City { get; set; }

        [Column("FK_FirmId")]
        public int FirmId { get; set; }
        public Firm Firm { get; set; }

        public ICollection<Activity> Activities { get; }
             = new List<Activity>();

    }//class
}//namespace
