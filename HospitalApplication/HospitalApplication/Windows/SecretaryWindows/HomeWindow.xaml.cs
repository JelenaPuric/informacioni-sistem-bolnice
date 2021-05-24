using HospitalApplication.Windows.SecretaryWindows;
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
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            CenterWindow();
        }

        private void CenterWindow()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
        }

        private void AllPatients_Click(object sender, RoutedEventArgs e)
        {
            AllPatientsWindow window = new AllPatientsWindow();
            this.Close();
            window.Show();
        }

        private void EmergencyButton_Click(object sender, RoutedEventArgs e)
        {
            IDEmergencyWindow window = new IDEmergencyWindow();
            AllPatientsWindow window1 = new AllPatientsWindow();
            this.Close();
            window1.Show();
            window.Show();
        }

        private void MakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            IDMakeAppointment window = new IDMakeAppointment();
            window.Show();
        }

        private void Doctors_Click(object sender, RoutedEventArgs e)
        {
            AllDoctorsWindow window = new AllDoctorsWindow();
            this.Close();
            window.Show();
        }
    }
}
