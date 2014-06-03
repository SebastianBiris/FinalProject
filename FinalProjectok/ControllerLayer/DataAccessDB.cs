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
    public class DataAccessDB           //Majd, Chris, Sebastian, Florin
    {
        const string DB_CONNECTION = @"Data Source =ealdb1.eal.local;User ID=ejl13_usr;Password=Baz1nga13";
        SqlConnection con;
        SqlCommand cmd;

        public DataAccessDB()
        {
            con = new SqlConnection(DB_CONNECTION);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }


        #region View Title from DB
        // Chris
        /*
         * create a list with titles
         */ 
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
                    returnTitlesList.Add(new Title(position, titleId));
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
        /*
         * create a list with roles
         */ 
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
                    returnRolesList.Add(new Role(roleType, roleId));
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
        /*
         * create a list with working hours
         */ 
        public List<WorkingHours> ViewWorkingHoursFromDB()
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

        #region View Shift From DB 
        //**Sebi**
        /*
         * create a list with shifts
         */ 
        public List<Shift> ViewShiftFromDB()
        {
            SqlDataReader dataReader = null;
            int shiftId;
            string shiftType;
            string shiftDescription;
            double shiftHour;
            List<Shift> returnShiftList = new List<Shift>();

            cmd.Parameters.Clear();
            cmd.CommandText = "SP_ViewShift";
            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    shiftId = int.Parse(dataReader["shiftID"].ToString());
                    shiftType = dataReader["shiftType"].ToString();
                    shiftDescription = dataReader["shiftDescription"].ToString();
                    shiftHour = double.Parse(dataReader["shiftHour"].ToString());
                    returnShiftList.Add(new Shift(shiftId, shiftType, shiftDescription, shiftHour));
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

        #region View Contact Info from DB 
        //Chris 13.05
        /*
         * create a list with information about staff members for cantacting them
         */ 
        public List<StaffMember> GetStaffMembersFromDB()
        {
            SqlDataReader dataReader = null;
            string cpr;
            int staffMemberId;
            string phoneNumber;
            string password;
            string staffMemberName;
            string email;
            string statusDescription;
            string position;
            string roleType;
            // int messageId;
            // string message;

            // List<Message>returnMessagesList = new List<Message>();
            List<StaffMember> returnStaffMembersList = new List<StaffMember>();
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_ViewContactInfo2";

            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    staffMemberName = dataReader["staffMemberName"].ToString();
                    phoneNumber = dataReader["phoneNo"].ToString();
                    email = dataReader["email"].ToString();
                    staffMemberId = int.Parse(dataReader["staffMemberID"].ToString());
                    cpr = dataReader["cpr"].ToString();
                    password = dataReader["staffPassword"].ToString();
                    statusDescription = dataReader["statusDescription"].ToString();
                    roleType = dataReader["roleType"].ToString();
                    position = dataReader["position"].ToString();
                    // returnMessagesList.Add(new Message(messageId,message,staffMemberId));
                    returnStaffMembersList.Add(new StaffMember(staffMemberId, staffMemberName, cpr, phoneNumber, email, password, statusDescription, position, roleType));

                }
                return returnStaffMembersList;
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

        #region Add New Staff Member to DB 
        // chris 13.05
        /*
         * adds information about a new staff member into database
         */ 
        public int AddNewStaffMemberInDB(string staffMemberName, string cpr, string phoneNumber, string email,
                                        string password, string statusDescription, int titleId, int roleId)
        {
            cmd.CommandText = "SP_CreateNewStaffMember";
            cmd.Parameters.Clear();

            SqlParameter par = new SqlParameter("@staffmemberID", SqlDbType.Int);
            par.Value = -1;
            par.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(par);
            cmd.Parameters.AddWithValue("@staffMemberName", staffMemberName);
            cmd.Parameters.AddWithValue("@cpr", cpr);  //CPR was nvarchar in DB & int in VS
            cmd.Parameters.AddWithValue("@phoneNo", phoneNumber);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@staffPassword", password);
            cmd.Parameters.AddWithValue("@statusDescription", statusDescription);
            cmd.Parameters.AddWithValue("@titleID", titleId);
            cmd.Parameters.AddWithValue("@roleID", roleId);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return int.Parse(cmd.Parameters["@staffmemberID"].Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region View Inbox Messages from DB
        /*Chris
         * create a list with messages
         */ 
        public List<Message> ViewMessagesFromDB()
        {
            SqlDataReader dataReader = null;

            int messageId, staffMemberId;
            string message;

            List<Message> returnMessagesList = new List<Message>();

            cmd.Parameters.Clear();
            cmd.CommandText = "SP_ViewMessages";

            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    messageId = (int.Parse(dataReader["messageId"].ToString()));
                    staffMemberId = (int.Parse(dataReader["staffMemberId"].ToString()));
                    message = dataReader["newMessage"].ToString();
                    returnMessagesList.Add(new Message(messageId, message, staffMemberId));
                }
                return returnMessagesList;
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

        #region Add new Message to DB 
        //chris & Majd 15.05
        /*
         * saves in database a message sent fron staff member to another one
         */ 
        public int AddMessageInDB(string inboxMessage, int staffMemberId)
        {
            cmd.CommandText = "SP_SendMessage";
            cmd.Parameters.Clear();

            SqlParameter par = new SqlParameter("@messageId", SqlDbType.Int);
            par.Value = -1;
            par.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(par);

            cmd.Parameters.AddWithValue("@newMessage", inboxMessage);
            cmd.Parameters.AddWithValue("staffMemberId", staffMemberId);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return int.Parse(cmd.Parameters["@messageId"].Value.ToString());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        #endregion

        #region Add Staff Member Work Day  
        //chris 19.05
        //constructor is inside shiftDate class
        /*
         * assigns a working day and a shift to a staff member
         */ 
        public void AddStaffMemberWorkDayInDB(int dateId, int staffMemberId, int shiftId)  // ????
        {
            cmd.CommandText = "SP_CreateStaffMemberWorkDay1";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@dateId", dateId);
            cmd.Parameters.AddWithValue("@staffMemberId", staffMemberId);
            cmd.Parameters.AddWithValue("@shiftId", shiftId);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region View Staff Member Shift Dates 
        //Florin
        /*
         * fill the list with assigned shifts for a staff member for a week day
         */ 
        public List<ShiftDate> ViewAssignedShiftDatesFromDB()
        {
            SqlDataReader dataReader = null;
            string staffMemberName;
            DateTime actualDate;
            string shiftType;

            List<ShiftDate> returnShiftDateslist = new List<ShiftDate>();
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_ViewAssignedShifts";

            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    staffMemberName = (dataReader["staffMemberName"].ToString());
                    shiftType = (dataReader["shiftType"].ToString());
                    actualDate = (DateTime)dataReader["actualDate"];
                    returnShiftDateslist.Add(new ShiftDate(staffMemberName, shiftType, actualDate));
                }
                return returnShiftDateslist;
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

        #region View shift dates IDs
        /*Florin
         * adds in a list dates for shifts from database
         */ 
        public List<ShiftDate> ViewShiftDatesFromDB()
        {
            SqlDataReader dataReader = null;
            int dateId;
            DateTime dateWorked;

            List<ShiftDate> returnShiftDatesIdlist = new List<ShiftDate>();
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_ViewStaffMemberWorkDay";

            try
            {
                con.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    dateId = (int.Parse(dataReader["dateID"].ToString()));
                    dateWorked = (DateTime)dataReader["actualDate"];
                    returnShiftDatesIdlist.Add(new ShiftDate(dateId, dateWorked));
                }
                return returnShiftDatesIdlist;
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

        #region Delete Messages From DB 
        //majd
        /*
         * deletes messages from inbox 
         */ 
        public int DeleteMessage(int messageId1)
        {
            cmd.CommandText = "SP_DeleteMessage";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@messageId", messageId1);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return int.Parse(cmd.Parameters["@messageId"].Value.ToString());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region Delete Staffmember From DB
        //majd
        /*
         * deletes a staff member informations from database
         */ 
        public string DeleteStaffMember(int staffMemberId)
        {
            cmd.CommandText = "SP_DeleteStaffMember";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@staffMemberID", staffMemberId);


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (cmd.Parameters["@staffMemberID"].Value.ToString());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region UpDate StaffMember in DB
        // Majd
        /*
         * updates a staff member informations
         */ 
        public int UpDateStaffMember(int staffMemberId, string staffMemberName, string cpr, string phoneNumber, string email,
                                        string password, string statusDescription, int titleId, int roleId)
        {
            cmd.CommandText = "SP_UpdateStaffMember";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@staffmemberID", staffMemberId);
            cmd.Parameters.AddWithValue("@staffMemberName", staffMemberName);
            cmd.Parameters.AddWithValue("@cpr", cpr);
            cmd.Parameters.AddWithValue("@phoneNo", phoneNumber);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@staffPassword", password);
            cmd.Parameters.AddWithValue("@statusDescription", statusDescription);
            cmd.Parameters.AddWithValue("@titleID", titleId);
            cmd.Parameters.AddWithValue("@roleID", roleId);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return int.Parse(cmd.Parameters["@staffmemberID"].Value.ToString());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region Connect to DB
        /*
         * connection to eal database
         * we have to change this to our local database
         */ 
        public bool ConnectToDB()
        {
            bool flag;
            try
            {
                const string DB_CONNECTION = @"Data Source =ealdb1.eal.local;User ID=ejl13_usr;Password=Baz1nga13";
                SqlConnection con = new SqlConnection(DB_CONNECTION);
                SqlCommand cmd = new SqlCommand();
                con = new SqlConnection(DB_CONNECTION);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                 flag = true;
                 return flag;
            }
            catch
            {
                flag = false;
                return flag;
            }
        }

        #endregion
    }
}




