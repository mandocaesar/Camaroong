namespace DeCamaroong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04092015UpdateMailClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mails", "Fullname", c => c.String());
            AddColumn("dbo.Mails", "createdDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mails", "createdDate");
            DropColumn("dbo.Mails", "Fullname");
        }
    }
}
