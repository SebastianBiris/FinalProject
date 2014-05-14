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
            DrawButtons();
        }
        public List<DateTime> myWeekDates { get; set; }



        public void FillTheWeeks()
        {
            int offset = 0;
            for (int j = 0; j < 5; j++)
            {
                int year = 2014 + YearOffSet;
                DateTime firstDayOfTheFirstWeekOfTheYear = myController.GetWeeks(year,DayOfWeek.Thursday);
                for (int i = 0; i < 54; i++)
                {
                    DateTime first = myController.GetWeeks((year + 1), DayOfWeek.Thursday);
                    DateTime second = firstDayOfTheFirstWeekOfTheYear.AddDays(1 + offset);

                    if (first <= second)
                    {
                        offset = 0;

                        break;
                    }


                    myController.GetWeekList(year, firstDayOfTheFirstWeekOfTheYear.AddDays(0 + offset),
                        firstDayOfTheFirstWeekOfTheYear.AddDays(1 + offset),
                        firstDayOfTheFirstWeekOfTheYear.AddDays(2 + offset),
                        firstDayOfTheFirstWeekOfTheYear.AddDays(3 + offset),
                        firstDayOfTheFirstWeekOfTheYear.AddDays(4 + offset),
                        firstDayOfTheFirstWeekOfTheYear.AddDays(5 + offset),
                        firstDayOfTheFirstWeekOfTheYear.AddDays(6 + offset));
                    offset += 7;
                }
                YearOffSet++;

            }

        }

        public int GetWeek()
        {
            WeekNow = myController.GetWeeksOfYear();
            return WeekNow;
        }




        public void MachingTheData(object sender, MouseButtonEventArgs e)
        {
            var getSelectedButton = (Button)sender;
            string str = getSelectedButton.Name;
            RowNumber = Convert.ToInt16(str[1] - 48);
            ColumnNumber = Convert.ToInt16(str[3] - 48);
            //            SelectDateTime1 = DayOfWeek[ColumnNumber - 1];


        }

        public void DrawButtons()
        {
            int dateCounter = 0;
            for (int i = 0; i <= 26; i++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                for (int j = 0; j <= 9; j++)
                {
                    dateCounter++;
                    if (Matrix[i, j] == 4)
                    {
                        Button cellButtons = new Button
                        {
                            Height = 34,
                            Width = 130,
                            Background = new SolidColorBrush(Colors.AliceBlue),

                        };
                        cellButtons.SetValue(Grid.RowProperty, i);
                        cellButtons.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(cellButtons);
                        cellButtons.MouseDoubleClick += MachingTheData;
                        cellButtons.Name = "R" + i + "C" + j;
                    }
                    else if (Matrix[i, j] == 2)
                    {
                        string dayHack = "Day" + (dateCounter - 1);
                        Button columnHeaderButton = new Button
                        {
                            Name = dayHack,
                            Height = 34,
                            Width = 130,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "X",
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        // Need to add aweeks
                        columnHeaderButton.SetValue(Grid.RowProperty, i);
                        columnHeaderButton.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(columnHeaderButton);
                        //   ColumnHeaderButtons.Add(columnHeaderButton);



                    }

                    else if (Matrix[i, j] == 6)
                    {

                        Button rowHeaderButton = new Button
                        {
                            Name = "something",
                            Height = 34,
                            Width = 130,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "X",
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,

                        };
                        //Add shift
                        rowHeaderButton.SetValue(Grid.RowProperty, i);
                        rowHeaderButton.SetValue(Grid.ColumnProperty, j);
                        myGrid.Children.Add(rowHeaderButton);

                    }

                    else if (Matrix[i, j] == 1)
                    {
                        string dayHack = "Day" + (dateCounter - 1);
                        Button columnHeaderButton = new Button
                        {
                            Name = dayHack,
                            Height = 34,
                            Width = 130,
                            Background = new SolidColorBrush(Colors.Azure),
                            Foreground = new SolidColorBrush(Colors.Black),
                            IsEnabled = true,
                            Content = "X",
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



        private void Previous_Click(object sender, RoutedEventArgs e)
        { }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //{
        //    foreach (Button button in drawButtons)
        //    { myGrid.Children.Remove(button); }
        //    drawButtons.Clear();
        //    myWeekDates.Clear();
        //    int tempWeekNo= (int)lbWeekNo.Content;
        //    int yearNo = (int)lbYearNo.Content;
        //    if (tempWeekNo == 1)
        //    { lbYearNo.Content = (yearNo - 1);
        //    lbWeekNo.Content = 52;
        //    offSetForYearChange -= 52;

        //    for (int i = 0; i < 7; i++)
        //    {



        //    }

        //}
    }
}
