using Microsoft.EntityFrameworkCore;
using DAL.Entity;
using System.Data;
using System.Diagnostics;
using DAL.Repository;

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

            if (Db_Config.EF_CORE_ENSURE_DELETED)
            {
                if (!IS_DB_INIT)
                {
                    Database.EnsureDeleted();
                }
            }

            if (Db_Config.EF_CORE_ENSURE_CREATED)
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
            options.UseSqlite($"Data Source={Db_Config.SQL_LITE_FILE_NAME}");

        }//OnConfiguring
    }//class
}//namespace