using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class WorkingHours
    {
        
        double _totalHoursWorked;


        public WorkingHours(double totalHoursWorked)
        {
            _totalHoursWorked = totalHoursWorked;
        }
        #region Properties //MAL
        public double TotalHoursWorked
        {
            get { return _totalHoursWorked; }
            set { _totalHoursWorked = value; }
        #endregion
        }
    }
}
