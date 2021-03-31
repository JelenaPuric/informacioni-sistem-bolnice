using System;
using System.Collections.Generic;
using System.Linq;
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

        

        public void MoveScheduledExamination(String id, DateTime date1, DateTime dateStart, DateTime dateEnd)
      {
            Examination ex = new Examination();
            for (int i = 0; i < examinations.Count(); i++)
            {
                if (examinations[i].ExaminationId == id)
                {
                    ex = examinations[i];
                    examinations.RemoveAt(i);
                }

            }
            ex.ExaminationDate = date1;
            ex.ExaminationStart = dateStart;
            ex.ExaminationEnd = dateEnd;
            examinations.Add(ex);
            sAd.EnterExaminations(examinations);
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