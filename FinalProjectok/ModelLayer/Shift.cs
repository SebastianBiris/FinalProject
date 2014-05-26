using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
    public class Shift : IShift
    {
        int _shiftId;
        string _shiftType;
        string _shiftDiscription;
        double _shiftHours;
        StaffMember myStaffMember;

        public Shift(int shiftId, string shiftType, string shiftDiscription, double shiftHours)
        {
            _shiftId = shiftId;
            _shiftType = shiftType;
            _shiftDiscription = shiftDiscription;
            _shiftHours = shiftHours;
        }
        public Shift(int shiftId, string shiftType, string shiftDiscription, double shiftHours, StaffMember tempStaffMember)
        {
            _shiftId = shiftId;
            _shiftType = shiftType;
            _shiftDiscription = shiftDiscription;
            _shiftHours = shiftHours;
            myStaffMember = tempStaffMember;
            myStaffMember.AddShift(this);
        }

        #region Properties
        //MAL

        public int ShiftId
        {
            get { return _shiftId; }
            set { _shiftId = value; }
        }

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
        }

        public StaffMember MyStaffMember
        {
            get { return myStaffMember; }
            set { myStaffMember = value; }
        }

        public IStaffMember MyIStaffMember
        {
            get { return (IStaffMember)myStaffMember; }
        }
        public override string ToString()
        {
            return ShiftType;
        }
        #endregion

        #region Methods
        //**Sebi**
        /*
         * calculates the real worked hours for a staff member
         */ 
        public double calculateActualHours()
        {
            WorkingHours myWorkingHours = new WorkingHours(2);
            double actualHoursWorked1 = myWorkingHours.ActualHoursWorked;
            double actualHoursInShift;
            actualHoursInShift = _shiftHours - actualHoursWorked1;
            return actualHoursInShift;
        }

        #endregion

    }
}
