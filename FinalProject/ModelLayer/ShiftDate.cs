using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
   public class ShiftDate: IShiftDate
   {
        DateTime _dateWorked;

       public ShiftDate(DateTime dateWorked)
       {
           _dateWorked = dateWorked;
       }

       #region Properties

       public DateTime DateWorked
       {
           get { return _dateWorked; }
           set { _dateWorked = value ; }
       }
       #endregion
   }
}
