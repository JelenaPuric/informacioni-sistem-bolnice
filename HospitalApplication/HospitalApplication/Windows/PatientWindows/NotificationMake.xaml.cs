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
using HospitalApplication.Controller;
using HospitalApplication.WorkWithFiles;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowNotificationMake.xaml
    /// </summary>
    public partial class WindowNotificationMake : Window
    {
        private FileNotification fileNotification = FileNotification.Instance;
        private int notificationId = 100000;
        private WindowPatientNotifications windowPatients = WindowPatientNotifications.Instance;
        private MainWindow mainWindow = MainWindow.Instance;
        private NotificationController controller = new NotificationController();
        List<Notification> notifications = new List<Notification>();

        public WindowNotificationMake()
        {
            InitializeComponent();
            notifications = fileNotification.GetNotifications();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Date.SelectedDate.Value.Date;
            DateTime newDate = GetDateAndTimeFromForm(date);
            List<DateTime> dates = new List<DateTime>();
            dates.Add(newDate);
            for (int i = 0; i < Int32.Parse(Repeat.Text); i++)
            {
                newDate = newDate.AddDays(1);
                dates.Add(newDate);
            }
            GenerateNotificationId();
            Notification notification = new Notification(dates, Title.Text, Description.Text, Repeat.Text, (notificationId + 1).ToString(), mainWindow.PatientsUsername);
            controller.ScheduleNotification(notification);
            windowPatients.UpdateView();
            Close();
        }

        private int GenerateNotificationId()
        {
            if (notificationId == 100000)
                for (int i = 0; i < notifications.Count; i++)
                    if (Int32.Parse(notifications[i].NotificationsId) > notificationId)
                        notificationId = Int32.Parse(notifications[i].NotificationsId);
            return notificationId;
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
