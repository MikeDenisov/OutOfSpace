using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OutOfSpace2.Web.Models.Interfaces;

namespace OutOfSpace2.Web.Models
{
    public class Carma: IHasCarma
    {
        public int Amount { get; set; }
        public IHasCarma Parent { get; set; }

        public int Increase()
        {
            return ++this.Amount;
        }

        public int Decrease()
        {
            return --this.Amount;
        }
    }
}