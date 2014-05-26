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
        int _titleId;

        public Title(string position, int titleId)
        {
            _position = position;
            _titleId = titleId;
        }
        #region Properties // MAL

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
       public int TitleId
        {
            get { return _titleId; }
            set { _titleId = value; }
        }
        #endregion
       
        #region Methods //**Sebi**
        //public void addSaffMemberinTitle(StaffMember anStaffMember)
        //{
        //    myStaffMember.Add(anStaffMember);
        //}
        #endregion

    }
}
