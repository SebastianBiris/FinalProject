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
    {//majd
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

        #region Login btn
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TabWindow myTab = new TabWindow();
            TabForStaff myTabForStaff = new TabForStaff();
            int tempId = -1;
            string myMember = "";
            string tempCpr = "";
            string tempName = "";
            List<IStaffMember> theStaffmeber = new List<IStaffMember>();
            List<IMessage> myList = new List<IMessage>();
            foreach (IStaffMember myStaffMember in myController.StaffMembers)
            {
                if (myStaffMember.Cpr == txtUserId.Text && myStaffMember.Password == passPassword.Password)
                {
                    myMember = myStaffMember.RoleType;
                    tempId = myStaffMember.StaffMemeberId;
                    tempName = myStaffMember.StaffMemberName;
                    tempCpr = myStaffMember.Cpr;
                }
                if (myStaffMember.Cpr != txtUserId.Text)
                {
                    theStaffmeber.Add(myStaffMember);
                }
            }

            foreach (IMessage myMessage in myController.Messages)
            {
                if (myMessage.StaffMemberId == tempId)
                {
                    myList.Add(myMessage);
                }

            }
            myTabWindow.listBoxStaffInfo.ItemsSource = theStaffmeber;
            myTabForStaff.ListBoxRequests.ItemsSource = myList;
            myTabWindow.ListBoxRequests.ItemsSource = myList;

            myTabForStaff.listBoxStaffInfo2.ItemsSource = theStaffmeber;
            myTabForStaff.listBoxContactStaff.ItemsSource = theStaffmeber;
            myTabForStaff.dataGridContactInfo.ItemsSource = theStaffmeber;


            if (myMember=="Owner")
            {
                this.Close();
                myTabWindow.Show();
            }

            else if (tempCpr != "")
            {
                this.Close();
                myTabForStaff.Show();
            }
            else
            {
                MessageBox.Show("Invalid user or password.Please try again.");
            }
            if (myMember== "Schedule leader")
            {
                myTabForStaff.btnManageSchedule.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            w.Show();
        }

    }
}

