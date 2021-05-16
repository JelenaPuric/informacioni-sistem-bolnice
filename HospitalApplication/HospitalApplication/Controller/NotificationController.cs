using HospitalApplication.Logic;
using HospitalApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Controller
{
    class NotificationController
    {
        private NotificationService notificationService = new NotificationService();

        public void ScheduleNotification(Notification n)
        {
            notificationService.ScheduleNotification(n);
        }

        public List<Notification> GetNotifications(string id)
        {
            return notificationService.GetNotifications(id);
        }

        public void CancelNotification(String id)
        {
            notificationService.CancelNotification(id);
        }

        public void EditNotification(string id, string title, string descriptioin, string repeat, DateTime date)
        {
            notificationService.EditNotification(id, title, descriptioin, repeat, date);
        }
    }
}
