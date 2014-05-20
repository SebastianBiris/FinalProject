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
          

           listBoxStaffInfo2.ItemsSource = null;
           listBoxStaffInfo2.ItemsSource = myController.StaffMembers;
           listBoxContactStaff.ItemsSource = myController.StaffMembers;
           dataGridContactInfo.ItemsSource = myController.StaffMembers;

         


        }

        private void listBoxStaffInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
           
         }  

        private void btnSubmitMail_Click(object sender, RoutedEventArgs e)
        {
            IStaffMember lbStaffMember2 = (IStaffMember) listBoxContactStaff.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember2;

            int tempStaffId = myController.SelectedStaffMember.StaffMemeberId;
            string message = txtContactStaff.Text;

            myController.CreateNewMessage(message,tempStaffId);
            MessageBox.Show("Your message was sent successfully.");
            txtContactStaff.Clear();
        }



        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
             IStaffMember lbStaffMember2 = (IStaffMember) listBoxStaffInfo2.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember2;

            int tempStaffId = myController.SelectedStaffMember.StaffMemeberId;
            string tempMessage = txtRespon.Text;
           
          myController.CreateNewMessage(tempMessage,tempStaffId);
            MessageBox.Show("Your message was sent successfully.");
                txtRespon.Clear();
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
            if (ListBoxRequests.SelectedItem == myController.SelectedMessage)
            {
                
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
    
      
    }
}
