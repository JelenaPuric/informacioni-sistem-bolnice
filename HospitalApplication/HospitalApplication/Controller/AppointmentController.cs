using HospitalApplication.Logic;
using HospitalApplication.Model;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Controller
{
    class AppointmentController
    {
        private AppointmentService examinationService = AppointmentService.Instance;

        public void ScheduleExamination(Appointment e) {
            examinationService.ScheduleExamination(e);
        }

        public bool MakeAppointment(int docIndex, DateTime date, string usernamePatient, string usernameDoctor, int roomId, string idExaminatin, ExaminationType typeExam, int postponeAppointment)
        {
            return examinationService.MakeAppointment( docIndex,  date,  usernamePatient,  usernameDoctor,  roomId,  idExaminatin,  typeExam, postponeAppointment);
        }

        public void CancelExamination(Appointment examination)
        {
            examinationService.CancelExamination(examination);
        }

        public void MoveExamination(Appointment examination, DateTime date)
        {
            examinationService.MoveExamination(examination, date);
        }

        public void EditExamination(Appointment examination, string doctor)
        {
            examinationService.EditExamination(examination, doctor);
        }

        public List<Appointment> GetExaminations(String patientName)
        {
            return examinationService.GetAppointments(patientName);
        }

        public void AddExaminationToDoctor(String doctorUsername, DateTime date)
        {
            examinationService.AddAppointmentToDoctor(doctorUsername, date);
        }

        public void RemoveExaminationFromDoctor(String doctorUsername, DateTime date)
        {
            examinationService.RemoveAppointmentFromDoctor(doctorUsername, date);
        }

        public bool IsDoctorFree(String doctorUsername, DateTime date)
        {
            return examinationService.IsDoctorFree(doctorUsername, date);
        }

        public void AddExaminationToRoom(int roomIndex, DateTime date)
        {
            examinationService.AddAppointmentToRoom(roomIndex, date);
        }

        public void RemoveExaminationFromRoom(String roomId, DateTime date)
        {
            examinationService.RemoveAppointmentFromRoom(roomId, date);
        }

        public Tuple<bool, int> IsRoomFree(DateTime date)
        {
            return examinationService.IsRoomFree(date);
        }

        public void UpdateDoctors()
        {
            examinationService.UpdateDoctors();
        }

        public void MoveAppointment(string id, DateTime date, int roomIndex)
        {
            examinationService.MoveAppointment(id, date, roomIndex);
        }
    }
}