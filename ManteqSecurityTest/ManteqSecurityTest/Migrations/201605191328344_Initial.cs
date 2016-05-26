namespace ManteqSecurityTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Licence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserLimit = c.Long(nullable: false),
                        DateCreation = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreation = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManteqApplicationRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreation = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        DateCreation = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        SubscriptionId = c.Int(nullable: false),
                        DateCreation = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId, cascadeDelete: true)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DateSubscribed = c.DateTime(nullable: false),
                        DateExpired = c.DateTime(nullable: false),
                        LicenceId = c.Int(nullable: false),
                        DateCreation = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedBy = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licence", t => t.LicenceId, cascadeDelete: true)
                .Index(t => t.LicenceId);
            
            CreateTable(
                "dbo.LicenceModule",
                c => new
                    {
                        ModuleId = c.Int(nullable: false),
                        LicenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ModuleId, t.LicenceId })
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Licence", t => t.LicenceId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.LicenceId);
            
            CreateTable(
                "dbo.UserManteqApplicationRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.ManteqApplicationRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserTenant",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.TenantId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Tenant", t => t.TenantId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTenant", "TenantId", "dbo.Tenant");
            DropForeignKey("dbo.UserTenant", "UserId", "dbo.User");
            DropForeignKey("dbo.Tenant", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.Subscription", "LicenceId", "dbo.Licence");
            DropForeignKey("dbo.UserManteqApplicationRole", "RoleId", "dbo.ManteqApplicationRole");
            DropForeignKey("dbo.UserManteqApplicationRole", "UserId", "dbo.User");
            DropForeignKey("dbo.LicenceModule", "LicenceId", "dbo.Licence");
            DropForeignKey("dbo.LicenceModule", "ModuleId", "dbo.Module");
            DropIndex("dbo.UserTenant", new[] { "TenantId" });
            DropIndex("dbo.UserTenant", new[] { "UserId" });
            DropIndex("dbo.UserManteqApplicationRole", new[] { "RoleId" });
            DropIndex("dbo.UserManteqApplicationRole", new[] { "UserId" });
            DropIndex("dbo.LicenceModule", new[] { "LicenceId" });
            DropIndex("dbo.LicenceModule", new[] { "ModuleId" });
            DropIndex("dbo.Subscription", new[] { "LicenceId" });
            DropIndex("dbo.Tenant", new[] { "SubscriptionId" });
            DropTable("dbo.UserTenant");
            DropTable("dbo.UserManteqApplicationRole");
            DropTable("dbo.LicenceModule");
            DropTable("dbo.Subscription");
            DropTable("dbo.Tenant");
            DropTable("dbo.User");
            DropTable("dbo.ManteqApplicationRole");
            DropTable("dbo.Module");
            DropTable("dbo.Licence");
        }
    }
}
