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
using System.Data;
using System.Data.SqlClient;

using ControllerLayer;
using InterfaceLayer;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccessDB myDB = new DataAccessDB();
        Controller myController = new Controller();

        TabForStaff myTabForStaff = new TabForStaff();
        TabWindow myTabWindow = new TabWindow();
        ForgetPasswordWindow w = new ForgetPasswordWindow();

        public MainWindow()
        {
            InitializeComponent();
            txtUserId.Focus();



        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TabWindow myTab = new TabWindow();
            TabForStaff myTabForStaff = new TabForStaff();
            int tempId = -1;
            string tempCpr = "";
            string tempName = "";

            List<IMessage> myList = new List<IMessage>();
            foreach (IStaffMember myStaffMember in myController.StaffMembers)
            {
                if (myStaffMember.Cpr == txtUserId.Text)
                {
                    tempId = myStaffMember.StaffMemeberId;
                    tempName = myStaffMember.StaffMemberName;
                    tempCpr = myStaffMember.Cpr;
                }
            }

            foreach (IMessage myMessage in myController.Messages)
            {
                if (myMessage.StaffMemberId == tempId)
                {
                    myList.Add(myMessage);
                }

            }

            myTabForStaff.ListBoxRequests.ItemsSource = myList;
            myTabWindow.ListBoxRequests.ItemsSource = myList;

            if (tempCpr == "1")
            {
                this.Close();
                myTabWindow.Show();
            }
            else
            {
                this.Close();
                myTabForStaff.Show();
            }

        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            w.Show();
           
        }

    }
}

