namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemDummyField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "DummyField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "DummyField", c => c.String());
        }
    }
}
