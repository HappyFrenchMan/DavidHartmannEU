using Microsoft.EntityFrameworkCore;
using DAL.Entity;
using System.Data;
using System.Diagnostics;
using DAL.Repository;
using sln_conf = Util.appSettings.AppSettingsReader;

namespace DAL
{
    public class Db_Context : DbContext
    {
        private static bool IS_DB_INIT = false;

        public DbSet<City> Cities { get; set; }
        public DbSet<Firm> Firms { get; set; }

        public Db_Context() :
            base()
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

        }//OnConfiguring
    }//class
}//namespace