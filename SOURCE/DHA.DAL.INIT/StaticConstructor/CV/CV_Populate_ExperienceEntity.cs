using DAH.DAL;
using DHA.DAL.Entity;
using c = DHA.DAL.INIT.StaticConstructor.CV.CV_DAL_Const;

namespace DHA.DAL.INIT.StaticConstructor.CV
{
    class CV_Populate_ExperienceEntity
    {           
        private static int S_Int_JobID_StaigiaireDevASP;
        private static int S_Int_JobID_DevAlternant;
        private static int S_Int_JobID_DevStagiaire;
        private static int S_Int_JobID_DevExpertTechPresta;
        private static int S_Int_JobID_DevAnalystePresta;
        private static int S_Int_JobID_Expert_Technique_Interne;

        public static void Init(MyDb pMyDb)
        {
            pMyDb.

            S_Int_JobID_StaigiaireDevASP = Init_Job_Stagiaire_DEV_ASP(pMyDb);
            S_Int_JobID_DevAlternant = Init_Job_Developpeur_Alternant(pMyDb);
            S_Int_JobID_DevStagiaire = Init_Job_Stagiaire_DEV(pMyDb);
            S_Int_JobID_DevExpertTechPresta = Init_Job_Dev_Expert_Technique_Prestataire(pMyDb);
            S_Int_JobID_DevAnalystePresta = Init_Job_Dev_Analyse_Prestataire(pMyDb);
            S_Int_JobID_Expert_Technique_Interne = Init_Job_Expert_Technique_Interne(pMyDb);

            Init_Experience_Servantes_DUT(pMyDb);
            Init_Experience_MIAGE(pMyDb);
            Init_Experience_W4(pMyDb);
            Init_Experience_SCPP(pMyDb);
            Init_Experience_ORDRE_AVOCATS(pMyDb);
            Init_Experience_BNPP(pMyDb);
            Init_Experience_MEDIAMOBILE(pMyDb);
            Init_Experience_MAYOLY_SPINDLER(pMyDb);
            Init_Experience_HUMANIS_DGCD(pMyDb);
            Init_Experience_METSO(pMyDb);
            Init_Experience_HUMANIS_FSS(pMyDb);
            Init_Experience_HUMANIS_AGD(pMyDb);
            Init_Experience_AGAP2(pMyDb);

        }//Init

