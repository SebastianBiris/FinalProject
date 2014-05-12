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
        int _cpr;
        int _staffMemeberId;
        string _phoneNumber;
        string _password;
        string _staffMemberName;
        string _email;
        string _statusDescription;       
        List<ShiftDate> myShiftDate;
        List<Title> _myTitle;

     
        List<Role> _myRole;

       
     //  public Role myrole;

        public StaffMember(int staffMemeberId, string staffMemberName,int cpr, string phoneNumber,
                           string email, string password,string statusDescription,List<Title> myTitle,List<Role> myRole)
        {
            _cpr = cpr;
            _staffMemeberId = staffMemeberId;
            _phoneNumber = phoneNumber;
            _password = password;
            _staffMemberName = staffMemberName;
            _email = email;
            _myTitle = myTitle;
            _myRole = myRole;
            _statusDescription = statusDescription;
            myShiftDate = new List<ShiftDate>();
        }
       
        #region Properties //MAL
        public int Cpr
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
         public List<Role> MyRole
        {
            get { return _myRole; }
            set { _myRole = value; }
        } 
       public List<Title> MyTitle
        {
            get { return _myTitle; }
            set { _myTitle = value; }
        }
       public string StatusDescription
       {
           get { return _statusDescription; }
           set { _statusDescription = value; }
       }
        #endregion
        
        #region Methods //**Sebi**
        public void addShiftDate(ShiftDate anShiftDate)
        {
            myShiftDate.Add(anShiftDate);
        }
        #endregion

    }
}