using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Vamia.Data.Migrations;

namespace Vamia
{
    public static class DatabaseConfig
    {
        public static void MigrateDatabase()
        {
            var dbMigrator = new DbMigrator(new Configuration());
            dbMigrator.Update();
        }
    }
}