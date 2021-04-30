using HospitalApplication.Model;
using HospitalApplication.WorkWithFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Logic
{
    class NotificationService
    {
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
            notifications = f.LoadFromFile();
        }

        public void ScheduleNotification(Notification n)
        {
            notifications.Add(n);
            f.WriteInFile(notifications);
        }

        public List<Notification> GetNotifications(string id)
        {
            List<Notification> n = new List<Notification>();
            for (int i = 0; i < notifications.Count; i++)
            {
                if (notifications[i].PatientId == id && notifications[i].Dates[notifications[i].Dates.Count - 1] > DateTime.Now)
                {
                    n.Add(notifications[i]);
                }
            }
            return n;
        }

        public void CancelNotification(String id)
        {
            for (int i = 0; i < notifications.Count; i++)
            {
                if (notifications[i].Id == id) notifications.RemoveAt(i);
            }
            f.WriteInFile(notifications);
        }

        public void EditNotification(string id, string title, string descriptioin, string repeat, DateTime date)
        {
            //prvo ga izbrisi, promeni datum pa vrati
            Notification n = new Notification();
            for (int i = 0; i < notifications.Count; i++)
            {
                if (notifications[i].Id == id)
                {
                    n = notifications[i];
                    notifications.RemoveAt(i);
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
            notifications.Add(n);
            f.WriteInFile(notifications);
        }

        private FilesNotification f = new FilesNotification();
        private List<Notification> notifications;

        public List<Notification> Notifications
        {
            get { return notifications; }
            set { notifications = value; }
        }
    }
}
