namespace DeCamaroong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04092015addisNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mails", "isNew", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mails", "isNew");
        }
    }
}
