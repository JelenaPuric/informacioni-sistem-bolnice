using System;
using System.Collections.Generic;
using HospitalApplication.WorkWithFiles;
using Model;
using WorkWithFiles;

namespace Logic
{
    public class ExaminationService
    {
        private FilesExamination filesExamination = new FilesExamination();
        private FilesDoctor filesDoctor = new FilesDoctor();
        public List<Examination> Examinations { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Room> Rooms { get; set; }
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
            Rooms = SerializationAndDeserilazationOfRooms.LoadRoom(); 

        }

        public void ScheduleExamination(Examination e)
        {
            Examinations.Add(e);
            filesExamination.WriteInFile(Examinations);
        }

        public void CancelExamination(String id)
        {
            for (int i = 0; i < Examinations.Count; i++)
            {
                if (Examinations[i].ExaminationId == id) Examinations.RemoveAt(i);
            }
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
                    SerializationAndDeserilazationOfRooms.EnterRoom(Rooms);

                    //Napraviti jos jedan parametar za odlaganje termina
                    Examination examination = new Examination(usernamePatient, usernameDoctor, Rooms[roomId].RoomId.ToString(), date, idExaminatin, typeExam, postponeAppointment);
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

        public void MoveExamination(string id, DateTime date, int roomIndex)
        {
            //prvo ga izbrisi, promeni datum pa vrati
            Examination e = new Examination();
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

        public void EditExamination(string id, string doctor)
        {
            //prvo ga izbrisi, promeni doktora pa vrati
            Examination e = new Examination();
            for (int i = 0; i < Examinations.Count; i++)
            {
                if (Examinations[i].ExaminationId == id)
                {
                    e = Examinations[i];
                    Examinations.RemoveAt(i);
                }
            }
            e.DoctorsId = doctor;
            Examinations.Add(e);
            filesExamination.WriteInFile(Examinations);
        }

        public List<Examination> GetExaminations(String patientName)
        {
            List<Examination> e = new List<Examination>();
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

        //vraca da li je soba slobodna i index sobe ako jeste
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
                            SerializationAndDeserilazationOfRooms.EnterRoom(Rooms);
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
            SerializationAndDeserilazationOfRooms.EnterRoom(Rooms);
        }

        public void updateDoctors()
        {
            Doctors = filesDoctor.LoadFromFile();
        }
    }
}