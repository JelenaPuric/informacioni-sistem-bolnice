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
        public Resources(int s)
        {
            InitializeComponent();
            RoomManagment rooms = new RoomManagment();
            List<Room> p = new List<Room>();

            Resource re = new Resource();
            re.id = "123";
            re.jeStaticka = true;
            re.kolicina = 5;
            re.proizvodjac = "Markovic";

            Room ro = new Room();
            ro = rooms.showRoom(s);
            ro.Resource.Add(re);
            p.Add(ro);
            lvDataBinding.ItemsSource = p;
        }
    }
}
