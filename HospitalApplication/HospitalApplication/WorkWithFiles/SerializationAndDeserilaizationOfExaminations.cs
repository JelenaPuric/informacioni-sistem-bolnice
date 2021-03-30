using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace WorkWithFiles
{
   public class SerializationAndDeserilaizationOfExaminations
   {
        private SerializationAndDeserilaizationOfExaminations() { }
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


/*
 *  private string path = "examinations.txt";
        public List<Examination> LoadFromFile()
      {
            List<Examination> examinations = new List<Examination>();
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] examination = line.Split(",");
                //DateTime myDate = DateTime.ParseExact(pregled[3], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime myDate = DateTime.Parse(examination[3]);
                Examination pr = new Examination(examination[0], examination[1], examination[2], myDate, examination[4]);
                examinations.Add(pr);
            }
            return examinations;
        }
      
      public void WriteInFile(List<Examination> examinations)
      {
            System.IO.File.WriteAllText(path, string.Empty);
            for (int i = 0; i < examinations.Count; i++)
            {
                File.AppendAllText(path, examinations[i].PatientsId + "," + examinations[i].DoctorsId + "," + examinations[i].RoomId + "," + examinations[i].ExaminationStart + "," + examinations[i].ExaminationId + "\n"); ;
            }
        }
   
 * 
    public void LoadPatient(string path)
    {
        List<String> lines = File.ReadAllLines(path).ToList();
        foreach (var line in lines)
        {
            string[] entries = line.Split(',');
            DateTime myDate = DateTime.Parse(entries[4]);



            string typeAcc = entries[0];
            AccountType typeAccc = (AccountType)Enum.Parse(typeof(AccountType), typeAcc);


            string type = entries[8];
            TypeOfPerson typeOfPerson = (TypeOfPerson)Enum.Parse(typeof(TypeOfPerson), type);

            Patient p = new Patient(typeAccc, entries[1], entries[2], entries[3], myDate,
                entries[5], entries[6], entries[7], typeOfPerson, entries[9], entries[10]);

            patients.Add(p);
        }

    }

    public void WritePatient(string path)
    {
        System.IO.File.WriteAllText(path, string.Empty);

        for (int i = 0; i < patients.Count; i++)
        {
            File.AppendAllText(path, patients[i].TypeAcc + "," + patients[i].Name + "," + patients[i].LastName + "," + patients[i].Id + "," + patients[i].DateOfBirth + "," + patients[i].PhoneNumber + "," + patients[i].Email + "," + patients[i].PlaceOfResidance + "," + patients[i].TypeOfPerson + "," + patients[i].Username + "," + patients[i].Password + "\n"); ;
        }
    }

} */