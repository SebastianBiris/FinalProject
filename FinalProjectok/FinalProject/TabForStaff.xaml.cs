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
        // IMessage myMessage;

        public TabForStaff()
        {
            InitializeComponent();
            myController = new Controller();
            listBoxStaffInfo.ItemsSource = null;
           listBoxStaffInfo.ItemsSource = myController.StaffMembers;
           listBoxContactStaff.ItemsSource = myController.StaffMembers;
           dataGridContactInfo.ItemsSource = myController.StaffMembers;

            ListBoxRequests.ItemsSource = null;


        }

        private void listBoxStaffInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //IMessage myMessage = (IMessage) ListBoxRequests.SelectedItem;
            //myController.SelectedMessage = myMessage;
            List<IMessage> myList = new List<IMessage>();
            IStaffMember lbStaffMember = (IStaffMember)listBoxStaffInfo.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember;

            foreach (IMessage myMessage in myController.Messages)
            {
                if (myController.SelectedStaffMember.StaffMemeberId == myMessage.StaffMemberId)
                {
                    myList.Add(myMessage);
                }
                ListBoxRequests.ItemsSource = myList;

            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
