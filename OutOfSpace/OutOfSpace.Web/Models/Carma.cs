using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using OutOfSpace.Web.Models.Interfaces;

namespace OutOfSpace.Web.Models
{
    [DataContract(IsReference = true)]
    public class Carma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Int64 Id { get; set; }
        [DataMember]
        public float Amount { get; set; }
        public Carma Parent { get; set; }
        [DataMember]
        public float Rate { get; set; }

        public float Increase()
        {
            return this.ChangeValue(1);
        }

        public float Decrease()
        {
            return this.ChangeValue(-1);
        }

        public float ChangeValue(float value)
        {
            Amount += value;
            if (Parent != null)
            {
                Parent.ChangeValue(value * Rate);
            }
            return Amount;
        }
    }
}