namespace DeCamaroong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGalleryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gallery",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.Gallery");
        }
    }
}
