namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 100));
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String());
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
        }
    }
}
