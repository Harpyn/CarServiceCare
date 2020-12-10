namespace CarServiceCare.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarRemoveCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "VIN", c => c.String());
            DropColumn("dbo.Cars", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Category", c => c.String());
            AlterColumn("dbo.Cars", "VIN", c => c.Int(nullable: false));
        }
    }
}
