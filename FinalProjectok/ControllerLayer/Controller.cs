using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelLayer;
using InterfaceLayer;

namespace ControllerLayer
{
    public class Controller
    {

        List<Shift> shift;
        List<ShiftDate> shiftDates;
        List<StaffMember> staffMembers;
        List<WorkingHours> workingHours;
        List<Title> titles;
        List<Role> roles;
        List<Message> messages;
        List<WeekList> weekList;
        List<IWeekList> myWeekList;
        IWeekList myIWeekList;
        WeekList myWeekList1;
        List<IShift> shifts;
        List<ShiftDate> shiftIds;

        IShift selectedShift;
        StaffMember selectedStaffMember;
        Message selectedMessage;
        IShiftDate selectedShiftDate;
        DataAccessDB myDataAccessDb;

        public Controller()
        {
            shift = new List<Shift>();
            shiftDates = new List<ShiftDate>();
            shiftIds = new List<ShiftDate>();
            staffMembers = new List<StaffMember>();
            workingHours = new List<WorkingHours>();
            titles = new List<Title>();
            roles = new List<Role>();
            myDataAccessDb = new DataAccessDB();
            weekList = new List<WeekList>();
            messages = new List<Message>();
            myWeekList = new List<IWeekList>();
            shifts = new List<IShift>();
            GetAllFromDB();
        }

        #region GetAllFromDB
        /*
         * get the information from database
         */
        public void GetAllFromDB()
        {
            staffMembers = myDataAccessDb.GetStaffMembersFromDB();
            shift = myDataAccessDb.ViewShiftFromDB();
            workingHours = myDataAccessDb.ViewWorkingHoursFromDB();
            titles = myDataAccessDb.ViewTitlesFromDB();
            roles = myDataAccessDb.ViewRoleFromDb();
            messages = myDataAccessDb.ViewMessagesFromDB();
            shiftDates = myDataAccessDb.ViewAssignedShiftDatesFromDB();
            shiftIds = myDataAccessDb.ViewShiftDatesFromDB();
        } 
        #endregion

        #region CreateStaffMember
        //chris
        /*
         * acutally we don't add a staff member in database - Alan
         * adds information about a staff member in database
         */ 
        public void CreateStaffMember(string staffMemberName, string cpr, string phoneNumber, string email, string password, string statusDescription, int titleId, int roleId)
        {
            int staffMemberNo;
            try
            {
                staffMemberNo = myDataAccessDb.AddNewStaffMemberInDB(staffMemberName, cpr, phoneNumber, email, password, statusDescription, titleId, roleId);
                StaffMember myStaffMember = new StaffMember(staffMemberNo, staffMemberName, cpr, phoneNumber, email,
                    password, statusDescription, titleId, roleId);

                staffMembers.Add(myStaffMember);
            }
            catch
            {
                throw new Exception("Data wasn`t saved correctly");
            }
        }
        #endregion
        
