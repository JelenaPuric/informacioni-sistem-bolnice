using HospitalApplication.Windows.Manager.Rooms;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalApplication.Windows.Manager.Prostorije
{
    /// <summary>
    /// Interaction logic for AllRooms.xaml
    /// </summary>
    public partial class AllRooms : Window
    {
        public AllRooms()
        {
            InitializeComponent();
            RoomService rooms = new RoomService();
            List<Room> p = rooms.showAllRooms();

            lvDataBinding.ItemsSource = p;
           
        }

        private void AddRoom_Clicked(object sender, RoutedEventArgs e)
        {
            AddRoom ar = new AddRoom();
            ar.Show();
            RoomService rooms = new RoomService();
            List<Room> p = rooms.showAllRooms();

            lvDataBinding.ItemsSource = p;
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            RoomService rooms = new RoomService();
            List<Room> p = rooms.showAllRooms();
            lvDataBinding.ItemsSource = p;
        }

        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            ShowRoomi sr = new ShowRoomi();
            sr.Show();
        }

        private void Deleted_Clicked(object sender, RoutedEventArgs e)
        {
            Room selected = (Room)lvDataBinding.SelectedItem;
            if (selected != null)
            {
                RoomService rm = new RoomService();
                rm.RemoveRoom(selected);
            }
            RoomService rooms = new RoomService();
            List<Room> p = rooms.showAllRooms();

            lvDataBinding.ItemsSource = p;
        }

        private void Edit_Clicked(object sender, RoutedEventArgs e)
        {
            Room selected = (Room)lvDataBinding.SelectedItem;
            if (selected != null)
            {
                EditR er = new EditR(selected);
                er.Show();
                //if (er.Submit.IsEnabled) {
                //    RoomManagment rm = new RoomManagment();
                //    rm.RemoveRoom(selected);
                //}
            }

        }
    }
}
