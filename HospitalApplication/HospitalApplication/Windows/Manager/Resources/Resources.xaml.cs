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
        private int ss;
        private bool ddd;
        public Resources(int s)
        {
            ss = s;
            InitializeComponent();
            RoomManagment rooms = new RoomManagment();
            //List<Room> p = new List<Room>();

            Room ro = new Room();
            ro = rooms.showRoom(s);

            //p.Add(ro);
            rooms.CheckIfZero(ro);
            lvDataBinding.ItemsSource = ro.Resource;
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            RoomManagment rooms = new RoomManagment();
            Room ro = new Room();
            ro = rooms.showRoom(ss);
            rooms.CheckIfZero(ro);
            lvDataBinding.ItemsSource = ro.Resource;
        }

        private void AddItem_Clicked(object sender, RoutedEventArgs e)
        {
            AddResource ad = new AddResource(ss);
            ad.Show();
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            RoomManagment rm = new RoomManagment();
            Resource selected = (Resource)lvDataBinding.SelectedItem;
            if (selected != null)
            {
                rm.RemoveItem(selected);
            }
            Room ro = new Room();
            ro = rm.showRoom(ss);

            lvDataBinding.ItemsSource = ro.Resource;
        }

        private void EditResource_Clicked(object sender, RoutedEventArgs e)
        {
            Resource selected = (Resource)lvDataBinding.SelectedItem;
            if (selected != null)
            {
                EditResource er = new EditResource(selected);
                er.Show();
            }
            
        }

        private void Static_Clicked(object sender, RoutedEventArgs e)
        {
            RoomManagment rooms = new RoomManagment();
            Room ro = new Room();
            List<Resource> rs = new List<Resource>();
            ro = rooms.showRoom(ss);
            for(int i = 0; i < ro.Resource.Count; i++)
            {
                if(ro.Resource[i].isStatic == true)
                {
                    rs.Add(ro.Resource[i]);
                }
            }
            lvDataBinding.ItemsSource = rs;
            ddd = true;
        }

        private void Dynamic_Clicked(object sender, RoutedEventArgs e)
        {
            RoomManagment rooms = new RoomManagment();
            Room ro = new Room();
            List<Resource> rs = new List<Resource>();
            ro = rooms.showRoom(ss);
            for (int i = 0; i < ro.Resource.Count; i++)
            {
                if (ro.Resource[i].isStatic != true)
                {
                    rs.Add(ro.Resource[i]);
                }
            }
            lvDataBinding.ItemsSource = rs;
            ddd = false;
        }

        private void Switching_Clicked(object sender, RoutedEventArgs e)
        {
            Resource selected = (Resource)lvDataBinding.SelectedItem;
            if (selected.isStatic == true)
            {

                    MoveStaticResource msr = new MoveStaticResource(selected);
                    msr.Show();
            }
            else
                {
                    MoveDynamicResource mdr = new MoveDynamicResource(selected);
                    mdr.Show();
                }
            
        }
    }
}
