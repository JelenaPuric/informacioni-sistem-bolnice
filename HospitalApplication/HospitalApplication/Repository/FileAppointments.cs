using System;
using System.Collections.Generic;
using System.IO;
using HospitalApplication.Repository;
using Model;
using Nancy.Json;
using Newtonsoft.Json;

namespace WorkWithFiles
{
   public class FileAppointments : IFile
   {
        private string path = "../../../Data/appointments.json";
        private List<Appointment> appointments;
        private static FileAppointments instance;
        public static FileAppointments Instance
        {
            get
            {
                if (null == instance)
                    instance = new FileAppointments();
                return instance;
            }
        }

        private FileAppointments()
        {
            Read();
        }

        public void Read()
        {
            string json = File.ReadAllText(path);
            appointments = JsonConvert.DeserializeObject<List<Appointment>>(json);
        }

        public void Write()
        {
            string json = JsonConvert.SerializeObject(appointments, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public List<Appointment> GetAppointments(){
            return appointments;
        }

        public Appointment GetAppointment(DateTime dateTime) 
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].ExaminationStart.Equals(dateTime)) return appointments[i];
            }
            return null;
        }

        public int GetAppointmentsIndex(Appointment appointment)
        {
            for (int i = 0; i < appointments.Count; i++)
                if (appointments[i] == appointment) return i;
            return 0;
        }

        public List<Appointment> GetAppointments(string patientsId)
        {
            List<Appointment> patientsAppointments = new List<Appointment>();
            for (int i = 0; i < appointments.Count; i++)
                if (appointments[i].PatientsId == patientsId && appointments[i].ExaminationStart >= DateTime.Now)
                    patientsAppointments.Add(appointments[i]);
            return patientsAppointments;
        }

        public int GenerateAppointmentsId(int appointmentId)
        {
            if (appointmentId == 100000)
                for (int i = 0; i < appointments.Count; i++)
                    appointmentId = Math.Max(appointmentId, Int32.Parse(appointments[i].ExaminationId));
            return appointmentId;
        }
    }
}