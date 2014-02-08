using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OutOfSpace.API.Models
{
    public class SpaceObject
    {
        [Key]        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Alt { get; set; }
        public string Description { get; set; }
        public double Heading { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Range { get; set; }
        public double Tilt { get; set; }
    }
}