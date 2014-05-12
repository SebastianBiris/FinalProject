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

        }


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
                    
                }
            
            }

        }


        private void MachingTheData(object sender, MouseButtonEventArgs e)
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
                               Height = 38,
                               Width = 134,
                               Background = new SolidColorBrush(Colors.AliceBlue),
                               
                           };
                        cellButtons.SetValue(Grid.RowProperty, i);
                        cellButtons.SetValue(Grid.ColumnProperty, j);
                   //     myGrid.Children.Add(cellButtons,cellButtons.MouseDoubleClick+= Ma)

                    }
                }
            }

        }
    }
}
