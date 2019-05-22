namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsHealty = c.Boolean(nullable: false),
                        FoodType = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: false) //false yaptým. cascade hatasý alýyordum
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FullName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "UserId", "dbo.Users");
            DropForeignKey("dbo.Foods", "UserId", "dbo.Users");
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Restaurants", new[] { "UserId" });
            DropIndex("dbo.Foods", new[] { "UserId" });
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            DropTable("dbo.Users");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Foods");
        }
    }
}
