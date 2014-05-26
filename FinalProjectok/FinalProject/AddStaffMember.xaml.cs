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
    /// Interaction logic for AddStaffMember.xaml
    /// </summary>
    public partial class AddStaffMember : Window
    {


        int title = -1;
        int role = -1;

        Controller myController = new Controller();
        public AddStaffMember()
        {
            InitializeComponent();

            listBoxStaff.ItemsSource = null;
            listBoxStaff.ItemsSource = myController.StaffMembers;
            cbRole.ItemsSource = null;
            cbTitle.ItemsSource = null;

            foreach (IRole roles in myController.Roles)
            {
                cbRole.Items.Add(roles.RoleType);
            }
            foreach (ITitle titles in myController.Titles)
            {
                cbTitle.Items.Add(titles.Position);
            }
        }

        #region Save Btn
        /**
         ** save a new staff member
         **/ 
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName1.Text;
            string cpr = txtCpr1.Text;
            string email = txtEmail1.Text;
            string password = txtPassword1.Text;
            string phoneNo = txtPhoneNumber1.Text;
            string status = txtStatus1.Text;

            if (cbRole.SelectedIndex == 0)
            {
                role = 1;
            }
            else if (cbRole.SelectedIndex == 1)
            {
                role = 2;
            }
            else if (cbRole.SelectedIndex == 2)
            {
                role = 3;
            }
            else if (cbRole.SelectedIndex == 3)
            {
                role = 4;
            }
            else
            {
                MessageBox.Show("Please pick a role");
                return;
            }
            if (cbTitle.SelectedIndex == 0)
            {
                title = 1;
            }
            else if (cbTitle.SelectedIndex == 1)
            {
                title = 2;
            }
            else if (cbTitle.SelectedIndex == 2)
            {
                title = 3;
            }
            else if (cbTitle.SelectedIndex == 3)
            {
                title = 4;
            }
            else if (cbTitle.SelectedIndex == 4)
            {
                title = 5;
            }
            else
            {
                MessageBox.Show("Please pick a title");
                return;
            }

            myController.CreateStaffMember(name, cpr, phoneNo, email, password, status, title, role);
            MessageBox.Show("Staff member saved");
        }
        #endregion

        #region Listbox Btn
        /*
         * shows staff member info
         */
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            {
                IStaffMember lbStaffMember = (IStaffMember)listBoxStaff.SelectedItem;
                myController.SelectedStaffMember = lbStaffMember;
                txtCpr1.Text = lbStaffMember.Cpr;
                txtEmail1.Text = lbStaffMember.Email;
                txtName1.Text = lbStaffMember.StaffMemberName;
                txtPassword1.Text = lbStaffMember.Password;
                txtPhoneNumber1.Text = lbStaffMember.PhoneNumber;
                txtStatus1.Text = lbStaffMember.StatusDescription;
                cbTitle.DataContext = lbStaffMember.Position;
                cbRole.DataContext = lbStaffMember.RoleType;
            }
        }
        #endregion

        #region Update Btn
        /*
         * update staff member infos
         */
        private void btnUpdateStaff_Click(object sender, RoutedEventArgs e)
        {
            IStaffMember lbStaffMember = (IStaffMember)listBoxStaff.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember;
            int staffId = myController.SelectedStaffMember.StaffMemeberId;
            string name = txtName1.Text;
            string cpr = txtCpr1.Text;
            string email = txtEmail1.Text;
            string password = txtPassword1.Text;
            string phoneNo = txtPhoneNumber1.Text;
            string status = txtStatus1.Text;

            if (txtName1.Text == "")
            {
                MessageBox.Show("Must Fill");
                return;
            }
            if (cbRole.SelectedIndex == 0)
            {
                role = 1;
            }
            else if (cbRole.SelectedIndex == 1)
            {
                role = 2;
            }
            else if (cbRole.SelectedIndex == 2)
            {
                role = 3;
            }
            else if (cbRole.SelectedIndex == 3)
            {
                role = 4;
            }
            else
            {
                MessageBox.Show("Please pick a role");
                return;
            }
            if (cbTitle.SelectedIndex == 0)
            {
                title = 1;
            }
            else if (cbTitle.SelectedIndex == 1)
            {
                title = 2;
            }
            else if (cbTitle.SelectedIndex == 2)
            {
                title = 3;
            }
            else if (cbTitle.SelectedIndex == 3)
            {
                title = 4;
            }
            else if (cbTitle.SelectedIndex == 4)
            {
                title = 5;
            }
            else
            {
                MessageBox.Show("Please pick a title");
                return;
            }
            myController.UpdateStaffMember(staffId, name, cpr, phoneNo, email, password, status, title, role);
            MessageBox.Show("Staff member updated");
        }
        #endregion

        #region btn Delete
        /*
         * delete a staff member
         */
        private void btnDeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            int tempId = -1;

            IStaffMember lbStaffMember = (IStaffMember)listBoxStaff.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember;

            tempId = myController.SelectedStaffMember.StaffMemeberId;
            if (tempId != -1)
            {
                myController.DeleteStaffMember(tempId);
                MessageBox.Show("Staff Member has been deleted");
            }
            else
            {
                MessageBox.Show("Staff Member has not been deleted successfully");
            }
        }
        #endregion

        #region Clear btn
        /*
         * clear infos about a staff member
         */ 

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtCpr1.Clear();
            txtEmail1.Clear();
            txtName1.Clear();
            txtPassword1.Clear();
            txtPhoneNumber1.Clear();
            txtStatus1.Clear();
            cbRole.ItemsSource = null;
            cbTitle.ItemsSource = null;
            txtName1.Focus();
        }
        #endregion

        #region btnClose
        /*
         * whe we close the window , the program is still working
         * stops the debugging
         */ 
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Environment.Exit(1);
        }
        #endregion
    }
}











