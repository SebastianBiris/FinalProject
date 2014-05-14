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
using System.Data.SqlClient;

using ControllerLayer;
using InterfaceLayer;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for StaffInfo.xaml
    /// </summary>
    public partial class StaffInfo : Window
    {
        Controller myController = new Controller();

        public StaffInfo()
        {

            InitializeComponent();
            txtName.Focus();

            listboxStaff.ItemsSource = null;
            listboxStaff.ItemsSource = myController.StaffMembers;

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //majd
            txtName.Clear();
            txtCpr.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
            txtRole.Clear();
            txtStatus.Clear();
            txtTilte.Clear();
            txtName.Focus();

        }

        private void listboxStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IStaffMember lbStaffMember = (IStaffMember)listboxStaff.SelectedItem;
            myController.SelectedStaffMember = lbStaffMember;

            txtCpr.Text = lbStaffMember.Cpr;
            txtEmail.Text = lbStaffMember.Email;
            txtName.Text = lbStaffMember.StaffMemberName;
            txtPassword.Text = lbStaffMember.Password;
            txtPhoneNumber.Text = lbStaffMember.PhoneNumber;
            txtRole.Text = lbStaffMember.RoleType;
            txtStatus.Text = lbStaffMember.StatusDescription;
            txtTilte.Text = lbStaffMember.Position;

        }

        private void btnAddStaffMember_Click(object sender, RoutedEventArgs e)
        {
            AddStaffMember nuWin = new AddStaffMember();
            this.Close();
            nuWin.Show();
           

        }
    }
}