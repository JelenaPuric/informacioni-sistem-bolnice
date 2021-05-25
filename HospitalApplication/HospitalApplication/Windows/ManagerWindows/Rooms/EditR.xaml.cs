using HospitalApplication.Controller;
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
        public EditR(Room oldRoom)
        {
            InitializeComponent();
            rs = oldRoom;
            textBoxNumberOfFloors.Text = oldRoom.NumberOfFloors.ToString();
            textBoxRoomId.Text = oldRoom.RoomId.ToString();
            textBoxRoomNumber.Text = oldRoom.RoomNumber.ToString();
            textBoxCapacity.Text = oldRoom.Capacity.ToString();
            checkBoxOccupied.IsChecked = (bool)oldRoom.Occupied;
            comboBoxRoomType.SelectedItem = oldRoom.RoomType;
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Room newRoom = new Room()
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
            ManagerController logic = new ManagerController();
            logic.CreateRoom(newRoom);
            logic.RemoveRoom(rs);
            Close();
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
