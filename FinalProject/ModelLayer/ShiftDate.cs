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
        List<Shift> myShift;

       public ShiftDate(DateTime dateWorked)
       {
           _dateWorked = dateWorked;
           myShift = new List<Shift>();
       }

       #region Properties

       public DateTime DateWorked
       {
           get { return _dateWorked; }
           set { _dateWorked = value ; }
       }
       #endregion

       #region Methods //**Sebi**
       public void addOrder(Shift anShift)
       {
           myShift.Add(anShift);
       }
       #endregion

   }
}
