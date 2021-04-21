using System;
using System.Collections.Generic;

namespace Model
{
   public class Doctor : Person
   {
      public System.Collections.ArrayList examination;
        private List<DateTime> scheduled;

        // !!!!!!!!!!!!!!!!!!!!!!!!
        public List<DateTime> Scheduled
        {
            get { return scheduled; }
            set { scheduled = value; }
        }

        public Doctor() { }

        public Doctor(string usernameee, string passworddd, List<DateTime> scheduledd)
        {
            Username = usernameee;
            Password = passworddd;
            Scheduled = scheduledd;
        }

        public System.Collections.ArrayList GetExamination()
      {
         if (examination == null)
            examination = new System.Collections.ArrayList();
         return examination;
      }
      
      public void SetExamination(System.Collections.ArrayList newExamination)
      {
         RemoveAllExamination();
         foreach (Examination oExamination in newExamination)
            AddExamination(oExamination);
      }
      
      public void AddExamination(Examination newExamination)
      {
         if (newExamination == null)
            return;
         if (this.examination == null)
            this.examination = new System.Collections.ArrayList();
         if (!this.examination.Contains(newExamination))
            this.examination.Add(newExamination);
      }
      
      public void RemoveExamination(Examination oldExamination)
      {
         if (oldExamination == null)
            return;
         if (this.examination != null)
            if (this.examination.Contains(oldExamination))
               this.examination.Remove(oldExamination);
      }
      
      public void RemoveAllExamination()
      {
         if (examination != null)
            examination.Clear();
      }
      public System.Collections.ArrayList requestToTheManager;
      
      public System.Collections.ArrayList GetRequestToTheManager()
      {
         if (requestToTheManager == null)
            requestToTheManager = new System.Collections.ArrayList();
         return requestToTheManager;
      }
      
      public void SetRequestToTheManager(System.Collections.ArrayList newRequestToTheManager)
      {
         RemoveAllRequestToTheManager();
         foreach (RequestToTheManager oRequestToTheManager in newRequestToTheManager)
            AddRequestToTheManager(oRequestToTheManager);
      }
      
      public void AddRequestToTheManager(RequestToTheManager newRequestToTheManager)
      {
         if (newRequestToTheManager == null)
            return;
         if (this.requestToTheManager == null)
            this.requestToTheManager = new System.Collections.ArrayList();
         if (!this.requestToTheManager.Contains(newRequestToTheManager))
            this.requestToTheManager.Add(newRequestToTheManager);
      }
      
      public void RemoveRequestToTheManager(RequestToTheManager oldRequestToTheManager)
      {
         if (oldRequestToTheManager == null)
            return;
         if (this.requestToTheManager != null)
            if (this.requestToTheManager.Contains(oldRequestToTheManager))
               this.requestToTheManager.Remove(oldRequestToTheManager);
      }
      
      public void RemoveAllRequestToTheManager()
      {
         if (requestToTheManager != null)
            requestToTheManager.Clear();
      }
   
      private String DoctorId;
      private Boolean Specialization;
   
   }
}