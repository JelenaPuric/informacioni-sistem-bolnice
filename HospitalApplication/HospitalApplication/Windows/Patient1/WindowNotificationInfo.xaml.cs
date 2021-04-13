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
        private WindowPatientNotifications w = WindowPatientNotifications.Instance;

        public WindowNotificationInfo()
        {
            InitializeComponent();
            Notification n = (Notification)w.lvUsers.SelectedItem;
            DateTime date = n.Dates[0];
            Date.Text = date.ToString();
            DrugName.Text = n.Title;
            Description.Text = n.Description;
            Days.Text = n.Repeat;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
