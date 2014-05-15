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
    public partial class TabForStaff : Window
    {
        Controller myController;

        public TabForStaff()
        {
            InitializeComponent();
            myController = new Controller();
            listBoxStaffInfo.ItemsSource = null;
           listBoxStaffInfo.ItemsSource = myController.StaffMembers;
           listBoxContactStaff.ItemsSource = myController.StaffMembers;
           dataGridContactInfo.ItemsSource = myController.StaffMembers;
        }
    }
}
