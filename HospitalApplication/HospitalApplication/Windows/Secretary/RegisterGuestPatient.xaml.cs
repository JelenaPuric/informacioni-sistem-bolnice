using HospitalApplication.Controller;
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
            //PatientManagement pm = new PatientManagement();
            SecretaryController sc = new SecretaryController();

            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string jmbg = textBoxJMBG.Text;


            string username = textBoxFirstName.Text + textBoxLastName.Text;
            string password = "123";


            string date = BoxDateTime.Text;
            string[] entries = date.Split('/');
            int year = Int32.Parse(entries[2]);
            int month = Int32.Parse(entries[0]);
            int day = Int32.Parse(entries[1]);
            DateTime myDate = new DateTime(year, month, day);



            int n = sc.GetAllPatients().Count;
            int idPatient;

            if (n > 0)
            {
                idPatient = Int32.Parse(sc.GetAllPatients()[n - 1].Id) + 1;
            }
            else idPatient = 0;


            TypeOfPerson typeOfPerson = (TypeOfPerson)Enum.Parse(typeof(TypeOfPerson), "Patient");
            

            AccountType typeAccc = (AccountType)Enum.Parse(typeof(AccountType), "guestAccount");

            MedicalRecord mr = new MedicalRecord(idPatient.ToString(), typeAccc, 0, firstName, lastName, "empty", jmbg, myDate, "empty", "empty", "empty", 0);

            Patient p = new Patient(typeAccc, firstName, lastName, idPatient.ToString(), myDate, "Empty", "Empty", "Empty", typeOfPerson, username, password, jmbg, 0, mr);

            sc.CreatePatient(p);
          



            aPw.UpdateView();

            Close();


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
