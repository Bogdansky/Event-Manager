namespace Test_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEventUser1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.EventUsers", "UserId", "dbo.ApplicationUsers");
            DropIndex("dbo.EventUsers", new[] { "UserId" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.EventUsers", "UserId", c => c.String());
            DropColumn("dbo.IdentityUserLogins", "ApplicationUser_Id");
            DropColumn("dbo.IdentityUserRoles", "ApplicationUser_Id");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserClaims");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IdentityUserRoles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.IdentityUserLogins", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.EventUsers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.IdentityUserRoles", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserLogins", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserClaims", "ApplicationUser_Id");
            CreateIndex("dbo.EventUsers", "UserId");
            AddForeignKey("dbo.EventUsers", "UserId", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
        }
    }
}
