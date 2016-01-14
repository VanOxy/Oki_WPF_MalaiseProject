namespace WCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addsextoteacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Sex", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Teachers", "Sex");
        }
    }
}