using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Vamia.Infrastructure.Migrations;

namespace Vamia.Web.Infrastructure
{
    public class DatabaseMigrator
    {
        public static void UpdateDatabase()
        {
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}