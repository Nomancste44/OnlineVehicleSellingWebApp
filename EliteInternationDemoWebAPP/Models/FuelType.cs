using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteInternationDemoWebAPP.Models
{
    public class FuelType
    {
        [Key]
        public int FuelTypeId { get; set; }
        [Required,Display(Name = "Fuel")]
        public string FuelTypeName { get; set; }

    }
}