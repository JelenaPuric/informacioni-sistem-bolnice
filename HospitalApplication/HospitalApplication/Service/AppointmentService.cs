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
        private FileAppointments filesAppointment = FileAppointments.Instance;
        private DoctorService doctorService = new DoctorService();
        private RoomService roomService = new RoomService();
        private FileDoctors fileDoctors = FileDoctors.Instance;
        public List<Appointment> Examinations { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Patient> Patients { get; set; }
        public int RoomIndx { get; set; }
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
            Examinations = filesAppointment.GetAppointments();
            Doctors = fileDoctors.GetDoctors();
            Rooms = FileRooms.LoadRoom();
            Patients = FilePatients.LoadPatients();
        }

        public void ScheduleExamination(Appointment appointment)
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
            doctorService.AddExaminationToDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            roomService.AddExaminationToRoom(roomIsFree.Item2, appointment.ExaminationStart);
            Examinations.Add(appointment);
            filesAppointment.Write();
        }

        public void CancelExamination(Appointment examination)
        {
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not cancel examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_CANCEL);
            doctorService.RemoveExaminationFromDoctor(examination.DoctorsId, examination.ExaminationStart);
            roomService.RemoveExaminationFromRoom(examination.RoomId, examination.ExaminationStart);
            Examinations.RemoveAt(filesAppointment.GetExaminationsIndex(examination));
            filesAppointment.Write();
        }

        public void EditExamination(Appointment examination, string newDoctorsId)
        {
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not edit examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(newDoctorsId, examination.ExaminationStart) == false){
                MessageBox.Show("There is no free term. Choose another time.");
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_EDIT);
            doctorService.RemoveExaminationFromDoctor(examination.DoctorsId, examination.ExaminationStart);
            doctorService.AddExaminationToDoctor(newDoctorsId, examination.ExaminationStart);
            examination.DoctorsId = newDoctorsId;
            filesAppointment.Write();
        }

        public void MoveExamination(Appointment examination, DateTime newDate)
        {
            Tuple<bool, int> roomIsFree = roomService.IsRoomFree(examination.ExaminationStart);
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)){
                MessageBox.Show("You can not move examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(examination.DoctorsId, newDate) == false || roomIsFree.Item1 == false){
                MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_MOVE);
            doctorService.RemoveExaminationFromDoctor(examination.DoctorsId, examination.ExaminationStart);
            doctorService.AddExaminationToDoctor(examination.DoctorsId, newDate);
            roomService.RemoveExaminationFromRoom(examination.RoomId, examination.ExaminationStart);
            roomService.AddExaminationToRoom(roomIsFree.Item2, newDate);
            examination.ExaminationStart = newDate;
            examination.RoomId = Rooms[roomIsFree.Item2].RoomId.ToString();
            filesAppointment.Write();
        }

        public bool MakeEmergencyAppointment(int docIndex, DateTime date, string usernamePatient, string usernameDoctor, 
                                             int roomId, string idExaminatin, ExaminationType typeExam, string postponeAppointment)
        {
            bool isFree = DoctorIsFree(docIndex, date);



            return false;
        }

        public bool MakeAppointment(int docIndex, DateTime date, string usernamePatient, string usernameDoctor, int roomId, string idExaminatin, ExaminationType typeExam, int postponeAppointment)
        {

            bool isFree = DoctorIsFree(docIndex, date);

            if ( isFree == false)
            {
                return false;
            }
            else
            {
              bool roomIsFree = RoomIsFree(date);

                if( roomIsFree == false)
                {
                    return false;
                }
                else
                {
                    roomId = RoomIndx;
                    Doctors[docIndex].Scheduled.Add(date);
                    fileDoctors.Write();

                    if (Rooms[roomId].Scheduled == null)
                    {
                        Rooms[roomId].Scheduled = new List<DateTime>();
                    }

                    Rooms[roomId].Scheduled.Add(date);
                    FileRooms.EnterRoom(Rooms);

                    //Napraviti jos jedan parametar za odlaganje termina
                    Appointment examination = new Appointment(usernamePatient, usernameDoctor, Rooms[roomId].RoomId.ToString(), date, idExaminatin, typeExam, postponeAppointment);
                    ScheduleExamination(examination);

                    return true;
                }

            }

        }

        public bool DoctorIsFree(int docIndex, DateTime date)
        {
            List<Doctor> listDoctor = fileDoctors.GetDoctors();
            for (int j = 0; j < listDoctor[docIndex].Scheduled.Count; j++)
            {
                if (listDoctor[docIndex].Scheduled[j] == date)
                {
                    return false;
                }
            }
            return true;
        }

        public bool RoomIsFree(DateTime d)
        {
            bool roomIsFree = false;

            for (int i = 0; i < Rooms.Count; i++)
            {
                
                //ako je null znaci da je slobodna i izadji iz petlje
                if (Rooms[i].Scheduled == null)
                {
                    roomIsFree = true;
                    RoomIndx = i;
                    break;
                }

                bool ok = true;
                for (int j = 0; j < Rooms[i].Scheduled.Count; j++)
                {
                    if (Rooms[i].Scheduled[j] == d)
                    {
                        ok = false;
                    }
                }
                if (ok == true)
                {
                    roomIsFree = true;
                    RoomIndx = i;
                    break;
                }
            }
            return roomIsFree;
        }

        public void MoveAppointment(string id, DateTime date, int roomIndex)
        {
            Appointment e = new Appointment();
            for (int i = 0; i < Examinations.Count; i++)
            {
                if (Examinations[i].ExaminationId == id)
                {
                    e = Examinations[i];
                    Examinations.RemoveAt(i);
                }
            }
            e.ExaminationStart = date;
            e.RoomId = Rooms[roomIndex].RoomId.ToString();
            Examinations.Add(e);
            filesAppointment.Write();
        }

        public List<Appointment> GetAppointments(String patientName) 
        {
            List<Appointment> appointments = new List<Appointment>();
            for (int i = 0; i < Examinations.Count; i++)
                if (Examinations[i].PatientsId == patientName && Examinations[i].ExaminationStart >= DateTime.Now)
                    appointments.Add(Examinations[i]);
            return appointments;
        }

        public void AddAppointmentToDoctor(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                if (Doctors[i].Username == doctorUsername)
                {
                    Doctors[i].Scheduled.Add(date);
                    fileDoctors.Write();
                    break;
                }
            }
        }

        public void RemoveAppointmentFromDoctor(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                if (Doctors[i].Username == doctorUsername)
                {
                    for (int j = 0; j < Doctors[i].Scheduled.Count; j++)
                    {
                        if (Doctors[i].Scheduled[j] == date)
                        {
                            Doctors[i].Scheduled.RemoveAt(j);
                            break;
                        }
                    }
                    fileDoctors.Write();
                    break;
                }
            }
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

        public void RemoveAppointmentFromRoom(String roomId, DateTime date)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].RoomId.ToString() == roomId)
                {
                    for (int j = 0; j < Rooms[i].Scheduled.Count; j++)
                    {
                        if (Rooms[i].Scheduled[j] == date)
                        {
                            Rooms[i].Scheduled.RemoveAt(j);
                            FileRooms.EnterRoom(Rooms);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public void AddAppointmentToRoom(int roomIndex, DateTime date)
        {
            Rooms[roomIndex].Scheduled.Add(date);
            FileRooms.EnterRoom(Rooms);
        }

        private void SetPatientsPenalty(Patient patient, int earnedPenalty) {
            int currentPenalty = patient.Penalty.Item1 + earnedPenalty;
            DateTime dateOfLastActivity = patient.Penalty.Item2;
            bool isPenaltyGreaterThanAllowed = patient.Penalty.Item3;
            currentPenalty = Math.Max(0, currentPenalty - (int)(DateTime.Now - dateOfLastActivity).TotalDays * Constants.SUBSTRACT_PENALTY_EVERY_DAY);
            dateOfLastActivity = DateTime.Now;
            if (currentPenalty > Constants.MAX_ALLOWED_PENALTY) isPenaltyGreaterThanAllowed = true;
            patient.Penalty = new Tuple<int, DateTime, bool>(currentPenalty, dateOfLastActivity, isPenaltyGreaterThanAllowed);
            FilePatients.EnterPatient(Patients);
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

        public void UpdateDoctors()
        {
            Doctors = fileDoctors.GetDoctors();
        }
    }
}