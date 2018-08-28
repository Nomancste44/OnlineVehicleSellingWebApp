using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteInternationDemoWebAPP.Models
{
    public class SteerType
    {
        [Key]
        public int SteerTypeId { get; set; }
        [Required,Display(Name = "Steer Type")]
        public string SteerTypeName { get; set; }
    }
}