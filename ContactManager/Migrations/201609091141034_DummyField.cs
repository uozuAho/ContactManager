namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DummyField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DummyField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "DummyField");
        }
    }
}
