namespace CarServiceCare.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseEnumAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "Type", c => c.String());
        }
    }
}
