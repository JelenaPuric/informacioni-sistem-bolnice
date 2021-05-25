using System;
using System.Collections.Generic;
using System.Windows;
using HospitalApplication.Model;
using HospitalApplication.Service;
using HospitalApplication.WorkWithFiles;
using Model;
using WorkWithFiles;

namespace Logic
{
    public class AppointmentService
    {
        private FileAppointments fileAppointments = FileAppointments.Instance;
        private DoctorService doctorService = new DoctorService();
        private RoomService roomService = new RoomService();
        private FilePatients filePatients = FilePatients.Instance;
        public List<Appointment> appointments;

        public AppointmentService()
        {
            appointments = fileAppointments.GetAppointments();
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            Tuple<bool, int> roomIsFree = roomService.IsRoomFree(appointment.ExaminationStart);
            appointment.RoomId = FileRooms.GetRoomId(roomIsFree.Item2);
            Patient patient = filePatients.GetPatientByUsername(appointment.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)) {
                MessageBox.Show("You can not schedule examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(appointment.DoctorsId, appointment.ExaminationStart) == false || roomIsFree.Item1 == false){
                MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }
            filePatients.SetPatientsPenalty(patient, Constants.PENALTY_SCHEDULE);
            doctorService.AddAppointmentToDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            roomService.AddAppointmentToRoom(roomIsFree.Item2, appointment.ExaminationStart);
            appointments.Add(appointment);
            fileAppointments.Write();
        }

        public void CancelAppointment(Appointment appointment)
        {
            Patient patient = filePatients.GetPatientByUsername(appointment.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not cancel examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            filePatients.SetPatientsPenalty(patient, Constants.PENALTY_CANCEL);
            doctorService.RemoveAppointmentFromDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            roomService.RemoveAppointmentFromRoom(appointment.RoomId, appointment.ExaminationStart);
            appointments.RemoveAt(fileAppointments.GetAppointmentsIndex(appointment));
            fileAppointments.Write();
        }

        public void EditAppointment(Appointment appointment, string doctorsId)
        {
            Patient patient = filePatients.GetPatientByUsername(appointment.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not edit examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(doctorsId, appointment.ExaminationStart) == false){
                MessageBox.Show("There is no free term. Choose another time.");
                return;
            }
            filePatients.SetPatientsPenalty(patient, Constants.PENALTY_EDIT);
            doctorService.RemoveAppointmentFromDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            doctorService.AddAppointmentToDoctor(doctorsId, appointment.ExaminationStart);
            appointment.DoctorsId = doctorsId;
            fileAppointments.Write();
        }

        public void MoveAppointment(Appointment appointment, DateTime newDate)
        {
            Tuple<bool, int> roomIsFree = roomService.IsRoomFree(appointment.ExaminationStart);
            Patient patient = filePatients.GetPatientByUsername(appointment.PatientsId); 
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not move examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(appointment.DoctorsId, newDate) == false || roomIsFree.Item1 == false){
                MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }
            filePatients.SetPatientsPenalty(patient, Constants.PENALTY_MOVE);
            doctorService.RemoveAppointmentFromDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            doctorService.AddAppointmentToDoctor(appointment.DoctorsId, newDate);
            roomService.RemoveAppointmentFromRoom(appointment.RoomId, appointment.ExaminationStart);
            roomService.AddAppointmentToRoom(roomIsFree.Item2, newDate);
            appointment.ExaminationStart = newDate;
            appointment.RoomId = FileRooms.GetRoomId(roomIsFree.Item2);
            fileAppointments.Write();
        }

        private bool PenaltyIsGreaterThanAllowed(Patient patient)
        {
            return patient.Penalty.Item3; 
        }
    }
}