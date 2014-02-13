using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfSpace.Web.Models
{
    public class SpaceObject
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public double Alt { get; set; }
        public int Alt_enum { get; set; }
        public string Description { get; set; }
        public double Heading { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Range { get; set; }
        public double Tilt { get; set; }
        public Carma Carma { get; set; }
        public ICollection<Photo> Photos { get; set; } 
    }
}