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

using  ControllerLayer;
using InterfaceLayer;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for AddStaffMember.xaml
    /// </summary>
    public partial class AddStaffMember : Window
    {
          const string DB_CONNECTION = @"Data Source =ealdb1.eal.local;User ID=ejl13_usr;Password=Baz1nga13";
        SqlConnection con = new SqlConnection(DB_CONNECTION);
        SqlCommand cmd=new SqlCommand();

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


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
             string name = txtName1.Text;
            string cpr = txtCpr1.Text;
           string email = txtEmail1.Text;
           string password = txtPassword1.Text;
           string phoneNo = txtPhoneNumber1.Text;
            int role = -1;
           string status = txtStatus1.Text;
           int title = -1;

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

            myController.CreateStaffMember(name,cpr,phoneNo,email,password,status,title,role);
            MessageBox.Show("Staff member saved");
            this.Close();
        }



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

            }
        }

        private void btnUpdateStaff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             SqlCommand SelectCommand = new SqlCommand("Update StaffMember Set staffMemberName ='" + this.txtName1.Text + "',phoneNo='" + this.txtPhoneNumber1.Text+ "' ,email ='"+ this.txtEmail1.Text+"',staffPassword='" + this.txtPassword1.Text+"' ,titleId='"+this.cbTitle.SelectedIndex+"' ,roleID= '" +this.cbRole.SelectedIndex+"',cpr='"+this.txtCpr1.Text+"',statusDescription='"+ this.txtStatus1.Text+"'Where staffMemberName='" + myController.SelectedStaffMember.StaffMemberName +"' ;", con);

                SqlDataReader myReader;
                con.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;

                while (myReader.Read())
                { count = count + 1; }
                if (count == 0)
                {
                    MessageBox.Show("updated");
                }

                else
                { MessageBox.Show("No"); }
                con.Close();
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand SelectCommand = new SqlCommand("Delete From StaffMember Where staffMemberName ='" + this.txtName1.Text + "';", con);
                SqlDataReader myReader;
                con.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;

                while (myReader.Read())
                { count = count + 1; }
                if (count == 0)
                {
                    MessageBox.Show("A Staff Member has been Deleted");
                }

                else
                { MessageBox.Show("Staff member is not deleted"); }
                con.Close();
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

  

      

        
    }
}
