using HospitalApplication.Model;
using HospitalApplication.WorkWithFiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;

namespace HospitalApplication.Logic
{
    class NotificationService
    {
        private FileNotification filesNotification = FileNotification.Instance;
        private List<Notification> notifications;
        private List<Notification> notificationsForLoggedInPatient;
        private FileNotification fileNotification = FileNotification.Instance;
        public static bool FlagIsMarked { get; set; } = false;
        
        public NotificationService()
        {
            notifications = filesNotification.GetNotifications();
        }

        public void ScheduleNotification(Notification notification)
        {
            notifications.Add(notification);
            filesNotification.Write();
        }

        public void CancelNotification(Notification notification)
        {
            for (int i = 0; i < notifications.Count; i++)
                if (notifications[i].NotificationsId == notification.NotificationsId) notifications.RemoveAt(i);
            filesNotification.Write();
        }

        public void EditNotification(Notification notification, string title, string descriptioin, string repeat, DateTime newDates)
        {
            notification.Title = title;
            notification.Description = descriptioin;
            notification.Repeat = repeat;
            List<DateTime> dates = new List<DateTime>();
            dates.Add(newDates);
            for (int i = 0; i < Int32.Parse(repeat); i++)
            {
                newDates = newDates.AddDays(1);
                dates.Add(newDates);
            }
            notification.Dates = dates;
            notifications.Add(notification);
            filesNotification.Write();
        }

        public void StartNotificationThread(string usernamee)
        {
            notificationsForLoggedInPatient = fileNotification.GetNotifications(usernamee);
            //test notifikacija
            List<DateTime> dates = new List<DateTime>();
            DateTime date = new DateTime(2021, 5, 16, 15, 14, 0);
            dates.Add(date);
            Notification nt = new Notification(dates, "hello", "world", "1", "100050", "m");
            notificationsForLoggedInPatient.Add(nt);

            Thread workerThread = new Thread(new ThreadStart(NotificationThread));
            workerThread.SetApartmentState(ApartmentState.STA);
            workerThread.Start();
        }

        private void NotificationThread()
        {
            while (true)
            {
                Thread.Sleep(1000);
                for (int i = 0; i < notificationsForLoggedInPatient.Count; i++)
                {
                    for (int j = 0; j < notificationsForLoggedInPatient[i].Dates.Count; j++)
                    {
                        if (notificationsForLoggedInPatient[i].Dates[j].ToString("HH:mm") == DateTime.Now.ToString("HH:mm"))
                        {
                            MessageBox.Show(notificationsForLoggedInPatient[i].Description, notificationsForLoggedInPatient[i].Title);
                            Thread.Sleep(60000);
                        }
                    }
                }
                if (FlagIsMarked) break;
            }
        }
    }
}
