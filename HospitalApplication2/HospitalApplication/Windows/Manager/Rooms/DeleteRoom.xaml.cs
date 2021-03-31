using Logic;
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
    /// Interaction logic for DeleteRoom.xaml
    /// </summary>
    public partial class DeleteRoom : UserControl
    {
        private int delete;
        public DeleteRoom()
        {
            InitializeComponent();
        }

        private void Deleted_Clicked(object sender, RoutedEventArgs e)
        {
            delete = Int32.Parse(forDelete.Text);
            RoomManagment up = new RoomManagment();
            up.RemoveRoom(delete);
            forDelete.Text = String.Empty;
        }
    }
}
