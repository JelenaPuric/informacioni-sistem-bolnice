using HospitalApplication.Model;
using HospitalApplication.WorkWithFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Logic
{
    class NotificationManagement
    {
        private static NotificationManagement instance;
        public static NotificationManagement Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new NotificationManagement();
                }
                return instance;
            }
        }

        public NotificationManagement()
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

            //notifikacija koja sluzi da demonstrira rad treda za notifikacije
            /*List<DateTime> dates = new List<DateTime>();
            DateTime date = new DateTime(2021, 4, 13, 10, 57, 0);
            dates.Add(date);
            Notification nt = new Notification(dates, "vucicu", "pederu", "1", "100050", "m");
            n.Add(nt);*/

            for (int i = 0; i < notifications.Count; i++)
            {
                if (notifications[i].PatientId == id)
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

        public List<DateTime> GetDates(string username)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime date = new DateTime(2021, 4, 13, 10, 42, 0);
            dates.Add(date);
            for (int i = 0; i < notifications.Count; i++)
            {
                //uzimam samo notifikacije za ulogovanog pacijenta
                if (notifications[i].PatientId != username) continue;
                for (int j = 0; j < notifications[i].Dates.Count; j++)
                {
                    //ne trebaju mi prosli datumi
                    if (notifications[i].Dates[j] >= DateTime.Now)
                        dates.Add(notifications[i].Dates[j]);
                }
            }
            return dates;
        }

        /*public List<Examination> GetExaminations(String patientName)
        {
            List<Examination> e = new List<Examination>();
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].PatientsId == patientName)
                {
                    e.Add(examinations[i]);
                }
            }
            return e;
        }*/

        private FilesNotification f = new FilesNotification();
        private List<Notification> notifications;

        public List<Notification> Notifications
        {
            get { return notifications; }
            set { notifications = value; }
        }
    }
}