        #region CreateMessage
//chris & Majd 15.05
        /*
         * saves a new message in db
         */
        public void CreateNewMessage(string inboxMessage, int staffMemberId)
        {
            int messageId;
            try
            {
                messageId = myDataAccessDb.AddMessageInDB(inboxMessage, staffMemberId);
                Message myMessages = new Message(messageId, inboxMessage, staffMemberId);

                messages.Add(myMessages);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DeleteMessage
        //MAjd
        /*
         * Deletes a message from db
         */
        public void DeleteMessage(int messageId)
        {
            myDataAccessDb.DeleteMessage(messageId);

        }
        #endregion

        #region DeleteStaffMember
        //Majd
        /*
         * deletes informations about a staff member from db
         */
        public void DeleteStaffMember(int staffMemberId)
        {
            myDataAccessDb.DeleteStaffMember(staffMemberId);
        }
        #endregion

        #region UpdateStaffMember
        /*
         * Updates information about a staff member in fb
         */ 
        public void UpdateStaffMember(int staffMemberID, string staffMemberName, string cpr, string phoneNumber, string email, string password, string statusDescription, int titleId, int roleId)
        {
            myDataAccessDb.UpDateStaffMember(staffMemberID, staffMemberName, cpr, phoneNumber, email, password, statusDescription, titleId, roleId);
        }
#endregion

        #region AddNewShiftDateinDB
        //chris 19.05 
        /*
         * adds a date for a shift in db
         */ 
        public void AddNewShiftDateInDB(int dateId, int staffMemberId, int shiftId)
        {
            selectedShiftDate = new ShiftDate(dateId, staffMemberId, shiftId);
            myDataAccessDb.AddStaffMemberWorkDayInDB(dateId, staffMemberId, shiftId);
        }
        #endregion

        #region NumberOf
        /*
         * we count the lenght fot staff member list, messages list and shiftdates list
         * are used for unit testing 
         */ 
        public int NumberOfStaffMembers()
        {
            return staffMembers.Count;
        }

        public int NumberOfMessages()
        {
            return messages.Count;
        }


        public int NumberOfShiftDate()
        {
            return shiftDates.Count;
        }
        #endregion

        #region GetDay/GetWeeksOfyear/GetWeeks/GetWeekList
        /*
         * gets the current day in the current week
         */ 
        public void GetDay(string day)
        {
            myIWeekList.GetDay(day);
        }
        /*
         * calculates the current week in the current year
         */ 
        public int GetWeeksOfYear()
        {
            Week currentWeek = new Week();
            return currentWeek.GetWeekOfYear();
        }
        /*
         * gets all the weeks of a year
         */
        public DateTime GetWeeks(int year, DayOfWeek thursday)
        {
            thursday = DayOfWeek.Thursday;
            return Week.GetWeekOneDayOne(year, thursday);
        }
        /*
         * I use it to return a list of weeks accesing the interface
         */ 
        public IWeekList GetWeekList(int year, DateTime day1, DateTime day2, DateTime day3, DateTime day4, DateTime day5, DateTime day6, DateTime day7)
        {
            myWeekList1 = new WeekList(year, day1, day2, day3, day4, day5, day6, day7);
            return myWeekList1;
        }
        #endregion

        #region Properties //**Sebi**



        public List<IShift> Shifts
        {
            get
            {
                List<IShift> resultList = new List<IShift>();

                foreach (Shift shift in shifts)
                {
                    resultList.Add((IShift)shift);
                }
                return resultList;
            }
        }
        public List<ShiftDate> ShiftIds
        {
            get { return shiftIds; }
            set { shiftIds = value; }
        }
        public List<Shift> Shift
        {
            get { return shift; }
            set { shift = value; }
        }
        public IShift Selectedshift
        {
            get { return selectedShift; }
            set { selectedShift = (Shift)value; }
        }

        public List<IShiftDate> ShiftDates
        {
            get
            {
                List<IShiftDate> resultList = new List<IShiftDate>();

                foreach (ShiftDate shiftDate in shiftDates)
                {
                    resultList.Add((IShiftDate)shiftDate);
                }
                return resultList;
            }
        }

        public List<IRole> Roles
        {
            get
            {
                List<IRole> resultList = new List<IRole>();

                foreach (Role role in roles)
                {
                    resultList.Add((IRole)role);
                }
                return resultList;
            }
        }

        public List<IWeekList> WeekLists
        {
            get
            {
                List<IWeekList> resultlist = new List<IWeekList>();

                foreach (WeekList weeklist in weekList)
                {
                    resultlist.Add((IWeekList)weeklist);
                }
                return resultlist;
            }
        }

        public List<IStaffMember> StaffMembers
        {
            get
            {
                List<IStaffMember> resultList = new List<IStaffMember>();

                foreach (StaffMember staffMember in staffMembers)
                {
                    resultList.Add((IStaffMember)staffMember);
                }
                return resultList;
            }
        }


        public List<ITitle> Titles
        {
            get
            {
                List<ITitle> resultList = new List<ITitle>();

                foreach (Title title in titles)
                {
                    resultList.Add((ITitle)title);
                }
                return resultList;
            }
        }

        public List<IWorkingHours2> WorkingHours
        {
            get
            {
                List<IWorkingHours2> resultList = new List<IWorkingHours2>();
                foreach (WorkingHours workinHours in workingHours)
                {
                    resultList.Add((IWorkingHours2)workinHours);
                }
                return resultList;
            }
        }

        //chris 15.05
        public List<IMessage> Messages
        {
            get
            {
                List<IMessage> resultList = new List<IMessage>();
                foreach (IMessage tempMessage in messages)
                {
                    resultList.Add(tempMessage);
                }
                return resultList;
            }
        }
        //Majd

        public IStaffMember SelectedStaffMember
        {
            get { return (IStaffMember)selectedStaffMember; }
            set { selectedStaffMember = (StaffMember)value; }
        }

        //Chris
        public IMessage SelectedMessage
        {
            get { return selectedMessage; }
            set { selectedMessage = (Message)value; }
        }

        public IShiftDate SelectedShiftDate
        {
            get { return selectedShiftDate; }
            set { selectedShiftDate = value; }
        }

        public List<IWeekList> MyWeekList
        {
            get { return myWeekList; }
            set { myWeekList = value; }
        }

        #endregion

    }
}
