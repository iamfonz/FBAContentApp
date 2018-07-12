namespace FBAContentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AmazonWarehouses", "State_Id", c => c.Int());
            AddColumn("dbo.CompanyAddresses", "State_Id", c => c.Int());
            CreateIndex("dbo.AmazonWarehouses", "State_Id");
            CreateIndex("dbo.CompanyAddresses", "State_Id");
            AddForeignKey("dbo.AmazonWarehouses", "State_Id", "dbo.States", "Id");
            AddForeignKey("dbo.CompanyAddresses", "State_Id", "dbo.States", "Id");
            DropColumn("dbo.AmazonWarehouses", "State");
            DropColumn("dbo.CompanyAddresses", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyAddresses", "State", c => c.String());
            AddColumn("dbo.AmazonWarehouses", "State", c => c.String());
            DropForeignKey("dbo.CompanyAddresses", "State_Id", "dbo.States");
            DropForeignKey("dbo.AmazonWarehouses", "State_Id", "dbo.States");
            DropIndex("dbo.CompanyAddresses", new[] { "State_Id" });
            DropIndex("dbo.AmazonWarehouses", new[] { "State_Id" });
            DropColumn("dbo.CompanyAddresses", "State_Id");
            DropColumn("dbo.AmazonWarehouses", "State_Id");
        }
    }
}
