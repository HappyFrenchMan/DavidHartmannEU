using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.DAL.Entity
{
    [Table("CV.T_Jobs")]
    public class CV_Job
    {
        [Column("JOB_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unicode(true)]
        [MaxLength(255)]
        [Column("JOB_JobName")]
        public string Name { get; set; }

        [Column("FK_ContratTypeKey")]
        public string ContractTypeKey { get; set; }
        public CV_ContractType ContractType { get; set; }

        public ICollection<CV_JobKeyRole> JobKeyRoles { get; }  = new List<CV_JobKeyRole>();

        public string JobKeyRolesToString()
        {
            string lStrResult = string.Empty;
            foreach (CV_JobKeyRole jkr in JobKeyRoles)
            {
                lStrResult += jkr.KeyRole.Name + "-";
            }
            return lStrResult.Substring(0, lStrResult.Length - 1);
        }

        public override string ToString()
        {
            return $"{Name}";
            //-{ContractType.Name}";
            //{JobKeyRolesToString}";
        }//ToString
    }//class
}//namespace
