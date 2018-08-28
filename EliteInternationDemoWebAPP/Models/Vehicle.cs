using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using  System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace EliteInternationDemoWebAPP.Models
{
    public class Vehicle
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        [Display(Name ="Model / Vehicle Name:"),Required(ErrorMessage = "Please Give a Vehicle Name")]
        public string Model { get; set; }
        [DataType(DataType.Date),Required(ErrorMessage = "Set the Registration Date")]
        public DateTime Registraion { get; set; }

        [Required,Display(Name = "Engine Capacity")]
        public float EngineCapacity { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required, Display(Name = "Steer Position")]
        public int SteerTypeId { get; set; }
        [Required]
        public float MileAges { get; set; }
        [Required,Display(Name = "Gear Type")]
        public int GearTypeId { get; set; }
        [Required,Display(Name = "Fuel type")]
        public int FuelTypeId { get; set; }
        [Required,Display(Name = "Color Of Vehicle")]
        public int ColorOfVehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        [ForeignKey("VehicleTypeId")]
        public virtual  TypeOfVehicle TypeOfVehicle { get; set; }
        [ForeignKey("SteerTypeId")]
        public virtual  SteerType SteerType { get; set; }
        [ForeignKey("GearTypeId")]
        public virtual  GearType GearType { get; set; }
        [ForeignKey("FuelTypeId")]
        public virtual FuelType FuelType { get; set; }
        [ForeignKey("ColorOfVehicleId")]
        public virtual  ColorOfVehilce ColorOfVehilce { get; set; }

    }

   
}