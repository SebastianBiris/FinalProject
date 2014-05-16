﻿using System;
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

           listBoxStaffInfo2.ItemsSource = null;
           listBoxStaffInfo2.ItemsSource = myController.StaffMembers;
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
                
            }
        
           ListBoxRequests.ItemsSource = myList;
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

    
      
    }
}
