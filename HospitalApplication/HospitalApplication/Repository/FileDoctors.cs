using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using Logic;
using Nancy.Json;
using HospitalApplication.Repository;

namespace HospitalApplication.WorkWithFiles
{
    class FileDoctors : IFile
    {
        private static string path = "../../../Data/doctors.json";
        private static List<Doctor> doctors;
        private static FileDoctors instance;
        public static FileDoctors Instance
        {
            get
            {
                if (null == instance)
                    instance = new FileDoctors();
                return instance;
            }
        }

        private FileDoctors() {
            Read();
        }

        public void Read()
        {
            string json = File.ReadAllText(path);
            doctors = new JavaScriptSerializer().Deserialize<List<Doctor>>(json);
        }

        public void Write()
        {
            string json = new JavaScriptSerializer().Serialize(doctors);
            File.WriteAllText(path, json);
        }

        public List<Doctor> GetDoctors() {
            return doctors;
        }

        public Doctor GetDoctor(string doctorUsername) {
            for (int i = 0; i < doctors.Count; i++)
                if (doctorUsername == doctors[i].Username)
                    return doctors[i];
            return null;
        }
    }
}
