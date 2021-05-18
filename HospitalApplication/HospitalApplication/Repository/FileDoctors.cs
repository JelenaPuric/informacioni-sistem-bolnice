using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using Logic;
using Nancy.Json;

namespace HospitalApplication.WorkWithFiles
{
    class FileDoctors
    {
        private static string path = "../../../Data/doctors.json";
        private static List<Doctor> doctors;

        public FileDoctors() {
            Read();
        }

        public static void Read()
        {
            string json = File.ReadAllText(path);
            doctors = new JavaScriptSerializer().Deserialize<List<Doctor>>(json);
        }

        public static void Write()
        {
            string json = new JavaScriptSerializer().Serialize(doctors);
            File.WriteAllText(path, json);
        }

        public static List<Doctor> GetDoctors() {
            Read();
            if (doctors == null) doctors = new List<Doctor>();
            return doctors;
        }

        public static Doctor GetDoctor(string doctorUsername) {
            Read();
            for (int i = 0; i < doctors.Count; i++)
                if (doctorUsername == doctors[i].Username)
                    return doctors[i];
            return null;
        }
    }
}
