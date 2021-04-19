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
        ComboBox cb;

        public DefineAllergenWindow(ComboBox comboBoxTypeAllergens)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);


            cb = comboBoxTypeAllergens;


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           string type1 = textBoxType1.Text;

         

           cb.Items.Add(type1);
            


            Close();
        }
    }
}
