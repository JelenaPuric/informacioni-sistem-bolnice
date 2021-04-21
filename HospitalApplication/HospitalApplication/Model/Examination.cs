using System;

namespace Model
{
   public class Examination
   {
      public Room room;
      public Patient[] pacient;
   
      private DateTime examinationStart;
      private DateTime examinatonEnd;
      private ExaminationType typeOfExamination;
      private Boolean urgentOperation = false;
      private String examinationId;
      private String patientsId;
      private String doctorsId;
      private String roomId;

        private ExaminationType examinationType;

      public Examination() { }


        public Examination(string patient, string doctor, string room, DateTime start, string id)
        {
            patientsId = patient;
            doctorsId = doctor;
            roomId = room;
            examinationStart = start;
            examinationId = id;
        }


        public Examination(string patient, string doctor, string room, DateTime start, string id, ExaminationType examType) {
            patientsId = patient;
            doctorsId = doctor;
            roomId = room;
            examinationStart = start;
            examinationId = id;
            examinationType = examType;
        }




        public ExaminationType ExaminationType
        {
            get { return examinationType; }
            set { examinationType = value; }
        }

        public string PatientsId
        {
            get { return patientsId; }
            set { patientsId = value; }
        }
        public string DoctorsId
        {
            get { return doctorsId; }
            set { doctorsId = value; }
        }
        public string RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        public DateTime ExaminationStart
        {
            get { return examinationStart; }
            set { examinationStart = value; }
        }
        public string ExaminationId
        {
            get { return examinationId; }
            set { examinationId = value; }
        }
    }
}