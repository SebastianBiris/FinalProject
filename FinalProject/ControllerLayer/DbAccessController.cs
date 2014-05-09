using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelLayer;
using InterfaceLayer;


namespace ControllerLayer
{
    class DbAccessController
    {


        #region View from DB Methods

        public List<Title> ViewTitleFromDB()
        {
            SqlDataReader dataReader = null;
            string position;
            List<Title> returnTitles = new List<Title>();

            
            
        }
            

        #endregion

    }
}
