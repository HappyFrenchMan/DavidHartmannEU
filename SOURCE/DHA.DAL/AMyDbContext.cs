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
    public abstract class AMyDbContext : DbContext
    {
        private static bool IS_DB_INIT = false;

        // CV Ref
        public DbSet<CV_LanguageSpoken> Languages { get; set; }
        public DbSet<CV_City> Cities { get; set; }
        public DbSet<CV_SkillType> Skill_Types { get; set; }
        public DbSet<CV_Skill> Skills { get; set; }
        // CV Fact        
        public DbSet<CV_Training> Trainings { get; set; }
        public DbSet<CV_TrainingDetail> TrainingDetails { get; set; }
        public DbSet<CV_Firm> Firms { get; set; }
        public DbSet<CV_Job> Jobs { get; set; }
        public DbSet<CV_KeyRole> KeyRoles { get; set; }        
        public DbSet<CV_ContractType> ContractTypes { get; set; }
        public DbSet<CV_Activity> Activities { get; set; }        
        public DbSet<CV_Experience> Experiences { get; set; }
        public DbSet<CV_ActivityDetail> ActivitiesDetail { get; set; }
        // Join Table
        public DbSet<CV_ActivitySkill> ActivitySkills { get; set; }
        public DbSet<CV_JobKeyRole> JobKeyRoles { get; set; }
        // DOC 
        public DbSet<DOC_Link> Links { get; set; }
        public DbSet<DOC_DocContentType> DocContentTypes { get; set; }
        public DbSet<DOC_WebDocument> WebDocuments { get; set; }
        public DbSet<DOC_DocumentContent> DocumentContents { get; set; }
        public DbSet<DOC_SubTypeDocument> SubTypeDocuments { get; set; }
        public DbSet<DOC_TypeDocument> TypeDocuments { get; set; }
        // Role
        public DbSet<USR_Role> Role { get; set; }
        public DbSet<USR_User> User { get; set; }

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
