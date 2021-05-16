using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HospitalApplication.Model;
using Model;
using Nancy.Json;

namespace HospitalApplication.WorkWithFiles
{
    class FilesNotifications
    {
        private string path = "../../../Data/notifications.json";

        public List<Notification> LoadFromFile()
        {
            if (!File.Exists(path))
                return new List<Notification>();

            string json = File.ReadAllText(path);
            List<Notification> appointments = new JavaScriptSerializer().Deserialize<List<Notification>>(json);

            return appointments;
        }

        public void WriteInFile(List<Notification> notifications)
        {
            string json = new JavaScriptSerializer().Serialize(notifications);
            File.WriteAllText(path, json);
        }
    }
}
