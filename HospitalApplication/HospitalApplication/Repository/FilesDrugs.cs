using HospitalApplication.Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HospitalApplication.Repository
{
    class FilesDrugs
    {
        public static string FileDrugs = "../../../Data/drugs.json";

        public static List<Drugs> LoadDrugs()
        {
            //ako ne postoji fajl (jos uvek nista nije sacuvano pri prvom pokretanju aplikacije vrati praznu listu)
            if (!File.Exists(FileDrugs))
                return new List<Drugs>();

            string json = File.ReadAllText(FileDrugs);
            List<Drugs> drugs = new JavaScriptSerializer().Deserialize<List<Drugs>>(json);

            return drugs;
        }

        public static void EnterDrug(List<Drugs> input)
        {
            string json = new JavaScriptSerializer().Serialize(input);
            File.WriteAllText(FileDrugs, json);
        }

    }
}
