using System;
using System.Diagnostics.CodeAnalysis;

namespace Model
{
    public class Appointment : IComparable<Appointment>
    {
        public Room room;
        public Patient[] pacient;
        public String ExaminationId { get; set; }
        public DateTime ExaminationStart { get; set; }
        public String PatientsId { get; set; }
        public String DoctorsId { get; set; }
        public String RoomId { get; set; }

        public int PostponeAppointment { get; set; }

        public ExaminationType AppointmentType { get; set; }

        public Appointment() { }

        public Appointment(string patientsId, string doctorsId, string roomId, DateTime start, string examinationId, ExaminationType appointmentType, int postponeAppointment) {
            PatientsId = patientsId;
            DoctorsId = doctorsId;
            RoomId = roomId;
            ExaminationStart = start;
            ExaminationId = examinationId;
            AppointmentType = appointmentType;
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