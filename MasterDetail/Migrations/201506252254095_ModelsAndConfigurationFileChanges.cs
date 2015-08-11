namespace MasterDetail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsAndConfigurationFileChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Labors", "Ak_Labor");
            DropIndex("dbo.Labors", "AK_Labor");
            CreateIndex("dbo.Labors", new[] { "WorkOrderId", "ServiceItemCode" }, unique: true, name: "AK_Labor");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Labors", "AK_Labor");
            CreateIndex("dbo.Labors", "ServiceItemCode", unique: true, name: "AK_Labor");
            CreateIndex("dbo.Labors", "WorkOrderId", unique: true, name: "Ak_Labor");
        }
    }
}
