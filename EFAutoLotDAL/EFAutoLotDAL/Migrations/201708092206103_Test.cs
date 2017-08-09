namespace EFAutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CreditRisks", "TimeStamp");
            DropColumn("dbo.Customer", "TimeStamp");
            DropColumn("dbo.Order", "TimeStamp");
            DropColumn("dbo.Inventory", "TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventory", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Order", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customer", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.CreditRisks", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
