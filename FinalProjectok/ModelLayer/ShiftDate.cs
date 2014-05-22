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
        int _dateId;
        int _staffMemberId;  //chris 19.05
        int _shiftId;
        StaffMember myStaffMember;
        string _staffMemberName;

        DateTime _actualDate;

        string _shiftType;

     

        public ShiftDate(int dateId, DateTime dateWorked, StaffMember actualStaffMember, int staffMemberId) //working with method inside StaffMember
        {
            _dateId = dateId;
            myStaffMember = actualStaffMember;//chris 19.05
            myStaffMember.AddShiftDate(this);
            _staffMemberId = staffMemberId;
            _dateWorked = dateWorked;
        }

        public ShiftDate(int dateId, DateTime dateWorked, int staffMemberId)  //Chris 19.05 For Viewing WorkDay from DB
        {
            _dateId = dateId;
            _dateWorked = dateWorked;
            _staffMemberId = staffMemberId;
        }
        public ShiftDate(string staffMemberName, string shiftType, DateTime actualDate)
        { _staffMemberName = staffMemberName;
        _shiftType = shiftType;
        _actualDate = actualDate;
        }

        public ShiftDate(int dateId, int staffMemberId, int shiftId)  //Chris 19.05 For saving staffMemberWorkDay to DB 
        {
            _dateId = dateId;
            _staffMemberId = staffMemberId;
            _shiftId = shiftId;
        }

       #region Properties

        public int DateId  //chris 19.05
        {
            get { return _dateId; }
            set { _dateId = value; }
        }

        public int StaffMemberId
        {
            get { return _staffMemberId; }
            set { _staffMemberId = value; }
        }

        public int ShiftId
        {
            get { return _shiftId; }
            set { _shiftId = value; }
        }

       public DateTime DateWorked
       {
           get { return _dateWorked; }
           set { _dateWorked = value ; }
       }

       public string StaffMemberName
       {
           get { return _staffMemberName; }
           set { _staffMemberName = value; }
       }
       public DateTime ActualDate
       {
           get { return _actualDate; }
           set { _actualDate = value; }
       }
       public string ShiftType
       {
           get { return _shiftType; }
           set { _shiftType = value; }
       }

       //chris 19.05
       public StaffMember MyStaffMember
       {
           get { return myStaffMember; }
           set { myStaffMember = value; }
       }

       public IStaffMember MyIStaffMember
       {
           get { return (IStaffMember)myStaffMember; }
       }
       #endregion

       public override string ToString()
       {
           return "date Worked -" + DateWorked.ToShortDateString() + "   staff id-" + myStaffMember.StaffMemberName;
       }

     
   }
}
