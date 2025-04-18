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
        public string JobName { get; set; }

        [Column("JOB_IsDev")]
        public bool IsDev { get; set; }
        [Column("JOB_IsAnalyst")]
        public bool IsAnalyst { get; set; }
        [Column("JOB_IsManager")]
        public bool IsManager { get; set; }
        [Column("JOB_IsCP")]
        public bool IsCP { get; set; }
        [Column("JOB_IsTechnicalExpert")]
        public bool IsTechnicalExpert { get; set; }


        [Unicode(true)]
        [MaxLength(255)]
        [Column("JOB_JobStatus")]
        public string JobStatus { get; set; }

        public enum CONST_ENUM_JOB_STATUS
        {
            EMPLOYEE, PRESTA, ALTERNANT, STAGIAIRE 
        }
        public enum CONST_ENUM_JOB_ROLE
        {
            DEV, ANALYST, MANAGER, CP, EXPERT
        }

        public bool Is_Statut_Salarie {
            get { return JobStatus == CONST_ENUM_JOB_STATUS.EMPLOYEE.ToString(); }
        }
        public bool Is_Statut_Prestataire
        {
            get { return JobStatus == CONST_ENUM_JOB_STATUS.PRESTA.ToString(); }
        }
        public bool Is_Statut_Alternant
        {
            get { return JobStatus == CONST_ENUM_JOB_STATUS.ALTERNANT.ToString(); }
        }
        public bool Is_Statut_Stagiaire
        {
            get { return JobStatus == CONST_ENUM_JOB_STATUS.STAGIAIRE.ToString(); }
        }

        public override string ToString()
        {
            string __strResult = JobName;
            if (IsAnalyst)
            {
                __strResult += "/Analyse";
            }
            if (IsManager)
            {
                __strResult += "/Encadrement";
            }
            if (IsCP)
            {
                __strResult += "/GestionProjet";
            }
            if (IsTechnicalExpert)
            {
                __strResult += "/ExpertiseTechnique";
            }
            if (IsDev)
            {
                __strResult += "/Développement";
            }
            if (Is_Statut_Salarie)
            {
                __strResult += "/Statut:Salarié";
            }
            if (Is_Statut_Alternant)
            {
                __strResult += "/Statut:Alternant";
            }
            if (Is_Statut_Prestataire)
            {
                __strResult += "/Statut:Prestataire";
            }
            if (Is_Statut_Stagiaire)
            {
                __strResult += "/Statut:Stagiaire";
            }
            return __strResult;
        }
    }
}
