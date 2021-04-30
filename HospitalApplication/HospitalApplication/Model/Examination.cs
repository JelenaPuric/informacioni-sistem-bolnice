using System;

namespace Model
{
    public class Examination
    {
        public Room room;
        public Patient[] pacient;
        private Boolean urgentOperation = false;
        public String ExaminationId { get; set; }
        public DateTime ExaminationStart { get; set; }
        public String PatientsId { get; set; }
        public String DoctorsId { get; set; }
        public String RoomId { get; set; }
        public ExaminationType ExaminationType { get; set; }

        public Examination() { }

        public Examination(string patient, string doctor, string room, DateTime start, string id)
        {
            PatientsId = patient;
            DoctorsId = doctor;
            RoomId = room;
            ExaminationStart = start;
            ExaminationId = id;
        }

        public Examination(string patient, string doctor, string room, DateTime start, string id, ExaminationType examType) {
            PatientsId = patient;
            DoctorsId = doctor;
            RoomId = room;
            ExaminationStart = start;
            ExaminationId = id;
            ExaminationType = examType;
        }
    }
}