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
    public class DataAccessDB
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
        #region View Title from DB
        // Chris
        public List<Title> ViewTitlesFromDB()
        {
            SqlDataReader dataReader = null;
            string position;
            int titleId;
            List<Title> returnTitlesList = new List<Title>();

            cmd.Parameters.Clear();
            cmd.CommandText = "SP_ViewTitle";
            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    position = dataReader["position"].ToString();
                    titleId = int.Parse(dataReader["titleID"].ToString());
                    returnTitlesList.Add(new Title(position,titleId));
                }
                return returnTitlesList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                    if (con.State == ConnectionState.Open)
                     {
                        con.Close();
                     }
            }
        }
        #endregion

        #region View Role From DB
        //MAL

        public List<Role> ViewRoleFromDb()
        {
            SqlDataReader dataReader = null;
            string roleType;
            int roleId;

            List<Role> returnRolesList = new List<Role>();

            cmd.Parameters.Clear();

            cmd.CommandText = "SP_ViewStaffRole";

            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    roleType = dataReader["roleType"].ToString();
                    roleId = int.Parse(dataReader["roleID"].ToString());
                    returnRolesList.Add(new Role(roleType,roleId));
                }
                return returnRolesList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region View Working Hours From DB
        //MAL

        public List<WorkingHours> VieWorkingHoursFromDB()
        {
            SqlDataReader dataReader = null;
            string actualHoursWorked;
            List<WorkingHours> returnWorkingHoursList = new List<WorkingHours>();

            cmd.Parameters.Clear();
            cmd.CommandText = "SP_ViewWorkingHour";

            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    actualHoursWorked = dataReader["actualHoursWorked"].ToString();

                    returnWorkingHoursList.Add(new WorkingHours(double.Parse(actualHoursWorked)));
                }
                return returnWorkingHoursList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

	    #region View Contact Info By STaff From DB //**Sebi**
	
	
	        public List<StaffMember> ViewContactInfoByStaff()
	        {
	             SqlDataReader dataReader = null;
	            string staffMemberName,phoneNo,email,password,statusDescription,position,role;
	            int staffMemberId,cpr,roleId,titleId;
	            List<StaffMember> returnStaffMemberList = new List<StaffMember>();
                List<Title> returnTitle = new List<Title>();
                List<Role> returnRole = new List<Role>();
	            cmd.Parameters.Clear();
	            cmd.CommandText = "SP_ViewContactInfo";
            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    staffMemberName = dataReader["staffMemberName"].ToString();
                    phoneNo = dataReader["phoneNoe"].ToString();
                    email = dataReader["email"].ToString();
                    staffMemberId = int.Parse(dataReader["staffMemberId"].ToString());
                    cpr = int.Parse(dataReader["cpr"].ToString());
                    password = dataReader["password"].ToString();
                    statusDescription = dataReader["statusDescription"].ToString();
                    roleId = int.Parse(dataReader["roleID"].ToString());
                    titleId = int.Parse(dataReader["titleID"].ToString());
                    position = dataReader["position"].ToString();
                    role = dataReader["role"].ToString();
                    returnRole.Add(new Role(role,roleId));
                    returnTitle.Add(new Title(position,titleId));
                  returnStaffMemberList.Add(new StaffMember(staffMemberId,staffMemberName,cpr,phoneNo,email,password,statusDescription,returnTitle,returnRole));
                }
                return returnStaffMemberList;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        
        #endregion

        #region View Shift From DB //**Sebi**
   
     public List<Shift>  ViewShiftFromDB()
        {
            SqlDataReader dataReader = null;
            string shiftType;
            string shiftDiscription;
            double shiftHours;
            List<Shift> returnShiftList = new List<Shift>();

            cmd.Parameters.Clear();
            cmd.CommandText = "SP_ViewShift";
            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    shiftType = dataReader["shiftType"].ToString();
                    shiftDiscription = dataReader["shiftDiscription"].ToString();
                    shiftHours = double.Parse(dataReader["shiftHours"].ToString());
                    returnShiftList.Add(new Shift(shiftType,shiftDiscription,shiftHours));
                }
                return returnShiftList;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                    if (con.State == ConnectionState.Open)
                     {
                        con.Close();
                     }
            }
        }  
    
    #endregion
    }
}

  
