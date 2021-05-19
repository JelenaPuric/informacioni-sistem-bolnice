﻿using HospitalApplication.Controller;
using HospitalApplication.Model;
using HospitalApplication.Windows.Patient1;
using HospitalApplication.WorkWithFiles;
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

namespace HospitalApplication.Windows.PatientWindows
{
    /// <summary>
    /// Interaction logic for NotificationsPage.xaml
    /// </summary>
    public partial class NotificationsPage : Page
    {
        private NotificationController notificationController = new NotificationController();
        private MainWindow mainWindow = MainWindow.Instance;
        private FileNotification fileNotification = FileNotification.Instance;

        private static NotificationsPage instance;
        public static NotificationsPage Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new NotificationsPage();
                }
                return instance;
            }
        }

        public NotificationsPage()
        {
            InitializeComponent();
            instance = this;
            List<Notification> notifications = fileNotification.GetNotifications(mainWindow.PatientsUsername);
            lvUsers.ItemsSource = notifications;
        }

        public void UpdateView()
        {
            List<Notification> notifications = fileNotification.GetNotifications(mainWindow.PatientsUsername);
            lvUsers.ItemsSource = null;
            lvUsers.ItemsSource = notifications;
        }

        private void MakeNotification_Click(object sender, RoutedEventArgs e)
        {
            WindowNotificationMake window = new WindowNotificationMake();
            window.Show();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            WindowNotificationInfo window = new WindowNotificationInfo();
            window.Show();
        }

        private void EditNotification_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            WindowNotificationEdit window = new WindowNotificationEdit();
            window.Show();
        }

        private void CancelNotification_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            Notification notification = (Notification)lvUsers.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Do you want to delete notification?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    notificationController.CancelNotification(notification);
                    UpdateView();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
