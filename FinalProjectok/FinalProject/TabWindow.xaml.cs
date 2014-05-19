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
    /// Interaction logic for TabWindow.xaml
    /// </summary>
    public partial class TabWindow : Window
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
        public List<string> days = new List<string> {"", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        int nr = -1;

        public int[,] Matrix =
        { 
            {4, 2, 2, 2, 2, 2, 2, 2, 7, 8},
            {5, 3, 3, 3, 3, 3, 3, 3, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            {1, 6, 6, 6, 6, 6, 6, 6, 9,10},
            
            
        };
        public TabWindow()
        {
            InitializeComponent();
            myController = new Controller();
            myWeekDates = new List<DateTime>();
            lbWeekNo.Content = myController.GetWeeksOfYear();
            lbYearNo.Content = DateTime.Now.Year;
            DrawButtons();
            listBoxStaffInfo.ItemsSource = null;
            listBoxStaffInfo.ItemsSource = myController.StaffMembers;
            listboxStaff.ItemsSource = null;
            listboxStaff.ItemsSource = myController.StaffMembers;
            FillTheWeeks();
            GetWeek();
        }
        public List<DateTime> myWeekDates { get; set; }
        public List<IWeekList> allWeeksList = new List<IWeekList>();


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

                        break;
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
            var getSelectedButton = (Button)sender;
            string str = getSelectedButton.Name;
          //  RowNumber = Convert.ToInt16(str[1] - 48);
           // ColumnNumber = Convert.ToInt16(str[3] - 48);
            //            SelectDateTime1 = DayOfWeek[ColumnNumber - 1];
            ForgetPasswordWindow forg = new ForgetPasswordWindow();
            forg.ShowDialog();

        }

        public void DrawButtons()
        {
            int dateCounter = -10;
            for (int i = 0; i <= 26; i++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) });
                myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Auto) });
                for (int j = 0; j <= 9; j++)
                {
                    dateCounter++;
                    if (Matrix[i, j] == 3)
                    {
                        string dayHack = "Day" + dateCounter;
                        Button cellButtons = new Button
                        {
                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.AliceBlue),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "The date",//allWeeksList[WeekNow-1].GetDay(dayHack).ToShortDateString(),
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        cellButtons.SetValue(Grid.RowProperty, i);
                        cellButtons.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(cellButtons);

                    }
                    else if (Matrix[i, j] == 2)
                    {

                        Button columnHeaderButton = new Button
                        {

                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = days[j],
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        // Need to add aweeks
                        columnHeaderButton.SetValue(Grid.RowProperty, i);
                        columnHeaderButton.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(columnHeaderButton);
                        //    ColumnHeaderButtons.Add(columnHeaderButton);



                    }

                    else if (Matrix[i, j] == 6 && i <= myController.StaffMembers.Count + 1)
                    { 

                        Button columnHeaderButton = new Button
                        {

                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "6",
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        //Add shift
                        columnHeaderButton.SetValue(Grid.RowProperty, i);
                        columnHeaderButton.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(columnHeaderButton);
                        columnHeaderButton.MouseDoubleClick += MachingTheData;
                    }

                    else if (Matrix[i, j] == 1)
                    {
                        if (nr < myController.StaffMembers.Count - 1)
                        {
                            nr++;
                            Button columnHeaderButton = new Button
                            {

                                Height = 20,
                                Width = 70,
                                Background = new SolidColorBrush(Colors.Azure),
                                Foreground = new SolidColorBrush(Colors.Black),
                                IsEnabled = true,
                                Content = myController.StaffMembers[nr].StaffMemberName,
                                HorizontalContentAlignment = HorizontalAlignment.Left,
                                VerticalContentAlignment = VerticalAlignment.Top,

                            };

                            columnHeaderButton.SetValue(Grid.RowProperty, i);
                            columnHeaderButton.SetValue(Grid.ColumnProperty, j);
                            myGrid.Children.Add(columnHeaderButton);
                        }

                    }
                    else if (Matrix[i, j] == 9 && i <= myController.StaffMembers.Count + 1 && i != 1)
                    {

                        Button columnHeaderButton = new Button
                        {

                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "9",
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        columnHeaderButton.SetValue(Grid.RowProperty, i);
                        columnHeaderButton.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(columnHeaderButton);
                    }
                   
                    else if (Matrix[i, j] == 10 && i <= myController.StaffMembers.Count + 1 && i!=1)
                    {

                        Button columnHeaderButton = new Button
                        {

                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "10",
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        columnHeaderButton.SetValue(Grid.RowProperty, i);
                        columnHeaderButton.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(columnHeaderButton);
                    }
                    else if (Matrix[i, j] == 8)
                    {

                        Button columnHeaderButton = new Button
                        {

                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "Total Real",
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        columnHeaderButton.SetValue(Grid.RowProperty, i);
                        columnHeaderButton.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(columnHeaderButton);
                    }
                    else if (Matrix[i, j] == 7)
                    {
                        
                        Button columnHeaderButton = new Button
                        {

                            Height = 20,
                            Width = 70,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "Total Skema",
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        columnHeaderButton.SetValue(Grid.RowProperty, i);
                        columnHeaderButton.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(columnHeaderButton);
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
                    myWeekDates.Add(
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    ColumnHeaderButtons[i].Content = 
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)).ToShortDateString();


                }

            }
            else
            {

                lbWeekNo.Content = (tempWeekNo - 1);

                for (int i = 0; i < 7; i++)
                {
                    myWeekDates.Add(
                         allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    ColumnHeaderButtons[i].Content =
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1))
                            .ToShortDateString();
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
                    myWeekDates.Add(
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1)));
                    ColumnHeaderButtons[i].Content =
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1))
                            .ToShortDateString();
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
                        allWeeksList[(int)lbWeekNo.Content + offSetForYearChange - 1].GetDay("Day" + (i + 1))
                            .ToShortDateString();
                }
            }
        }

        private void btnAddStaffMember_Click(object sender, RoutedEventArgs e)
        {
            AddStaffMember nuWin = new AddStaffMember();
            this.Close();
            nuWin.Show();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtCpr.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
            txtRole.Clear();
            txtStatus.Clear();
            txtTilte.Clear();
            txtName.Focus();
        }

        private void listboxStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IStaffMember lbStaffMember = (IStaffMember)listboxStaff.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember;

            txtCpr.Text = lbStaffMember.Cpr;
            txtEmail.Text = lbStaffMember.Email;
            txtName.Text = lbStaffMember.StaffMemberName;
            txtPassword.Text = lbStaffMember.Password;
            txtPhoneNumber.Text = lbStaffMember.PhoneNumber;
            txtRole.Text = lbStaffMember.RoleType;
            txtStatus.Text = lbStaffMember.StatusDescription;
            txtTilte.Text = lbStaffMember.Position;
        }
    }
}

