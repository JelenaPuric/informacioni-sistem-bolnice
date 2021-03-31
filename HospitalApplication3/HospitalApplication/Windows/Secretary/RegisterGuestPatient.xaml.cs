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
        public RegisterGuestPatient()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            FilesPatients sp = FilesPatients.GetInstance();
            PatientManagement pm = new PatientManagement();

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
            DateTime defaultBirthDay = new DateTime(1000, 10, 10);

            AccountType typeAccc = (AccountType)Enum.Parse(typeof(AccountType), "guestAccount");

            Patient p = new Patient(typeAccc, firstName, lastName, idPatient.ToString(), defaultBirthDay, "Empty", "Empty", "Empty", typeOfPerson, username, password);

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
