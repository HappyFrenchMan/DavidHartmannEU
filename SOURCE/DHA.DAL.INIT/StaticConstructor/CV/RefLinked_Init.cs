using DAH.DAL;
using DHA.DAL.CV.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHA.DAL.Initializer.StaticConstructor.CV
{
    class RefLinked_Init
    {
        public static void Init_Skill(MyDb pMyDB)
        {         
            pMyDB.CVSkillRepository.Add(new Entity.CV_SkillType)
            MyCatalog.add_skill("W2000","OS","Windows 2000","" );
            MyCatalog.add_skill("WXP","OS","Windows XP","" );
            MyCatalog.add_skill("SQLS","DEVSQL","Sql Server","" );
            MyCatalog.add_skill("ORACLE", "DEVSQL","Oracle","PL\\SQL" );
            MyCatalog.add_skill("ACCESS","DEVSQL","ACCESS","" );
            MyCatalog.add_skill("SSIS", "DEVSQL","SSIS","" );
            MyCatalog.add_skill("OLAP", "DEVSQL","OLAP","" );
            MyCatalog.add_skill("SSRS", "DEVSQL","SQL Server Reporting Services","" );
            MyCatalog.add_skill("ASP", "DEVW","ASP","" );
            MyCatalog.add_skill("ASP.NET", "DEVW","ASP.NET","" );
            MyCatalog.add_skill("WEBSERVICE", "DEVW","Web Service","" );
            MyCatalog.add_skill("C#", "DEV","C#","" );
            MyCatalog.add_skill("DOTNET", "DEV",".NET","" );
            MyCatalog.add_skill("WINFORM", "DEV",".NET Winform","WinForm" );
            MyCatalog.add_skill("SERVICESDOTNET", "DEV", "Service Windows .NET", "");
            MyCatalog.add_skill("CR9", "DEV","Crystal Report 9","" );
            MyCatalog.add_skill("VSS", "DEVSOURCE", "VISUAL SOURCE SAFE","" );
            MyCatalog.add_skill("GIT", "DEVSOURCE", "GIT", "");
            MyCatalog.add_skill("TFS", "DEVSOURCE", "TFS","" );
            MyCatalog.add_skill("VBNET", "DEV","VB.NET","" );
            MyCatalog.add_skill("VB", "DEV","VISUAL BASIC","" );
            MyCatalog.add_skill("JAVA", "DEV","JAVA","" );
            MyCatalog.add_skill("JUNIT", "DEV","JUNIT","" );
            MyCatalog.add_skill("ECLIPSE", "DEV","ECLIPSE","" );
            MyCatalog.add_skill("XML", "DEV","XML","" );
            MyCatalog.add_skill("DAX", "ERP","Dynamics AX","" );
            MyCatalog.add_skill("AZURE", "CLOUD", "Microsoft Azure Platform");

        }//Init_Skill

        public static void add_skill(
    string pStrSkillKey,
    string pStrSkillTypeKey,
    string pStrName,
    string pStrDetail = "")
        {

            Skill_Type? lSkillType =
                  Repository.(pStrSkillTypeKey);

            lDHA_Db_Context.Attach<Skill_Type>(lSkillType);

            Skill lSkill = new Skill()
            {
                Key = pStrSkillKey,
                Type = lSkillType,
                Name = pStrName,
                Detail = pStrDetail
            };

            lDHA_Db_Context.Skills.Add(lSkill);
            lDHA_Db_Context.SaveChanges();
        }//using
    }//add_skill
}//class
}//namespace
