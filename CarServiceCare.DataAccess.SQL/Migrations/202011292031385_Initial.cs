namespace CarServiceCare.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarInsurances",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        InsuranceType = c.String(),
                        InsuranceCompany = c.String(),
                        ValidTo = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                        Car_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CarBrand = c.Int(nullable: false),
                        VehicleType = c.Int(nullable: false),
                        FuelType = c.Int(nullable: false),
                        CubicCapacity = c.Int(nullable: false),
                        Power = c.Int(nullable: false),
                        VIN = c.Int(nullable: false),
                        Kilometer = c.Int(nullable: false),
                        Owners = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstRegistration = c.DateTime(nullable: false),
                        DateOfPurchase = c.DateTime(nullable: false),
                        Model = c.String(),
                        Color = c.String(),
                        LicensePlate = c.String(),
                        Category = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                        Car_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Refuelings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FuelStation = c.String(),
                        FuelType = c.Int(nullable: false),
                        Route = c.String(),
                        DrivingStyle = c.String(),
                        Distance = c.Int(nullable: false),
                        FuelConsumption = c.Int(nullable: false),
                        Liters = c.Int(),
                        PriceForLiter = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                        Car_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RepairType = c.String(),
                        EstimatedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Priority = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                        Car_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ServiceType = c.String(),
                        CarService = c.String(),
                        Description = c.String(),
                        Kilometer = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                        Car_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.STK",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ValidTo = c.DateTime(nullable: false),
                        Station = c.String(),
                        Description = c.String(),
                        Kilometer = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Passed = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                        Car_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.TireChanges",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        TireManufacturer = c.String(),
                        Balanced = c.String(),
                        CarService = c.String(),
                        Kilometer = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Note = c.String(),
                        Photo = c.String(),
                        Car_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TireChanges", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.STKs", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Services", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Repairs", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Refuelings", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Expenses", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.CarInsurances", "Car_Id", "dbo.Cars");
            DropIndex("dbo.TireChanges", new[] { "Car_Id" });
            DropIndex("dbo.STKs", new[] { "Car_Id" });
            DropIndex("dbo.Services", new[] { "Car_Id" });
            DropIndex("dbo.Repairs", new[] { "Car_Id" });
            DropIndex("dbo.Refuelings", new[] { "Car_Id" });
            DropIndex("dbo.Expenses", new[] { "Car_Id" });
            DropIndex("dbo.CarInsurances", new[] { "Car_Id" });
            DropTable("dbo.TireChanges");
            DropTable("dbo.STKs");
            DropTable("dbo.Services");
            DropTable("dbo.Repairs");
            DropTable("dbo.Refuelings");
            DropTable("dbo.Expenses");
            DropTable("dbo.Cars");
            DropTable("dbo.CarInsurances");
        }
    }
}
