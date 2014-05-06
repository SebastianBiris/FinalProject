using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class Status
    {
        string _statusDiscriotion;
        string _statusType;

        public Status(string statusDiscription, string statusType)
        {
            _statusDiscriotion = statusDiscription;
            _statusType = statusType;
        }
        #region Properties //MAL
        public string StatusDiscriotion
        {
            get { return _statusDiscriotion; }
            set { _statusDiscriotion = value; }
        }
        public string StatusType
        {
            get { return _statusType; }
            set { _statusType = value; }
        #endregion
        }

    }
}