        private static int Init_Job_Stagiaire_DEV_ASP(MyDb pMyDb)
        {
            return pMyDb.RepoCVUpdate.add_job(
                "Stagiaire Développeur ASP",
                CV_DAL_Const.CT_STAGIAIRE_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Stagiaire_DEV_ASP

        private static int Init_Job_Stagiaire_DEV(MyDb pMyDb)
        {
            return pMyDb.RepoCVUpdate.add_job(
                "Stagiaire Développeur",
                CV_DAL_Const.CT_STAGIAIRE_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Stagiaire_DEV

        private static int Init_Job_Developpeur_Alternant(MyDb pMyDb)
        {
            return pMyDb.RepoCVUpdate.add_job(
                "Développeur ( Contrat d'apprentissage en alternance )",
                CV_DAL_Const.CT_ALTERNANT_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Developpeur_Alternant

        private static int Init_Job_Dev_Expert_Technique_Prestataire(MyDb pMyDb)
        {
            return pMyDb.RepoCVUpdate.add_job(
                "Développeur et Expert Technique",
                CV_DAL_Const.CT_PRESTA_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE,
                CV_DAL_Const.KR_EXPERTTECH_CODE);
        }//Init_Job_Dev_Expert_Technique_Prestataire

        private static int Init_Job_Dev_Analyse_Prestataire(MyDb pMyDb)
        {
            return pMyDb.RepoCVUpdate.add_job(
                "Développeur et Analyste",
                CV_DAL_Const.CT_PRESTA_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE,
                CV_DAL_Const.KR_ANALYST_CODE);
        }//Init_Job_Dev_Analyse_Prestataire

        private static int Init_Job_Expert_Technique_Interne(MyDb pMyDb)
        {
            return pMyDb.RepoCVUpdate.add_job(
                "Expert Technique Interne",
                CV_DAL_Const.CT_EMPLOYE_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE,
                CV_DAL_Const.KR_ANALYST_CODE,
                CV_DAL_Const.KR_EXPERTTECH_CODE);
        }//Init_Job_Expert_Technique_Interne

        private static int Init_Experience_Servantes_DUT(MyDb pMyDb)
        {
            CV_Firm? lFirmServantes = Get_Firm(pMyDb,c.FI_SERVANTES_KEY );

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience
                ("SERVANTES",
               "Stage de DUT",
                78220,
                lFirmServantes.Key,
                2001, 3,
                2001, 9);

            int lIntActivityId =
                pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_StaigiaireDevASP,
                "ELECTRE", "Réalisation d’un site intranet de gestion des congés Payés.", "",
                    "Apprentissage de l'ASP.");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "SQLS", "W2000", "ASP");

            lIntActivityId =
                      pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_StaigiaireDevASP,
                      "PROJ", "Réalisation d'un site intranet pour la gestion de projet", "",
                          "Définition des besoins.",
                          "Réalisation de la charte graphique.",
                          "Maintenance et évolution.");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "SQLS", "W2000", "ASP");

            return 0;

        }//Init_Experience_Servantes_DUT



        private static void Init_Experience_MIAGE(MyDb pMyDb)
        {
            CV_Firm? lFirmServantes = Get_Firm(pMyDb, c.FI_SERVANTES_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "SERVANTES",
               "Licence et Maîtrise MIAGE en alternance, Faculté d'Evry",
                78220,
                lFirmServantes.Key,
                2001, 10,
                2003, 10);
            int lIntActivityId =
                pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAlternant,
                "FAURECIA", "Plateforme Intranet d’échange de documents (fournisseurs, clients) :",
                "", "Réalisation du module de téléchargement des documents en base de données.",
                "Réalisation de la charte graphique.");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "SQLS", "W2000", "ASP.NET", "C#");
            lIntActivityId =
                pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAlternant,
                "ITALCEMENTI", "Réalisation d'un trombinoscope",
                "", "Développement du module d'administration.");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "SQLS", "W2000", "VBNET", "ASP.NET");
            lIntActivityId =
                pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAlternant,
                "CROIX-ROUGE", "Réalisation d'un module de génération de PDF",
                "", "Proposition d’architecture technique",
                "Dossiers de Conception Technique Détaillée",
                "Développement d'un service en Visual Basic",
                "Installation du service sur le serveur Intranet",
                "Maintenance corrective et évolutive",
                "Gestion des anomalies",
                "Responsable des livraisons");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "SQLS", "W2000", "ASP", "VB");


            lIntActivityId =
                pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAlternant,
                "MARAIS DE DOL", "Réalisation d'un progiciel de gestion.",
                "", "Création d'une nouvelle interface graphique",
                "Maintenance corrective et évolutive");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "SQLS", "W2000", "ACCESS", "VB");

        }//Init_Experience_MIAGE

        private static void Init_Experience_W4(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb,c.FI_W4_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "W4",
               "Stage de DESS ",
                91300,
                lFirm.Key,
                2004, 03,
                2004, 08);

            int lIntActivityId =
                pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevStagiaire,
                "JUNIT", "Etude de marché des outils de test de recette d’application web", "",
                "Définition des besoins de l'outil de test de recette",
                "Ecriture des tests unitaires (JAVA – JUNIT)",
                "Développement de l'outil (JAVA – JWEBUNIT – JUNIT)",
                "Mise en production de l'outil et réalisation de tests de recette du portail intranet de la société",
                "Maintenance évolutive et corrective de ce portail.");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "W2000", "C#", "ASP.NET", "JAVA", "XML", "JUNIT", "ECLIPSE");

        }//Init_Experience_W4

        private static void Init_Experience_SCPP(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_SCPP_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "SCPP",
               "Prestation pour la SCPP",
                92200,
                lFirm.Key,
                2004, 11,
                2004, 12);

            int lIntActivityId =
                pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevExpertTechPresta,
                "SCPP", "Extranet pour le MIDEM", "",
                 "Transfert de compétences",
                 "Proposition d'architecture technique",
                 "Création et mise en production de services Web pour Oracle",
                 "Mise en place de la charte graphique (CSS)",
                 "Développement de fonctionnalités");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "C#", "ASP.NET", "ORACLE", "WEBSERVICE");

        }//Init_Experience_SCPP

        private static void Init_Experience_ORDRE_AVOCATS(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_AJILON_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "AVOCATS",
               "Prestation pour le client « Ordre des Avocats à la Cour de Paris »",
                93170,
                lFirm.Key,
                2005, 1,
                2005, 4);

            int lIntActivityId =
                pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
                "AJILON", "AIDA : Gestion des Dossiers", "",
                 "Spécifications techniques détaillées",
                 "Analyse et développement d'un service Windows pour l'automatisation de l'archivage des dossiers",
                 "Documentation technique",
                 "Tests unitaires et d'intégration");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "W2000", "DOTNET", "C#", "ORACLE", "WEBSERVICE", "CR9", "VSS", "WINFORM");

        }//Init_Experience_ORDRE_AVOCATS

        private static void Init_Experience_BNPP(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb,c.FI_BNPP_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "BNPP",
               "Prestation chez BNP PARIBAS",
                93100,
                lFirm.Key,
                2005, 4,
                2007, 5);

            int lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
               "CONFIDENTIEL", "Développement d'un service Web", "",
               "Spécifications fonctionnelles détaillées",
               "Spécifications techniques détaillées",
                "Analyse et développement d'un service Web",
                "Ecriture du cahier de recette",
                "Tests unitaires",
                "Préparation de la mise en production");
            pMyDb.RepoCVUpdate          .add_skills(lIntActivityId, "WXP", "DOTNET", "C#", "ORACLE", "WEBSERVICE", "CR9");

        }//Init_Experience_BNPP

        private static void Init_Experience_MEDIAMOBILE(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_MM_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "MEDIAMOBILE",
               "Expert Technique .Net",
                94200,
                lFirm.Key,
                2007, 5,
                2009, 9);

            int lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_Expert_Technique_Interne,
               "EXPERT", "Développement d'une infrastructure", "",
               "Encadrement",
               "Documentation et pilotage projet",
               "Développement C# et Gestion de projet",
               "Construction d’une architecture pour répondre aux besoins",
               "Contact client fréquent",
               "Forte implication dans la démarche qualité de l’entreprise");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "WXP", "DOTNET", "C#", "ORACLE", "SERVICESDOTNET");

        }//Init_Experience_MEDIAMOBILE

        private static void Init_Experience_MAYOLY_SPINDLER(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_LMSP_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "MAYOLY_SPINDLER",
               "Responsable d'applications / Expert Technique AX",
                78400,
                lFirm.Key,
                2009, 9,
                2015, 6);

            int lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_Expert_Technique_Interne,
               "AX", "Expertise Technique Dynamics AX", "",
               "Installation de l'ERP Dynamics AX",
               "Paramétrage de l'ERP",
               "Surveillance des flux de l'ERP",
               "Mise en place des profils de sécurité");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "DAX", "SQLS");

            lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_Expert_Technique_Interne,
               "APPMANAGER", "Responsable d'applications", "",
               "Développement de modules de transformation de données métiers",
               "Développement d'interfaces pour les bases de données",
               "Développement d'applications Web",
               "Installation d'applications tierces et paramétrage de ces applications");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "SSIS", "OLAP", "ACCESS", "SSRS", "SQLS");

            lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_Expert_Technique_Interne,
               "SUPERVISION", "Supervision du système d'information", "",
               "Au quotidien, contrôles des échanges entre les applications",
               "Mise en place d'outils pour contrôler ces échanges");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "SQLS", "DOTNET");


        }//Init_Experience_MAYOLY_SPINDLER

        private static void Init_Experience_HUMANIS_DGCD(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_MH_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "HUMANIS",
               "Analyste MOE / Domaine « Assurance De Personnes »",
                45000,
                lFirm.Key,
                2015, 11,
                2017, 12);

            int lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
               "MOE", "Analyste Fonctionnel", "Domaine « assurance de personnes »",
               "Suivi de projet",
               "Gestion des évolutions",
               "Gestion des incidents de production",
               "Pilotage des développements");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "C#", "DOTNET", "TFS", "ASP.NET", "SQLS");

        }//Init_Experience_HUMANIS_DGCD

        private static void Init_Experience_METSO(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_METSO_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "METSO",
               "Expert technique",
                45160,
                lFirm.Key,
                2018, 3,
                2019, 3);

            int lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevExpertTechPresta,
               "Référent technique C# Winform",
               "", "",
               "Développement de services Windows");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "C#", "DOTNET", "WINFORM", "SQLS", "SERVICESDOTNET");

        }//Init_Experience_METSO

        private static void Init_Experience_HUMANIS_FSS(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_MH_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "HUMANIS",
               "Analyste MOE / Domaine « Frais Soin de Santé »",
                45000,
                lFirm.Key,
                2019, 03,
                2022, 06);

            int lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
               "MOE", "Analyste Fonctionnel", "Domaine « Frais Soin de Santé »",
               "Suivi de projet",
               "Gestion des évolutions",
               "Gestion des incidents de production",
               "Pilotage des développements");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "C#", "DOTNET", "TFS", "ASP.NET", "SQLS");

        }//Init_Experience_HUMANIS_FSS

        private static void Init_Experience_HUMANIS_AGD(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_MH_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "HUMANIS",
               "Développeur MOE / Domaine « Gestion Intermédiée »",
                45000,
                lFirm.Key,
                2022, 09,
                2024, 06);

            int lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
               "MOE", "Développeur", "Domaine « Gestion Intermédiée »",
               "Développement de flux SSIS",
               "Développements métier");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "C#", "DOTNET", "TFS", "ASP.NET", "SQLS", "SSIS", "GIT");

        }//Init_Experience_HUMANIS_AGD        

        private static void Init_Experience_AGAP2(MyDb pMyDb)
        {
            CV_Firm? lFirm = Get_Firm(pMyDb, c.FI_AGAP2_KEY);

            int lIntExperienceID =
                pMyDb.RepoCVUpdate.add_experience(
               "TMA Siemens",
               "Analyste Développeur / TMA Siemens",
                92012,
                lFirm.Key,
                2024, 12,
                2025, 02);

            int lIntActivityId =
               pMyDb.RepoCVUpdate.add_activity(lIntExperienceID, S_Int_JobID_DevExpertTechPresta,
               "TMA", "Développeur", "TMA Siemens",
               "Développement .Net",
               "Maintenance Azure");
            pMyDb.RepoCVUpdate.add_skills(lIntActivityId, "C#", "DOTNET", "AZURE", "ASP.NET", "SQLS", "SSIS", "GIT");

        }//Init_Experience_AGAP2

        static CV_Firm Get_Firm(MyDb pMyDb, string pStrFirmKey)
        {
            CV_Firm? lFirm = pMyDb.Firms.First(a => a.Key == pStrFirmKey);

            if (lFirm == null)
            {
                throw new Exception($"{pStrFirmKey} not found !");
            }

            return lFirm;
        }//Get_Firm


    }//class
}//namespace
