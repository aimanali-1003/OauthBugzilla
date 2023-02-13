namespace Oauth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        BugId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        status = c.Int(nullable: false),
                        type = c.Int(nullable: false),
                        deadline = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BugId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProjectId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserRoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProjects", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Bugs", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Bugs", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropIndex("dbo.UserProjects", new[] { "UserId" });
            DropIndex("dbo.Bugs", new[] { "ProjectId" });
            DropIndex("dbo.Bugs", new[] { "UserId" });
            DropTable("dbo.Logins");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.UserProjects");
            DropTable("dbo.Projects");
            DropTable("dbo.Bugs");
        }
    }
}
