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
        private NotificationService ntf = NotificationService.Instance;
        private MainWindow mainWIndow = MainWindow.Instance;

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

            //List<Notification> notifications = m.GetExaminations(l.EnteredUsername);
            List<Notification> notifications = ntf.GetNotifications(mainWIndow.PatientsUsername);
            //List<Examination> examinations = m.Examinations;
            lvUsers.ItemsSource = notifications;
            //Logic.PatientNotifications p = new Logic.PatientNotifications();
            //TestLabela.Content = mainWIndow.PatientsUsername;
        }

        public void UpdateView()
        {
            List<Notification> notifications = ntf.GetNotifications(mainWIndow.PatientsUsername);
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
            //ako nista nije selektovano zavrsi funkciju
            if (!(lvUsers.SelectedIndex > -1))
            {
                return;
            }
            WindowNotificationInfo window = new WindowNotificationInfo();
            window.Show();
        }

        private void EditNotification_Click(object sender, RoutedEventArgs e)
        {
            //ako nista nije selektovano zavrsi funkciju
            if (!(lvUsers.SelectedIndex > -1))
            {
                return;
            }
            WindowNotificationEdit window = new WindowNotificationEdit();
            window.Show();
        }

        private void CancelNotification_Click(object sender, RoutedEventArgs e)
        {
            //ako nista nije selektovano zavrsi funkciju
            if (!(lvUsers.SelectedIndex > -1))
            {
                return;
            }
            Notification n = (Notification)lvUsers.SelectedItem;
            string id = n.NotificationsId;

            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to delete notification?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    ntf.CancelNotification(id);
                    UpdateView();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
