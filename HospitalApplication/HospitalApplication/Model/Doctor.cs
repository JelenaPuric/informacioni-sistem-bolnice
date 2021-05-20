using System;
using System.Collections.Generic;

namespace Model
{
   public class Doctor : Person
   {
        private String doctorId;
        private DoctorType doctorType;
        private List<DateTime> scheduled;

        public Doctor() { }

        public Doctor(string usernameee, string passworddd, List<DateTime> scheduledd, DoctorType doctorTypee, string idDoctor)
        {
            Username = usernameee;
            Password = passworddd;
            Scheduled = scheduledd;
            doctorType = doctorTypee;
            doctorId = idDoctor;
        }

        public string DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
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
   }
}