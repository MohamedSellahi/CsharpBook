namespace EFAutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeStamps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Order", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Inventory", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventory", "TimeStamp");
            DropColumn("dbo.Order", "TimeStamp");
            DropColumn("dbo.Customer", "TimeStamp");
        }
    }
}
