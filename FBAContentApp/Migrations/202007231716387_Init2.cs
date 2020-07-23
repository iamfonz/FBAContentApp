namespace FBAContentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AmazonWarehouses", "State_Id", "dbo.States");
            DropForeignKey("dbo.CompanyAddresses", "State_Id", "dbo.States");
            DropIndex("dbo.AmazonWarehouses", new[] { "State_Id" });
            DropIndex("dbo.CompanyAddresses", new[] { "State_Id" });
            RenameColumn(table: "dbo.AmazonWarehouses", name: "State_Id", newName: "StateId");
            RenameColumn(table: "dbo.CompanyAddresses", name: "State_Id", newName: "StateId");
            AlterColumn("dbo.AmazonWarehouses", "StateId", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyAddresses", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.AmazonWarehouses", "StateId");
            CreateIndex("dbo.CompanyAddresses", "StateId");
            AddForeignKey("dbo.AmazonWarehouses", "StateId", "dbo.States", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CompanyAddresses", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyAddresses", "StateId", "dbo.States");
            DropForeignKey("dbo.AmazonWarehouses", "StateId", "dbo.States");
            DropIndex("dbo.CompanyAddresses", new[] { "StateId" });
            DropIndex("dbo.AmazonWarehouses", new[] { "StateId" });
            AlterColumn("dbo.CompanyAddresses", "StateId", c => c.Int());
            AlterColumn("dbo.AmazonWarehouses", "StateId", c => c.Int());
            RenameColumn(table: "dbo.CompanyAddresses", name: "StateId", newName: "State_Id");
            RenameColumn(table: "dbo.AmazonWarehouses", name: "StateId", newName: "State_Id");
            CreateIndex("dbo.CompanyAddresses", "State_Id");
            CreateIndex("dbo.AmazonWarehouses", "State_Id");
            AddForeignKey("dbo.CompanyAddresses", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.AmazonWarehouses", "State_Id", "dbo.States", "Id");
        }
    }
}
