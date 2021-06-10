using HospitalApplication.Controller;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class RegisterPatientWindow : Window
    {
        private SecretaryController secretaryController = new SecretaryController();
        private AllPatientsWindow allPatientsWindow = AllPatientsWindow.GetInstance();

        public RegisterPatientWindow()
        {
            InitializeComponent();
            CenterWindow();
            MSex.IsChecked = true;
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

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //VALIDACIJA PRAZNIH POLJA
            if (textBoxFirstName.Text.Equals("") && textBoxLastName.Text.Equals("") && textBoxPhoneNumber.Text.Equals("") && textBoxEmail.Text.Equals("") &&
                textBoxPlaceOfResidance.Text.Equals("") && textBoxUsername.Text.Equals("") && textBoxPassword.Text.Equals("") && textBoxJMBG.Text.Equals(""))
            {
                MessageBox.Show("All fields are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxFirstName.Text.Equals(""))
            {
                MessageBox.Show("First name field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxLastName.Text.Equals(""))
            {
                MessageBox.Show("Last name field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxJMBG.Text.Equals(""))
            {
                MessageBox.Show("JMBG field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (BoxDateTime.Text.Equals(""))
            {
                MessageBox.Show("Date field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxPlaceOfResidance.Text.Equals(""))
            {
                MessageBox.Show("Place of residance field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxEmail.Text.Equals(""))
            {
                MessageBox.Show("Email field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxPhoneNumber.Text.Equals(""))
            {
                MessageBox.Show("Phone number field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxUsername.Text.Equals(""))
            {
                MessageBox.Show("Username field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxPassword.Text.Equals(""))
            {
                MessageBox.Show("Password field are required", "Info", MessageBoxButton.OK);
                return;
            }
            // VALIDACIJA First Name i Last name -- VELIKO POCETNO SLOVO
            if (textBoxFirstName.Text[0].ToString() != textBoxFirstName.Text[0].ToString().ToUpper())
            {
                MessageBox.Show("First capital letter of first name are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxLastName.Text[0].ToString() != textBoxLastName.Text[0].ToString().ToUpper())
            {
                MessageBox.Show("First capital letter of last name are required", "Info", MessageBoxButton.OK);
                return;
            }
            // VALIDACIJA JMBG DA SU DOZVOLJENI BROJEVI SAMO I DA IMA 13 brojeva
            if (!textBoxJMBG.Text.All(char.IsDigit))
            {
                MessageBox.Show("In JMBG field only numbers are allowed", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxJMBG.Text.Length != 13)
            {
                MessageBox.Show("JMBG field must contain 13 numbers", "Info", MessageBoxButton.OK);
                return;
            }
            //VALIDACIJA Place of residance da je prvo veliko pocetno slovo
            if (textBoxPlaceOfResidance.Text[0].ToString() != textBoxPlaceOfResidance.Text[0].ToString().ToUpper())
            {
                MessageBox.Show("First capital letter of place of residance are required", "Info", MessageBoxButton.OK);
                return;
            }
            // VALIDACIJA Email adrese da bude u ispravnom obliku
            if (!IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("Invalid email adress.", "Info", MessageBoxButton.OK);
                return;
            }
            //VALIDACIJA  Phone number da budu brojevi
            if (!textBoxPhoneNumber.Text.All(char.IsDigit))
            {
                MessageBox.Show("In phone number field only numbers are allowed", "Info", MessageBoxButton.OK);
                return;
            }
            //-------------------------------------------------------


            MedicalRecord newMedicalRecord = new MedicalRecord(GenerateIdForNewPatient(), 0, 0, textBoxFirstName.Text, textBoxLastName.Text, "empty", textBoxJMBG.Text, GetSelectedDate(), "empty", 
                                                               textBoxPlaceOfResidance.Text, textBoxPhoneNumber.Text, GetSelectedSexType());

            Patient newPatient = new Patient(0, textBoxFirstName.Text, textBoxLastName.Text, GenerateIdForNewPatient(), GetSelectedDate(), textBoxPhoneNumber.Text, textBoxEmail.Text, textBoxPlaceOfResidance.Text, 
                                            (TypeOfPerson)Enum.Parse(typeof(TypeOfPerson), "Patient"), textBoxUsername.Text, textBoxPassword.Text, textBoxJMBG.Text, GetSelectedSexType(), newMedicalRecord, 
                                            new List<Allergen>(), new Tuple<int, DateTime, bool>(0, DateTime.Now, false));

            secretaryController.CreatePatient(newPatient);
            allPatientsWindow.UpdateView();
            Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private SexType GetSelectedSexType()
        {
            SexType sex = SexType.male;
            if (Convert.ToBoolean(MSex.IsChecked)){
                sex = SexType.male;
            }
            else if (Convert.ToBoolean(FSex.IsChecked)){
                sex = SexType.female;
            }
            return sex;
        }

        private string GenerateIdForNewPatient()
        {
            int n = secretaryController.GetPatients().Count;
            int idPatient;
            if (n > 0)
            {
                idPatient = Int32.Parse(secretaryController.GetPatients()[n - 1].Id) + 1;
            }
            else idPatient = 0;
            return idPatient.ToString();
        }

        private DateTime GetSelectedDate()
        {
            string date = BoxDateTime.Text;
            string[] entries = date.Split('/');
            int year = Int32.Parse(entries[2]);
            int month = Int32.Parse(entries[0]);
            int day = Int32.Parse(entries[1]);
            return new DateTime(year, month, day);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
