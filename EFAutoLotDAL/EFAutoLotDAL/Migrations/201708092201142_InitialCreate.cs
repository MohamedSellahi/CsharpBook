namespace EFAutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditRisks",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.CustId)
                .Index(t => new { t.LastName, t.FirstName }, unique: true, name: "IDX_CreditRisk_Name");
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.CustId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Inventory", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustId, cascadeDelete: true)
                .Index(t => t.CustId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Maker = c.String(maxLength: 50),
                        Color = c.String(maxLength: 50),
                        PetName = c.String(maxLength: 50),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "CustId", "dbo.Customer");
            DropForeignKey("dbo.Order", "CarId", "dbo.Inventory");
            DropIndex("dbo.Order", new[] { "CarId" });
            DropIndex("dbo.Order", new[] { "CustId" });
            DropIndex("dbo.CreditRisks", "IDX_CreditRisk_Name");
            DropTable("dbo.Inventory");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
            DropTable("dbo.CreditRisks");
        }
    }
}
