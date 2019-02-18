namespace Test_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserInfoes", "Surname", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "Surname", c => c.String());
            AlterColumn("dbo.UserInfoes", "Name", c => c.String());
        }
    }
}
