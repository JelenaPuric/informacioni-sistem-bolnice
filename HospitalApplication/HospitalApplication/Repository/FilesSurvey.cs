using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HospitalApplication.Model;
using Nancy.Json;
using Newtonsoft.Json;

namespace HospitalApplication.Repository
{
    class FilesSurvey
    {
        public static string path = "../../../surveys.json";

        public List<Survey> ReadSurveys()
        {
            if (!File.Exists(path))
                return new List<Survey>();
            //string json = File.ReadAllText(path);
            //List<Survey> surveys = new JavaScriptSerializer().Deserialize<List<Survey>>(json);
            /*JsonSerializer jsonSerializer = new JsonSerializer();
            StreamReader sr = new StreamReader(path);
            JsonReader jsonReader = new JsonTextReader(sr);
            List<Survey> surveys = jsonSerializer.Deserialize(jsonReader) as List<Survey>;
            jsonReader.Close();
            sr.Close();*/

            //sa ovakvim jsonom radi deserijalizacija niza, na nacine iznad json nije mogao da ucita niz, nmp zasto
            //https://www.youtube.com/watch?v=ZqARpaB39TY&ab_channel=DimitriPatarroyo svaka cast ovom liku
            string jsonFIle = File.ReadAllText(path);
            List<Survey> surveys = JsonConvert.DeserializeObject<List<Survey>>(jsonFIle);
            return surveys;
        }

        public void WriteSurveys(List<Survey> input)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            StreamWriter sw = new StreamWriter(path);
            JsonWriter jsonWriter = new JsonTextWriter(sw);
            jsonSerializer.Serialize(jsonWriter, input);
            jsonWriter.Close();
            sw.Close();
            //string json = new JavaScriptSerializer().Serialize(input);
            //File.WriteAllText(path, json);
        }
    }
}
