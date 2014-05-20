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
        const string DB_CONNECTION = @"Data Source =ealdb1.eal.local;User ID=ejl13_usr;Password=Baz1nga13";
        SqlConnection con = new SqlConnection(DB_CONNECTION);
        SqlCommand cmd=new SqlCommand();
        TabForStaff myTabForStaff = new TabForStaff();
        TabWindow myTabWindow = new TabWindow();
        

        public MainWindow()
        {
            InitializeComponent();
            txtUserId.Focus();
           
            
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        { TabWindow myTab= new TabWindow();
            TabForStaff myTabForStaff = new TabForStaff();
            int tempId=-1;
            string tempName="";
          

            List<IMessage> myList = new List<IMessage>();
           

            foreach (IStaffMember myStaffMember in myController.StaffMembers)
            {
                if (myStaffMember.Cpr == txtUserId.Text)
                {
                    tempId = myStaffMember.StaffMemeberId;
                    tempName = myStaffMember.StaffMemberName;
                }
                        }

                  foreach (IMessage myMessage in myController.Messages)
                    {  
                      if (myMessage.StaffMemberId == tempId)
                      {
                          myList.Add(myMessage) ;
                      }
                      
                   }

                  myTabForStaff.ListBoxRequests.ItemsSource = myList;
                  myTab.ListBoxRequests.ItemsSource = myList;
                  

                 
          
        
            
            try
            {   
                SqlCommand SelectCommand = new SqlCommand("select * from StaffMember where cpr ='" + this.txtUserId.Text + "'and staffPassword ='" + this.passPassword.Password+ "';", con);
                SqlDataReader myReader;
                con.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;

                while (myReader.Read())
                { count =count +1; }
                if (count == 1)
                { 
                this.Close();
                //myTab.Show();
                    if (txtUserId.Text == "1")
                    {
                        
                        this.Close();
                        myTab.Show();
                    }
                    else if (txtUserId.Text != "1")
                    {
                        this.Close();
                        myTabForStaff.Show();
                    }
                }
                else if(count>1)
                {MessageBox.Show("Duplicated User or password. Access denied.");}
                else
                {MessageBox.Show("User or password is not correct.Plase try again .");}
                con.Close();}
            
              catch(Exception ex)
               {MessageBox.Show(ex.Message);}
        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            TabWindow nt = new TabWindow();
            ForgetPasswordWindow w = new ForgetPasswordWindow();
            
            this.Hide();
            nt.ShowDialog();
            this.Show();
        }
    }
}
