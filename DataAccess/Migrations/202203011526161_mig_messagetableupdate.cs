namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messagetableupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageContent", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageContent", c => c.String(maxLength: 300));
        }
    }
}
