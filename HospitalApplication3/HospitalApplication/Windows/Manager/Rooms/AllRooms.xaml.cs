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
    public partial class AllRooms : UserControl
    {
        public AllRooms()
        {
            InitializeComponent();
            RoomManagment rooms = new RoomManagment();
            List<Room> p = rooms.showAllRooms();

            lvDataBinding.ItemsSource = p;
           
        }
    }
}
