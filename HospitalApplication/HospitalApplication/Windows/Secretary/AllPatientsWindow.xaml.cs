using HospitalApplication.Controller;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AllPatientsWindow.xaml
    /// </summary>
    public partial class AllPatientsWindow : Window
    {

        private static AllPatientsWindow _instance;

        public static AllPatientsWindow GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AllPatientsWindow();
            }
            return _instance;
        }



        public AllPatientsWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            _instance = this;

            SecretaryController sc = new SecretaryController();


            lvUsers.ItemsSource = sc.GetAllPatients();
        }

        private void RegisterPatient_Click(object sender, RoutedEventArgs e)
        {
            RegisterOptionWindow window = new RegisterOptionWindow();
            window.Show();

        }

        private void DeletePatient_Click_1(object sender, RoutedEventArgs e)
        {
            DeletePatientWindow window = new DeletePatientWindow();
            window.Show();
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {

            EditPatientWindow window = new EditPatientWindow();
            window.Show();

        }

        private void ViewPatient_Click(object sender, RoutedEventArgs e)
        {
            IDViewPatientWindow window = new IDViewPatientWindow();
            window.Show();
        }

        private void MakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            IDMakeAppointment window = new IDMakeAppointment();
            window.Show();

        }

        public void UpdateView()
        {
            //PatientManagement pm = new PatientManagement();
            SecretaryController sc = new SecretaryController();
            List<Patient> patients = sc.GetAllPatients();
            lvUsers.ItemsSource = sc.GetAllPatients();

            //ICollectionView view = CollectionViewSource.GetDefaultView(patients);
           // view.Refresh();
        }

        private void MedicalRecord_Click(object sender, RoutedEventArgs e)
        {
            IDMedicalRecord window = new IDMedicalRecord();
            window.Show();

        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            NewsWindow window = new NewsWindow();
            window.Show();
        }

        private void EmergencyButton_Click(object sender, RoutedEventArgs e)
        {
            IDEmergencyWindow window = new IDEmergencyWindow();
            window.Show();
        }
    }
}
