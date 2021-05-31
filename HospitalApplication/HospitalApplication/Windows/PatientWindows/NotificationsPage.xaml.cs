using HospitalApplication.Controller;
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
    public partial class NotificationsPage : Page
    {
        private NotificationController controller = new NotificationController();
        private MainWindow mainWindow = MainWindow.Instance;
        private FileNotifications fileNotifications = FileNotifications.Instance;

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
            List<Notification> notifications = fileNotifications.GetNotifications(mainWindow.PatientsUsername);
            lvUsers.ItemsSource = notifications;
        }

        public void UpdateView()
        {
            List<Notification> notifications = fileNotifications.GetNotifications(mainWindow.PatientsUsername);
            lvUsers.ItemsSource = null;
            lvUsers.ItemsSource = notifications;
        }

        private void MakeNotification_Click(object sender, RoutedEventArgs e)
        {
            WindowNotificationMake window = new WindowNotificationMake();
            window.ShowDialog();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            WindowNotificationInfo window = new WindowNotificationInfo();
            window.ShowDialog();
        }

        private void EditNotification_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            WindowNotificationEdit window = new WindowNotificationEdit();
            window.ShowDialog();
        }

        private void CancelNotification_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            Notification notification = (Notification)lvUsers.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Do you want to delete notification?", "Confirmation", MessageBoxButton.YesNo);
            switch (result){
                case MessageBoxResult.Yes:
                    controller.CancelNotification(notification);
                    UpdateView();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}