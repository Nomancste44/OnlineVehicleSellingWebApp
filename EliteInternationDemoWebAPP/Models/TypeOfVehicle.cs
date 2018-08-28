using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteInternationDemoWebAPP.Models
{
    public class TypeOfVehicle
    {
        [Key, ScaffoldColumn(false),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleTypeId { get; set; }
        [Required,Display(Name = "Vehicle Type")]
        public string VehicleTypeName { get; set; }
        public virtual IEnumerable<Vehicle> ListOfVehicles { get; set; }

    }
}