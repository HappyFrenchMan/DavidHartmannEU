using DHA.UTIL.Log4Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using DHA.DAL.Entity;
using sln_conf = DHA.UTIL.appSettings.AppSettingsReader;

namespace DHA.DAL
{
    internal class MyDbContext : DbContext
    {
        private static bool IS_DB_INIT = false;

        // CV Ref
        public DbSet<CV_LanguageSpoken> Languages { get; set; }
        internal DbSet<CV_City> Cities { get; set; }
        internal DbSet<CV_SkillType> Skill_Types { get; set; }
        internal DbSet<CV_Skill> Skills { get; set; }
        // CV Fact        
        internal DbSet<CV_Training> Trainings { get; set; }
        internal DbSet<CV_TrainingDetail> TrainingDetails { get; set; }
        internal DbSet<CV_Firm> Firms { get; set; }
        internal DbSet<CV_Job> Jobs { get; set; }
        internal DbSet<CV_KeyRole> KeyRoles { get; set; }        
        internal DbSet<CV_ContractType> ContractTypes { get; set; }
        internal DbSet<CV_Activity> Activities { get; set; }        
        internal DbSet<CV_Experience> Experiences { get; set; }
        internal DbSet<CV_ActivityDetail> ActivitiesDetail { get; set; }
        // Join Table
        internal DbSet<CV_ActivitySkill> ActivitySkills { get; set; }
        internal DbSet<CV_JobKeyRole> JobKeyRoles { get; set; }
        // DOC 
        internal DbSet<DOC_Link> Links { get; set; }
        internal DbSet<DOC_DocContentType> DocContentTypes { get; set; }
        internal DbSet<DOC_WebDocument> WebDocuments { get; set; }
        internal DbSet<DOC_DocumentContent> DocumentContents { get; set; }
        internal DbSet<DOC_SubTypeDocument> SubTypeDocuments { get; set; }
        internal DbSet<DOC_TypeDocument> TypeDocuments { get; set; }
        // Role
        internal DbSet<USR_Role> Role { get; set; }
        internal DbSet<USR_User> User { get; set; }

        public AMyDbContext() : base()
        {

            if (sln_conf.ReadBool(sln_conf.EN_APPS_KEY.DAL_BOOL_EF_CORE_ENSURE_DELETED))
            {
                if (!IS_DB_INIT)
                {
                    Database.EnsureDeleted();
                }
            }

            if (sln_conf.ReadBool(sln_conf.EN_APPS_KEY.DAL_BOOL_EF_CORE_ENSURE_CREATED))
            {
                if (!IS_DB_INIT)
                {
                    Database.EnsureCreated();
                }
            }

            IS_DB_INIT = true;
        }//DHA_Db_Context


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"{sln_conf.Read(sln_conf.EN_APPS_KEY.DAL_STR_DATABASE_CONNECTION_STRING)}");
            options.EnableSensitiveDataLogging();
            options.LogTo(this.Log, [RelationalEventId.CommandExecuted]);
        }//OnConfiguring

        public void Log(string message)
        {
            sLog4NetLogger.Debug("##EFCORE##"+message);
        }//Log

    }//class
}//namespace
