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

namespace HospitalApplication.Windows.Secretary
{
    public partial class MedicalRecordWindow : Window
    {
        private SecretaryController secretaryController = new SecretaryController();
        private Patient selectedPatient;
        private AllPatientsWindow allPatientsWindow = AllPatientsWindow.GetInstance();

        public MedicalRecordWindow(string idPatient)
        {
            InitializeComponent();
            CenterWindow();
            selectedPatient = secretaryController.GetPatient(idPatient);
            lvUsers.ItemsSource = selectedPatient.ListAllergens;
            DisplayValuesFromSelectedPatient();
        }

        private void DisplayValuesFromSelectedPatient()
        {
            ComboBox1.Text = selectedPatient.TypeAcc.ToString();
            ComboBoxMartialStatus.Text = selectedPatient.medicalRecord.MartialStatus.ToString();
            textBoxFirstName.Text = selectedPatient.Name;
            textBoxNameParent.Text = selectedPatient.medicalRecord.NameParent;
            textBoxLastName.Text = selectedPatient.LastName;
            textBoxJMBG.Text = selectedPatient.Jmbg;

            if (selectedPatient.SexType == SexType.male)
                MSex.IsChecked = true;
            else
                FSex.IsChecked = true;

            BoxDateTime.Text = selectedPatient.DateOfBirth.ToString();
            textBoxHealthCard.Text = selectedPatient.medicalRecord.NumberOfHealthCard;
            textBoxPlaceOfResidance.Text = selectedPatient.PlaceOfResidance;
            textBoxPhoneNumber.Text = selectedPatient.PhoneNumber;
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
            if (ComboBox1.Text.Equals("") && textBoxFirstName.Text.Equals("") && textBoxLastName.Text.Equals("") && textBoxPhoneNumber.Text.Equals("")  && textBoxHealthCard.Text.Equals("") &&
                textBoxPlaceOfResidance.Text.Equals("") && textBoxJMBG.Text.Equals("") && ComboBoxMartialStatus.Text.Equals("") && textBoxNameParent.Text.Equals(""))
            {
                MessageBox.Show("All fields are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (ComboBox1.Text.Equals(""))
            {
                MessageBox.Show("Type doctor field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (ComboBoxMartialStatus.Text.Equals(""))
            {
                MessageBox.Show("Martial status field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxFirstName.Text.Equals(""))
            {
                MessageBox.Show("First name field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxNameParent.Text.Equals(""))
            {
                MessageBox.Show("Name of one parent field are required", "Info", MessageBoxButton.OK);
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
            if (textBoxHealthCard.Text.Equals(""))
            {
                MessageBox.Show("Health card field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxPlaceOfResidance.Text.Equals(""))
            {
                MessageBox.Show("Place of residance field are required", "Info", MessageBoxButton.OK);
                return;
            }
            if (textBoxPhoneNumber.Text.Equals(""))
            {
                MessageBox.Show("Phone number field are required", "Info", MessageBoxButton.OK);
                return;
            }
            // VALIDACIJA First Name i Last name i Name of parent-- VELIKO POCETNO SLOVO textBoxNameParent
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
            if (textBoxNameParent.Text[0].ToString() != textBoxNameParent.Text[0].ToString().ToUpper())
            {
                MessageBox.Show("Name of one parent field are required", "Info", MessageBoxButton.OK);
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
            // VALIDACIJA ZA HEALTH CARD  da budu samo brojevi 
            if (!textBoxHealthCard.Text.All(char.IsDigit))
            {
                MessageBox.Show("In health card field only numbers are allowed", "Info", MessageBoxButton.OK);
                return;
            }
            //VALIDACIJA Place of residance da je prvo veliko pocetno slovo
            if (textBoxPlaceOfResidance.Text[0].ToString() != textBoxPlaceOfResidance.Text[0].ToString().ToUpper())
            {
                MessageBox.Show("First capital letter of place of residance are required", "Info", MessageBoxButton.OK);
                return;
            }
            //VALIDACIJA  Phone number da budu brojevi
            if (!textBoxPhoneNumber.Text.All(char.IsDigit))
            {
                MessageBox.Show("In phone number field only numbers are allowed", "Info", MessageBoxButton.OK);
                return;
            }
            //-------------------------------------------------------

            SetNewMedicalRecordValuesToSelectedPatient();
            secretaryController.UpdateMedicalRecord(selectedPatient);
            allPatientsWindow.UpdateView();
            Close();
        }

        private void SetNewMedicalRecordValuesToSelectedPatient()
        {
            selectedPatient.medicalRecord.TypeAcc = (AccountType)Enum.Parse(typeof(AccountType), ComboBox1.Text);
            selectedPatient.medicalRecord.MartialStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), ComboBoxMartialStatus.Text);
            selectedPatient.medicalRecord.FirstName = textBoxFirstName.Text;
            selectedPatient.medicalRecord.NameParent = textBoxNameParent.Text;
            selectedPatient.medicalRecord.LastName = textBoxLastName.Text;
            selectedPatient.medicalRecord.Jmbg = textBoxJMBG.Text;
            selectedPatient.medicalRecord.SexType = GetSelectedSexType();
            selectedPatient.medicalRecord.DateOfBirth = GetNewSelectedDate();
            selectedPatient.medicalRecord.NumberOfHealthCard = textBoxHealthCard.Text;
            selectedPatient.medicalRecord.PlaceOfResidance = textBoxPlaceOfResidance.Text;
            selectedPatient.medicalRecord.PhoneNumber = textBoxPhoneNumber.Text;
        }

        private SexType GetSelectedSexType()
        {
            SexType sex = SexType.male;
            if (Convert.ToBoolean(MSex.IsChecked))
                return sex = SexType.male;
            else if (Convert.ToBoolean(FSex.IsChecked))
                return sex = SexType.female;
            return sex;
        }

        private DateTime GetNewSelectedDate()
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

        private void DefineAllergen_Click(object sender, RoutedEventArgs e)
        {
             DefineAllergenWindow window = new DefineAllergenWindow();
             window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             AddAllergenWindow window = new AddAllergenWindow(selectedPatient.Id);
             window.Show();
        }

        private void Refresh_Click_1(object sender, RoutedEventArgs e)
        {
            selectedPatient = secretaryController.GetPatient(selectedPatient.Id);
            lvUsers.ItemsSource = selectedPatient.ListAllergens;
        }
    }
}
