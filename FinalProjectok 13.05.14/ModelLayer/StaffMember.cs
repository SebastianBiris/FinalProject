﻿using System;
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
        string _phoneNumber;
        string _password;
        string _staffMemberName;
        string _email;
        string _statusDescription;
        int _titleId;
        int _roleId;
        List<ShiftDate> myShiftDate;
    

        public StaffMember(int staffMemeberId, string staffMemberName,string cpr, string phoneNumber,
                           string email, string password, string statusDescription, int titleId, int roleId)
        {
            _cpr = cpr;
            _staffMemeberId = staffMemeberId;
            _phoneNumber = phoneNumber;
            _password = password;
            _staffMemberName = staffMemberName;
            _email = email;
            _titleId = titleId;
            _roleId = roleId;
            _statusDescription = statusDescription;
            myShiftDate = new List<ShiftDate>();
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
        
        #region Methods //**Sebi**
        public void addShiftDate(ShiftDate anShiftDate)
        {
            myShiftDate.Add(anShiftDate);
        }

        #endregion

    }
}