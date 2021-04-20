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
    /// Interaction logic for DefineAllergenWindow.xaml
    /// </summary>
    public partial class DefineAllergenWindow : Window
    {

        public DefineAllergenWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllergensManagement am = new AllergensManagement();

           string typeAllergen = textBoxTypeAllergen.Text;

            int n = am.GetAllAllergens().Count;
            int idAllergen;
            if (n > 0)
            {
                idAllergen = Int32.Parse(am.GetAllAllergens()[n - 1].Id) + 1;
            }
            else idAllergen = 0;

            Allergen a = new Allergen(idAllergen.ToString(), typeAllergen);

            am.CreateAllergen(a);


            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
