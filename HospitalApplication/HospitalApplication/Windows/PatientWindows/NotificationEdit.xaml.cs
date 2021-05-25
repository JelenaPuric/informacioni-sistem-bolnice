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
using HospitalApplication.Controller;
using HospitalApplication.Logic;
using HospitalApplication.Model;
using HospitalApplication.Service;
using HospitalApplication.Windows;
using HospitalApplication.Windows.PatientWindows;

namespace HospitalApplication.Windows.Patient1
{
    public partial class WindowNotificationEdit : Window
    {
        private NotificationsPage notificationsPage = NotificationsPage.Instance;
        private NotificationController controller = new NotificationController();
        private FormService formService = new FormService();

        public WindowNotificationEdit()
        {
            InitializeComponent();
            Notification notification = (Notification)notificationsPage.lvUsers.SelectedItem;
            Date.SelectedDate = notification.Dates[0];
            Title.Text = notification.Title;
            Description.Text = notification.Description;
            Repeat.Text = notification.Repeat;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Notification notification = (Notification)notificationsPage.lvUsers.SelectedItem;
            DateTime newDate = formService.GetDateAndTimeFromForm(Date.SelectedDate.Value.Date, Combo);
            controller.EditNotification(notification, Title.Text, Description.Text, Repeat.Text, newDate);
            notificationsPage.UpdateView();
            Close();
        }
    }
}