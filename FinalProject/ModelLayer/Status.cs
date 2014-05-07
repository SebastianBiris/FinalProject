using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
   public class Status
    {
        string _statusDiscription;
        string _statusType;
        List<StaffMember> myStaffMember;

        public Status(string statusDiscription, string statusType)
        {
            _statusDiscription = statusDiscription;
            _statusType = statusType;
            myStaffMember = new List<StaffMember>();
        }
        #region Properties //MAL
        public string StatusDiscriotion
        {
            get { return _statusDiscription; }
            set { _statusDiscription = value; }
        }
        public string StatusType
        {
            get { return _statusType; }
            set { _statusType = value; }
        #endregion
        }

        #region Methods //**Sebi**
        public void addStaffMemberinStatus(StaffMember anStaffMember)
        {
            myStaffMember.Add(anStaffMember);
        }
        #endregion


    }
}
