﻿using System;
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
using WorkWithFiles;

namespace HospitalApplication.Windows.Secretary
{
    /// <summary>
    /// Interaction logic for MoveAppointment.xaml
    /// </summary>
    public partial class MoveAppointment : Window
    {

        FileAppointments fx = FileAppointments.Instance;


        private static MoveAppointment instance;
        public static MoveAppointment Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new MoveAppointment();
                }
                return instance;
            }
        }

        public MoveAppointment()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            instance = this;

            lvUsers.ItemsSource = fx.GetAppointments();
        }

        private void MoveAppointment_Click(object sender, RoutedEventArgs e)
        {
            FunMoveAppointmentWindow window = new FunMoveAppointmentWindow();
            window.Show();
        }
        
        private void RefreshList_Click(object sender, RoutedEventArgs e)
        {
            lvUsers.ItemsSource = fx.GetAppointments();
        }
    }
}
