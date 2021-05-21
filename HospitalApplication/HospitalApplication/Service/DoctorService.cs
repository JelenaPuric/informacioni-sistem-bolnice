using HospitalApplication.WorkWithFiles;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Service
{
    public class DoctorService
    {
        private List<Doctor> doctors;
        private FileDoctors fileDoctors = FileDoctors.Instance;


        private static DoctorService instance;
        public static DoctorService Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new DoctorService();
                }
                return instance;
            }
        }

        public DoctorService() {
            instance = this;
            doctors = fileDoctors.GetDoctors();
        }


        public void CreateDoctor(Doctor newDoctor)
        {
            doctors.Add(newDoctor);
            fileDoctors.Write();
        }

        public void DeleteDoctor(string idDoctor)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].DoctorId == idDoctor)
                {
                    doctors.RemoveAt(i); break;
                }
            }
            fileDoctors.Write();
        }

        public void UpdateDoctor(Doctor currentDoctor)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id.Equals(currentDoctor.Id))
                {
                    doctors[i].DoctorType = currentDoctor.DoctorType;
                    doctors[i].Username = currentDoctor.Username;
                    doctors[i].Password = currentDoctor.Password;
                }
            }
            fileDoctors.Write();
        }

        public bool IsDoctorFree(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < doctors.Count; i++)
                if (doctors[i].Username == doctorUsername)
                    for (int j = 0; j < doctors[i].Scheduled.Count; j++)
                        if (doctors[i].Scheduled[j] == date)
                            return false;
            return true;
        }


        public void AddExaminationToDoctor(String doctorUsername, DateTime date)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username == doctorUsername)
                {
                    doctors[i].Scheduled.Add(date);
                    fileDoctors.Write();
                    break;
                }
            }
        }

        public void RemoveExaminationFromDoctor(String doctorUsername, DateTime date)
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
                    fileDoctors.Write();
                    break;
                }
            }
        }

    }
}
