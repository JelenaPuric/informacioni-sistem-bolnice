using System;
using System.Diagnostics.CodeAnalysis;

namespace Model
{
    public class Appointment : IComparable<Appointment>
    {
        public Room room;
        public Patient[] pacient;
        private Boolean urgentOperation = false;
        public String ExaminationId { get; set; }
        public DateTime ExaminationStart { get; set; }
        public String PatientsId { get; set; }
        public String DoctorsId { get; set; }
        public String RoomId { get; set; }

        public int PostponeAppointment { get; set; }

        public ExaminationType ExaminationType { get; set; }

        public Appointment() { }
     public Appointment(string patient, string doctor, string room, DateTime start, string id)
        {
            PatientsId = patient;
            DoctorsId = doctor;
            RoomId = room;
            ExaminationStart = start;
            ExaminationId = id;
        }
   

        public Appointment(string patient, string doctor, string room, DateTime start, string id, ExaminationType examType, int postponeAppointment) {
            PatientsId = patient;
            DoctorsId = doctor;
            RoomId = room;
            ExaminationStart = start;
            ExaminationId = id;
            ExaminationType = examType;
            PostponeAppointment = postponeAppointment;
        }

        
        public int CompareTo([AllowNull] Appointment other)
        {
            if (this.PostponeAppointment > other.PostponeAppointment)
                return 1;
            else if (this.PostponeAppointment < other.PostponeAppointment)
                return -1;
            else
                return 0;
        }
        
    }
}