using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelLayer;
using InterfaceLayer;

namespace ControllerLayer
{
    class Controller
    {
        //lists for GUI
        List<Shift> shifts;
        List<ShiftDate> shiftDates;
        List<StaffMember> staffMembers;
        List<WorkingHours> workingHours;
        List<Title> titles;
        List<Role> roles;

        //Shift currentShift;
        //ShiftDate currentShiftDate;
        //StaffMember currentStaffMember;
        //WorkingHours currentWorkingHours;
        //Title currentTitle;
        //Status currentStatus;
        //Role currentRole;
      //  DbAccessController myDbAccessController;

        #region properties //**Sebi**
        public Controller()
        {
            shifts = new List<Shift>();
            shiftDates = new List<ShiftDate>();
            staffMembers = new List<StaffMember>();
            workingHours = new List<WorkingHours>();
            titles = new List<Title>();
           
            roles = new List<Role>();
        }

        public List<IShift> Shifts
        {
            get
            {
                List<IShift> resultList = new List<IShift>();

                foreach (Shift shift in shifts)
                {
                    resultList.Add((IShift)shift);
                }
                return resultList;
            }
        }

        public List<IShiftDate> ShiftDates
        {
            get
            {
                List<IShiftDate> resultList = new List<IShiftDate>();

                foreach (ShiftDate shiftDate in shiftDates)
                {
                    resultList.Add((IShiftDate)shiftDate);
                }
                return resultList;
            }
        }

        public List<IRole> Roles
        {
            get
            {
                List<IRole> resultList = new List<IRole>();

                foreach (Role role in roles)
                {
                    resultList.Add((IRole)role);
                }
                return resultList;
            }
        }

        public List<IStaffMember> StaffMembers
        {
            get
            {
                List<IStaffMember> resultList = new List<IStaffMember>();

                foreach (StaffMember staffMember in staffMembers)
                {
                    resultList.Add((IStaffMember)staffMember);
                }
                return resultList;
            }
        }


        public List<ITitle> Titles
        {
            get
            {
                List<ITitle> resultList = new List<ITitle>();

                foreach (Title title in titles)
                {
                    resultList.Add((ITitle)title);
                }
                return resultList;
            }
        }

        public List<IWorkingHours2> WorkingHours
        {
            get {
                List<IWorkingHours2> resultList = new List<IWorkingHours2>();
                foreach (WorkingHours workinHours in workingHours)
                {
                    resultList.Add((IWorkingHours2)workinHours);
                }
                return resultList;
            }
        }

        #endregion
    }
}
