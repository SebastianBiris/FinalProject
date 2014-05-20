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
       

        public ForgetPasswordWindow()
        {
            InitializeComponent();
          
            txtforgotPassword.Focus();
            
        }

        private void btnSendPassword_Click(object sender, RoutedEventArgs e)
        {
            string tempEmail = "";
            string tempPassword = "";

            foreach (IStaffMember myStaffMember in myController.StaffMembers)
            {
                if (txtforgotPassword.Text == myStaffMember.Email)
                {
                    tempPassword = myStaffMember.Password;
                    tempEmail = myStaffMember.Email;
                }
             
            }
           
                
                  
                    
                    
                    SmtpClient staff = new SmtpClient();
                    staff.Port = 587;
                    staff.Host = "smtp.gmail.com";
                    staff.EnableSsl = true;
                    staff.Timeout = 10000;
                    staff.DeliveryMethod = SmtpDeliveryMethod.Network;
                    staff.UseDefaultCredentials = false;
                    staff.Credentials = new NetworkCredential("gertrudssystem@gmail.com", "HappyPuppy");

                    MailMessage mm = new MailMessage("gertrudssystem@gmail.com ", txtforgotPassword.Text, "Forgotten Password", "Your Password is " + tempPassword);
                    staff.Send(mm);
                    mm.IsBodyHtml = true;
                    mm.BodyEncoding = Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    MessageBox.Show("Your Password has been sent to this email " + txtforgotPassword.Text);
              
                
          
}
            
    }
}
