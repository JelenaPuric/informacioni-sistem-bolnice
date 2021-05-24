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

namespace HospitalApplication.Windows.Secretary
{
    public partial class AddAllergenWindow : Window
    {
        private Patient patient;
        private SecretaryController secretaryController = new SecretaryController();
        private AllergensService allergenService = new AllergensService();
        private PatientService patientService = new PatientService();
       

        public AddAllergenWindow(string idPatient)
        {
            InitializeComponent();
            CenterWindow();
            patient = secretaryController.getPatient(idPatient);
            AddExistingTypeAllergensInComboBox();
        }

        private void AddExistingTypeAllergensInComboBox()
        {
            foreach (var item in allergenService.GetAllAllergens()){
                ComboBox1.Items.Add(item.Name);
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Allergen newAlergen = new Allergen(allergenService.getID(ComboBox1.Text), ComboBox1.Text, textBoxTypeAllergen.Text);
            patient.ListAllergens.Add(newAlergen);
            patientService.updateAllergen(patient);
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
