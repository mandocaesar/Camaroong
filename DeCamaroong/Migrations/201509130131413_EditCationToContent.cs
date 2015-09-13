namespace DeCamaroong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCationToContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "Content", c => c.String());
            DropColumn("dbo.Galleries", "Caption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Galleries", "Caption", c => c.String());
            DropColumn("dbo.Galleries", "Content");
        }
    }
}
