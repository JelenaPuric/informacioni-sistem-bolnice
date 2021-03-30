using HospitalApplication.Windows.Manager.Rooms;
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

namespace HospitalApplication.Windows.Manager.Prostorije
{
    /// <summary>
    /// Interaction logic for WindowRooms.xaml
    /// </summary>
    public partial class WindowRooms : Window
    {
        public WindowRooms()
        {
            InitializeComponent();
        }

        private void AllRooms_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AllRooms();
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new DeleteRoom();
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddRoom();
        }

        private void Find_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ShowRoomi();
        }
    }
}
