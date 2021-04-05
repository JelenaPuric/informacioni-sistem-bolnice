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
    public partial class EditR : UserControl
    {
        private Room romic;
        public EditR(int i)
        {
            RoomManagment rm = new RoomManagment();
            romic = rm.showRoom(i);
            textBoxNumberOfFloors.Text = romic.NumberOfFloors.ToString();
            textBoxRoomId.Text = romic.RoomId.ToString();
            textBoxRoomNumber.Text = romic.RoomNumber.ToString();
            textBoxCapacity.Text = romic.Capacity.ToString();
            
            checkBoxOccupied.IsChecked = (bool)romic.Occupied;
            
            
            InitializeComponent();
        }
    }
}
