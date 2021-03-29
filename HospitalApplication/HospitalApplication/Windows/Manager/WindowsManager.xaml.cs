using HospitalApplication.Windows.Manager.Prostorije;
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
            WindowRooms wr = new WindowRooms();
            wr.Show();
        }
    }
}
