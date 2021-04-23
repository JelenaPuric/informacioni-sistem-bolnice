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

namespace HospitalApplication.Windows.Manager.Resources
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            SearchResource sr = new SearchResource();
            sr.Show();
            Close();
        }

        private void Room_Clicked(object sender, RoutedEventArgs e)
        {
            SearchRoom sr = new SearchRoom();
            sr.Show();
            Close();
        }
    }
}
