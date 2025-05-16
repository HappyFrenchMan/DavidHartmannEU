using DHA.DAL.CV.DAO;
using DHA.DAL.CV.Entity;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    public static class Job_Init
    {
        public static int Init_Job_Stagiaire_DEV_ASP()
        {
            return MyJobs.add(
                "Stagiaire Développeur ASP",
                Ref_Init_Const.CT_STAGIAIRE_CODE,
                Ref_Init_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Stagiaire_DEV_ASP

        public static int Init_Job_Stagiaire_DEV()
        {
            return MyJobs.add(
                "Stagiaire Développeur",
                Ref_Init_Const.CT_STAGIAIRE_CODE,
                Ref_Init_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Stagiaire_DEV


        public static int Init_Job_Developpeur_Alternant()
        {
            return MyJobs.add(
                "Développeur ( Contrat d'apprentissage en alternance )",
                Ref_Init_Const.CT_ALTERNANT_CODE,
                Ref_Init_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Developpeur_Alternant

        public static int Init_Job_Dev_Expert_Technique_Prestataire()
        {
            return MyJobs.add(
                "Développeur et Expert Technique",
                Ref_Init_Const.CT_PRESTA_CODE,
                Ref_Init_Const.KR_DEVELOPPEUR_CODE,
                Ref_Init_Const.KR_EXPERTTECH_CODE);
        }//Init_Job_Dev_Expert_Technique_Prestataire

        public static int Init_Job_Dev_Analyse_Prestataire()
        {
            return MyJobs.add(
                "Développeur et Analyste",
                Ref_Init_Const.CT_PRESTA_CODE,
                Ref_Init_Const.KR_DEVELOPPEUR_CODE,
                Ref_Init_Const.KR_ANALYST_CODE);
        }//Init_Job_Dev_Analyse_Prestataire


        public static int Init_Job_Expert_Technique_Interne()
        {
            return MyJobs.add(
                "Expert Technique Interne",
                Ref_Init_Const.CT_EMPLOYE_CODE,
                Ref_Init_Const.KR_DEVELOPPEUR_CODE,
                Ref_Init_Const.KR_ANALYST_CODE,
                Ref_Init_Const.KR_EXPERTTECH_CODE);
        }//Init_Job_Expert_Technique_Interne

    }//class
}//namespace
