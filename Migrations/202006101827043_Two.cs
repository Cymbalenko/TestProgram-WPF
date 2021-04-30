namespace TestProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Settings", "SettingViewModal_Id", "dbo.Settings");
            DropIndex("dbo.Settings", new[] { "SettingViewModal_Id" });
            DropTable("dbo.Settings");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Settings", "SettingViewModal_Id");
            AddForeignKey("dbo.Settings", "SettingViewModal_Id", "dbo.Settings", "Id");
        }
    }
}
