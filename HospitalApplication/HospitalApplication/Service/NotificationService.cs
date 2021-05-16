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
        private FilesNotifications filesNotification = new FilesNotifications();
        public List<Notification> Notifications { get; set; }
        private List<Notification> notificationsForLoggedInPatient;
        private static NotificationService instance;
        public bool FlagIsMarked { get; set; } = false;
        public static NotificationService Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new NotificationService();
                }
                return instance;
            }
        }

        public NotificationService()
        {
            Notifications = filesNotification.LoadFromFile();
        }

        public NotificationService(string usernamee)
        {
            notificationsForLoggedInPatient = GetNotifications(usernamee);
            //test notifikacija
            List<DateTime> dates = new List<DateTime>();
            DateTime date = new DateTime(2021, 5, 16, 15, 14, 0);
            dates.Add(date);
            Notification nt = new Notification(dates, "hello", "world", "1", "100050", "m");
            notificationsForLoggedInPatient.Add(nt);

            Thread workerThread = new Thread(new ThreadStart(AnnounceNotification));
            workerThread.SetApartmentState(ApartmentState.STA);
            workerThread.Start();
        }

        public void ScheduleNotification(Notification n)
        {
            Notifications.Add(n);
            filesNotification.WriteInFile(Notifications);
        }

        public List<Notification> GetNotifications(string id)
        {
            List<Notification> n = new List<Notification>();
            if (Notifications == null) return n;
            for (int i = 0; i < Notifications.Count; i++)
            {
                if (Notifications[i].PatientsId == id && Notifications[i].Dates[Notifications[i].Dates.Count - 1] > DateTime.Now)
                {
                    n.Add(Notifications[i]);
                }
            }
            return n;
        }

        public void CancelNotification(String id)
        {
            for (int i = 0; i < Notifications.Count; i++)
            {
                if (Notifications[i].NotificationsId == id) Notifications.RemoveAt(i);
            }
            filesNotification.WriteInFile(Notifications);
        }

        public void EditNotification(string id, string title, string descriptioin, string repeat, DateTime date)
        {
            //prvo ga izbrisi, promeni datum pa vrati
            Notification n = new Notification();
            for (int i = 0; i < Notifications.Count; i++)
            {
                if (Notifications[i].NotificationsId == id)
                {
                    n = Notifications[i];
                    Notifications.RemoveAt(i);
                }
            }
            n.Title = title;
            n.Description = descriptioin;
            n.Repeat = repeat;

            List<DateTime> dates = new List<DateTime>();
            dates.Add(date);
            for (int i = 0; i < Int32.Parse(repeat); i++)
            {
                date = date.AddDays(1);
                dates.Add(date);
            }
            n.Dates = dates;
            Notifications.Add(n);
            filesNotification.WriteInFile(Notifications);
        }

        private void AnnounceNotification()
        {
            while (true)
            {
                Thread.Sleep(1000);
                for (int i = 0; i < notificationsForLoggedInPatient.Count; i++)
                {
                    string now = DateTime.Now.ToString("HH:mm");
                    string notify;
                    for (int j = 0; j < notificationsForLoggedInPatient[i].Dates.Count; j++)
                    {
                        notify = notificationsForLoggedInPatient[i].Dates[j].ToString("HH:mm");
                        if (notify == now)
                        {
                            MessageBoxResult info = MessageBox.Show(notificationsForLoggedInPatient[i].Description, notificationsForLoggedInPatient[i].Title);
                            Thread.Sleep(60000);
                        }
                    }
                }
                if (FlagIsMarked) break;
            }
        }
    }
}
