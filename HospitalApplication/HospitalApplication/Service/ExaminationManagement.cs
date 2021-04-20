using System;
using System.Collections.Generic;
using HospitalApplication.WorkWithFiles;
using Model;
using WorkWithFiles;

namespace Logic
{
    public class ExaminationManagement
    {
        private static ExaminationManagement instance;
        public static ExaminationManagement Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new ExaminationManagement();
                }
                return instance;
            }
        }

        public ExaminationManagement()
        {
            examinations = f.LoadFromFile();
            doctors = fd.LoadFromFile();
        }

        public void ScheduleExamination(Examination e)
        {
            examinations.Add(e);
            f.WriteInFile(examinations);
        }

        public void CancelExamination(String id)
        {
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationId == id) examinations.RemoveAt(i);
            }
            f.WriteInFile(examinations);
        }

        /*public void Cancel(int index)
        {
            examinations.RemoveAt(index);
            f.WriteInFile(examinations);
        }*/

        /*public void Move(int index, DateTime date)
        {
            //prvo ga izbrisi, promeni datum pa vrati
            Examination e = examinations[index];
            examinations.RemoveAt(index);
            e.ExaminationStart = date;
            examinations.Add(e);
            f.WriteInFile(examinations);
        }*/

        public void MoveExamination(string id, DateTime date)
        {
            //prvo ga izbrisi, promeni datum pa vrati
            Examination e = new Examination();
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationId == id)
                {
                    e = examinations[i];
                    examinations.RemoveAt(i);
                }
            }
            e.ExaminationStart = date;
            examinations.Add(e);
            f.WriteInFile(examinations);
        }

        public void EditExamination(string id, string doctor)
        {
            //prvo ga izbrisi, promeni doktora pa vrati
            Examination e = new Examination();
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationId == id)
                {
                    e = examinations[i];
                    examinations.RemoveAt(i);
                }
            }
            e.DoctorsId = doctor;
            examinations.Add(e);
            f.WriteInFile(examinations);
        }

        public List<Examination> GetExaminations(String patientName)
        {
            List<Examination> e = new List<Examination>();
            for (int i = 0; i < examinations.Count; i++)
            {
                //dodaje preglede za pacijenta patientName i to samo one koji nisu prosli
                if (examinations[i].PatientsId == patientName && examinations[i].ExaminationStart >= DateTime.Now)
                {
                    e.Add(examinations[i]);
                }
            }
            return e;
        }

        public void addExaminationToDoctor(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username == doctorUsername)
                {
                    doctors[i].Scheduled.Add(date);
                    fd.WriteInFile(doctors);
                    break;
                }
            }
        }

        public void removeExaminationFromDoctor(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username == doctorUsername)
                {
                    for (int j = 0; j < doctors[i].Scheduled.Count; j++)
                    {
                        if (doctors[i].Scheduled[j] == date)
                        {
                            doctors[i].Scheduled.RemoveAt(j);
                            break;
                        }
                    }
                    fd.WriteInFile(doctors);
                    break;
                }
            }
        }

        public bool doctorsExaminationExists(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username == doctorUsername)
                {
                    for (int j = 0; j < doctors[i].Scheduled.Count; j++)
                    {
                        if (doctors[i].Scheduled[j] == date)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void updateDoctors()
        {
            doctors = fd.LoadFromFile();
        }

        private FilesExamination f = new FilesExamination();
        private FilesDoctor fd = new FilesDoctor();
        private List<Examination> examinations;
        private List<Doctor> doctors;

        public List<Examination> Examinations
        {
            get { return examinations; }
            set { examinations = value; }
        }
        /*public List<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; }
        }*/
    }
}