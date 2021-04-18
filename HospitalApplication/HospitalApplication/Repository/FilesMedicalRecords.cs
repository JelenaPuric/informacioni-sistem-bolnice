using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkWithFiles
{
   public class FilesMedicalRecords
   {

        public static string FileMedicalRecords = "../../../medicalRecords.json";

        public static List<MedicalRecord> LoadMedicalRecords()
        {
            //ako ne postoji fajl (jos uvek nista nije sacuvano pri prvom pokretanju aplikacije vrati praznu listu)
            if (!File.Exists(FileMedicalRecords))
                return new List<MedicalRecord>();

            string json = File.ReadAllText(FileMedicalRecords);
            List<MedicalRecord> medicalRecords = new JavaScriptSerializer().Deserialize<List<MedicalRecord>>(json);

            return medicalRecords;
        }

        public static void EnterMedicalRecord(List<MedicalRecord> input)
        {
            string json = new JavaScriptSerializer().Serialize(input);
            File.WriteAllText(FileMedicalRecords, json);
        }

    }
}