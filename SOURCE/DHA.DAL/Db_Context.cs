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
    public class Db_Context : DbContext
    {
        private static bool IS_DB_INIT = false;

        // CV Ref
        public DbSet<CV_LanguageSpoken> Languages { get; set; }
        public DbSet<CV_City> Cities { get; set; }
        public DbSet<CV_SkillType> Skill_Types { get; set; }
        public DbSet<CV_Skill> Skills { get; set; }
        // CV Fact
        //public DbSet<Link> Links { get; set; }
        //public DbSet<CV_Training> Trainings { get; set; }
        //public DbSet<CV_TrainingDetail> TrainingDetails { get; set; }
        //public DbSet<CV_Firm> Firms { get; set; }
        //public DbSet<CV_Job> Jobs { get; set; }
        //public DbSet<CV_KeyRole> KeyRoles { get; set; }        
        public DbSet<CV_ContractType> ContractTypes { get; set; }
        //public DbSet<CV_Activity> Activities { get; set; }        
        //public DbSet<CV_Experience> Experiences { get; set; }
        //public DbSet<CV_ActivityDetail> ActivitiesDetail { get; set; }
        // Join Table
        public DbSet<CV_ActivitySkill> ActivitySkills { get; set; }
        public DbSet<CV_JobKeyRole> JobKeyRoles { get; set; }
        // DOC 
        //public DbSet<DocContentType> DocContentTypes { get; set; }
        //public DbSet<WebDocument> WebDocuments { get; set; }
        //public DbSet<DocumentContent> DocumentContents { get; set; }
        //public DbSet<SubTypeDocument> SubTypeDocuments { get; set; }
        //public DbSet<TypeDocument> TypeDocuments { get; set; }
        // Role
        public DbSet<USR_Role> Role { get; set; }
        public DbSet<USR_User> User { get; set; }

        public Db_Context() : 
            base( )
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
            options.LogTo(this.Log, [RelationalEventId.CommandExecuted]);
        }//OnConfiguring

        public void Log(string message)
        {
            sLog4NetLogger.Debug("##EFCORE##"+message);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Activity>()
            //    .HasMany(e => e.Skills)
            //    .WithMany(e => e.Activities)
            //    .UsingEntity(
            //        "ActivitySkill",
            //        l => l.HasOne(typeof(Skill)).WithMany().HasForeignKey("SkillsId").HasPrincipalKey(nameof(Skill.ID)),
            //        r => r.HasOne(typeof(Activity)).WithMany().HasForeignKey("ActivitiesId").HasPrincipalKey(nameof(Activity.ID)),
            //        j => j.HasKey("ActivitiesId", "SkillsId"));
        }//OnModelCreating

    }//class
}//namespace
