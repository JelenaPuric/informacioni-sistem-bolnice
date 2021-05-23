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

        public void ScheduleAppointment(Appointment appointment) {
            appointmentService.ScheduleAppointment(appointment);
        }

        public void CancelAppointment(Appointment appointment)
        {
            appointmentService.CancelAppointment(appointment);
        }

        public void MoveAppointment(Appointment appointment, DateTime date)
        {
            appointmentService.MoveAppointment(appointment, date);
        }

        public void EditAppointment(Appointment appointment, string doctorsId   )
        {
            appointmentService.EditAppointment(appointment, doctorsId);
        }

        public void AddExaminationToDoctor(String doctorsUsername, DateTime date)
        {
            appointmentService.AddAppointmentToDoctor(doctorsUsername, date);
        }

        public void RemoveExaminationFromDoctor(String doctorsUsername, DateTime date)
        {
            appointmentService.RemoveAppointmentFromDoctor(doctorsUsername, date);
        }

        public bool IsDoctorFree(String doctorsUsername, DateTime date)
        {
            return appointmentService.IsDoctorFree(doctorsUsername, date);
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