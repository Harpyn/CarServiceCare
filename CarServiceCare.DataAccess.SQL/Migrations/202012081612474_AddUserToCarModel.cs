namespace CarServiceCare.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToCarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "UserId", c => c.String());
            CreateIndex("dbo.Cars", "User_Id");
            AddForeignKey("dbo.Cars", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "User_Id", "dbo.Users");
            DropIndex("dbo.Cars", new[] { "User_Id" });
            AlterColumn("dbo.Users", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "User_Id");
        }
    }
}
