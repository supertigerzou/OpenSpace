namespace GreenField.Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorEntityPicture",
                c => new
                    {
                        AuthorId = c.Long(nullable: false),
                        EntityPictureId = c.Long(nullable: false),
                        Primary = c.Boolean(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorId, t.EntityPictureId })
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.EntityPicture", t => t.EntityPictureId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.EntityPictureId);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PersonType = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LoginUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LoginUser_Id)
                .Index(t => t.LoginUser_Id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        AutherId = c.Long(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.AutherId, cascadeDelete: true)
                .Index(t => t.AutherId);
            
            CreateTable(
                "dbo.BookEntityPicture",
                c => new
                    {
                        BookId = c.Long(nullable: false),
                        EntityPictureId = c.Long(nullable: false),
                        Primary = c.Boolean(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.EntityPictureId })
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.EntityPicture", t => t.EntityPictureId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.EntityPictureId);
            
            CreateTable(
                "dbo.EntityPicture",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ThumbNailPhoto = c.Binary(),
                        ThumbnailPhotoFileName = c.String(maxLength: 50),
                        LargePhoto = c.Binary(),
                        LargePhotoFileName = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Cover = c.String(),
                        Desc = c.String(),
                        Duration = c.Int(nullable: false),
                        TellerId = c.Long(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teller", t => t.TellerId, cascadeDelete: true)
                .Index(t => t.TellerId);
            
            CreateTable(
                "dbo.StoryEntityPicture",
                c => new
                    {
                        StoryId = c.Long(nullable: false),
                        EntityPictureId = c.Long(nullable: false),
                        Primary = c.Boolean(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoryId, t.EntityPictureId })
                .ForeignKey("dbo.Story", t => t.StoryId, cascadeDelete: true)
                .ForeignKey("dbo.EntityPicture", t => t.EntityPictureId, cascadeDelete: true)
                .Index(t => t.StoryId)
                .Index(t => t.EntityPictureId);
            
            CreateTable(
                "dbo.Teller",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PersonType = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LoginUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LoginUser_Id)
                .Index(t => t.LoginUser_Id);
            
            CreateTable(
                "dbo.TellerEntityPicture",
                c => new
                    {
                        TellerId = c.Long(nullable: false),
                        EntityPictureId = c.Long(nullable: false),
                        Primary = c.Boolean(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.TellerId, t.EntityPictureId })
                .ForeignKey("dbo.Teller", t => t.TellerId, cascadeDelete: true)
                .ForeignKey("dbo.EntityPicture", t => t.EntityPictureId, cascadeDelete: true)
                .Index(t => t.TellerId)
                .Index(t => t.EntityPictureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Story", "TellerId", "dbo.Teller");
            DropForeignKey("dbo.Teller", "LoginUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TellerEntityPicture", "EntityPictureId", "dbo.EntityPicture");
            DropForeignKey("dbo.TellerEntityPicture", "TellerId", "dbo.Teller");
            DropForeignKey("dbo.StoryEntityPicture", "EntityPictureId", "dbo.EntityPicture");
            DropForeignKey("dbo.StoryEntityPicture", "StoryId", "dbo.Story");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AuthorEntityPicture", "EntityPictureId", "dbo.EntityPicture");
            DropForeignKey("dbo.AuthorEntityPicture", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.Author", "LoginUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookEntityPicture", "EntityPictureId", "dbo.EntityPicture");
            DropForeignKey("dbo.BookEntityPicture", "BookId", "dbo.Book");
            DropForeignKey("dbo.Book", "AutherId", "dbo.Author");
            DropIndex("dbo.TellerEntityPicture", new[] { "EntityPictureId" });
            DropIndex("dbo.TellerEntityPicture", new[] { "TellerId" });
            DropIndex("dbo.Teller", new[] { "LoginUser_Id" });
            DropIndex("dbo.StoryEntityPicture", new[] { "EntityPictureId" });
            DropIndex("dbo.StoryEntityPicture", new[] { "StoryId" });
            DropIndex("dbo.Story", new[] { "TellerId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BookEntityPicture", new[] { "EntityPictureId" });
            DropIndex("dbo.BookEntityPicture", new[] { "BookId" });
            DropIndex("dbo.Book", new[] { "AutherId" });
            DropIndex("dbo.Author", new[] { "LoginUser_Id" });
            DropIndex("dbo.AuthorEntityPicture", new[] { "EntityPictureId" });
            DropIndex("dbo.AuthorEntityPicture", new[] { "AuthorId" });
            DropTable("dbo.TellerEntityPicture");
            DropTable("dbo.Teller");
            DropTable("dbo.StoryEntityPicture");
            DropTable("dbo.Story");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.EntityPicture");
            DropTable("dbo.BookEntityPicture");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
            DropTable("dbo.AuthorEntityPicture");
        }
    }
}
