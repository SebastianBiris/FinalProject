using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControllerLayer;
using InterfaceLayer;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for TabForStaff.xaml
    /// </summary>
    public partial class TabForStaff : Window   //Majd & Chris
    {
        Controller myController;
        int RowNumber;
        int ColumnNumber;
        int YearOffSet;
        DateTime SelectDateTime1 = DateTime.Now.AddDays(0);
        int WeekNow { get; set; }
        int offSetForYearChange;
        public List<Button> drawButtons = new List<Button>();
        public List<Button> ColumnHeaderButtons { get; set; }
        public List<string> days = new List<string> { "", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        int nr = -1;
        const int i = 27, j = 8;
        string[,] Matrix = new string[i, j];
       
        TabWindow myTabWindow = new TabWindow();
        public TabForStaff()
        {
            InitializeComponent();
            scheduleTab.Focus();
            myController = new Controller();
            myWeekDates = new List<DateTime>();
            ColumnHeaderButtons = new List<Button>();
            lbWeekNo.Content = myController.GetWeeksOfYear();
            lbYearNo.Content = DateTime.Now.Year;
            FillTheWeeks();
            GetWeek();
            DrawButtons();
            
        }

        
        private void btnSubmitMail_Click(object sender, RoutedEventArgs e)
        {
            IStaffMember lbStaffMember2 = (IStaffMember) listBoxContactStaff.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember2;

            if (myController.SelectedStaffMember != null)
            {
                 int tempStaffId = myController.SelectedStaffMember.StaffMemeberId;
                 string message = txtContactStaff.Text;

                 myController.CreateNewMessage(message,tempStaffId);
                 MessageBox.Show("Your message was sent successfully.");
                 txtContactStaff.Clear();
            }
            else
            {
                MessageBox.Show("Did not send. You must also select a staff member");
            }
           
        }



        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
             IStaffMember lbStaffMember2 = (IStaffMember) listBoxStaffInfo2.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember2;

            
           
            if(myController.SelectedStaffMember != null)
            { 
                int tempStaffId = myController.SelectedStaffMember.StaffMemeberId;
                string tempMessage = txtRespon.Text;

                myController.CreateNewMessage(tempMessage,tempStaffId);
                 MessageBox.Show("Your message was sent successfully.");
                 txtRespon.Clear();
            }
            else
            {
                MessageBox.Show("Did not send. You must also select a staff member");
            }
        }



        private void btnSubmitShiftChange_Click(object sender, RoutedEventArgs e)
        {
            int tempId = 6;
            string tempMessage = txtShiftChangeRequest.Text;

            myController.CreateNewMessage(tempMessage,tempId);
            MessageBox.Show("Your message was sent successfully.");
            txtShiftChangeRequest.Clear();
        }

        private void btnClearShiftChange_Click(object sender, RoutedEventArgs e)
        {
            txtShiftChangeRequest.Clear();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int tempId = -1;

            IMessage lbMessage = (IMessage)ListBoxRequests.SelectedItem;
            myController.SelectedMessage = lbMessage;

            tempId = myController.SelectedMessage.MessageId;

            myController.DeleteMessage(tempId);
            MessageBox.Show("Message deleted");
          
        }
        public List<DateTime> myWeekDates { get; set; }
        public List<IWeekList> allWeeksList = new List<IWeekList>();
        public List<IShiftDate> myIShift = new List<IShiftDate>();

        public void FillTheWeeks()
        {
            int offset = 0;
            for (int j = 0; j < 5; j++)
            {
                int year = 2014 + YearOffSet;
                DateTime firstDayOfTheFirstWeekOfTheYear = myController.GetWeeks(year, DayOfWeek.Thursday);
                for (int i = 0; i < 54; i++)
                {
                    DateTime first = myController.GetWeeks((year + 1), DayOfWeek.Thursday);
                    DateTime second = firstDayOfTheFirstWeekOfTheYear.AddDays(1 + offset);
                    if (first <= second)
                    {
                        offset = 0;
                    }

                    allWeeksList.Add(myController.GetWeekList(year, firstDayOfTheFirstWeekOfTheYear.AddDays(0 + offset),
                          firstDayOfTheFirstWeekOfTheYear.AddDays(1 + offset),
                          firstDayOfTheFirstWeekOfTheYear.AddDays(2 + offset),
                          firstDayOfTheFirstWeekOfTheYear.AddDays(3 + offset),
                          firstDayOfTheFirstWeekOfTheYear.AddDays(4 + offset),
                          firstDayOfTheFirstWeekOfTheYear.AddDays(5 + offset),
                          firstDayOfTheFirstWeekOfTheYear.AddDays(6 + offset)));
                    offset += 7;
                }
                YearOffSet++;
            }

        }

        public void GetWeek()
        {
            WeekNow = myController.GetWeeksOfYear();

        }
       
        public void DrawButtons()
        {
            int dateCounter = -9;
            for (int i = 0; i <= 26; i++)
            {

                for (int j = 0; j <= 7; j++)
                {
                    dateCounter++;
                    if (i == 1 && j != 0)
                    {
                        string dayHack = "Day" + dateCounter;
                        Matrix[i, j] = allWeeksList[myController.GetWeeksOfYear() - 1].GetDay(dayHack).ToShortDateString();
                        myWeekDates.Add(allWeeksList[myController.GetWeeksOfYear() - 1].GetDay(dayHack));
                    }
                    else if (i == 0 && j != 0 && j != 8 && j != 9)
                    {
                        Matrix[i, j] = days[j];
                    }

                    else if (j == 0 && i != 0 && i != 1)
                    {
                        if (nr < myController.StaffMembers.Count - 1)
                        {
                            nr++;
                            Matrix[i, j] = myController.StaffMembers[nr].StaffMemberName;
                        }
                    }
                    else if (i > 1 && j > 0)
                    {
                        for (int a = 0; a < myController.ShiftDates.Count; a++)
                        {
                            if (Matrix[i, 0] == myController.ShiftDates[a].StaffMemberName && Matrix[1, j] == myController.ShiftDates[a].ActualDate.ToShortDateString())
                            {
                                Matrix[i, j] = myController.ShiftDates[a].ShiftType;
                            }
                        }

                    }
                }
            }
            for (int i = 0; i <= 26; i++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) });
                myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Auto) });
                for (int j = 0; j <= 7; j++)
                {
                    if (i == 1 && j != 0)
                    {
                        Button cellButtons = new Button
                        {
                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = Matrix[i, j],
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,
                        };
                        cellButtons.SetValue(Grid.RowProperty, i);
                        cellButtons.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(cellButtons);
                        ColumnHeaderButtons.Add(cellButtons);
                    }
                    else if (i <= myController.StaffMembers.Count + 1 )
                    {
                        Button cellButtons = new Button
                        {
                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = Matrix[i, j],
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,
                        };
                        cellButtons.SetValue(Grid.RowProperty, i);
                        cellButtons.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(cellButtons);

                    }
                   
                }
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

            foreach (Button button in drawButtons)
            {
                myGrid.Children.Remove(button);
            }
            Button mybutton = new Button();
            drawButtons.Clear();
            myWeekDates.Clear();
            int tempWeekNo = (int)lbWeekNo.Content;
            int yearNo = (int)lbYearNo.Content;
            if (tempWeekNo == 1)
            {
                lbYearNo.Content = (yearNo - 1);
                lbWeekNo.Content = 52;
                offSetForYearChange -= 52;

                for (int i = 0; i < 7; i++)
                {
                    myWeekDates.Add(allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    mybutton.Content = allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)).ToShortDateString();
                }
            }
            else
            {
                lbWeekNo.Content = (tempWeekNo - 1);

                for (int i = 0; i < 7; i++)
                {
                    myWeekDates.Add(allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    ColumnHeaderButtons[i].Content = allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)).ToShortDateString();
                }
            }
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in drawButtons)
            {
                myGrid.Children.Remove(button);
            }
            drawButtons.Clear();
            myWeekDates.Clear();
            int tempweekNo = (int)lbWeekNo.Content;
            int YearNo = (int)lbYearNo.Content;
            if (tempweekNo == 52)
            {
                lbYearNo.Content = (YearNo + 1);
                lbWeekNo.Content = 1;
                offSetForYearChange += 52;

                for (int i = 0; i < 7; i++)
                {
                    myWeekDates.Add(allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    ColumnHeaderButtons[i].Content = allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)).ToShortDateString();
                }
            }
            else
            {
                lbWeekNo.Content = (tempweekNo + 1);

                for (int i = 0; i < 7; i++)
                {
                    myWeekDates.Add(
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    ColumnHeaderButtons[i].Content =
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1));
                }
            }

        }

     
      

        public void TestingStuff()
        {

            ////chris 19.05 and sebastian 20.05   ****TESTING (adding to lists)
            //    IStaffMember lbStaffMember2 = (IStaffMember)listBoxContactStaff.SelectedItem;
            //    myController.SelectedStaffMember = lbStaffMember2;

            //    List<IShiftDate> tempList =new List<IShiftDate>();
            //    tempList = myController.ShiftDates;

            //    List<IShift>tempShifts = new List<IShift>();
            //    tempShifts = myController.Shifts;

            //    int dateId = 0 ;
            //    int staffId = myController.SelectedStaffMember.StaffMemeberId;
            //    DateTime dateWorked = DateTime.Today.Date;
            //    int shiftId = 1;

            //    if (myController.SelectedStaffMember != null)
            //    {

            //        foreach (IShift myShift in tempShifts)
            //    {
            //         if (myShift.ShiftType == "E")
            //         {
            //             shiftId = myShift.ShiftId;
            //         }
            //     }
            //        //chris & sebastian 20.05
            //        bool t = false;  //***Stop flag doesn't work like this in a foreach..
            //        foreach (IShiftDate myshiftDate in tempList)
            //        {
            //            if (dateWorked == myshiftDate.DateWorked && t==false)
            //            {
            //                dateId = myshiftDate.DateId;
            //                t = true;
            //            myController.AddNewShiftDateInDB(dateId,staffId,shiftId);
            //            }
            //        }
            //        MessageBox.Show("You added a staff member work day");

            //    }
            //if (myController.SelectedStaffMember != null)
            //{
            //    myController.AddNewShiftDate(dateId,dateWorked,myController.SelectedStaffMember,staffId);
            // //   myController.AddNewShiftDate(dateId, dateWorked, staffId);

            // MessageBox.Show("Added correctly");
            //    foreach (IShiftDate sd in myController.ShiftDates)
            //    {
            //        MessageBox.Show(sd.ToString());
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No good");
            //}
        }

        private void btnManageSchedule_Click(object sender, RoutedEventArgs e)
        {
            ManageSchedule myWindow = new ManageSchedule();
            myWindow.ShowDialog();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Environment.Exit(1);
        }

    
    
      
    }
}
