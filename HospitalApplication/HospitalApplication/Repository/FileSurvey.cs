﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HospitalApplication.Model;
using Nancy.Json;
using Newtonsoft.Json;

namespace HospitalApplication.Repository
{
    class FileSurvey : IFile
    {
        private string path = "../../../Data/surveys.json";
        private List<Survey> surveys;
        private static FileSurvey instance;
        public static FileSurvey Instance
        {
            get
            {
                if (null == instance)
                    instance = new FileSurvey();
                return instance;
            }
        }

        private FileSurvey() {
            Read();
        }

        public void Read()
        {
            string json = File.ReadAllText(path);
            surveys = JsonConvert.DeserializeObject<List<Survey>>(json);
        }

        public void Write()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            StreamWriter streamWriter = new StreamWriter(path);
            JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
            jsonSerializer.Serialize(jsonWriter, surveys);
            jsonWriter.Close();
            streamWriter.Close();
        }

        public List<Survey> GetSurveys() {
            return surveys;
        }
    }
}