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
    /// Interaction logic for ShowRoomi.xaml
    /// </summary>
    public partial class ShowRoomi : UserControl
    {
        private int delete;
        public ShowRoomi()
        {
            InitializeComponent();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            delete = int.Parse(forShw.Text);
            RoomManagment mg = new RoomManagment();
            Room roo = new Room();
            roo = mg.showRoom(delete);

            fallback.Text = roo.NumberOfFloors.ToString();
        }
    }
}
