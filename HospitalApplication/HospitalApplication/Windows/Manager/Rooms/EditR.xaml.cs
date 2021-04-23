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

namespace HospitalApplication.Windows.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for EditR.xaml
    /// </summary>
    public partial class EditR : Window
    {
        private Room rs;
        public EditR(Room ro)
        {
            InitializeComponent();
            rs = ro;
            textBoxNumberOfFloors.Text = ro.NumberOfFloors.ToString();
            textBoxRoomId.Text = ro.RoomId.ToString();
            textBoxRoomNumber.Text = ro.RoomNumber.ToString();
            textBoxCapacity.Text = ro.Capacity.ToString();
            checkBoxOccupied.IsChecked = (bool)ro.Occupied;
            comboBoxRoomType.SelectedItem = ro.RoomType;
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Room r = new Room()
            {
                Capacity = Int32.Parse(textBoxCapacity.Text),
                NumberOfFloors = Int32.Parse(textBoxNumberOfFloors.Text),
                Occupied = (bool)checkBoxOccupied.IsChecked,
                RoomId = Int32.Parse(textBoxRoomId.Text),
                RoomNumber = Int32.Parse(textBoxRoomNumber.Text),
                RoomType = (RoomType)comboBoxRoomType.SelectedIndex,
                Resource = rs.Resource,
                Scheduled = rs.Scheduled
            };
            RoomManagment mr = new RoomManagment();

            int s = rs.RoomId;
            //int s = Int32.Parse(textBoxRoomId.Text);
            mr.RemoveById(s);
            mr.CreateRoom(r);
            Close();
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
