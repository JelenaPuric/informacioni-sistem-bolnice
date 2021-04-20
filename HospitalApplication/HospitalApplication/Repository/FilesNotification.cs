using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HospitalApplication.Model;
using Model;

namespace HospitalApplication.WorkWithFiles
{
    class FilesNotification
    {
        private string path = "notifications.txt";
        public List<Notification> LoadFromFile()
        {
            List<Notification> notifications = new List<Notification>();
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] notification = line.Split(",");
                List<DateTime> terms = new List<DateTime>();
                string[] term = notification[0].Split("~");
                //ovaj and u foru je tu da ne bi pokusao da prazan string pretvori u date
                for (int i = 0; i < term.Length && term[i] != ""; i++)
                {
                    DateTime date = DateTime.Parse(term[i]);
                    terms.Add(date);
                }
                //DateTime myDate = DateTime.ParseExact(pregled[3], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                Notification ntf = new Notification(terms, notification[1], notification[2], notification[3], notification[4], notification[5]);
                notifications.Add(ntf);
            }
            return notifications;
        }

        public void WriteInFile(List<Notification> notifications)
        {
            System.IO.File.WriteAllText(path, string.Empty);
            for (int i = 0; i < notifications.Count; i++)
            {
                for (int j = 0; j < notifications[i].Dates.Count; j++)
                {
                    File.AppendAllText(path, notifications[i].Dates[j] + "");
                    if (j < notifications[i].Dates.Count - 1)
                    {
                        File.AppendAllText(path, "~");
                    }
                }
                File.AppendAllText(path, ",");
                File.AppendAllText(path, notifications[i].Title + "," + notifications[i].Description + "," + notifications[i].Repeat + "," + notifications[i].Id + "," + notifications[i].PatientId);
                File.AppendAllText(path, "\n");
            }
        }
    }
}
