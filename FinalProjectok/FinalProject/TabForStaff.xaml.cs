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
    public partial class TabForStaff : Window   //Majd, Chris,  Florin,  Sebastian
    {
        Controller myController;
        int YearOffSet;
        DateTime SelectDateTime1 = DateTime.Now.AddDays(0);
        int WeekNow { get; set; }
        int offSetForYearChange;
        public List<Button> drawnButtons = new List<Button>();
        public List<Button> ColumnHeaderButtons { get; set; }
        public List<string> days = new List<string> { "", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        int nr = -1;
        string[] array;
        const int i = 27, j = 8;
        string[,] Matrix = new string[i, j];
       
        TabWindow myTabWindow = new TabWindow();
        public TabForStaff()
        {
            InitializeComponent();
            scheduleTab.Focus();
            myController = new Controller();
            myWeekDates = new List<DateTime>();
            array = new string[7];
            lbWeekNo.Content = myController.GetWeeksOfYear();
            lbYearNo.Content = DateTime.Now.Year;
            FillTheWeeks();
            GetWeek();
            GetCurrentWeekDates();
            DrawButtons();
            
        }
        #region GetCurrentWeekDates
        /*
         * sebastian - i create a method to get the current dates for each week apart 
         */
        public void GetCurrentWeekDates()
        {
           for (int i = 0; i < 7; i++)
            {
                string dayHack = "Day" + (i + 1);
                array[i] = allWeeksList[myController.GetWeeksOfYear() - 1].GetDay(dayHack).ToShortDateString();
                myWeekDates.Add(allWeeksList[myController.GetWeeksOfYear() - 1].GetDay(dayHack));
            }
        }
        #endregion

        #region SubmitMailButton
        /*
         * submit a request for a shift change
         */ 
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

        #endregion

        #region Send Mail To a StaffMember
        /*
         * sends a email to a staff member choosed with a shift change request
         */
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
        #endregion

        #region Submit ShiftChange
        /*
         * submit the message to staff member
         */
        private void btnSubmitShiftChange_Click(object sender, RoutedEventArgs e)
        {
            int tempId = 6;
            string tempMessage = txtShiftChangeRequest.Text;

            myController.CreateNewMessage(tempMessage,tempId);
            MessageBox.Show("Your message was sent successfully.");
            txtShiftChangeRequest.Clear();
        }
        #endregion

        #region Clear Changed Shift
        /*
         * clears the request
         */
        private void btnClearShiftChange_Click(object sender, RoutedEventArgs e)
        {
            txtShiftChangeRequest.Clear();
        }
        #endregion

        #region Delete Shift
        /*
         *Deletes a message from inbox
         */ 
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int tempId = -1;

            IMessage lbMessage = (IMessage)ListBoxRequests.SelectedItem;
            myController.SelectedMessage = lbMessage;

            tempId = myController.SelectedMessage.MessageId;

            myController.DeleteMessage(tempId);
            MessageBox.Show("Message deleted");
          
        }
        #endregion
        public List<DateTime> myWeekDates { get; set; }
        public List<IWeekList> allWeeksList = new List<IWeekList>();
        public List<IShiftDate> myIShift = new List<IShiftDate>();

        #region FillTheWeeks
        /*
         * fills a list with dates for each week
         */
        public void FillTheWeeks()
        {
            int offset = 0;
            for (int j = 0; j < 5; j++)
            {
                int year = 2014 + YearOffSet;
                DateTime firstDayOfTheFirstWeekOfTheYear = myController.GetWeeks(year, DayOfWeek.Monday);
                for (int i = 0; i < 54; i++)
                {
                    DateTime first = myController.GetWeeks((year + 1), DayOfWeek.Monday);
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
        #endregion

        #region GetWeek
        /*
         * get the current week
         */ 
        public void GetWeek()
        {
            WeekNow = myController.GetWeeksOfYear();

        }
        #endregion

        #region DrawButtons
        /*
         * drws buttons for each cell
         * fill the button with the right content
         */
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
                        Matrix[i, j] = array[j - 1];
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
                        for (int a = myController.ShiftDates.Count - 1; a > -1; a--)
                        {
                            if (Matrix[i, 0] == myController.ShiftDates[a].StaffMemberName && Matrix[1, j] == myController.ShiftDates[a].ActualDate.ToShortDateString())
                            {
                                Matrix[i, j] = myController.ShiftDates[a].ShiftType;
                                a = 0;
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
                        drawnButtons.Add(cellButtons);
                    }
                    else if (i <= myController.StaffMembers.Count + 1 && !(j != 0 && i != 0 && i != 1))
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
                        drawnButtons.Add(cellButtons);

                    }
                    else if (j != 0 && i != 0 && i != 1 && i <= myController.StaffMembers.Count + 1)
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
                        drawnButtons.Add(cellButtons);
                        cellButtons.Name = "R" + i + "C" + j;
                    }
                }
            }
        } 
        #endregion

        #region PreviousWeek Button
        /*
         * shows the previous week
         * we have to refresh the matrix with last week schedule content somehow
         */
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            RemoveButtons();
            drawnButtons.Clear();
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
                    array[i] = allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)).ToShortDateString();
                }
            }
            else
            {
                lbWeekNo.Content = (tempWeekNo - 1);

                for (int i = 0; i < 7; i++)
                {
                    myWeekDates.Add(allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    array[i] = allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)).ToShortDateString();
                }
            }
            DrawButtons();
        } 
        #endregion

        #region NextWeek Button
        /*
         * shows the next week schedule
         * we have to refresh the matrix with the next week schedule content somehow
         */
        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            RemoveButtons();
            drawnButtons.Clear();
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
                    array[i] = allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)).ToShortDateString();
                }
            }
            else
            {
                lbWeekNo.Content = (tempweekNo + 1);

                for (int i = 0; i < 7; i++)
                {
                    myWeekDates.Add(
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    array[i] = allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)).ToShortDateString();
                }

            }
            DrawButtons();
        }
        #endregion

        #region Manage Schedule
        /*
         * opens the manage schedule window
         */ 
        private void btnManageSchedule_Click(object sender, RoutedEventArgs e)
        {
            ManageSchedule myWindow = new ManageSchedule();
            myWindow.ShowDialog();
        }
        
        #endregion

        #region Close Button
        /*
         * program is still running after closing the window
         * stops the debugging when the window is closed
         */
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Environment.Exit(1);
        } 
        #endregion

        #region RemoveButtons
        /*
         * removes buttons from cells
         */
        public void RemoveButtons()
        {
            for (int i = 0; i <= 26; i++)
            {

                for (int j = 0; j <= 7; j++)
                { Matrix[i, j] = null; }

            }
            nr = -1;
            foreach (var button in drawnButtons)
            {
                myGrid.Children.Remove(button);
            }
        }
        #endregion
  
    }
}
