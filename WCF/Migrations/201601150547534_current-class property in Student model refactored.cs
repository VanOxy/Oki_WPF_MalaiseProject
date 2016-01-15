namespace WCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currentclasspropertyinStudentmodelrefactored : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "CurrentClass", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "CurrentsClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "CurrentsClass", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "CurrentClass");
        }
    }
}
