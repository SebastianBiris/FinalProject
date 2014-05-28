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
    /// Interaction logic for Assign_Shift.xaml
    /// </summary>
    public partial class Assign_Shift : Window
    {
        Controller myController = new Controller();
        List<IShift> myIshift = new List<IShift>();
        TabWindow myWindow = new TabWindow();
   /*
    * assigns a shift to a staff member on the choosed date
    */ 
        public Assign_Shift()
        {
            InitializeComponent();
            FillShiftList();
           
        }

        private void FillShiftList()
        {  
            foreach (IShift myShift in myController.Shift)
            {
                myIshift.Add(myShift);
                lbShiftType.ItemsSource = myIshift;
            }
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            this.Hide();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Environment.Exit(1);
        }
    }
}
