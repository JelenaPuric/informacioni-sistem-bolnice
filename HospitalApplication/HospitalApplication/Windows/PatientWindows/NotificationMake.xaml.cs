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
using HospitalApplication.Windows.PatientWindows;
using HospitalApplication.Service;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowNotificationMake.xaml
    /// </summary>
    public partial class WindowNotificationMake : Window
    {
        private int notificationId = 100000;
        private FileNotifications fileNotification = FileNotifications.Instance;
        private NotificationsPage notificationsPage = NotificationsPage.Instance;
        private MainWindow mainWindow = MainWindow.Instance;
        private NotificationController controller = new NotificationController();
        private FormService formService = new FormService();

        public WindowNotificationMake()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate = formService.GetDateAndTimeFromForm(Date.SelectedDate.Value.Date, Combo);
            List<DateTime> dates = new List<DateTime>();
            dates.Add(newDate);
            for (int i = 0; i < Int32.Parse(Repeat.Text); i++){
                newDate = newDate.AddDays(1);
                dates.Add(newDate);
            }
            notificationId = fileNotification.GenerateNotificationId(notificationId);
            Notification notification = new Notification(dates, Title.Text, Description.Text, Repeat.Text, (notificationId + 1).ToString(), mainWindow.PatientsUsername);
            controller.ScheduleNotification(notification);
            notificationsPage.UpdateView();
            Close();
        }
    }
}