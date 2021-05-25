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

        public bool IsDoctorFree(String doctorsUsername, DateTime date)
        {
            return appointmentService.IsDoctorFree(doctorsUsername, date);
        }

        public Tuple<bool, int> IsRoomFree(DateTime date)
        {
            return appointmentService.IsRoomFree(date);
        }
    }
}