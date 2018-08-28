namespace EliteInternationDemoWebAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ColorOfVehilces",
                c => new
                    {
                        ColorOfVehicleId = c.Int(nullable: false, identity: true),
                        ColorOfVehicleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ColorOfVehicleId);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        FuelTypeId = c.Int(nullable: false, identity: true),
                        FuelTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FuelTypeId);
            
            CreateTable(
                "dbo.GearTypes",
                c => new
                    {
                        GearTypeId = c.Int(nullable: false, identity: true),
                        GearTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GearTypeId);
            
            CreateTable(
                "dbo.SteerTypes",
                c => new
                    {
                        SteerTypeId = c.Int(nullable: false, identity: true),
                        SteerTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SteerTypeId);
            
            CreateTable(
                "dbo.TypeOfVehicles",
                c => new
                    {
                        VehicleTypeId = c.Int(nullable: false, identity: true),
                        VehicleTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.VehicleImages",
                c => new
                    {
                        VehicleImageId = c.Int(nullable: false, identity: true),
                        VehicleImages = c.Binary(),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleImageId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        Registraion = c.DateTime(nullable: false),
                        EngineCapacity = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SteerTypeId = c.Int(nullable: false),
                        MileAges = c.Single(nullable: false),
                        GearTypeId = c.Int(nullable: false),
                        FuelTypeId = c.Int(nullable: false),
                        ColorOfVehicleId = c.Int(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.ColorOfVehilces", t => t.ColorOfVehicleId, cascadeDelete: true)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeId, cascadeDelete: true)
                .ForeignKey("dbo.GearTypes", t => t.GearTypeId, cascadeDelete: true)
                .ForeignKey("dbo.SteerTypes", t => t.SteerTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfVehicles", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.ColorOfVehicleId)
                .Index(t => t.FuelTypeId)
                .Index(t => t.GearTypeId)
                .Index(t => t.SteerTypeId)
                .Index(t => t.VehicleTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleImages", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.TypeOfVehicles");
            DropForeignKey("dbo.Vehicles", "SteerTypeId", "dbo.SteerTypes");
            DropForeignKey("dbo.Vehicles", "GearTypeId", "dbo.GearTypes");
            DropForeignKey("dbo.Vehicles", "FuelTypeId", "dbo.FuelTypes");
            DropForeignKey("dbo.Vehicles", "ColorOfVehicleId", "dbo.ColorOfVehilces");
            DropIndex("dbo.VehicleImages", new[] { "VehicleId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            DropIndex("dbo.Vehicles", new[] { "SteerTypeId" });
            DropIndex("dbo.Vehicles", new[] { "GearTypeId" });
            DropIndex("dbo.Vehicles", new[] { "FuelTypeId" });
            DropIndex("dbo.Vehicles", new[] { "ColorOfVehicleId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleImages");
            DropTable("dbo.TypeOfVehicles");
            DropTable("dbo.SteerTypes");
            DropTable("dbo.GearTypes");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.ColorOfVehilces");
        }
    }
}
