using DAH.DAL;
using DHA.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.INIT.StaticConstructor.CV
{
    internal class CV_Populate_ExperienceEntity
    {           
        public static int S_Int_JobID_StaigiaireDevASP;
        public static int S_Int_JobID_DevAlternant;
        public static int S_Int_JobID_DevStagiaire;
        public static int S_Int_JobID_DevExpertTechPresta;
        public static int S_Int_JobID_DevAnalystePresta;
        public static int S_Int_JobID_Expert_Technique_Interne;

        public static void Init(MyDb pMyDb)
        {
            S_Int_JobID_StaigiaireDevASP = Init_Job_Stagiaire_DEV_ASP(pMyDb);
            S_Int_JobID_DevAlternant = Init_Job_Developpeur_Alternant(pMyDb);
            S_Int_JobID_DevStagiaire = Init_Job_Stagiaire_DEV(pMyDb);
            S_Int_JobID_DevExpertTechPresta = Init_Job_Dev_Expert_Technique_Prestataire(pMyDb);
            S_Int_JobID_DevAnalystePresta = Init_Job_Dev_Analyse_Prestataire(pMyDb);
            S_Int_JobID_Expert_Technique_Interne = Init_Job_Expert_Technique_Interne(pMyDb);

            Init_Experience_Servantes_DUT(pMyDb);
            Init_Experience_MIAGE();
            Init_Experience_W4();
            Init_Experience_SCPP();
            Init_Experience_ORDRE_AVOCATS();
            Init_Experience_BNPP();
            Init_Experience_MEDIAMOBILE();
            Init_Experience_MAYOLY_SPINDLER();
            Init_Experience_HUMANIS_DGCD();
            Init_Experience_METSO();
            Init_Experience_HUMANIS_FSS();
            Init_Experience_HUMANIS_AGD();
            Init_Experience_AGAP2();

        }//Init

        public static int Init_Job_Stagiaire_DEV_ASP(MyDb pMyDb)
        {
            return pMyDb.CVFeedCR.add_job(
                "Stagiaire Développeur ASP",
                CV_DAL_Const.CT_STAGIAIRE_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Stagiaire_DEV_ASP

        public static int Init_Job_Stagiaire_DEV(MyDb pMyDb)
        {
            return pMyDb.CVFeedCR.add_job(
                "Stagiaire Développeur",
                CV_DAL_Const.CT_STAGIAIRE_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Stagiaire_DEV

        public static int Init_Job_Developpeur_Alternant(MyDb pMyDb)
        {
            return pMyDb.CVFeedCR.add_job(
                "Développeur ( Contrat d'apprentissage en alternance )",
                CV_DAL_Const.CT_ALTERNANT_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE);
        }//Init_Job_Developpeur_Alternant

        public static int Init_Job_Dev_Expert_Technique_Prestataire(MyDb pMyDb)
        {
            return pMyDb.CVFeedCR.add_job(
                "Développeur et Expert Technique",
                CV_DAL_Const.CT_PRESTA_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE,
                CV_DAL_Const.KR_EXPERTTECH_CODE);
        }//Init_Job_Dev_Expert_Technique_Prestataire

        public static int Init_Job_Dev_Analyse_Prestataire(MyDb pMyDb)
        {
            return pMyDb.CVFeedCR.add_job(
                "Développeur et Analyste",
                CV_DAL_Const.CT_PRESTA_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE,
                CV_DAL_Const.KR_ANALYST_CODE);
        }//Init_Job_Dev_Analyse_Prestataire

        public static int Init_Job_Expert_Technique_Interne(MyDb pMyDb)
        {
            return pMyDb.CVFeedCR.add_job(
                "Expert Technique Interne",
                CV_DAL_Const.CT_EMPLOYE_CODE,
                CV_DAL_Const.KR_DEVELOPPEUR_CODE,
                CV_DAL_Const.KR_ANALYST_CODE,
                CV_DAL_Const.KR_EXPERTTECH_CODE);
        }//Init_Job_Expert_Technique_Interne

        public static int Init_Experience_Servantes_DUT(MyDb pMyDB)
        {
            CV_Firm? lFirmServantes = pMyDB.CVFirmRepository.FindOne(a => a.Name=="SERVANTES");

            CV_ExperiencePeriod __cvExpPeriod =
                new CV_ExperiencePeriod() { YearStart = 2001, YearEnd = 2001, MonthStart = 3, MonthEnd = 9 };
            pMyDB.CVExperiencePeriodRepository.Add(__cvExpPeriod);

            //int lIntExperienceID =
            //    pMyDB.CVExperienceRepository.Add(
            //        new CV_Experience()
            //        {
            //            FirmId = lFirmServantes.ID,
            //            Name = "Stage de DUT",
                        
            //        });
            //   "SERVANTES",
            //   ,
            //    78220,
            //    lFirmServantes.ID,
            //    2001, 3,
            //    2001, 9);
            //int lIntActivityId =
            //    MyActivity.add_activity(lIntExperienceID, S_Int_JobID_StaigiaireDevASP,
            //    "ELECTRE", "Réalisation d’un site intranet de gestion des congés Payés.", "",
            //        "Apprentissage de l'ASP.");
            //MyActivity.add_skills(lIntActivityId, "SQLS", "W2000", "ASP");
            //lIntActivityId =
            //          MyActivity.add_activity(lIntExperienceID, S_Int_JobID_StaigiaireDevASP,
            //          "PROJ", "Réalisation d'un site intranet pour la gestion de projet", "",
            //              "Définition des besoins.",
            //              "Réalisation de la charte graphique.",
            //              "Maintenance et évolution.");
            //MyActivity.add_skills(lIntActivityId, "SQLS", "W2000", "ASP");


            return 0;

        }//Init_Experience_Servantes_DUT



        public static void Init_Experience_MIAGE()
        {
            Firm? lFirmServantes = Get_Firm("SERVANTES");

            int lIntExperienceID =
                MyExperience.add(
               "SERVANTES",
               "Licence et Maîtrise MIAGE en alternance, Faculté d'Evry",
                78220,
                lFirmServantes.ID,
                2001, 10,
                2003, 10);
            int lIntActivityId =
                MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAlternant,
                "FAURECIA", "Plateforme Intranet d’échange de documents (fournisseurs, clients) :",
                "", "Réalisation du module de téléchargement des documents en base de données.",
                "Réalisation de la charte graphique.");
            MyActivity.add_skills(lIntActivityId, "SQLS", "W2000", "ASP.NET", "C#");
            lIntActivityId =
                MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAlternant,
                "ITALCEMENTI", "Réalisation d'un trombinoscope",
                "", "Développement du module d'administration.");
            MyActivity.add_skills(lIntActivityId, "SQLS", "W2000", "VBNET", "ASP.NET");
            lIntActivityId =
                MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAlternant,
                "CROIX-ROUGE", "Réalisation d'un module de génération de PDF",
                "", "Proposition d’architecture technique",
                "Dossiers de Conception Technique Détaillée",
                "Développement d'un service en Visual Basic",
                "Installation du service sur le serveur Intranet",
                "Maintenance corrective et évolutive",
                "Gestion des anomalies",
                "Responsable des livraisons");
            MyActivity.add_skills(lIntActivityId, "SQLS", "W2000", "ASP", "VB");


            lIntActivityId =
                MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAlternant,
                "MARAIS DE DOL", "Réalisation d'un progiciel de gestion.",
                "", "Création d'une nouvelle interface graphique",
                "Maintenance corrective et évolutive");
            MyActivity.add_skills(lIntActivityId, "SQLS", "W2000", "ACCESS", "VB");

        }//Init_Experience_MIAGE

        public static void Init_Experience_W4()
        {
            Firm? lFirm = Get_Firm("W4");

            int lIntExperienceID =
                MyExperience.add(
               "W4",
               "Stage de DESS ",
                91300,
                lFirm.ID,
                2004, 03,
                2004, 08);

            int lIntActivityId =
                MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevStagiaire,
                "JUNIT", "Etude de marché des outils de test de recette d’application web", "",
                "Définition des besoins de l'outil de test de recette",
                "Ecriture des tests unitaires (JAVA – JUNIT)",
                "Développement de l'outil (JAVA – JWEBUNIT – JUNIT)",
                "Mise en production de l'outil et réalisation de tests de recette du portail intranet de la société",
                "Maintenance évolutive et corrective de ce portail.");
            MyActivity.add_skills(lIntActivityId, "W2000", "C#", "ASP.NET", "JAVA", "XML", "JUNIT", "ECLIPSE");

        }//Init_Experience_W4

        public static void Init_Experience_SCPP()
        {
            Firm? lFirm = Get_Firm("SCPP");

            int lIntExperienceID =
                MyExperience.add(
               "SCPP",
               "Prestation pour la SCPP",
                92200,
                lFirm.ID,
                2004, 11,
                2004, 12);

            int lIntActivityId =
                MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevExpertTechPresta,
                "SCPP", "Extranet pour le MIDEM", "",
                 "Transfert de compétences",
                 "Proposition d'architecture technique",
                 "Création et mise en production de services Web pour Oracle",
                 "Mise en place de la charte graphique (CSS)",
                 "Développement de fonctionnalités");
            MyActivity.add_skills(lIntActivityId, "C#", "ASP.NET", "ORACLE", "WEBSERVICE");

        }//Init_Experience_SCPP

        private static void Init_Experience_ORDRE_AVOCATS()
        {
            Firm? lFirm = Get_Firm("AJILON");

            int lIntExperienceID =
                MyExperience.add(
               "AVOCATS",
               "Prestation pour le client « Ordre des Avocats à la Cour de Paris »",
                93170,
                lFirm.ID,
                2005, 1,
                2005, 4);

            int lIntActivityId =
                MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
                "AJILON", "AIDA : Gestion des Dossiers", "",
                 "Spécifications techniques détaillées",
                 "Analyse et développement d'un service Windows pour l'automatisation de l'archivage des dossiers",
                 "Documentation technique",
                 "Tests unitaires et d'intégration");
            MyActivity.add_skills(lIntActivityId, "W2000", "DOTNET", "C#", "ORACLE", "WEBSERVICE", "CR9", "VSS", "WINFORM");

        }//Init_Experience_ORDRE_AVOCATS

        public static void Init_Experience_BNPP()
        {
            Firm? lFirm = Get_Firm("BNPP");

            int lIntExperienceID =
                MyExperience.add(
               "BNPP",
               "Prestation chez BNP PARIBAS",
                93100,
                lFirm.ID,
                2005, 4,
                2007, 5);

            int lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
               "CONFIDENTIEL", "Développement d'un service Web", "",
               "Spécifications fonctionnelles détaillées",
               "Spécifications techniques détaillées",
                "Analyse et développement d'un service Web",
                "Ecriture du cahier de recette",
                "Tests unitaires",
                "Préparation de la mise en production");
            MyActivity.add_skills(lIntActivityId, "WXP", "DOTNET", "C#", "ORACLE", "WEBSERVICE", "CR9");

        }//Init_Experience_BNPP

        public static void Init_Experience_MEDIAMOBILE()
        {
            Firm? lFirm = Get_Firm("MM");

            int lIntExperienceID =
                MyExperience.add(
               "MEDIAMOBILE",
               "Expert Technique .Net",
                94200,
                lFirm.ID,
                2007, 5,
                2009, 9);

            int lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_Expert_Technique_Interne,
               "EXPERT", "Développement d'une infrastructure", "",
               "Encadrement",
               "Documentation et pilotage projet",
               "Développement C# et Gestion de projet",
               "Construction d’une architecture pour répondre aux besoins",
               "Contact client fréquent",
               "Forte implication dans la démarche qualité de l’entreprise");
            MyActivity.add_skills(lIntActivityId, "WXP", "DOTNET", "C#", "ORACLE", "SERVICESDOTNET");

        }//Init_Experience_MEDIAMOBILE

        public static void Init_Experience_MAYOLY_SPINDLER()
        {
            Firm? lFirm = Get_Firm("LMSP");

            int lIntExperienceID =
                MyExperience.add(
               "MAYOLY_SPINDLER",
               "Responsable d'applications / Expert Technique AX",
                78400,
                lFirm.ID,
                2009, 9,
                2015, 6);

            int lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_Expert_Technique_Interne,
               "AX", "Expertise Technique Dynamics AX", "",
               "Installation de l'ERP Dynamics AX",
               "Paramétrage de l'ERP",
               "Surveillance des flux de l'ERP",
               "Mise en place des profils de sécurité");
            MyActivity.add_skills(lIntActivityId, "DAX", "SQLS");

            lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_Expert_Technique_Interne,
               "APPMANAGER", "Responsable d'applications", "",
               "Développement de modules de transformation de données métiers",
               "Développement d'interfaces pour les bases de données",
               "Développement d'applications Web",
               "Installation d'applications tierces et paramétrage de ces applications");
            MyActivity.add_skills(lIntActivityId, "SSIS", "OLAP", "ACCESS", "SSRS", "SQLS");

            lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_Expert_Technique_Interne,
               "SUPERVISION", "Supervision du système d'information", "",
               "Au quotidien, contrôles des échanges entre les applications",
               "Mise en place d'outils pour contrôler ces échanges");
            MyActivity.add_skills(lIntActivityId, "SQLS", "DOTNET");


        }//Init_Experience_MAYOLY_SPINDLER

        public static void Init_Experience_HUMANIS_DGCD()
        {
            Firm? lFirm = Get_Firm("MH");

            int lIntExperienceID =
                MyExperience.add(
               "HUMANIS",
               "Analyste MOE / Domaine « Assurance De Personnes »",
                45000,
                lFirm.ID,
                2015, 11,
                2017, 12);

            int lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
               "MOE", "Analyste Fonctionnel", "Domaine « assurance de personnes »",
               "Suivi de projet",
               "Gestion des évolutions",
               "Gestion des incidents de production",
               "Pilotage des développements");
            MyActivity.add_skills(lIntActivityId, "C#", "DOTNET", "TFS", "ASP.NET", "SQLS");

        }//Init_Experience_HUMANIS_DGCD

        public static void Init_Experience_METSO()
        {
            Firm? lFirm = Get_Firm("METSO");

            int lIntExperienceID =
                MyExperience.add(
               "METSO",
               "Expert technique",
                45160,
                lFirm.ID,
                2018, 3,
                2019, 3);

            int lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevExpertTechPresta,
               "Référent technique C# Winform",
               "", "",
               "Développement de services Windows");
            MyActivity.add_skills(lIntActivityId, "C#", "DOTNET", "WINFORM", "SQLS", "SERVICESDOTNET");

        }//Init_Experience_METSO

        public static void Init_Experience_HUMANIS_FSS()
        {
            Firm? lFirm = Get_Firm("MH");

            int lIntExperienceID =
                MyExperience.add(
               "HUMANIS",
               "Analyste MOE / Domaine « Frais Soin de Santé »",
                45000,
                lFirm.ID,
                2019, 03,
                2022, 06);

            int lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
               "MOE", "Analyste Fonctionnel", "Domaine « Frais Soin de Santé »",
               "Suivi de projet",
               "Gestion des évolutions",
               "Gestion des incidents de production",
               "Pilotage des développements");
            MyActivity.add_skills(lIntActivityId, "C#", "DOTNET", "TFS", "ASP.NET", "SQLS");

        }//Init_Experience_HUMANIS_FSS

        public static void Init_Experience_HUMANIS_AGD()
        {
            Firm? lFirm = Get_Firm("MH");

            int lIntExperienceID =
                MyExperience.add(
               "HUMANIS",
               "Développeur MOE / Domaine « Gestion Intermédiée »",
                45000,
                lFirm.ID,
                2022, 09,
                2024, 06);

            int lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevAnalystePresta,
               "MOE", "Développeur", "Domaine « Gestion Intermédiée »",
               "Développement de flux SSIS",
               "Développements métier");
            MyActivity.add_skills(lIntActivityId, "C#", "DOTNET", "TFS", "ASP.NET", "SQLS", "SSIS", "GIT");

        }//Init_Experience_HUMANIS_AGD        

        public static void Init_Experience_AGAP2()
        {
            Firm? lFirm = Get_Firm("AGAP2");

            int lIntExperienceID =
                MyExperience.add(
               "TMA Siemens",
               "Analyste Développeur / TMA Siemens",
                92012,
                lFirm.ID,
                2024, 12,
                2025, 02);

            int lIntActivityId =
               MyActivity.add_activity(lIntExperienceID, S_Int_JobID_DevExpertTechPresta,
               "TMA", "Développeur", "TMA Siemens",
               "Développement .Net",
               "Maintenance Azure");
            MyActivity.add_skills(lIntActivityId, "C#", "DOTNET", "AZURE", "ASP.NET", "SQLS", "SSIS", "GIT");

        }//Init_Experience_AGAP2

        static Firm Get_Firm(string pStrFirmCode)
        {
            Firm? lFirm = MyCatalog.select_firm(pStrFirmCode);

            if (lFirm == null)
            {
                throw new Exception($"{pStrFirmCode} not found !");
            }

            return lFirm;
        }//Get_Firm


    }//class
}//namespace
