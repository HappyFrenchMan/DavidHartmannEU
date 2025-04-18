using DHA.Common.Log4Net;
using DHA.EntityFrameworkCore_Models.CV.Entity;
using DHA.EntityFrameworkCore_Models.DOC.Entity;
using DHA.EntityFrameworkCore_Models.USER.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace DHA.EntityFrameworkCore_Models
{
    public class DHA_Db_Context : DbContext
    {
        private static bool IS_DB_INIT = false;

        // CV Ref
        public DbSet<Language> Languages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Skill_Type> Skill_Types { get; set; }
        public DbSet<Skill> Skills { get; set; }
        // CV Fact
        public DbSet<Link> Links { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingDetail> TrainingDetails { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityDetail> ActivitiesDetail { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        // CV Link
        public DbSet<ActivitySkill> ActivitySkills { get; set; }
        // DOC 
        public DbSet<DocContentType> DocContentTypes { get; set; }
        public DbSet<WebDocument> WebDocuments { get; set; }
        public DbSet<DocumentContent> DocumentContents { get; set; }
        public DbSet<SubTypeDocument> SubTypeDocuments { get; set; }
        public DbSet<TypeDocument> TypeDocuments { get; set; }
        // Role
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        public DHA_Db_Context() : 
            base( )
        {

            if (EF_StaticConfiguration.EF_CORE_ENSURE_DELETED)
            {
                if (!IS_DB_INIT)
                {
                    Database.EnsureDeleted();
                }
            }

            if (EF_StaticConfiguration.EF_CORE_ENSURE_CREATED)
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
            options.UseSqlite($"Data Source={EF_StaticConfiguration.SQL_LITE_FILE_NAME}");

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
