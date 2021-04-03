using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class ExaminationManagement
   {
        private static ExaminationManagement instance;
        public static ExaminationManagement Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new ExaminationManagement();
                }
                return instance;
            }
        }

        public ExaminationManagement() {
          examinations = f.LoadFromFile();
      }
      
      public void ScheduleExamination(Examination e)
      {
            examinations.Add(e);
            f.WriteInFile(examinations);
      }
      
      public void CancelExamination(String id)
      {
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationId == id) examinations.RemoveAt(i);
            }
            f.WriteInFile(examinations);
        }

        public void Cancel(int index)
        {
            examinations.RemoveAt(index);
            f.WriteInFile(examinations);
        }

        public void Move(int index, DateTime date)
        {
            //prvo ga izbrisi, promeni datum pa vrati
            Examination e = examinations[index];
            examinations.RemoveAt(index);
            e.ExaminationStart = date;
            examinations.Add(e);
            f.WriteInFile(examinations);
        }

        public void MoveExamination(string id, DateTime date)
        {
            //prvo ga izbrisi, promeni datum pa vrati
            Examination e = new Examination();
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationId == id)
                {
                    e = examinations[i];
                    examinations.RemoveAt(i);
                }
            }
            e.ExaminationStart = date;
            examinations.Add(e);
            f.WriteInFile(examinations);
        }

        public List<Examination> GetExaminations(String patientName) {
            List<Examination> e = new List<Examination>();
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].PatientsId == patientName)
                {
                    e.Add(examinations[i]);
                }
            }
            return e;
        }

        private FilesExamination f = new FilesExamination();
      private List<Examination> examinations;

      public List<Examination> Examinations
        {
            get { return examinations; }
            set { examinations = value; }
      }
   }
}