using System;
using System.Collections.Generic;

namespace Model
{
   public class Doctor : Person
   {
      public System.Collections.ArrayList examination;
        private List<DateTime> scheduled;
        private DoctorType doctorType;


        public Doctor() { }

        public Doctor(string usernameee, string passworddd, List<DateTime> scheduledd, DoctorType doctorTypee)
        {
            Username = usernameee;
            Password = passworddd;
            Scheduled = scheduledd;
            doctorType = doctorTypee;
        }
        public DoctorType DoctorType
        {
            get { return doctorType; }
            set { doctorType = value; }
        }

        public List<DateTime> Scheduled
        {
            get { return scheduled; }
            set { scheduled = value; }
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
      

      
      public void RemoveAllRequestToTheManager()
      {
         if (requestToTheManager != null)
            requestToTheManager.Clear();
      }
   
      private String DoctorId;
      private Boolean Specialization;
   
   }
}