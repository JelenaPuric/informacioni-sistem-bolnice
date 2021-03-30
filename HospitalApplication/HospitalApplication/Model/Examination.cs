using System;

namespace Model
{
   public class Examination
   {
      public Room room;
      public Patient[] pacient;

      private DateTime examinationDate;
        private bool specialization;
        private DateTime examinationStart;
        private DateTime examinationEnd;
      private ExaminationType typeOfExamination;
      private Boolean urgentOperation = false;
      private String examinationId;
      private String patientsId;
      private String doctorsId;
      private String roomId;

      public Examination() { }

      public Examination(string patient, string doctor, string room, DateTime start, DateTime end, DateTime examDate, bool specialty , string id, ExaminationType typeExam) {
            patientsId = patient;
            doctorsId = doctor;
            roomId = room;
            examinationStart = start;
            examinationEnd = end;
            examinationDate = examDate;
            specialization = specialty;
            examinationId = id;
            typeOfExamination = typeExam;
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

        public DateTime ExaminationEnd
        {
            get { return examinationEnd; }
            set { examinationEnd = value; }
        }

        public bool Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }
        public string ExaminationId
        {
            get { return examinationId; }
            set { examinationId = value; }
        }

        public DateTime ExaminationDate
        { 
            get { return examinationDate; }
            set { examinationDate = value; }
        }
        public ExaminationType TypeOfExamination
        {
            get { return typeOfExamination; }
            set { typeOfExamination = value; }
        }
    }
}