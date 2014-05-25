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

        #region Methods

        //chris
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

        //chris & Majd 15.05

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

        //MAjd
        public void DeleteMessage(int messageId)
        {
            myDataAccessDb.DeleteMessage(messageId);

        }

        //Majd
 
        public void DeleteStaffMember(int staffMemberId)
        {
            myDataAccessDb.DeleteStaffMember(staffMemberId);
        }
        public void UpdateStaffMember(int staffMemberID, string staffMemberName, string cpr, string phoneNumber, string email, string password, string statusDescription, int titleId, int roleId)
        {
            myDataAccessDb.UpDateStaffMember(staffMemberID, staffMemberName, cpr, phoneNumber, email, password, statusDescription, titleId, roleId);
        }

        //chris 19.05 
        public void AddNewShiftDateInDB(int dateId, int staffMemberId, int shiftId)
        {
            selectedShiftDate = new ShiftDate(dateId, staffMemberId, shiftId);
            myDataAccessDb.AddStaffMemberWorkDayInDB(dateId, staffMemberId, shiftId);
        }

        public void AddNewShiftDate(int dateId, DateTime dateWorked, IStaffMember sm, int staffId) //????? GUI Layer
        {
            ShiftDate nuShiftDate = new ShiftDate(dateId, dateWorked, (StaffMember)sm, staffId);
            shiftDates.Add(nuShiftDate);
        }

        //25.05
        public int NumberOfStaffMembers()
        {
            return staffMembers.Count;
        }

        public int NumberOfMessages()
        {
            return messages.Count;
        }

        #endregion
      
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

        public void GetDay(string day) 
        {
            myIWeekList.GetDay(day);
        }

        public int GetWeeksOfYear()
        {
            Week currentWeek = new Week();

            return currentWeek.GetWeekOfYear();
        }
        public DateTime GetWeeks(int year, DayOfWeek thursday)
        {
            thursday = DayOfWeek.Thursday;
            return Week.GetWeekOneDayOne(year, thursday);
        }


        public IWeekList GetWeekList(int year, DateTime day1, DateTime day2, DateTime day3, DateTime day4, DateTime day5, DateTime day6, DateTime day7)
        {

            myWeekList1 = new WeekList(year, day1, day2, day3, day4, day5, day6, day7);
            return myWeekList1;
        }
        public List<IWeekList> MyWeekList
        {
            get { return myWeekList; }
            set { myWeekList = value; }
        }
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

        #endregion

    }
}
