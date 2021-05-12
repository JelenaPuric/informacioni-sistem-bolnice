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
using HospitalApplication.Controller;
using HospitalApplication.Logic;
using HospitalApplication.Model;
using HospitalApplication.Windows;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowNotificationEdit.xaml
    /// </summary>
    public partial class WindowNotificationEdit : Window
    {
        private NotificationService notificationService = NotificationService.Instance;
        private WindowPatientNotifications windowNotifications = WindowPatientNotifications.Instance;
        private AppointmentController controller = new AppointmentController();

        public WindowNotificationEdit()
        {
            InitializeComponent();
            Notification notification = (Notification)windowNotifications.lvUsers.SelectedItem;
            DateTime date = notification.Dates[0];
            Date.SelectedDate = date;
            Title.Text = notification.Title;
            Description.Text = notification.Description;
            Repeat.Text = notification.Repeat;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Notification notification = (Notification)windowNotifications.lvUsers.SelectedItem;
            DateTime date = Date.SelectedDate.Value.Date;
            DateTime newDate = GetDateAndTimeFromForm(date);
            controller.EditNotification(notification.NotificationsId, Title.Text, Description.Text, Repeat.Text, newDate);
            windowNotifications.UpdateView();
            Close();
        }

        private DateTime GetDateAndTimeFromForm(DateTime date)
        {
            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 24; i++)
            {
                appointment.Add((i, 0, 0));
                appointment.Add((i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            return date + time;
        }
    }
}
