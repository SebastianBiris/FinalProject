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

     
        public Title(string position)
        {
            _position = position;
        }
        #region Properties // MAL
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        #endregion
        }

    }
}
