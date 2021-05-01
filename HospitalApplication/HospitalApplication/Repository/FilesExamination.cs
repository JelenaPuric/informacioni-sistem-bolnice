using System;
using System.Collections.Generic;
using System.IO;
using Model;

namespace WorkWithFiles
{
   public class FilesExamination
   {
        private string path = "examinations.txt";
        public List<Examination> LoadFromFile()
      {
            List<Examination> examinations = new List<Examination>();
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] examination = line.Split(",");
                //DateTime myDate = DateTime.ParseExact(pregled[3], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                DateTime myDate = DateTime.Parse(examination[3]);

                ExaminationType examinationType = (ExaminationType)Enum.Parse(typeof(ExaminationType), examination[5]);

                Examination pr = new Examination(examination[0], examination[1], examination[2], myDate, examination[4], examinationType, examination[6]);
                examinations.Add(pr);
            }
            return examinations;
        }
      
      public void WriteInFile(List<Examination> examinations)
      {
            System.IO.File.WriteAllText(path, string.Empty);
            for (int i = 0; i < examinations.Count; i++)
            {
                File.AppendAllText(path, examinations[i].PatientsId + "," + examinations[i].DoctorsId + "," + examinations[i].RoomId + "," 
                    + examinations[i].ExaminationStart + "," + examinations[i].ExaminationId + ","
                    + examinations[i].ExaminationType + "," + examinations[i].PostponeAppointment + "\n"); ;
            }
        }
   
   }
}