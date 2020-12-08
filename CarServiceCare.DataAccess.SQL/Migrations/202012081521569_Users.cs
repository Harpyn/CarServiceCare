namespace CarServiceCare.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.CarInsurances", "InsuranceType", c => c.Int(nullable: false));
            AlterColumn("dbo.CarInsurances", "InsuranceCompany", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarInsurances", "InsuranceCompany", c => c.String());
            AlterColumn("dbo.CarInsurances", "InsuranceType", c => c.String());
            DropTable("dbo.Users");
        }
    }
}
