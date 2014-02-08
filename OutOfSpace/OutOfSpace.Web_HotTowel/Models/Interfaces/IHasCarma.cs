using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfSpace2.Web.Models.Interfaces
{
    public interface IHasCarma
    {
        int Increase();
        int Decrease();
        int Amount { get; set; }
    }
}
