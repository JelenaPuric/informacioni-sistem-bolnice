using HospitalApplication.Controller;
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

namespace HospitalApplication.Windows.Secretary
{
    /// <summary>
    /// Interaction logic for MedicalRecordWindow.xaml
    /// </summary>
    public partial class MedicalRecordWindow : Window
    {
        List<string> cbListTypeAllergens = new List<string>();
        private Patient p;
        private AllPatientsWindow aPw = AllPatientsWindow.GetInstance();

        public MedicalRecordWindow(string value)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);


           // cbListTypeAllergens.Add("nesto");
           // ComboBoxTypeAllergens.Items.Add(cbListTypeAllergens[0]);


            SecretaryController sc = new SecretaryController();
            p = sc.getPatient(value);

            ComboBox1.Text = p.TypeAcc.ToString();
            ComboBoxMartialStatus.Text = p.medicalRecord.MartialStatus.ToString();
            textBoxFirstName.Text = p.Name;
            textBoxNameParent.Text = p.medicalRecord.NameParent;
            textBoxLastName.Text = p.LastName;
            textBoxJMBG.Text = p.Jmbg;

            if (p.SexType == SexType.male)
            {
                MSex.IsChecked = true;
            }
            else
            {
                FSex.IsChecked = true;
            }

            BoxDateTime.Text = p.DateOfBirth.ToString();
            textBoxHealthCard.Text = p.medicalRecord.NumberOfHealthCard;
            textBoxPlaceOfResidance.Text = p.PlaceOfResidance;
            textBoxPhoneNumber.Text = p.PhoneNumber;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SecretaryController sc = new SecretaryController();

            AccountType typeAcc = (AccountType)Enum.Parse(typeof(AccountType), ComboBox1.Text);
            p.medicalRecord.TypeAcc = typeAcc;

            MaritalStatus martialStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), ComboBoxMartialStatus.Text);
            p.medicalRecord.MartialStatus = martialStatus;

            p.medicalRecord.FirstName = textBoxFirstName.Text;
            p.medicalRecord.NameParent = textBoxNameParent.Text;
            p.medicalRecord.LastName = textBoxLastName.Text;
            p.medicalRecord.Jmbg = textBoxJMBG.Text;

            SexType sex;
            if (Convert.ToBoolean(MSex.IsChecked))
            {
                sex = SexType.male;
                p.medicalRecord.SexType = sex;
            }
            else if (Convert.ToBoolean(FSex.IsChecked))
            {
                sex = SexType.female;
                p.medicalRecord.SexType = sex;
            }

            string date = BoxDateTime.Text;
            string[] entries = date.Split('/');
            int year = Int32.Parse(entries[2]);
            int month = Int32.Parse(entries[0]);
            int day = Int32.Parse(entries[1]);
            DateTime myDate = new DateTime(year, month, day);

            p.medicalRecord.DateOfBirth = myDate;
            p.medicalRecord.NumberOfHealthCard = textBoxHealthCard.Text;
            p.medicalRecord.PlaceOfResidance = textBoxPlaceOfResidance.Text;
            p.medicalRecord.PhoneNumber = textBoxPhoneNumber.Text;

            sc.UpdateMedicalRecord(p);

            aPw.UpdateView();

            Close();

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedIndex = 0;
        }

        private void DefineAllergens_Click_1(object sender, RoutedEventArgs e)
        {
            DefineAllergenWindow window = new DefineAllergenWindow(ComboBoxTypeAllergens);
            window.Show();
       

            //foreach (var item in Enum.GetValues(typeof(AllergensType)))
            //{
            //    ComboBoxTypeAllergens.Items.Add(item);
            //}

        }
    }
}
