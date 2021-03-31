using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalApplication.Windows.Secretary
{
    /// <summary>
    /// Interaction logic for RegistrationOptionWindow.xaml
    /// </summary>
    public partial class RegistrationOptionWindow : Window
    {
        public RegistrationOptionWindow()
        {
            InitializeComponent();
        }

        private void PermAcc_Click(object sender, RoutedEventArgs e)
        {
            RegisterPatientWindow window = new RegisterPatientWindow();
            window.Show();
        }

        private void GuestAcc_Click(object sender, RoutedEventArgs e)
        {
            RegisterGuestPatient window = new RegisterGuestPatient();
            window.Show();

        }


    }
}
