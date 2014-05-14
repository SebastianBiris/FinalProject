﻿using System;
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

using ControllerLayer;
using InterfaceLayer;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for ViewContact.xaml
    /// </summary>
    public partial class ViewContact : Window
    {
        Controller myController = new Controller();

        
        public ViewContact()
        {
            InitializeComponent();

            dataGridContactInfo.ItemsSource = myController.StaffMembers;
            listBoxContactStaff.ItemsSource = null;
            listBoxContactStaff.ItemsSource = myController.StaffMembers;
        }
    }
}
