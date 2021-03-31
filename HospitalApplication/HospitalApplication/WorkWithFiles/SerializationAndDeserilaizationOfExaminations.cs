using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace WorkWithFiles
{
   public class SerializationAndDeserilaizationOfExaminations
   {
        public SerializationAndDeserilaizationOfExaminations() { }
        private static SerializationAndDeserilaizationOfExaminations _instance;

        public static SerializationAndDeserilaizationOfExaminations GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SerializationAndDeserilaizationOfExaminations();
            }
            return _instance;
        }

        private string path = "examination1.txt";

        List<Examination> examinations = new List<Examination>();
        public List<Examination> GetExaminations()
        {
            return examinations;
        }



        public List<Examination> LoadExaminations()
      {
            List<Examination> examinations = new List<Examination>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] examination = line.Split(",");

                DateTime date1 = DateTime.Parse(examination[3]);
                DateTime date2 = DateTime.Parse(examination[4]);
                DateTime date3 = DateTime.Parse(examination[5]);
                string type = examination[8];
                ExaminationType typeOfExamination = (ExaminationType)Enum.Parse(typeof(ExaminationType), type);
                //  String specijalizacija = examination[6].ToString();
                Examination ex = new Examination(examination[0], examination[1], examination[2], date1, date2, date3, true, examination[7], typeOfExamination);
                examinations.Add(ex);
            }
            return examinations;
        }
      
      public void EnterExaminations(List<Examination> examinations)
      {
            System.IO.File.WriteAllText(path, string.Empty);
            for (int i = 0; i < examinations.Count; i++)
            {
                File.AppendAllText(path, examinations[i].PatientsId + "," + examinations[i].DoctorsId + "," + examinations[i].RoomId + "," + examinations[i].ExaminationStart + "," + examinations[i].ExaminationEnd + "," + examinations[i].ExaminationDate + "," + examinations[i].Specialization + "," + examinations[i].ExaminationId +  "," + examinations[i].TypeOfExamination + "\n"); 
            }
            
        }
   
   }
}


