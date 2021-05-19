﻿using HospitalApplication.Logic;
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
using System.Windows.Threading;

namespace HospitalApplication.Windows.PatientWindows
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private double panelWidth;
        private bool hidden = true;
        private DispatcherTimer timer;

        public Home()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            panelWidth = sidePanel.Width;
            sidePanel.Width = 57;
            MenuHome.IsSelected = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void panelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 3;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 3;
                if (sidePanel.Width <= 57)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void MenuHome_Selected(object sender, RoutedEventArgs e)
        {
            Main.Content = new PatientsPage();
        }

        private void MenuNotification_Selected(object sender, RoutedEventArgs e)
        {
            Main.Content = new NotificationsPage();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            NotificationService.FlagIsMarked = true;
        }
    }
}
