using System;
using System.Collections.Generic;
using Model;

namespace Logic
{
   public class ExaminationAndOperationCrud
   {
      public Boolean ScheduleExamunation(Model.Examination examination)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean CancelScheduledExamination(int iDexamination)
      {
         // TODO: implement
         return false;
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
      
      public Boolean ScheduleOperation(Model.Examination operation)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean CancelSchedyledOperation(int iDexamination)
      {
         // TODO: implement
         return false;
      }
      
      public List<Examination> ShowScheduledOperations()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean MoveScheduledOperation(int iDexamination)
      {
         // TODO: implement
         return false;
      }
   
      private List<Examination> Examination;
   
   }
}