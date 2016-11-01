namespace Bookstore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Title = c.String(),
                        Isbn = c.String(maxLength: 13),
                        Pages = c.Int(),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Isbn, unique: true);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderedBooks",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.BookId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedBooks", "BookId", "dbo.Books");
            DropForeignKey("dbo.OrderedBooks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Images", "BookId", "dbo.Books");
            DropIndex("dbo.OrderedBooks", new[] { "BookId" });
            DropIndex("dbo.OrderedBooks", new[] { "OrderId" });
            DropIndex("dbo.Images", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "Isbn" });
            DropTable("dbo.OrderedBooks");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Images");
            DropTable("dbo.Books");
        }
    }
}
