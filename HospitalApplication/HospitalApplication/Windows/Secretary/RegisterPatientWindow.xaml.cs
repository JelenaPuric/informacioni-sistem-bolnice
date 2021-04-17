using Logic;
using Model;
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
    /// Interaction logic for RegisterPatientWindow.xaml
    /// </summary>
    public partial class RegisterPatientWindow : Window
    {
        private AllPatientsWindow aPw = AllPatientsWindow.GetInstance();

        public RegisterPatientWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //FilesPatients sp = FilesPatients.GetInstance();
            PatientManagement pm = new PatientManagement();

            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;

            string date = BoxDateTime.Text;
            string[] entries = date.Split('/');
            int year = Int32.Parse(entries[2]);
            int month = Int32.Parse(entries[0]);
            int day = Int32.Parse(entries[1]);
            DateTime myDate = new DateTime(year, month, day);

            string placeOfResidance = textBoxPlaceOfResidance.Text;
            string email = textBoxEmail.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            int n = pm.Patients.Count;
            int idPatient;

            if (n > 0)
            {
                idPatient = Int32.Parse(pm.Patients[n - 1].Id) + 1;
            }
            else idPatient = 0;

            TypeOfPerson typeOfPerson = (TypeOfPerson)Enum.Parse(typeof(TypeOfPerson), "Patient");


            Patient p = new Patient(0, firstName, lastName, idPatient.ToString(), myDate, phoneNumber, email, placeOfResidance, typeOfPerson, username, password);
            

            pm.CreatePatient(p);
           // sp.WritePatient(sp.Path);

            aPw.UpdateView();

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
