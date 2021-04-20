using HospitalApplication.Logic;
using HospitalApplication.Model;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Controller
{
    class PatientController
    {
        private ExaminationManagement m = ExaminationManagement.Instance;
        private NotificationManagement ntf = NotificationManagement.Instance;

        public void ScheduleExamination(Examination e) {
            m.ScheduleExamination(e);
        }

        public void CancelExamination(String id)
        {
            m.CancelExamination(id);
        }

        public void MoveExamination(string id, DateTime date)
        {
            m.MoveExamination(id, date);
        }

        public void EditExamination(string id, string doctor)
        {
            m.EditExamination(id, doctor);
        }

        public List<Examination> GetExaminations(String patientName)
        {
            return m.GetExaminations(patientName);
        }

        public void addExaminationToDoctor(String doctorUsername, DateTime date)
        {
            m.addExaminationToDoctor(doctorUsername, date);
        }

        public void removeExaminationFromDoctor(String doctorUsername, DateTime date)
        {
            m.removeExaminationFromDoctor(doctorUsername, date);
        }

        public bool doctorsExaminationExists(String doctorUsername, DateTime date)
        {
            return m.doctorsExaminationExists(doctorUsername, date);
        }

        public void updateDoctors()
        {
            m.updateDoctors();
        }

        public void ScheduleNotification(Notification n)
        {
            ntf.ScheduleNotification(n);
        }

        public List<Notification> GetNotifications(string id)
        {
            return ntf.GetNotifications(id);
        }

        public void CancelNotification(String id)
        {
            ntf.CancelNotification(id);
        }

        public void EditNotification(string id, string title, string descriptioin, string repeat, DateTime date)
        {
            ntf.EditNotification(id, title, descriptioin, repeat, date);
        }
    }
}
