using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class ExaminationManagement
   {
      public ExaminationManagement() {
          examinations = f.LoadFromFile();
      }

      public void ShowExaminations()
      {
         // TODO: implement
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
      
      public bool MoveExamination()
      {
         // TODO: implement
         return false;
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