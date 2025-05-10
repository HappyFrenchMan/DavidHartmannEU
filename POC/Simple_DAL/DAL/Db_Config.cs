using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Db_Config
    {
        public static string SQL_LITE_FILE_NAME = string.Empty;

        public static bool EF_CORE_ENSURE_CREATED = false;

        public static bool EF_CORE_ENSURE_DELETED = false;
    }
}
