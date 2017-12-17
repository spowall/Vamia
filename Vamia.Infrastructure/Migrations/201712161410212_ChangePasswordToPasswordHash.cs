namespace Vamia.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePasswordToPasswordHash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            Sql("UPDATE dbo.Users SET PasswordHash = Password");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            Sql("UPDATE dbo.Users SET Password = PasswordHash");
            DropColumn("dbo.Users", "PasswordHash");
        }
    }
}
