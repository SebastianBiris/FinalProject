using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
    public class Role:IRole
    {
        string _roleType;
        List<StaffMember> myStaffMember;

        public Role(string roleType)
        {
            _roleType = roleType;
            myStaffMember = new List<StaffMember>();
        }

        #region Properties //MAL
        public string RoleType
        {
            get { return _roleType; }
            set { _roleType = value; }

        #endregion
        }
        #region Methods //**Sebi**
        public void addStaffMemberinRole(StaffMember anStaffMember)
        {
            myStaffMember.Add(anStaffMember);
        }
        #endregion

    }
}
