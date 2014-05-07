using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InterfaceLayer;

namespace ModelLayer
{
   public class Title : ITitle
    {
        string _position;
        List<StaffMember> myStaffMember;
     
        public Title(string position)
        {
            _position = position;
            myStaffMember = new List<StaffMember>();
        }
        #region Properties // MAL
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        #endregion
        }

        #region Methods //**Sebi**
        public void addOrder(StaffMember anOrder)
        {
            myStaffMember.Add(anOrder);
        }
        #endregion

    }
}
