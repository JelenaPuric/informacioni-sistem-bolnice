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
using WorkWithFiles;

namespace HospitalApplication.Windows.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryWindow.xaml
    /// </summary>
    public partial class SecretaryWindow : Window
    {
        public SecretaryWindow()
        {
            InitializeComponent();
        }

        private void AllPatients_Click(object sender, RoutedEventArgs e)
        {
            FilesPatients sp = FilesPatients.GetInstance();

            AllPatientsWindow window = new AllPatientsWindow();
            window.Show();

        }

        private void RegisterPatient_Click(object sender, RoutedEventArgs e)
        {   

            RegistrationOptionWindow window = new RegistrationOptionWindow();
            window.Show();

        }

        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            DeletePatientWindow window = new DeletePatientWindow();
            window.Show();

        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            EditPatientWindow window = new EditPatientWindow();
            window.Show();

        }


    }
}
