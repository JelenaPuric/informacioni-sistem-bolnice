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

        public bool MakeAppointment(int docIndex, DateTime date, string usernamePatient, string usernameDoctor, int roomId, string idExaminatin, ExaminationType typeExam, int postponeAppointment)
        {
            return examinationService.MakeAppointment( docIndex,  date,  usernamePatient,  usernameDoctor,  roomId,  idExaminatin,  typeExam, postponeAppointment);
        }

        public void CancelExamination(Examination examination)
        {
            examinationService.CancelExamination(examination);
        }

        public void MoveExamination(Examination examination, DateTime date, int roomIndex)
        {
            examinationService.MoveExamination(examination, date, roomIndex);
        }

        public void EditExamination(Examination examination, string doctor)
        {
            examinationService.EditExamination(examination, doctor);
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

        public void MoveAppointment(string id, DateTime date, int roomIndex)
        {
            examinationService.MoveAppointment(id, date, roomIndex);
        }
    }
}
