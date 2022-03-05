namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Logins", "UserName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Logins", "Password", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "Password", c => c.String());
            AlterColumn("dbo.Logins", "UserName", c => c.String());
        }
    }
}
