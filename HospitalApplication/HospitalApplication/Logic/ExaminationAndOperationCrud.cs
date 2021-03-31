using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class ExaminationAndOperationCrud
   {
        public ExaminationAndOperationCrud()
        {
            examinations = sAd.LoadExaminations();
        }

        public void ScheduleExamunation(Model.Examination examination)
      {
            examinations.Add(examination);
            sAd.EnterExaminations(examinations);
        }
      
      public void CancelScheduledExamination(String iDexamination)
      {
            SerializationAndDeserilaizationOfExaminations sAd = SerializationAndDeserilaizationOfExaminations.GetInstance();


            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationId == iDexamination) examinations.RemoveAt(i);
            }
            sAd.EnterExaminations(examinations);
        }
      
      public List<Examination> ShowScheduledExaminations()
      {
            // TODO: implement
         List<Examination> e = new List<Examination>();
         return e;
      }

        

        public Boolean MoveScheduledExamination(int iDexamination)
      {
         // TODO: implement
         return false;
      }

        private SerializationAndDeserilaizationOfExaminations sAd = new SerializationAndDeserilaizationOfExaminations();
        private List<Examination> examinations;

        public List<Examination> Examinations
        {
            get { return examinations; }
            set { examinations = value; }
        }


        

    }
}