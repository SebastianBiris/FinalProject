using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
   public interface IShift
    {
       string shiftType { get; }
       string shiftDiscription { get; }
       double shiftHours { get; }
    }
}

