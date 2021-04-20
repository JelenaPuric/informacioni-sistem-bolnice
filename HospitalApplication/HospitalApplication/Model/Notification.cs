using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Model
{
    class Notification
    {
        private List<DateTime> dates;
        private string title;
        private string description;
        private string repeat;
        private string id;
        private string patientId;

        public Notification(List<DateTime> datess, string titlee, string descriptionn, string repeatt, string idd, string patientIdd)
        {
            dates = datess;
            title = titlee;
            description = descriptionn;
            repeat = repeatt;
            id = idd;
            patientId = patientIdd;
        }

        public Notification() { }

        public List<DateTime> Dates
        {
            get { return dates; }
            set { dates = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }
    }
}
