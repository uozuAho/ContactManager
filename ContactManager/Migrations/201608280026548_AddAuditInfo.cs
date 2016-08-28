namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CreatedUtc", c => c.DateTime());
            AddColumn("dbo.Contacts", "UserCreated", c => c.String());
            AddColumn("dbo.Contacts", "ModifiedUtc", c => c.DateTime());
            AddColumn("dbo.Contacts", "UserModified", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "UserModified");
            DropColumn("dbo.Contacts", "ModifiedUtc");
            DropColumn("dbo.Contacts", "UserCreated");
            DropColumn("dbo.Contacts", "CreatedUtc");
        }
    }
}
