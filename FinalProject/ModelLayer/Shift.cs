using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class Shift
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
        public string Discription
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
    }
}
