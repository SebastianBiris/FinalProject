using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelLayer;
using InterfaceLayer;

namespace ControllerLayer
{
   public  class Controller
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

        WeekList myWeekList1;
        List<IShift>shifts;

        
     
        StaffMember selectedStaffMember;
        Message selectedMessage;


        DataAccessDB myDataAccessDb;

      
       
        public Controller()
        {
            shift = new List<Shift>();
            shiftDates = new List<ShiftDate>();
            staffMembers = new List<StaffMember>();
            workingHours = new List<WorkingHours>();
            titles = new List<Title>();
            roles = new List<Role>();
            myDataAccessDb = new DataAccessDB();
            weekList = new List<WeekList>();
            messages = new List<Message>();
            GetAllFromDB();
            myWeekList = new List<IWeekList>();
            shifts = new List<IShift>();
        }

        #region properties //**Sebi**

      

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
            { List<IWeekList> resultlist = new List<IWeekList>();

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
            get {
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


        //chris
        public void CreateStaffMember(string staffMemberName,string cpr, string phoneNumber,string email, string password,string statusDescription,int titleId,int roleId)
        {
            int staffMemberNo;
            try
            {
                staffMemberNo = myDataAccessDb.AddNewStaffMemberInDB(staffMemberName, cpr, phoneNumber, email, password,statusDescription, titleId, roleId);
                StaffMember myStaffMember = new StaffMember(staffMemberNo, staffMemberName, cpr, phoneNumber, email,
                    password, statusDescription, titleId, roleId);
                    
                staffMembers.Add(myStaffMember);
            }
            catch 
            {
                throw new Exception("Data wasn`t saved correctly");
            }
        }

       //Chris
       public void DeleteStaffMember(StaffMember selectedMember)
       {
           foreach (StaffMember sm in StaffMembers)  //IStaffMember ???
           {
               staffMembers.Remove(selectedMember);
           }
       }
       //Majd
       public IStaffMember SelectedStaffMember
       {
           get { return (IStaffMember)selectedStaffMember; }
           set { selectedStaffMember = (StaffMember)value; }
       }
       //Chris
       public Message SelectedMessage
       {
           get { return  selectedMessage; }
           set { selectedMessage = value; }
       }
       
    

       public void GetAllFromDB()
       {
           staffMembers = myDataAccessDb.GetStaffMembersFromDB();
           shift = myDataAccessDb.ViewShiftFromDB();
           workingHours = myDataAccessDb.ViewWorkingHoursFromDB();
           titles = myDataAccessDb.ViewTitlesFromDB();
           roles = myDataAccessDb.ViewRoleFromDb();
           messages = myDataAccessDb.ViewMessagesFromDB();
       }

       public void GetDay(string day)
       {
           myWeekList1.GetDay(day);


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
    }
}
