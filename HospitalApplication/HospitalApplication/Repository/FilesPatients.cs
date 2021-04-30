using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkWithFiles
{
   public class FilesPatients
   {

        public static string FilePatient = "../../../Data/patients.json";

        public static List<Patient> LoadPatients()
        {
            //ako ne postoji fajl (jos uvek nista nije sacuvano pri prvom pokretanju aplikacije vrati praznu listu)
            if (!File.Exists(FilePatient))
                return new List<Patient>();

            string json = File.ReadAllText(FilePatient);
            List<Patient> patients = new JavaScriptSerializer().Deserialize<List<Patient>>(json);

            return patients;
        }

        public static void EnterPatient(List<Patient> input)
        {
            string json = new JavaScriptSerializer().Serialize(input);
            File.WriteAllText(FilePatient, json);
        }

    }
}