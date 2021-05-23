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
        private AppointmentService appointmentService = AppointmentService.Instance;

        public void ScheduleAppointment(Appointment e) {
            appointmentService.ScheduleAppointment(e);
        }

        public void CancelAppointment(Appointment examination)
        {
            appointmentService.CancelAppointment(examination);
        }

        public void MoveAppointment(Appointment examination, DateTime date)
        {
            appointmentService.MoveAppointment(examination, date);
        }

        public void EditAppointment(Appointment examination, string doctor)
        {
            appointmentService.EditAppointment(examination, doctor);
        }

        public void AddExaminationToDoctor(String doctorUsername, DateTime date)
        {
            appointmentService.AddAppointmentToDoctor(doctorUsername, date);
        }

        public void RemoveExaminationFromDoctor(String doctorUsername, DateTime date)
        {
            appointmentService.RemoveAppointmentFromDoctor(doctorUsername, date);
        }

        public bool IsDoctorFree(String doctorUsername, DateTime date)
        {
            return appointmentService.IsDoctorFree(doctorUsername, date);
        }

        public void AddExaminationToRoom(int roomIndex, DateTime date)
        {
            appointmentService.AddAppointmentToRoom(roomIndex, date);
        }

        public void RemoveExaminationFromRoom(String roomId, DateTime date)
        {
            appointmentService.RemoveAppointmentFromRoom(roomId, date);
        }

        public Tuple<bool, int> IsRoomFree(DateTime date)
        {
            return appointmentService.IsRoomFree(date);
        }

        public void MoveAppointment(string id, DateTime date, int roomIndex)
        {
            appointmentService.MoveAppointment(id, date, roomIndex);
        }
    }
}