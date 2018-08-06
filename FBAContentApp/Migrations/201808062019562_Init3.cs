namespace FBAContentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shipments", "ShipmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shipments", "ShipmentDate");
        }
    }
}
