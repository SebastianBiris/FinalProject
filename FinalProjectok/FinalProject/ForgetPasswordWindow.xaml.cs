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
        #region Send Password
        /*
         * sends the password via email
         */ 
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
            if (tempEmail != "")
            {
                SmtpClient staff = new SmtpClient();
                staff.Port = 587;
                staff.Host = "smtp.gmail.com";
                staff.EnableSsl = true;
                staff.Timeout = 10000;
                staff.Credentials = new NetworkCredential("gertrudssystem@gmail.com", "HappyPuppy");
                MailMessage myMailMessage = new MailMessage("gertrudssystem@gmail.com ", txtforgotPassword.Text,
                "Forgotten Password", "Your Password is " + tempPassword);
                staff.Send(myMailMessage);
                MessageBox.Show("Your Password has been sent to this email " + txtforgotPassword.Text);
            }
            else { MessageBox.Show("Invalid email"); }
        }
        #endregion

        #region Close Button
        /*
         * when the window is closed ,program is stil running
         * stops debugging the program
         */ 
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Environment.Exit(1);
        } 
        #endregion

    }
}
