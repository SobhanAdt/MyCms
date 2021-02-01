namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initailedit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PageComments", "Email", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PageComments", "Email", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
