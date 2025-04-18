using DHA.EntityFrameworkCore_Models.CV.DAO;
using DHA.EntityFrameworkCore_Models.CV.Entity;

namespace DHA.EntityFrameworkCore_Models.Initializer.StaticConstructor.CV
{
    public static class Job_Init
    {
        public static int Init_Job_Stagiaire_DEV_ASP()
        {
            return MyJobs.add(
                "Stagiaire Développeur ASP",
                Job.CONST_ENUM_JOB_STATUS.STAGIAIRE,
                Job.CONST_ENUM_JOB_ROLE.DEV);
        }//Init_Job_Stagiaire_DEV_ASP

        public static int Init_Job_Stagiaire_DEV()
        {
            return MyJobs.add(
                "Stagiaire Développeur",
                Job.CONST_ENUM_JOB_STATUS.STAGIAIRE,
                Job.CONST_ENUM_JOB_ROLE.DEV);
        }//Init_Job_Stagiaire_DEV


        public static int Init_Job_Developpeur_Alternant()
        {
            return MyJobs.add(
                "Développeur ( Contrat d'apprentissage en alternance )",
                Job.CONST_ENUM_JOB_STATUS.ALTERNANT,
                Job.CONST_ENUM_JOB_ROLE.DEV);
        }//Init_Job_Developpeur_Alternant

        public static int Init_Job_Dev_Expert_Technique_Prestataire()
        {
            return MyJobs.add(
                "Développeur et Expert Technique",
                Job.CONST_ENUM_JOB_STATUS.PRESTA,
                Job.CONST_ENUM_JOB_ROLE.DEV,
                Job.CONST_ENUM_JOB_ROLE.EXPERT);
        }//Init_Job_Dev_Expert_Technique_Prestataire

        public static int Init_Job_Dev_Analyse_Prestataire()
        {
            return MyJobs.add(
                "Développeur et Analyste",
                Job.CONST_ENUM_JOB_STATUS.PRESTA,
                Job.CONST_ENUM_JOB_ROLE.DEV,
                Job.CONST_ENUM_JOB_ROLE.ANALYST);
        }//Init_Job_Dev_Analyse_Prestataire


        public static int Init_Job_Expert_Technique_Interne()
        {
            return MyJobs.add(
                "Expert Technique Interne",
                Job.CONST_ENUM_JOB_STATUS.EMPLOYEE,
                Job.CONST_ENUM_JOB_ROLE.DEV,
                Job.CONST_ENUM_JOB_ROLE.ANALYST,
                Job.CONST_ENUM_JOB_ROLE.EXPERT);
        }//Init_Job_Expert_Technique_Interne

    }//class
}//namespace
