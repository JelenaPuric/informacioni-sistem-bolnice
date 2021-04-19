using HospitalApplication.Model;
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

namespace HospitalApplication.Windows.Manager.Resources
{
    /// <summary>
    /// Interaction logic for Resources.xaml
    /// </summary>
    public partial class Resources : Window
    {
        private int ss;
        public Resources(int s)
        {
            ss = s;
            InitializeComponent();
            RoomManagment rooms = new RoomManagment();
            List<Room> p = new List<Room>();

            Room ro = new Room();
            ro = rooms.showRoom(s);

            p.Add(ro);
            lvDataBinding.ItemsSource = p;
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
           this.Show();
        }

        private void AddItem_Clicked(object sender, RoutedEventArgs e)
        {
            AddResource ad = new AddResource(ss);
            ad.Show();
        }
    }
}
