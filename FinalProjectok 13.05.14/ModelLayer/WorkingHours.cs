using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using  InterfaceLayer;


namespace ModelLayer
{
    public class WorkingHours : IWorkingHours2
   {  double _actualHoursWorked;
     public WorkingHours(double actualHoursWorked)
        {
            _actualHoursWorked = actualHoursWorked;
        }
 
 #region Properties //MAL

     

     public double ActualHoursWorked
     {
         get { return _actualHoursWorked; }
         set { _actualHoursWorked = value; }
     }
        #endregion
        }
    }

