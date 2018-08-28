using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteInternationDemoWebAPP.Models
{
    public class ColorOfVehilce
    {
        [Key]
        public int ColorOfVehicleId { get; set; }
        [Required,Display(Name = "Color")]
        public string ColorOfVehicleName { get; set; }

    }
}