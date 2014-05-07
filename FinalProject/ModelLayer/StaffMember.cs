﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
    class StaffMember
    {
        int _cpr;
        int _staffMemeberId;
        string _phoneNumber;
        string _password;
        string _staffMemberName;
        string _email;

        public StaffMember(int staffMemeberId, string staffMemberName,int cpr, string phoneNumber,
                           string email, string password)
        {
            _cpr = cpr;
            _staffMemeberId = staffMemeberId;
            _phoneNumber = phoneNumber;
            _password = password;
            _staffMemberName = staffMemberName;
            _email = email;
        }
        #region Properties //MAL
        public int Cpr
        {
            get { return _cpr; }
            set { _cpr = value; }
        }
        public int UserId
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
        public string Name
        {
            get { return _staffMemberName; }
            set { _staffMemberName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        #endregion
        }
    }
}