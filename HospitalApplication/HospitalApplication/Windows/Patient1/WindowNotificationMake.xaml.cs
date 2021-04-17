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
using HospitalApplication.Model;
using HospitalApplication.Logic;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowNotificationMake.xaml
    /// </summary>
    public partial class WindowNotificationMake : Window
    {
        private NotificationManagement ntf = NotificationManagement.Instance;
        private int idNotification = 100000;
        private WindowPatientNotifications w = WindowPatientNotifications.Instance;
        private MainWindow mw = MainWindow.Instance;

        public WindowNotificationMake()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Date.SelectedDate.Value.Date;
            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime d = date + time;
            List<DateTime> dates = new List<DateTime>();
            dates.Add(d);
            for (int i = 0; i < Int32.Parse(Days.Text); i++)
            {
                d = d.AddDays(1);
                dates.Add(d);
            }
            string title = DrugName.Text;
            string comment = Description.Text;
            string repeat = Days.Text;

            List<Notification> notifications = ntf.Notifications;
            for (int i = 0; i < notifications.Count; i++)
            {
                if (Int32.Parse(notifications[i].Id) > idNotification)
                {
                    idNotification = Int32.Parse(notifications[i].Id);
                }
            }

            Notification n = new Notification(dates, title, comment, repeat, (idNotification + 1).ToString(), mw.EnteredUsername);
            ntf.ScheduleNotification(n);

            w.UpdateView();
            Close();
        }
    }
}
