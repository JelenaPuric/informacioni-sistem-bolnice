﻿using HospitalApplication.Model;
using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HospitalApplication.Repository
{
    class FileAnamnesis : IFile
    {
        private static string path = "../../../Data/anamnesis.json";
        public List<Anamnesis> anamnesis;
        private static FileAnamnesis instance;
        public static FileAnamnesis Instance
        {
            get
            {
                if (null == instance)
                    instance = new FileAnamnesis();
                return instance;
            }
        }

        private FileAnamnesis()
        {
            Read();
        }

        public void Read()
        {
            string json = File.ReadAllText(path);
            anamnesis = new JavaScriptSerializer().Deserialize<List<Anamnesis>>(json);
        }

        public void Write()
        {
            string json = new JavaScriptSerializer().Serialize(anamnesis);
            File.WriteAllText(path, json);
        }

        public List<Anamnesis> GetAnamnesis(string patientsId)
        {
            List<Anamnesis> patientAnamnesis = new List<Anamnesis>();
            for (int i = 0; i < anamnesis.Count; i++)
                if (anamnesis[i].PatientsId == patientsId) patientAnamnesis.Add(anamnesis[i]);
            return patientAnamnesis;
        }
    }
}