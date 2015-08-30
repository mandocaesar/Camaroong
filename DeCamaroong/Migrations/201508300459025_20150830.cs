namespace DeCamaroong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20150830 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyBuildings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LandSquare = c.String(),
                        BuildingSquare = c.String(),
                        BathRoom = c.Int(nullable: false),
                        BedRoom = c.Int(nullable: false),
                        Content = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mails");
            DropTable("dbo.PropertyBuildings");
        }
    }
}
