namespace TestProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Three : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Name", c => c.String(nullable: false, maxLength: 1024));
        }
    }
}
