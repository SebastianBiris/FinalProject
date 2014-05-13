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
        int _id;

        
       // List<StaffMember> myStaffMember;

        public Role(string roleType,int id)
        {
            _roleType = roleType;
            _id = id;
           // myStaffMember = new List<StaffMember>();
        }

        #region Properties //MAL

        public string RoleType
        {
            get { return _roleType; }
            set { _roleType = value; }
         }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion
       
        #region Methods //**Sebi**
        //public void addStaffMemberinRole(StaffMember anStaffMember)
        //{
        //    myStaffMember.Add(anStaffMember);
        //}
        #endregion

    }
}
