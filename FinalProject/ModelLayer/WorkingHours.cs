using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
    class WorkingHours
    {
        
        double _actualHoursWorked;


        public WorkingHours(double actualHoursWorked)
        {
            _actualHoursWorked = actualHoursWorked;
        }
        #region Properties //MAL
        public double TotalHoursWorked
        {
            get { return _actualHoursWorked; }
            set { _actualHoursWorked = value; }
        #endregion
        }
    }
}
