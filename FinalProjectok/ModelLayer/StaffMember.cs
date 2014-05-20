using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
   public   class StaffMember : IStaffMember
    {
        string _cpr;
        int _staffMemeberId;
        int _titleId;
        int _roleId;
        string _phoneNumber;
        string _password;
        string _staffMemberName;
        string _email;
        string _statusDescription;
        string _position;
        string _roleType;

        List<ShiftDate> myShiftDate;
        List<Shift> myShift;
       // List<Message> myInboxMessages;
    

       public  StaffMember(int staffMemeberId, string staffMemberName,string cpr, string phoneNumber,
                           string email, string password, string statusDescription, int titleId, int roleID)
       {
           _cpr = cpr;
           _staffMemeberId = staffMemeberId;
           _phoneNumber = phoneNumber;
           _password = password;
           _staffMemberName = staffMemberName;
           _email = email;
           _titleId = titleId;
           _roleId = roleID;
           _statusDescription = statusDescription;
       }

        public StaffMember(int staffMemeberId, string staffMemberName,string cpr, string phoneNumber,
                           string email, string password, string statusDescription,  string position,string roleType)
        {
            _cpr = cpr;
            _staffMemeberId = staffMemeberId;
            _phoneNumber = phoneNumber;
            _password = password;
            _staffMemberName = staffMemberName;
            _email = email;
            _position = position;
            _roleType = roleType;
            _statusDescription = statusDescription;
            myShiftDate = new List<ShiftDate>();
            myShift = new List<Shift>();
          //  myInboxMessages = new List<Message>(); 
        }
       
        #region Properties //MAL
        public string Cpr
        {
            get { return _cpr; }
            set { _cpr = value; }
        }
        public int StaffMemeberId
        {
            get { return _staffMemeberId; }
            set { _staffMemeberId = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string StaffMemberName
        {
            get { return _staffMemberName; }
            set { _staffMemberName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
       public string StatusDescription
       {
           get { return _statusDescription; }
           set { _statusDescription = value; }
       }
       public string RoleType
       {
           get { return _roleType; }
           set { _roleType = value; }
       }
       public string Position
       {
           get { return _position; }
           set { _position = value; }
       }

       public int RoleId
       {
           get { return _roleId; }
           set { _roleId = value; }
       }

       public int TitleId
       {
           get { return _titleId; }
           set { _titleId = value; }
       }

       #endregion

       public override string ToString()
       {
           return StaffMemberName;
       }

       #region Methods //**Sebi**
        public void AddShiftDate(ShiftDate anShiftDate)
        {
            myShiftDate.Add(anShiftDate);
        }

        public void AddShift(Shift anShift)
        {
            myShift.Add(anShift);
        }

        #endregion

    }
}