using HospitalApplication.Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HospitalApplication.Repository
{
    class ReportedDrugsFiles
    {
        public static string FileDrugs = "../../../Data/reportedDrugs.json";

        public static List<ReportedDrugs> LoadReports()
        {
            //ako ne postoji fajl (jos uvek nista nije sacuvano pri prvom pokretanju aplikacije vrati praznu listu)
            if (!File.Exists(FileDrugs))
                return new List<ReportedDrugs>();

            string json = File.ReadAllText(FileDrugs);
            List<ReportedDrugs> drugs = new JavaScriptSerializer().Deserialize<List<ReportedDrugs>>(json);

            return drugs;
        }

        public static void EnterReport(List<ReportedDrugs> input)
        {
            string json = new JavaScriptSerializer().Serialize(input);
            File.WriteAllText(FileDrugs, json);
        }

    }
}
