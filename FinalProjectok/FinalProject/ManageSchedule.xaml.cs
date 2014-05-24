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
    /// Interaction logic for ManageSchedule.xaml
    /// </summary>
    public partial class ManageSchedule : Window
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
        
        public ManageSchedule()
        {
            InitializeComponent();
            myController = new Controller();
            myWeekDates = new List<DateTime>();
            ColumnHeaderButtons = new List<Button>();
            lbWeekNo.Content = myController.GetWeeksOfYear();
            lbYearNo.Content = DateTime.Now.Year;
            FillTheWeeks();
            GetWeek();
            DrawButtons();
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
        public void MachingTheData(object sender, MouseButtonEventArgs e)
        {
            Assign_Shift myWindow = new Assign_Shift();
            int tempDateId = -1;
            int tempStaffId = -1;
            int tempShiftId = -1;
            Assign_Shift shiftWindow = new Assign_Shift();
            shiftWindow.ShowDialog();
            var getSelectedButton = (Button)sender;
            string str = getSelectedButton.Name;

            int tempRowNr1 = Convert.ToInt16(str[1] - 48);
            int tempRowNr2 = Convert.ToInt16(str[2] - 48);
            if (tempRowNr1 * 10 + tempRowNr2 < 27)
            {
                RowNumber = tempRowNr1 * 10 + tempRowNr2;
                ColumnNumber = Convert.ToInt16(str[4] - 48);
            }
            else
            {
                RowNumber = Convert.ToInt16(str[1] - 48);
                ColumnNumber = Convert.ToInt16(str[3] - 48);
            }
            foreach (IShiftDate myShift in myController.ShiftIds)
            {
                if (Matrix[1, ColumnNumber] == myShift.DateWorked.ToShortDateString())
                { tempDateId = myShift.DateId; }
            }
            foreach (IStaffMember myStaff in myController.StaffMembers)
            {
                if (Matrix[RowNumber, 0] == myStaff.StaffMemberName)
                { tempStaffId = myStaff.StaffMemeberId; }
            }
            IShift cbShift = (IShift)myWindow.lbShiftType.SelectedItem;
            IShift myshifts = (IShift)shiftWindow.lbShiftType.SelectedItem;
            myController.Selectedshift = myshifts;
            if (myController.Selectedshift != null)
            { tempShiftId = myController.Selectedshift.ShiftId; }
            if (tempShiftId != -1)
            {
                myController.AddNewShiftDateInDB(tempDateId, tempStaffId, tempShiftId);

            }

            myController.GetAllFromDB();
            DrawButtons();
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
                        cellButtons.MouseDoubleClick += MachingTheData;
                        cellButtons.Name = "R" + i + "C" + j;
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
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            TabForStaff myWindow = new TabForStaff();

            this.Close();
          
        }
    }
}
