using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
   public interface IShift
    {

       string ShiftType { get; }
       string ShiftDiscription { get; }
       double ShiftHours { get; }

    }
}
