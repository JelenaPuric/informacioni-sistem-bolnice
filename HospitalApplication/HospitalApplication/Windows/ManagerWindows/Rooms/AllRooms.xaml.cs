using HospitalApplication.Controller;
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
using WorkWithFiles;

namespace HospitalApplication.Windows.Manager.Prostorije
{
    public partial class AllRooms : Window
    {
        private FileRooms fileRooms = FileRooms.Instance;

        public AllRooms()
        {
            InitializeComponent();
            lvDataBinding.ItemsSource = fileRooms.ShowAllRooms();
        }

        private void AddRoom_Clicked(object sender, RoutedEventArgs e)
        {
            AddRoom window = new AddRoom();
            window.Show();
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            List<Room> allRooms = fileRooms.ShowAllRooms();
            lvDataBinding.ItemsSource = allRooms;
        }

        private void Search_Clicked(object sender, RoutedEventArgs e)
        {
            ShowRoomi window = new ShowRoomi();
            window.Show();
        }

        private void Deleted_Clicked(object sender, RoutedEventArgs e)
        {
            ManagerController logic = new ManagerController();
            Room selected = (Room)lvDataBinding.SelectedItem;
            if (selected != null)
                logic.RemoveRoom(selected);
            List<Room> allRooms = fileRooms.ShowAllRooms();
            lvDataBinding.ItemsSource = allRooms;
        }

        private void Edit_Clicked(object sender, RoutedEventArgs e)
        {
            Room selected = (Room)lvDataBinding.SelectedItem;
            if (selected != null)
            {
                EditR window = new EditR(selected);
                window.Show();
            }
        }
    }
}
