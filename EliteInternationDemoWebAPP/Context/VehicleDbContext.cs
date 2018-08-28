using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.AccessControl;
using EliteInternationDemoWebAPP.Models;

namespace EliteInternationDemoWebAPP.Context
{
    public class VehicleDbContext:DbContext
    {
        public DbSet<TypeOfVehicle> TypesOfVehicles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<ColorOfVehilce> ColorOfVehilces { get; set; }
        public DbSet<GearType> GearTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<SteerType> SteerTypes { get; set; }

        public VehicleDbContext():base("VehicleDbContext")
        {
            
        }
    }
}