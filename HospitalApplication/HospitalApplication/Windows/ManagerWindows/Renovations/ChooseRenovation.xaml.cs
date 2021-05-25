﻿using HospitalApplication.Windows.Manager.Renovationn;
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

namespace HospitalApplication.Windows.ManagerWindows.Renovations
{
    /// <summary>
    /// Interaction logic for ChooseRenovation.xaml
    /// </summary>
    public partial class ChooseRenovation : Window
    {
        public ChooseRenovation()
        {
            InitializeComponent();
        }

        private void One_Clicked(object sender, RoutedEventArgs e)
        {
            AddRenovation window = new AddRenovation();
            window.Show();
            Close();
        }
    }
}
