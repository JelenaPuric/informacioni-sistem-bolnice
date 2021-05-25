﻿using HospitalApplication.Model;
using HospitalApplication.Service;
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
    public partial class MoveStaticResource : Window
    {
        private Resource oldResourceAtributes;

        public MoveStaticResource(Resource oldResource)
        {
            InitializeComponent();
            RelocationResourceService service = new RelocationResourceService();
            List<Transfer> allTransfers = service.showAllTransfers();
            service.CheckTransfers();
            lvDataBinding.ItemsSource = allTransfers;
            oldResourceAtributes = oldResource;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            AddMoveStaticResource window = new AddMoveStaticResource(oldResourceAtributes);
            window.Show();
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            RelocationResourceService service = new RelocationResourceService();
            List<Transfer> allTransfers = service.showAllTransfers();
            service.CheckTransfers();
            lvDataBinding.ItemsSource = allTransfers;
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            Transfer oldTransfer = (Transfer)lvDataBinding.SelectedItem;
            RelocationResourceService service = new RelocationResourceService();
            service.DeleteTransfer(oldTransfer);
            List<Transfer> allTransfers = service.showAllTransfers();
            lvDataBinding.ItemsSource = allTransfers;
        }
    }
}
