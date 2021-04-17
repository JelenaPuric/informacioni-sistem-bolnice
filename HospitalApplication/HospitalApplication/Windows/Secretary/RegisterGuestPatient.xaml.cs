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
    /// Interaction logic for RegisterGuestPatient.xaml
    /// </summary>
    public partial class RegisterGuestPatient : Window
    {
        private AllPatientsWindow aPw = AllPatientsWindow.GetInstance();
        public RegisterGuestPatient()
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
            DateTime defaultBirthDay = new DateTime(1000, 10, 10);

            AccountType typeAccc = (AccountType)Enum.Parse(typeof(AccountType), "guestAccount");

            Patient p = new Patient(typeAccc, firstName, lastName, idPatient.ToString(), defaultBirthDay, "Empty", "Empty", "Empty", typeOfPerson, username, password);

            pm.CreatePatient(p);
            //sp.WritePatient(sp.Path);



            aPw.UpdateView();

            Close();


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
