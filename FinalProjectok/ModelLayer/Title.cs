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
        int _id;

        public Title(string position, int id)
        {
            _position = position;
            _id = id;
        }
        #region Properties 
       // MAL

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
       public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion
       

    }
}
