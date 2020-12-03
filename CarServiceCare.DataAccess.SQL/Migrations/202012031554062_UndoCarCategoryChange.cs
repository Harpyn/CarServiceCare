namespace CarServiceCare.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UndoCarCategoryChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Category", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Category", c => c.Int(nullable: false));
        }
    }
}
