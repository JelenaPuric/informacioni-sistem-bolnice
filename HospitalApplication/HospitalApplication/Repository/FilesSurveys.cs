using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HospitalApplication.Model;
using Nancy.Json;
using Newtonsoft.Json;

namespace HospitalApplication.Repository
{
    class FilesSurveys : IFile
    {
        public string path = "../../../Data/surveys.json";
        public List<Survey> surveys = new List<Survey>();
        private static FilesSurveys instance;
        public static FilesSurveys Instance
        {
            get
            {
                if (null == instance)
                    instance = new FilesSurveys();
                return instance;
            }
        }

        private FilesSurveys() {
            Read();
        }

        public void Read()
        {
            string jsonFIle = File.ReadAllText(path);
            surveys = JsonConvert.DeserializeObject<List<Survey>>(jsonFIle);
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
