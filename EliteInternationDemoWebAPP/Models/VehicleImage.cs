using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EliteInternationDemoWebAPP.Models
{
    public class VehicleImage
    {
        [Key]
        public int VehicleImageId { get; set; }
        public byte[] VehicleImages { get; set; }
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    }
}