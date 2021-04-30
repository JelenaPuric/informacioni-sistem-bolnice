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

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowNotificationInfo.xaml
    /// </summary>
    public partial class WindowNotificationInfo : Window
    {
        private WindowPatientNotifications windowNotifications = WindowPatientNotifications.Instance;

        public WindowNotificationInfo()
        {
            InitializeComponent();
            Notification notification = (Notification)windowNotifications.lvUsers.SelectedItem;
            DateTime date = notification.Dates[0];
            Date.Text = date.ToString();
            DrugName.Text = notification.Title;
            Description.Text = notification.Description;
            Days.Text = notification.Repeat;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
