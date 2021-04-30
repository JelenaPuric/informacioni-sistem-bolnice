using HospitalApplication.Model;
using HospitalApplication.WorkWithFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Logic
{
    class NotificationService
    {
        private FilesNotification filesNotification = new FilesNotification();
        public List<Notification> Notifications { get; set; }
        private static NotificationService instance;
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

        public void ScheduleNotification(Notification n)
        {
            Notifications.Add(n);
            filesNotification.WriteInFile(Notifications);
        }

        public List<Notification> GetNotifications(string id)
        {
            List<Notification> n = new List<Notification>();
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
    }
}
