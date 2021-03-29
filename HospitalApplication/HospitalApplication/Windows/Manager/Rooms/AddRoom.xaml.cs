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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : UserControl
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Room r = new Room()
            {
                Capacity = Int16.Parse(textBoxCapacity.Text),
                NumberOfFloors = Int16.Parse(textBoxNumberOfFloors.Text),
                Occupied = (bool)checkBoxOccupied.IsChecked,
                RoomId = Int16.Parse(textBoxRoomId.Text),
                RoomNumber = Int16.Parse(textBoxRoomNumber.Text),
            };
            RoomManagment mr = new RoomManagment();
            mr.CreateRoom(r);
            textBoxCapacity.Text = String.Empty;
            textBoxNumberOfFloors.Text = String.Empty;
            textBoxRoomId.Text = String.Empty;
            textBoxRoomNumber.Text = String.Empty;
        }
    }
}
