namespace WCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class modifygardetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Grade", c => c.Int(nullable: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Grade", c => c.String());
        }
    }
}