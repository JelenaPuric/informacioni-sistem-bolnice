using System;
using System.Collections.Generic;
using System.IO;
using Model;
using Nancy.Json;

namespace WorkWithFiles
{
   public class FilesAppointments
   {
        private string path = "../../../Data/appointments.json";

        public List<Appointment> LoadFromFile()
        {
            //ako ne postoji fajl (jos uvek nista nije sacuvano pri prvom pokretanju aplikacije vrati praznu listu)
            if (!File.Exists(path))
                return new List<Appointment>();

            string json = File.ReadAllText(path);
            List<Appointment> appointments = new JavaScriptSerializer().Deserialize<List<Appointment>>(json);

            return appointments;
        }

        public void WriteInFile(List<Appointment> appointments)
        {
            string json = new JavaScriptSerializer().Serialize(appointments);
            File.WriteAllText(path, json);
        }
   }
}