using DAH.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    class CV_RefLinked_Init
    {
        public static void Init_Skill(MyDb pMyDB)
        {         
            pMyDB.CVFeedCR.add_skill("W2000", "OS", "Windows 2000", "");
            pMyDB.CVFeedCR.add_skill("W2000","OS","Windows 2000","" );
            pMyDB.CVFeedCR.add_skill("WXP","OS","Windows XP","" );
            pMyDB.CVFeedCR.add_skill("SQLS","DEVSQL","Sql Server","" );
            pMyDB.CVFeedCR.add_skill("ORACLE", "DEVSQL","Oracle","PL\\SQL" );
            pMyDB.CVFeedCR.add_skill("ACCESS","DEVSQL","ACCESS","" );
            pMyDB.CVFeedCR.add_skill("SSIS", "DEVSQL","SSIS","" );
            pMyDB.CVFeedCR.add_skill("OLAP", "DEVSQL","OLAP","" );
            pMyDB.CVFeedCR.add_skill("SSRS", "DEVSQL","SQL Server Reporting Services","" );
            pMyDB.CVFeedCR.add_skill("ASP", "DEVW","ASP","" );
            pMyDB.CVFeedCR.add_skill("ASP.NET", "DEVW","ASP.NET","" );
            pMyDB.CVFeedCR.add_skill("WEBSERVICE", "DEVW","Web Service","" );
            pMyDB.CVFeedCR.add_skill("C#", "DEV","C#","" );
            pMyDB.CVFeedCR.add_skill("DOTNET", "DEV",".NET","" );
            pMyDB.CVFeedCR.add_skill("WINFORM", "DEV",".NET Winform","WinForm" );
            pMyDB.CVFeedCR.add_skill("SERVICESDOTNET", "DEV", "Service Windows .NET", "");
            pMyDB.CVFeedCR.add_skill("CR9", "DEV","Crystal Report 9","" );
            pMyDB.CVFeedCR.add_skill("VSS", "DEVSOURCE", "VISUAL SOURCE SAFE","" );
            pMyDB.CVFeedCR.add_skill("GIT", "DEVSOURCE", "GIT", "");
            pMyDB.CVFeedCR.add_skill("TFS", "DEVSOURCE", "TFS","" );
            pMyDB.CVFeedCR.add_skill("VBNET", "DEV","VB.NET","" );
            pMyDB.CVFeedCR.add_skill("VB", "DEV","VISUAL BASIC","" );
            pMyDB.CVFeedCR.add_skill("JAVA", "DEV","JAVA","" );
            pMyDB.CVFeedCR.add_skill("JUNIT", "DEV","JUNIT","" );
            pMyDB.CVFeedCR.add_skill("ECLIPSE", "DEV","ECLIPSE","" );
            pMyDB.CVFeedCR.add_skill("XML", "DEV","XML","" );
            pMyDB.CVFeedCR.add_skill("DAX", "ERP","Dynamics AX","" );
            pMyDB.CVFeedCR.add_skill("AZURE", "CLOUD", "Microsoft Azure Platform");

        }//Init_Skill

        public static void Init_Training(MyDb pMyDb)
        {
            pMyDb.CVFeedCR.addTraining(91600, 1999,
                "BAC ES  - Spécialité Mathématiques");

            pMyDb.CVFeedCR.addTraining(78140, 2001,
                "DUT (Diplôme universitaire de technologie) informatique",
                "Projet d'étude : Progiciel de gestion en Java");

            pMyDb.CVFeedCR.addTraining(91000, 2003,
                "Licence et Maîtrise MIAGE",
                "(Méthodes informatiques appliquées à la gestion)",
                "Formation en alternance. ",
                "( Rythme de l’alternance 1 mois / 1 mois )",
                "Entreprise: Servantès(78)");

            pMyDb.CVFeedCR.addTraining(91000, 2004,
                "DESS Documentaire et Multimédia",
                "Nouvelles technologies (XML,XSL)",
                "Gestion Documentaire (Workflow,Gestion de contenu)",
                "Multimédia et Réseau (Streaming,TCP/IP)",
                "Projet d’étude : La plateforme J2EE JBoss");

        }//Init_Training


    }//class
}//namespace
