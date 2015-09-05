namespace DeCamaroong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05092015AddBuildingImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        PropertyBuilding_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PropertyBuildings", t => t.PropertyBuilding_ID)
                .Index(t => t.PropertyBuilding_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildingImages", "PropertyBuilding_ID", "dbo.PropertyBuildings");
            DropIndex("dbo.BuildingImages", new[] { "PropertyBuilding_ID" });
            DropTable("dbo.BuildingImages");
        }
    }
}
