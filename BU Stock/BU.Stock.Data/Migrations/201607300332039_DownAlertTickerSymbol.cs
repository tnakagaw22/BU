namespace BU.Stock.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DownAlertTickerSymbol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DownAlerts", "TickerSymbol", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.DownAlerts", "Symbol");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DownAlerts", "Symbol", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.DownAlerts", "TickerSymbol");
        }
    }
}
