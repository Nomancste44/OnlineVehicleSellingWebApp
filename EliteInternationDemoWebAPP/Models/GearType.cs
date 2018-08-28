using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EliteInternationDemoWebAPP.Models
{
    public class GearType
    {
        [Key]
        public int GearTypeId { get; set; }
        [Required,Display(Name = "Gear Type")]
        public string GearTypeName { get; set; }

    }
}