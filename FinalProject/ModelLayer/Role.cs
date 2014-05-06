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

        public Role(string roleType)
        {
            _roleType = roleType;
        }

        #region Properties //MAL
        public string RoleType
        {
            get { return _roleType; }
            set { _roleType = value; }

        #endregion
        }
    }
}
