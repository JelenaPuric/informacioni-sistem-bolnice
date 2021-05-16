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
        private ExaminationService examinationService = ExaminationService.Instance;

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

        public void MoveAppointment(string id, DateTime date, int roomIndex)
        {
            examinationService.MoveAppointment(id, date, roomIndex);
        }
    }
}
