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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUserId.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ForgetPasswordWindow w = new ForgetPasswordWindow();
            
            this.Hide();
            w.ShowDialog();
            this.Show();
        }
    }
}
