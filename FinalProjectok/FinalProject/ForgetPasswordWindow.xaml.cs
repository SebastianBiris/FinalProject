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
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;

using ControllerLayer;
using InterfaceLayer;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for ForgetPasswordWindow.xaml
    /// </summary>
    public partial class ForgetPasswordWindow : Window
    {
        Controller myController = new Controller();
       // DataAccessDB myAccessDb = new DataAccessDB();
       const string DB_CONNECTION = @"Data Source =ealdb1.eal.local;User ID=ejl13_usr;Password=Baz1nga13";
        SqlConnection con = new SqlConnection(DB_CONNECTION);
        SqlCommand cmd = new SqlCommand();

        public ForgetPasswordWindow()
        {
            InitializeComponent();
          //  myAccessDb.ConnectToDB();
            txtforgotPassword.Focus();
            
        }

        private void btnSendPassword_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {  con.Open();
                SqlCommand forgotEmail = new SqlCommand("select staffPassword from StaffMember where email =  '" + this.txtforgotPassword.Text + "';",con);
                object forgotenPassword = forgotEmail.ExecuteScalar();
                SqlDataReader myReader;
                
                myReader = forgotEmail.ExecuteReader();
                int count = 0;

                while (myReader.Read())
                { count = count + 1; }
                if (count == 1)
                {
                  
                    MessageBox.Show("Your Password has been sent to this email " + txtforgotPassword.Text);
                    
                    SmtpClient staff = new SmtpClient();
                    staff.Port = 587;
                    staff.Host = "smtp.gmail.com";
                    staff.EnableSsl = true;
                    staff.Timeout = 10000;
                    staff.DeliveryMethod = SmtpDeliveryMethod.Network;
                    staff.UseDefaultCredentials = false;
                    staff.Credentials = new NetworkCredential("gertrudssystem@gmail.com", "HappyPuppy");

                    MailMessage mm = new MailMessage("gertrudssystem@gmail.com ", txtforgotPassword.Text, "Forgotten Password", "Your Password is " + forgotenPassword);
                    staff.Send(mm);
                    mm.IsBodyHtml = true;
                    mm.BodyEncoding = Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
              
                }
                else
                {
                    MessageBox.Show("Fuck u");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
            
    }
}
