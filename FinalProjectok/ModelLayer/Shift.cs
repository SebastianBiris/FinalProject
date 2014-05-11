using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
  public  class Shift:IShift
    {
        string _shiftType;
        string _shiftDiscription;
        double _shiftHours;
       
    
        public Shift(string shiftType, string shiftDiscription, double shiftHours)
        {
            _shiftType = shiftType;
            _shiftDiscription = shiftDiscription;
            _shiftHours = shiftHours;
           
        }
        #region Properties //MAL
        public string ShiftType
        {
            get { return _shiftType; }
            set { _shiftType = value; }
        }
        public string ShiftDiscription
        {
            get { return _shiftDiscription; }
            set { _shiftDiscription = value; }
        }
        public double ShiftHours
        {
            get { return _shiftHours; }
            set { _shiftHours = value; }
#endregion
        }
        #region Methods //**Sebi**
     
        public double calculateActualHours()
        {
            WorkingHours myWorkingHours = new WorkingHours(2);
            double actualHoursWorked1 =myWorkingHours.ActualHoursWorked;
            double actualHoursInShift;
            actualHoursInShift = _shiftHours - actualHoursWorked1;
            return actualHoursInShift;
        }
        #endregion
    }
}
