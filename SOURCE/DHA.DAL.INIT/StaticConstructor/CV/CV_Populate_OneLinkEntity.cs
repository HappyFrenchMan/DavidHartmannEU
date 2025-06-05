using DAH.DAL;
using DHA.DAL.INIT.StaticConstructor.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    class CV_Populate_OneLinkEntity
    {
        public static void Init_Skill(MyDb pMyDB)
        {         
            pMyDB.RepoCVUpdate.add_skill("W2000", "OS", "Windows 2000", "");
            pMyDB.RepoCVUpdate.add_skill("W2000","OS","Windows 2000","" );
            pMyDB.RepoCVUpdate.add_skill("WXP","OS","Windows XP","" );
            pMyDB.RepoCVUpdate.add_skill("SQLS","DEVSQL","Sql Server","" );
            pMyDB.RepoCVUpdate.add_skill("ORACLE", "DEVSQL","Oracle","PL\\SQL" );
            pMyDB.RepoCVUpdate.add_skill("ACCESS","DEVSQL","ACCESS","" );
            pMyDB.RepoCVUpdate.add_skill("SSIS", "DEVSQL","SSIS","" );
            pMyDB.RepoCVUpdate.add_skill("OLAP", "DEVSQL","OLAP","" );
            pMyDB.RepoCVUpdate.add_skill("SSRS", "DEVSQL","SQL Server Reporting Services","" );
            pMyDB.RepoCVUpdate.add_skill("ASP", "DEVW","ASP","" );
            pMyDB.RepoCVUpdate.add_skill("ASP.NET", "DEVW","ASP.NET","" );
            pMyDB.RepoCVUpdate.add_skill("WEBSERVICE", "DEVW","Web Service","" );
            pMyDB.RepoCVUpdate.add_skill("C#", "DEV","C#","" );
            pMyDB.RepoCVUpdate.add_skill("DOTNET", "DEV",".NET","" );
            pMyDB.RepoCVUpdate.add_skill("WINFORM", "DEV",".NET Winform","WinForm" );
            pMyDB.RepoCVUpdate.add_skill("SERVICESDOTNET", "DEV", "Service Windows .NET", "");
            pMyDB.RepoCVUpdate.add_skill("CR9", "DEV","Crystal Report 9","" );
            pMyDB.RepoCVUpdate.add_skill("VSS", "DEVSOURCE", "VISUAL SOURCE SAFE","" );
            pMyDB.RepoCVUpdate.add_skill("GIT", "DEVSOURCE", "GIT", "");
            pMyDB.RepoCVUpdate.add_skill("TFS", "DEVSOURCE", "TFS","" );
            pMyDB.RepoCVUpdate.add_skill("VBNET", "DEV","VB.NET","" );
            pMyDB.RepoCVUpdate.add_skill("VB", "DEV","VISUAL BASIC","" );
            pMyDB.RepoCVUpdate.add_skill("JAVA", "DEV","JAVA","" );
            pMyDB.RepoCVUpdate.add_skill("JUNIT", "DEV","JUNIT","" );
            pMyDB.RepoCVUpdate.add_skill("ECLIPSE", "DEV","ECLIPSE","" );
            pMyDB.RepoCVUpdate.add_skill("XML", "DEV","XML","" );
            pMyDB.RepoCVUpdate.add_skill("DAX", "ERP","Dynamics AX","" );
            pMyDB.RepoCVUpdate.add_skill("AZURE", "CLOUD", "Microsoft Azure Platform");

        }//Init_Skill

        public static void Init_Training(MyDb pMyDb)
        {
            pMyDb.RepoCVUpdate.add_training(91600, 1999,
                "BAC ES  - Spécialité Mathématiques");

            pMyDb.RepoCVUpdate.add_training(78140, 2001,
                "DUT (Diplôme universitaire de technologie) informatique",
                "Projet d'étude : Progiciel de gestion en Java");

            pMyDb.RepoCVUpdate.add_training(91000, 2003,
                "Licence et Maîtrise MIAGE",
                "(Méthodes informatiques appliquées à la gestion)",
                "Formation en alternance. ",
                "( Rythme de l’alternance 1 mois / 1 mois )",
                "Entreprise: Servantès(78)");

            pMyDb.RepoCVUpdate.add_training(91000, 2004,
                "DESS Documentaire et Multimédia",
                "Nouvelles technologies (XML,XSL)",
                "Gestion Documentaire (Workflow,Gestion de contenu)",
                "Multimédia et Réseau (Streaming,TCP/IP)",
                "Projet d’étude : La plateforme J2EE JBoss");

        }//Init_Training



    }//class
}//namespace
