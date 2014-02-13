using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfSpace.Web.Models.Interfaces
{
    public interface IHasCarma
    {
        float ChangeValue(float value);
        float Amount { get; set; }
    }
}
