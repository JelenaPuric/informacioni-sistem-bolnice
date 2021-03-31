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
        public RegisterPatientWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            FilesPatients sp = FilesPatients.GetInstance();

            if (textBoxFirstName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter  first name!");
                return;
            }
            else if (textBoxLastName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter  last name!");
                return;
            }
            else if (BoxDateTime.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter  birthday!");
                return;
            }
            else if (textBoxPlaceOfResidance.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter place of residance!");
                return;
            }
            else if (textBoxEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter email!");
                return;
            }
            else if (textBoxPhoneNumber.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter  phone number");
                return;
            }
            else if (textBoxUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter username!");
                return;
            }
            else if (textBoxPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter password!");
                return;
            }



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

            int n = sp.GetPatients().Count;
            int idPatient;

            if (n > 0)
            {
                idPatient = Int32.Parse(sp.GetPatients()[n - 1].Id) + 1;
            }
            else idPatient = 0;

            TypeOfPerson typeOfPerson = (TypeOfPerson)Enum.Parse(typeof(TypeOfPerson), "Patient");


            Patient p = new Patient(0, firstName, lastName, idPatient.ToString(), myDate, phoneNumber, email, placeOfResidance, typeOfPerson, username, password);
            PatientManagement pm = new PatientManagement();

            pm.CreatePatient(p);
            sp.WritePatient("patients.txt");


            Close();
        }


        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }




    }
}
