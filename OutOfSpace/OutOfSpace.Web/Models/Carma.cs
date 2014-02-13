using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OutOfSpace.Web.Models.Interfaces;

namespace OutOfSpace.Web.Models
{
    public class Carma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public float Amount { get; set; }
        public Carma Parent { get; set; }
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