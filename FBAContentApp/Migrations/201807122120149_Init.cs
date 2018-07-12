namespace FBAContentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AmazonWarehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseCode = c.String(),
                        Name = c.String(),
                        AddressLine = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShipmentBoxes",
                c => new
                    {
                        BoxId = c.String(nullable: false, maxLength: 128),
                        BoxContentString = c.String(),
                        Shipment_ShipmentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BoxId)
                .ForeignKey("dbo.Shipments", t => t.Shipment_ShipmentId)
                .Index(t => t.Shipment_ShipmentId);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        ShipmentId = c.String(nullable: false, maxLength: 128),
                        ShipFromCenter_Id = c.Int(),
                        ShipToCenter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ShipmentId)
                .ForeignKey("dbo.CompanyAddresses", t => t.ShipFromCenter_Id)
                .ForeignKey("dbo.AmazonWarehouses", t => t.ShipToCenter_Id)
                .Index(t => t.ShipFromCenter_Id)
                .Index(t => t.ShipToCenter_Id);
            
            CreateTable(
                "dbo.CompanyAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipments", "ShipToCenter_Id", "dbo.AmazonWarehouses");
            DropForeignKey("dbo.Shipments", "ShipFromCenter_Id", "dbo.CompanyAddresses");
            DropForeignKey("dbo.ShipmentBoxes", "Shipment_ShipmentId", "dbo.Shipments");
            DropIndex("dbo.Shipments", new[] { "ShipToCenter_Id" });
            DropIndex("dbo.Shipments", new[] { "ShipFromCenter_Id" });
            DropIndex("dbo.ShipmentBoxes", new[] { "Shipment_ShipmentId" });
            DropTable("dbo.States");
            DropTable("dbo.CompanyAddresses");
            DropTable("dbo.Shipments");
            DropTable("dbo.ShipmentBoxes");
            DropTable("dbo.AmazonWarehouses");
        }
    }
}
