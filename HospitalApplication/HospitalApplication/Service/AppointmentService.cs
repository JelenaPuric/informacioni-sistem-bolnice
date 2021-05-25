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
        private FileDoctors fileDoctors = FileDoctors.Instance;
        private FilePatients filePatients = FilePatients.Instance;
        public List<Appointment> Appointments { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Patient> Patients { get; set; }
        private static AppointmentService instance;
        public static AppointmentService Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new AppointmentService();
                }
                return instance;
            }
        }

        public AppointmentService()
        {
            Appointments = fileAppointments.GetAppointments();
            Doctors = fileDoctors.GetDoctors();
            Rooms = FileRooms.LoadRoom();
            Patients = filePatients.GetPatients();
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            Tuple<bool, int> roomIsFree = roomService.IsRoomFree(appointment.ExaminationStart);
            appointment.RoomId = FileRooms.GetRoomId(roomIsFree.Item2);
            Patient patient = GetPatient(appointment.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)) {
                MessageBox.Show("You can not schedule examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(appointment.DoctorsId, appointment.ExaminationStart) == false || roomIsFree.Item1 == false){
                MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_SCHEDULE);
            doctorService.AddAppointmentToDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            roomService.AddAppointmentToRoom(roomIsFree.Item2, appointment.ExaminationStart);
            Appointments.Add(appointment);
            fileAppointments.Write();
        }

        public void CancelAppointment(Appointment appointment)
        {
            Patient patient = GetPatient(appointment.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not cancel examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_CANCEL);
            doctorService.RemoveAppointmentFromDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            roomService.RemoveAppointmentFromRoom(appointment.RoomId, appointment.ExaminationStart);
            Appointments.RemoveAt(fileAppointments.GetAppointmentsIndex(appointment));
            fileAppointments.Write();
        }

        public void EditAppointment(Appointment appointment, string doctorsId)
        {
            Patient patient = GetPatient(appointment.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not edit examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(doctorsId, appointment.ExaminationStart) == false){
                MessageBox.Show("There is no free term. Choose another time.");
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_EDIT);
            doctorService.RemoveAppointmentFromDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            doctorService.AddAppointmentToDoctor(doctorsId, appointment.ExaminationStart);
            appointment.DoctorsId = doctorsId;
            fileAppointments.Write();
        }

        public void MoveAppointment(Appointment appointment, DateTime newDate)
        {
            Tuple<bool, int> roomIsFree = roomService.IsRoomFree(appointment.ExaminationStart);
            Patient patient = GetPatient(appointment.PatientsId); 
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not move examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(appointment.DoctorsId, newDate) == false || roomIsFree.Item1 == false){
                MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_MOVE);
            doctorService.RemoveAppointmentFromDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            doctorService.AddAppointmentToDoctor(appointment.DoctorsId, newDate);
            roomService.RemoveAppointmentFromRoom(appointment.RoomId, appointment.ExaminationStart);
            roomService.AddAppointmentToRoom(roomIsFree.Item2, newDate);
            appointment.ExaminationStart = newDate;
            appointment.RoomId = Rooms[roomIsFree.Item2].RoomId.ToString();
            fileAppointments.Write();
        }

        public bool IsDoctorFree(String doctorUsername, DateTime date) 
        {
            for (int i = 0; i < Doctors.Count; i++)
                if (Doctors[i].Username == doctorUsername)
                    for (int j = 0; j < Doctors[i].Scheduled.Count; j++)
                        if (Doctors[i].Scheduled[j] == date)
                            return false;
            return true;
        }

        public Tuple<bool, int> IsRoomFree(DateTime date) 
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                bool roomIsFree = true;
                for (int j = 0; j < Rooms[i].Scheduled.Count; j++)
                    if (Rooms[i].Scheduled[j] == date)
                        roomIsFree = false;
                for (int j = 0; j < Rooms[i].Renovation.Count; j++)
                    for(int k=0; k< Rooms[i].Renovation[j].Days.Count; k++)
                        if (Rooms[i].Renovation[j].Days[k] == date)
                            roomIsFree = false;
                if (roomIsFree)
                    return new Tuple<bool, int>(true, i);
            }
            return new Tuple<bool, int>(false, -1);
        }

        private void SetPatientsPenalty(Patient patient, int earnedPenalty) {
            int currentPenalty = patient.Penalty.Item1 + earnedPenalty;
            DateTime dateOfLastActivity = patient.Penalty.Item2;
            bool isPenaltyGreaterThanAllowed = patient.Penalty.Item3;
            currentPenalty = Math.Max(0, currentPenalty - (int)(DateTime.Now - dateOfLastActivity).TotalDays * Constants.SUBSTRACT_PENALTY_EVERY_DAY);
            dateOfLastActivity = DateTime.Now;
            if (currentPenalty > Constants.MAX_ALLOWED_PENALTY) isPenaltyGreaterThanAllowed = true;
            patient.Penalty = new Tuple<int, DateTime, bool>(currentPenalty, dateOfLastActivity, isPenaltyGreaterThanAllowed);
            filePatients.Write();
        }

        private bool PenaltyIsGreaterThanAllowed(Patient patient)
        {
            return patient.Penalty.Item3; 
        }

        private Patient GetPatient(string patientsUsername) {
            for (int i = 0; i < Patients.Count; i++)
                if (Patients[i].Username == patientsUsername) return Patients[i];
            return null;
        }
    }
}