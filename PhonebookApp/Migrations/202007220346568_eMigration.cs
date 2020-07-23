namespace PhonebookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "EmailAddress");
        }
    }
}
