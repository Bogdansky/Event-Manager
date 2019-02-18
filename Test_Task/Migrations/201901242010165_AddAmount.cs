namespace Test_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "UserAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "UserAmount");
        }
    }
}
