using HospitalApplication.Windows.Manager.Medicines;
using HospitalApplication.Windows.Manager.Prostorije;
using HospitalApplication.Windows.Manager.Resources;
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

namespace HospitalApplication.Windows.Manager
{
    /// <summary>
    /// Interaction logic for WindowsManager.xaml
    /// </summary>
    public partial class WindowsManager : Window
    {
        public WindowsManager()
        {
            InitializeComponent();
        }

        private void Rooms_Clicked(object sender, RoutedEventArgs e)
        {
            AllRooms wr = new AllRooms();
            wr.Show();
        }

        private void Resources_Clicked(object sender, RoutedEventArgs e)
        {
            Resources.Menu m = new Resources.Menu();
            m.Show();
        }

        private void Renovation_Clicked(object sender, RoutedEventArgs e)
        {
            Renovationn.Renovations r = new Renovationn.Renovations();
            r.Show();
        }

        private void Medicines_Clicked(object sender, RoutedEventArgs e)
        {
            Medicines.main m = new main();
            m.Show();
        }
    }
}
