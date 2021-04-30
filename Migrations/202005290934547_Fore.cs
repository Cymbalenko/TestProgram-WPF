namespace TestProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fore : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ansvers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ansvers", "Name", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
