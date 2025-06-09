using DAH.DAL;
using DHA.DAL.INIT.StaticConstructor.CV;
using DHA.DAL.QueryResult;
using DHA.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    class CV_Populate_OneLinkEntity : ACVPopulate
    {
        public static void Init_Skill(MyDb pMyDB)
        {         
            add_skill(pMyDB,"W2000", "OS", "Windows 2000", "");
            add_skill(pMyDB,"W2000","OS","Windows 2000","" );
            add_skill(pMyDB,"WXP","OS","Windows XP","" );
            add_skill(pMyDB,"SQLS","DEVSQL","Sql Server","" );
            add_skill(pMyDB,"ORACLE", "DEVSQL","Oracle","PL\\SQL" );
            add_skill(pMyDB,"ACCESS","DEVSQL","ACCESS","" );
            add_skill(pMyDB,"SSIS", "DEVSQL","SSIS","" );
            add_skill(pMyDB,"OLAP", "DEVSQL","OLAP","" );
            add_skill(pMyDB,"SSRS", "DEVSQL","SQL Server Reporting Services","" );
            add_skill(pMyDB,"ASP", "DEVW","ASP","" );
            add_skill(pMyDB,"ASP.NET", "DEVW","ASP.NET","" );
            add_skill(pMyDB,"WEBSERVICE", "DEVW","Web Service","" );
            add_skill(pMyDB,"C#", "DEV","C#","" );
            add_skill(pMyDB,"DOTNET", "DEV",".NET","" );
            add_skill(pMyDB,"WINFORM", "DEV",".NET Winform","WinForm" );
            add_skill(pMyDB,"SERVICESDOTNET", "DEV", "Service Windows .NET", "");
            add_skill(pMyDB,"CR9", "DEV","Crystal Report 9","" );
            add_skill(pMyDB,"VSS", "DEVSOURCE", "VISUAL SOURCE SAFE","" );
            add_skill(pMyDB,"GIT", "DEVSOURCE", "GIT", "");
            add_skill(pMyDB,"TFS", "DEVSOURCE", "TFS","" );
            add_skill(pMyDB,"VBNET", "DEV","VB.NET","" );
            add_skill(pMyDB,"VB", "DEV","VISUAL BASIC","" );
            add_skill(pMyDB,"JAVA", "DEV","JAVA","" );
            add_skill(pMyDB,"JUNIT", "DEV","JUNIT","" );
            add_skill(pMyDB,"ECLIPSE", "DEV","ECLIPSE","" );
            add_skill(pMyDB,"XML", "DEV","XML","" );
            add_skill(pMyDB,"DAX", "ERP","Dynamics AX","" );
            add_skill(pMyDB,"AZURE", "CLOUD", "Microsoft Azure Platform");

            
        }//Init_Skill

        private static void add_skill(MyDb pMyDb,string pStrSkillKey, string pStrSkillTypeKey, string pStrName, string pStrDetail = "")
        {
            UpdateResult __updateResult = pMyDb.RepoCVUpdate.add_skill(pStrSkillKey, pStrSkillTypeKey, pStrName, pStrDetail);
            AssertEntityUpdated(__updateResult, 1, "Error while add skill !");
        }//add_skill

        public static void Init_Training(MyDb pMyDb)
        {
            string __errorMsg = "Error while add training !";

            UpdateResult __updateResult = pMyDb.RepoCVUpdate.add_training(91600, 1999,
                "BAC ES  - Spécialité Mathématiques");
            AssertIsSuccess(__updateResult);

            __updateResult = pMyDb.RepoCVUpdate.add_training(78140, 2001,
                "DUT (Diplôme universitaire de technologie) informatique",
                "Projet d'étude : Progiciel de gestion en Java");
            AssertIsSuccess(__updateResult);

            __updateResult = pMyDb.RepoCVUpdate.add_training(91000, 2003,
                "Licence et Maîtrise MIAGE",
                "(Méthodes informatiques appliquées à la gestion)",
                "Formation en alternance. ",
                "( Rythme de l’alternance 1 mois / 1 mois )",
                "Entreprise: Servantès(78)");
            AssertIsSuccess(__updateResult);

            __updateResult = pMyDb.RepoCVUpdate.add_training(91000, 2004,
                "DESS Documentaire et Multimédia",
                "Nouvelles technologies (XML,XSL)",
                "Gestion Documentaire (Workflow,Gestion de contenu)",
                "Multimédia et Réseau (Streaming,TCP/IP)",
                "Projet d’étude : La plateforme J2EE JBoss");
            AssertIsSuccess(__updateResult);

        }//Init_Training



    }//class
}//namespace
