namespace Test_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventUsers", "EventId", "dbo.Events");
            DropIndex("dbo.EventUsers", new[] { "EventId" });
            AlterColumn("dbo.EventUsers", "EventId", c => c.Int());
            CreateIndex("dbo.EventUsers", "EventId");
            AddForeignKey("dbo.EventUsers", "EventId", "dbo.Events", "EventId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventUsers", "EventId", "dbo.Events");
            DropIndex("dbo.EventUsers", new[] { "EventId" });
            AlterColumn("dbo.EventUsers", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.EventUsers", "EventId");
            AddForeignKey("dbo.EventUsers", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
        }
    }
}
