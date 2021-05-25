using HospitalApplication.Repository;
using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkWithFiles
{
   public class FilePatients : IFile
   {
        private static string path = "../../../Data/patients.json";
        private static List<Patient> patients;
        private static FilePatients instance;
        public static FilePatients Instance
        {
            get
            {
                if (null == instance)
                    instance = new FilePatients();
                return instance;
            }
        }

        private FilePatients()
        {
            Read();
        }

        public void Read()
        {
            string json = File.ReadAllText(path);
            patients = new JavaScriptSerializer().Deserialize<List<Patient>>(json);
        }

        public void Write()
        {
            string json = new JavaScriptSerializer().Serialize(patients);
            File.WriteAllText(path, json);
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public Patient GetPatient(string iDPatient)
        {
            Patient p = new Patient();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == iDPatient)
                    p = patients[i]; break;
            }
            return p;
        }
    }
}