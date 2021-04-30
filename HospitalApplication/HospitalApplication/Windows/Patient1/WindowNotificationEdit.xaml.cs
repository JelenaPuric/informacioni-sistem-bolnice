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
using HospitalApplication.Windows;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowNotificationEdit.xaml
    /// </summary>
    public partial class WindowNotificationEdit : Window
    {
        private NotificationService ntf = NotificationService.Instance;
        private WindowPatientNotifications w = WindowPatientNotifications.Instance;
        private PatientController controller = new PatientController();

        public WindowNotificationEdit()
        {
            InitializeComponent();
            Notification n = (Notification)w.lvUsers.SelectedItem;
            DateTime date = n.Dates[0];
            Date.SelectedDate = date;
            DrugName.Text = n.Title;
            Description.Text = n.Description;
            Days.Text = n.Repeat;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Notification n = (Notification)w.lvUsers.SelectedItem;
            string id = n.NotificationsId;

            DateTime date = Date.SelectedDate.Value.Date;
            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 24; i++)
            {
                appointment.Add((i, 0, 0));
                appointment.Add((i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime d = date + time;

            controller.EditNotification(id, DrugName.Text, Description.Text, Days.Text, d);
            w.UpdateView();
            Close();
        }
    }
}
