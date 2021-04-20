﻿using HospitalApplication.Model;
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
using System.Windows.Shapes;

namespace HospitalApplication.Windows.Manager.Resources
{
    /// <summary>
    /// Interaction logic for MoveDynamicResource.xaml
    /// </summary>
    public partial class MoveDynamicResource : Window
    {
        private Resource rebus;
        public MoveDynamicResource(Resource r)
        {
            InitializeComponent();
            textBoxName.Text = r.name;
            textBoxQuantity.Text = r.quantity.ToString();
            rebus = r;
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Resource re = new Resource();
            re.roomId = int.Parse(textBoxRoomId.Text);

            if (int.Parse(textBoxQuantity.Text) > int.Parse(textBoxKolicina.Text)) {
                re.quantity = int.Parse(textBoxKolicina.Text);
            }
            else {
                MessageBox.Show(" You don't have that many resources " );
            }
            re.name = rebus.name;
            re.isStatic = rebus.isStatic;
            re.manufacturer = rebus.manufacturer;
            re.idItem = rebus.idItem;


            RoomManagment rm = new RoomManagment();
            rm.TransferDynamicItem(re, int.Parse(textBoxKolicina.Text));
            rm.RemoveQuantity(rebus, int.Parse(textBoxKolicina.Text));

            if (rebus.quantity == 0)
                rm.RemoveItem(rebus);

            Close();
        }
    }
}
