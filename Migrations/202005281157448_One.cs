namespace TestProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class One : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ansvers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Check = c.Int(nullable: false),
                        CorrectAnsver = c.Int(nullable: false),
                        CountBall = c.Int(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1024),
                        Check = c.Int(nullable: false),
                        PhotoPath = c.String(),
                        AudioPath = c.String(),
                        Response = c.Int(nullable: false),
                        CountTrueAnsverToQuestion = c.Int(nullable: false),
                        CountTrue = c.Int(nullable: false),
                        CountFalse = c.Int(nullable: false),
                        Theme_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Themes", t => t.Theme_Id)
                .Index(t => t.Theme_Id);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1024),
                        Procent = c.Int(nullable: false),
                        TrueText = c.String(),
                        FalseText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ThemeName = c.String(nullable: false),
                        CountProcent = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Passet = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SelectedTheme = c.String(nullable: false),
                        Language = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        SettingViewModal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Settings", t => t.SettingViewModal_Id)
                .Index(t => t.SettingViewModal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Settings", "SettingViewModal_Id", "dbo.Settings");
            DropForeignKey("dbo.Questions", "Theme_Id", "dbo.Themes");
            DropForeignKey("dbo.Ansvers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Settings", new[] { "SettingViewModal_Id" });
            DropIndex("dbo.Questions", new[] { "Theme_Id" });
            DropIndex("dbo.Ansvers", new[] { "Question_Id" });
            DropTable("dbo.Settings");
            DropTable("dbo.Histories");
            DropTable("dbo.Themes");
            DropTable("dbo.Questions");
            DropTable("dbo.Ansvers");
        }
    }
}
