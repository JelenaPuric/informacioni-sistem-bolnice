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
    public class ExaminationService
    {
        private FilesAppointments filesExamination = new FilesAppointments();
        private DoctorService doctorService = new DoctorService();
        private RoomService roomService = new RoomService();
        public List<Appointment> Examinations { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Patient> Patients { get; set; }
        public int RoomIndx { get; set; }
        private static ExaminationService instance;
        public static ExaminationService Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new ExaminationService();
                }
                return instance;
            }
        }

        public ExaminationService()
        {
            Examinations = filesExamination.LoadFromFile();
            Doctors = FilesDoctors.GetDoctors();
            Rooms = FilesRooms.LoadRoom();
            Patients = FilesPatients.LoadPatients();
        }

        public void ScheduleExamination(Appointment appointment)
        {
            Tuple<bool, int> roomIsFree = roomService.IsRoomFree(appointment.ExaminationStart);
            appointment.RoomId = FilesRooms.GetRoomId(roomIsFree.Item2);
            Patient patient = GetPatient(appointment.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient)) {
                MessageBox.Show("You can not schedule examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(appointment.DoctorsId, appointment.ExaminationStart) == false || roomIsFree.Item1 == false) {
                MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
            }
            SetPatientsPenalty(patient, Constants.PENALTY_SCHEDULE);
            doctorService.AddExaminationToDoctor(appointment.DoctorsId, appointment.ExaminationStart);
            roomService.AddExaminationToRoom(roomIsFree.Item2, appointment.ExaminationStart);
            Examinations.Add(appointment);
            filesExamination.WriteInFile(Examinations);
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
            Examinations.RemoveAt(GetExaminationsIndex(examination));
            filesExamination.WriteInFile(Examinations);
        }

        public void EditExamination(Appointment examination, string newDoctorsId)
        {
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient))
            {
                MessageBox.Show("You can not edit examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(newDoctorsId, examination.ExaminationStart) == false){
                MessageBox.Show("There is no free term. Choose another time.");
            }
            SetPatientsPenalty(patient, Constants.PENALTY_EDIT);
            doctorService.RemoveExaminationFromDoctor(examination.DoctorsId, examination.ExaminationStart);
            doctorService.AddExaminationToDoctor(newDoctorsId, examination.ExaminationStart);
            examination.DoctorsId = newDoctorsId;
            filesExamination.WriteInFile(Examinations);
        }

        public void MoveExamination(Appointment examination, DateTime newDate)
        {
            Tuple<bool, int> roomIsFree = roomService.IsRoomFree(examination.ExaminationStart);
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient))
            {
                MessageBox.Show("You can not move examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            if (doctorService.IsDoctorFree(examination.DoctorsId, newDate) == false || roomIsFree.Item1 == false){
                MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
            }
            SetPatientsPenalty(patient, Constants.PENALTY_MOVE);
            doctorService.RemoveExaminationFromDoctor(examination.DoctorsId, examination.ExaminationStart);
            doctorService.AddExaminationToDoctor(examination.DoctorsId, newDate);
            roomService.RemoveExaminationFromRoom(examination.RoomId, examination.ExaminationStart);
            roomService.AddExaminationToRoom(roomIsFree.Item2, newDate);
            examination.ExaminationStart = newDate;
            examination.RoomId = Rooms[roomIsFree.Item2].RoomId.ToString();
            filesExamination.WriteInFile(Examinations);
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
                    FilesDoctors.Write();

                    if (Rooms[roomId].Scheduled == null)
                    {
                        Rooms[roomId].Scheduled = new List<DateTime>();
                    }

                    Rooms[roomId].Scheduled.Add(date);
                    FilesRooms.EnterRoom(Rooms);

                    //Napraviti jos jedan parametar za odlaganje termina
                    Appointment examination = new Appointment(usernamePatient, usernameDoctor, Rooms[roomId].RoomId.ToString(), date, idExaminatin, typeExam, postponeAppointment);
                    ScheduleExamination(examination);

                    return true;
                }

            }

        }

        public bool DoctorIsFree(int docIndex, DateTime date)
        {
            List<Doctor> listDoctor = FilesDoctors.GetDoctors();
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
            filesExamination.WriteInFile(Examinations);
        }



        public List<Appointment> GetExaminations(String patientName)
        {
            List<Appointment> e = new List<Appointment>();
            for (int i = 0; i < Examinations.Count; i++)
            {
                //dodaje preglede za pacijenta patientName i to samo one koji nisu prosli
                if (Examinations[i].PatientsId == patientName && Examinations[i].ExaminationStart >= DateTime.Now)
                {
                    e.Add(Examinations[i]);
                }
            }
            return e;
        }

        public void addExaminationToDoctor(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                if (Doctors[i].Username == doctorUsername)
                {
                    Doctors[i].Scheduled.Add(date);
                    FilesDoctors.Write();
                    break;
                }
            }
        }

        public void removeExaminationFromDoctor(String doctorUsername, DateTime date)
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
                    FilesDoctors.Write();
                    break;
                }
            }
        }

        public bool doctorIsFree(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                if (Doctors[i].Username == doctorUsername)
                {
                    for (int j = 0; j < Doctors[i].Scheduled.Count; j++)
                    {
                        if (Doctors[i].Scheduled[j] == date)
                            return false;
                    }
                }
            }
            return true;
        }

        public Tuple<bool, int> roomIsFree(DateTime date)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                bool roomIsFree = true;
                for (int j = 0; j < Rooms[i].Scheduled.Count; j++)
                {
                    if (Rooms[i].Scheduled[j] == date)
                        roomIsFree = false;
                }
                if (roomIsFree)
                    return new Tuple<bool, int>(true, i);
            }
            return new Tuple<bool, int>(false, -1);
        }

        public void removeExaminationFromRoom(String roomId, DateTime date)
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
                            FilesRooms.EnterRoom(Rooms);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public void addExaminationToRoom(int roomIndex, DateTime date)
        {
            Rooms[roomIndex].Scheduled.Add(date);
            FilesRooms.EnterRoom(Rooms);
        }

        private void SetPatientsPenalty(Patient patient, int earnedPenalty) {
            int currentPenalty = patient.Penalty.Item1 + earnedPenalty;
            DateTime dateOfLastActivity = patient.Penalty.Item2;
            bool isPenaltyGreaterThanAllowed = patient.Penalty.Item3;
            patient.Penalty = GetPenaltyItemsNewValue(currentPenalty, dateOfLastActivity, isPenaltyGreaterThanAllowed);
            FilesPatients.EnterPatient(Patients);
        }

        private Tuple<int, DateTime, bool> GetPenaltyItemsNewValue(int currentPenalty, DateTime dateOfLastActivity, bool isPenaltyGreaterThanAllowed)
        {
            currentPenalty = Math.Max(0, currentPenalty - (int)(DateTime.Now - dateOfLastActivity).TotalDays * Constants.SUBSTRACT_PENALTY_EVERY_DAY);
            dateOfLastActivity = DateTime.Now;
            if (currentPenalty > Constants.MAX_ALLOWED_PENALTY) isPenaltyGreaterThanAllowed = true;
            return new Tuple<int, DateTime, bool>(currentPenalty, dateOfLastActivity, isPenaltyGreaterThanAllowed);
        }

        private bool PenaltyIsGreaterThanAllowed(Patient patient)
        {
            return patient.Penalty.Item3;
        }

        private int GetExaminationsIndex(Appointment examination) {
            for (int i = 0; i < Examinations.Count; i++)
                if (Examinations[i] == examination) return i;
            return 0;
        }

        private Patient GetPatient(string patientsUsername) {
            for (int i = 0; i < Patients.Count; i++)
                if (Patients[i].Username == patientsUsername) return Patients[i];
            return null;
        }

        public void updateDoctors()
        {
            Doctors = FilesDoctors.GetDoctors();
        }
    }
}