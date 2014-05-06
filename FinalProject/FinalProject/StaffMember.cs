using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class StaffMember
    {
        int _cpr;
        int _userId;
        string _phoneNumber;
        string _password;
        string _name;
        string _email;

        public StaffMember(int cpr, int userId, string phoneNumber, string password,
            string name, string email)
        {
            _cpr = cpr;
            _userId = userId;
            _phoneNumber = phoneNumber;
            _password = password;
            _name = name;
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
            get { return _userId; }
            set { _userId = value; }
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
            get { return _name; }
            set { _name = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        #endregion
        }
    }
}