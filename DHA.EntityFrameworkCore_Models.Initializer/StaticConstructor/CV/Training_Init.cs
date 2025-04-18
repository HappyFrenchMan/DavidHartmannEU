using DHA.EntityFrameworkCore_Models.CV.DAO;

namespace DHA.EntityFrameworkCore_Models.Initializer.StaticConstructor.CV
{
    class Training_Init
    {
        public static void Init_Training()
        {

            MyTraining.add(91600, 1999,
                "BAC ES  - Spécialité Mathématiques");

            MyTraining.add(78140, 2001,
                "DUT (Diplôme universitaire de technologie) informatique",
                "Projet d'étude : Progiciel de gestion en Java");

            MyTraining.add(91000, 2003,
                "Licence et Maîtrise MIAGE",
                "(Méthodes informatiques appliquées à la gestion)",
                "Formation en alternance. ",
                "( Rythme de l’alternance 1 mois / 1 mois )",
                "Entreprise: Servantès(78)");

            MyTraining.add(91000, 2004,
                "DESS Documentaire et Multimédia",
                "Nouvelles technologies (XML,XSL)",
                "Gestion Documentaire (Workflow,Gestion de contenu)",
                "Multimédia et Réseau (Streaming,TCP/IP)",
                "Projet d’étude : La plateforme J2EE JBoss");
    
        }//Init_Training

    }//class
}//namespace
