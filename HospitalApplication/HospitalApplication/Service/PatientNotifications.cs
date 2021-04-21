using HospitalApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
//using Tulpep.NotificationWindow;

namespace HospitalApplication.Logic
{
    class PatientNotifications
    {
        private string username;
        //private List<DateTime> dates;
        private List<Notification> notifications;
        private NotificationManagement ntf = NotificationManagement.Instance;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public PatientNotifications(string usernamee)
        {


            username = usernamee;
            //dates = ntf.GetDates(username);
            notifications = ntf.GetNotifications(username);
            //test notifikacija
            List<DateTime> dates = new List<DateTime>();
            DateTime date = new DateTime(2021, 4, 21, 13, 9, 0);
            dates.Add(date);
            Notification nt = new Notification(dates, "hello", "world", "1", "100050", "m");
            notifications.Add(nt);

            Thread workerThread = new Thread(new ThreadStart(notification));
            workerThread.SetApartmentState(ApartmentState.STA);
            workerThread.Start();
            /*PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "info";
            popup.ContentText = "popup";
            popup.Popup();*/
        }

        private void notification()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; i < notifications.Count; i++)
                {
                    string now = DateTime.Now.ToString("HH:mm");
                    string notify;
                    for (int j = 0; j < notifications[i].Dates.Count; j++)
                    {
                        notify = notifications[i].Dates[j].ToString("HH:mm");
                        if (notify == now)
                        {
                            MessageBoxResult info = System.Windows.MessageBox.Show(notifications[i].Description, notifications[i].Title);
                            System.Threading.Thread.Sleep(60000);
                        }
                    }
                }

                /*for (int i = 0; i < dates.Count; i++) {
                    string now = DateTime.Now.ToString("HH:mm");
                    string notify = dates[i].ToString("HH:mm");
                    if (notify == now)
                    {
                        //PopupNotifier popup = new PopupNotifier();
                        //popup.TitleText = "info";
                        //popup.ContentText = "popup";
                        //popup.Popup();
                        MessageBoxResult info = System.Windows.MessageBox.Show("Do you want to cancel examination?", "Drug remainder");
                        //WindowExaminationSchedule window = new WindowExaminationSchedule();
                        //window.Show();
                        System.Threading.Thread.Sleep(60000);
                    }
                }*/

                //popup iskoci kada koristim i messagebox a ne ako njega samog, cudno
                //System.Threading.Thread.Sleep(1000);
                //DateTime date = new DateTime(2021, 4, 13, 10, 35, 0);
                //TimeSpan time = new TimeSpan(10, 51, 0);
                //string now = DateTime.Now.ToString("HH:mm");
                //string notify = date.ToString("HH:mm");
                //if (notify == now)
                //{
                /*PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "info";
                popup.ContentText = "popup";
                popup.Popup();*/
                //    MessageBoxResult info = System.Windows.MessageBox.Show("Do you want to cancel examination?", "Drug remainder");
                //WindowExaminationSchedule window = new WindowExaminationSchedule();
                //window.Show();
                //}
            }
        }
    }
}
