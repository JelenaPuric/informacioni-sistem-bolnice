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
        private ExaminationService examinationService = ExaminationService.Instance;
        private NotificationService notificationService = NotificationService.Instance;

        public void ScheduleExamination(Examination e) {
            examinationService.ScheduleExamination(e);
        }

        public bool MakeAppointment(int docIndex, DateTime date, string usernamePatient, string usernameDoctor, int roomId, string idExaminatin, ExaminationType typeExam)
        {
            return examinationService.MakeAppointment( docIndex,  date,  usernamePatient,  usernameDoctor,  roomId,  idExaminatin,  typeExam);
        }

        public void CancelExamination(String id)
        {
            examinationService.CancelExamination(id);
        }

        public void MoveExamination(string id, DateTime date, int roomIndex)
        {
            examinationService.MoveExamination(id, date, roomIndex);
        }

        public void EditExamination(string id, string doctor)
        {
            examinationService.EditExamination(id, doctor);
        }

        public List<Examination> GetExaminations(String patientName)
        {
            return examinationService.GetExaminations(patientName);
        }

        public void AddExaminationToDoctor(String doctorUsername, DateTime date)
        {
            examinationService.addExaminationToDoctor(doctorUsername, date);
        }

        public void RemoveExaminationFromDoctor(String doctorUsername, DateTime date)
        {
            examinationService.removeExaminationFromDoctor(doctorUsername, date);
        }

        public bool DoctorIsFree(String doctorUsername, DateTime date)
        {
            return examinationService.doctorIsFree(doctorUsername, date);
        }

        public void AddExaminationToRoom(int roomIndex, DateTime date)
        {
            examinationService.addExaminationToRoom(roomIndex, date);
        }

        public void RemoveExaminationFromRoom(String roomId, DateTime date)
        {
            examinationService.removeExaminationFromRoom(roomId, date);
        }

        public Tuple<bool, int> RoomIsFree(DateTime date)
        {
            return examinationService.roomIsFree(date);
        }

        public void UpdateDoctors()
        {
            examinationService.updateDoctors();
        }

        public void ScheduleNotification(Notification n)
        {
            notificationService.ScheduleNotification(n);
        }

        public List<Notification> GetNotifications(string id)
        {
            return notificationService.GetNotifications(id);
        }

        public void CancelNotification(String id)
        {
            notificationService.CancelNotification(id);
        }

        public void EditNotification(string id, string title, string descriptioin, string repeat, DateTime date)
        {
            notificationService.EditNotification(id, title, descriptioin, repeat, date);
        }
    }
}
