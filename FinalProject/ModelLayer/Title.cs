using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class Title
    {
        string _possition;

     
        public Title(string possition)
        {
            _possition = possition;
        }
        #region Properties // MAL
        public string Possition
        {
            get { return _possition; }
            set { _possition = value; }
        #endregion
        }

    }
}
