namespace FBAContentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipmentBoxes", "BoxNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShipmentBoxes", "BoxNumber");
        }
    }
}
