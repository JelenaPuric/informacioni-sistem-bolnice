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
    /// <summary>
    /// Interaction logic for AddAllergenWindow.xaml
    /// </summary>
    public partial class AddAllergenWindow : Window
    {

        private string idP;

        public AddAllergenWindow(string idPatient)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            idP = idPatient;

            AllergensManagement am = new AllergensManagement();
            List<Allergen> defAllergens = am.GetAllAllergens();


            foreach (var item in defAllergens)
            {
                ComboBox1.Items.Add(item.Name);
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SecretaryController sc = new SecretaryController();
            AllergensManagement am = new AllergensManagement();
            PatientManagement pm = new PatientManagement();

            Patient p;
            string cb = ComboBox1.Text;
            string specName = textBoxTypeAllergen.Text;

            List<Patient> patients = sc.GetAllPatients();
            p = sc.getPatient(idP);

            string idAllergen = am.getID(cb);
            Allergen a = new Allergen(idAllergen, cb, specName);

            p.ListAllergens.Add(a);

            pm.updateAllergen(p);


            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
