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
        private ExaminationManagement examinationManagement = ExaminationManagement.Instance;
        private NotificationManagement ntf = NotificationManagement.Instance;

        public void ScheduleExamination(Examination e) {
            examinationManagement.ScheduleExamination(e);
        }


        public bool MakeAppointment(int docIndex, DateTime date, string usernamePatient, string usernameDoctor, int roomId, string idExaminatin, ExaminationType typeExam)
        {
            return examinationManagement.MakeAppointment( docIndex,  date,  usernamePatient,  usernameDoctor,  roomId,  idExaminatin,  typeExam);
        }


        public void CancelExamination(String id)
        {
            examinationManagement.CancelExamination(id);
        }

        public void MoveExamination(string id, DateTime date, int roomIndex)
        {
            examinationManagement.MoveExamination(id, date, roomIndex);
        }

        public void EditExamination(string id, string doctor)
        {
            examinationManagement.EditExamination(id, doctor);
        }

        public List<Examination> GetExaminations(String patientName)
        {
            return examinationManagement.GetExaminations(patientName);
        }

        public void AddExaminationToDoctor(String doctorUsername, DateTime date)
        {
            examinationManagement.addExaminationToDoctor(doctorUsername, date);
        }

        public void RemoveExaminationFromDoctor(String doctorUsername, DateTime date)
        {
            examinationManagement.removeExaminationFromDoctor(doctorUsername, date);
        }

        public bool DoctorIsFree(String doctorUsername, DateTime date)
        {
            return examinationManagement.doctorIsFree(doctorUsername, date);
        }

        public void AddExaminationToRoom(int roomIndex, DateTime date)
        {
            examinationManagement.addExaminationToRoom(roomIndex, date);
        }

        public void RemoveExaminationFromRoom(String roomId, DateTime date)
        {
            examinationManagement.removeExaminationFromRoom(roomId, date);
        }

        public Tuple<bool, int> RoomIsFree(DateTime date)
        {
            return examinationManagement.roomIsFree(date);
        }

        public void UpdateDoctors()
        {
            examinationManagement.updateDoctors();
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
