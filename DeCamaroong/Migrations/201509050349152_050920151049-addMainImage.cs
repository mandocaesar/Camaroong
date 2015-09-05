namespace DeCamaroong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _050920151049addMainImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyBuildings", "Title", c => c.String());
            AddColumn("dbo.PropertyBuildings", "PostDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingImages", "MainImage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BuildingImages", "MainImage");
            DropColumn("dbo.PropertyBuildings", "PostDate");
            DropColumn("dbo.PropertyBuildings", "Title");
        }
    }
}
