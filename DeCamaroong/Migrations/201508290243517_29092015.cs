namespace DeCamaroong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29092015 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.todoItems", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.todoItems", new[] { "User_Id" });
            CreateTable(
                "dbo.BlogItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        date = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            DropTable("dbo.todoItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.todoItems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        task = c.String(),
                        completed = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.BlogItems", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BlogItems", new[] { "User_Id" });
            DropTable("dbo.BlogItems");
            CreateIndex("dbo.todoItems", "User_Id");
            AddForeignKey("dbo.todoItems", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
