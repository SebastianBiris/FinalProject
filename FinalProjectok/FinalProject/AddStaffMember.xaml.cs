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

using  ControllerLayer;
using InterfaceLayer;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for AddStaffMember.xaml
    /// </summary>
    public partial class AddStaffMember : Window
    {
         Controller myController = new Controller();
        public AddStaffMember()
        {
            InitializeComponent();

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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        
        

        
    }
}
