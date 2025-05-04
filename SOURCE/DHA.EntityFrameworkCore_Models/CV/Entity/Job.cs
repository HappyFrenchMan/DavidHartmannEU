using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHA.EntityFrameworkCore_Models.CV.Entity
{
    [Table("CV.T_Jobs")]
    public class Job
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
        public ContractType ContractType { get; set; }

        public ICollection<JobKeyRole> JobKeyRoles { get; }  = new List<JobKeyRole>();        

    }
}
