using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OutOfSpace.Web.Models
{
    public class Photo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public Int64 SpaceObjectId { get; set; }
        [ForeignKey("SpaceObjectId")]
        [IgnoreDataMember]
        public SpaceObject Target { get; set; }
        public Carma Carma { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}