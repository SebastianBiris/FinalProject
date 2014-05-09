using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using ModelLayer;
using InterfaceLayer;


namespace ControllerLayer
{
    class DataAccessDB
    {
        const string DB_CONNECTION = @"Data Source ealdb1.eal.local;User ID=ejl13_usr;Password=Baz1nga13";
        SqlConnection con;
        SqlCommand cmd;



        public DataAccessDB()
        {
            con = new SqlConnection(DB_CONNECTION);
            cmd=new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;


     }

        public bool loginCheck(string staffMemberName, string staffPassowrd)
        {
            cmd.CommandText = "SP_Login";
            cmd.Parameters.Clear();

            SqlParameter param = new SqlParameter("@UserName", SqlDbType.Int);
            param.Value = -1;
            param.Direction = ParameterDirection.Output; // I want to get something back
            cmd.Parameters.Add(param);

            return true;

        }


    }
}