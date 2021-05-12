using System;
using System.Collections.Generic;
using System.Windows;
using HospitalApplication.Model;
using HospitalApplication.WorkWithFiles;
using Model;
using WorkWithFiles;

namespace Logic
{
    public class ExaminationService
    {
        private FilesExamination filesExamination = new FilesExamination();
        private FilesDoctor filesDoctor = new FilesDoctor();
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
            Doctors = filesDoctor.LoadFromFile();
            Rooms = FilesRoom.LoadRoom();
            Patients = FilesPatients.LoadPatients();
        }

        public void ScheduleExamination(Appointment examination)
        {
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient))
            {
                MessageBox.Show("You can not schedule examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_SCHEDULE);
            Examinations.Add(examination);
            filesExamination.WriteInFile(Examinations);
        }

        public void CancelExamination(Appointment examination)
        {
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient))
            {
                MessageBox.Show("You can not cancel examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_CANCEL);
            Examinations.RemoveAt(GetExaminationsIndex(examination));
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
                    filesDoctor.WriteInFile(Doctors);

                    if (Rooms[roomId].Scheduled == null)
                    {
                        Rooms[roomId].Scheduled = new List<DateTime>();
                    }

                    Rooms[roomId].Scheduled.Add(date);
                    FilesRoom.EnterRoom(Rooms);

                    //Napraviti jos jedan parametar za odlaganje termina
                    Appointment examination = new Appointment(usernamePatient, usernameDoctor, Rooms[roomId].RoomId.ToString(), date, idExaminatin, typeExam, postponeAppointment);
                    ScheduleExamination(examination);

                    return true;
                }

            }

        }

        public bool DoctorIsFree(int docIndex, DateTime date)
        {
            List<Doctor> listDoctor = filesDoctor.LoadFromFile();
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

        /*public void MoveExamination(string examinationId, DateTime date, int roomIndex)
        {
            Tuple<Examination, int> examinationItems = GetExamination(examinationId);
            Patient patient = GetPatient(examinationItems.Item1.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient))
            {
                MessageBox.Show("You can not move examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            SetPatientsPenalty(patient, PENALTY_MOVE);
            Examinations.RemoveAt(examinationItems.Item2);
            examinationItems.Item1.ExaminationStart = date;
            examinationItems.Item1.RoomId = Rooms[roomIndex].RoomId.ToString();
            Examinations.Add(examinationItems.Item1);
            filesExamination.WriteInFile(Examinations);
        }*/

        public void MoveExamination(Appointment examination, DateTime date, int roomIndex)
        {
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient))
            {
                MessageBox.Show("You can not move examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_MOVE);
            examination.ExaminationStart = date;
            examination.RoomId = Rooms[roomIndex].RoomId.ToString();
            filesExamination.WriteInFile(Examinations);
        }

        public void EditExamination(Appointment examination, string doctorsId)
        {
            Patient patient = GetPatient(examination.PatientsId);
            if (PenaltyIsGreaterThanAllowed(patient))
            {
                MessageBox.Show("You can not edit examinations anymore. For more information contact us at zdravo@hospital.rs or call 095-5155-622.", "Info");
                return;
            }
            SetPatientsPenalty(patient, Constants.PENALTY_EDIT);
            examination.DoctorsId = doctorsId;
            filesExamination.WriteInFile(Examinations);
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
                    filesDoctor.WriteInFile(Doctors);
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
                    filesDoctor.WriteInFile(Doctors);
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
                            FilesRoom.EnterRoom(Rooms);
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
            FilesRoom.EnterRoom(Rooms);
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
            Doctors = filesDoctor.LoadFromFile();
        }
    }
}