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
    /// Interaction logic for AddResource.xaml
    /// </summary>
    public partial class AddResource : Window
    {
        private int j;
        public AddResource(int i)
        {
            InitializeComponent();
            j = i;
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Resource r = new Resource()
            {
                name = textBoxName.Text,
                quantity = int.Parse(textBoxQuantity.Text),
                isStatic = (bool)checkBoxIsStatic.IsChecked,
                manufacturer = textBoxManufacturer.Text,
                roomId = j
            };

            RoomManagment rm = new RoomManagment();
            rm.AddItem(r);
            Close();
        }
    }
}
