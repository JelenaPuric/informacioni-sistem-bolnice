using HospitalApplication.Model;
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
using HospitalApplication.Logic;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowPatientNotifications.xaml
    /// </summary>
    public partial class WindowPatientNotifications : Window
    {
        private NotificationService notificationService = NotificationService.Instance;
        private MainWindow mainWindow = MainWindow.Instance;

        private static WindowPatientNotifications instance;
        public static WindowPatientNotifications Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new WindowPatientNotifications();
                }
                return instance;
            }
        }

        public WindowPatientNotifications()
        {
            InitializeComponent();
            instance = this;
            List<Notification> notifications = notificationService.GetNotifications(mainWindow.PatientsUsername);
            lvUsers.ItemsSource = notifications;
        }

        public void UpdateView()
        {
            List<Notification> notifications = notificationService.GetNotifications(mainWindow.PatientsUsername);
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
            string notificationId = notification.NotificationsId;

            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete notification?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    notificationService.CancelNotification(notificationId);
                    UpdateView();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
