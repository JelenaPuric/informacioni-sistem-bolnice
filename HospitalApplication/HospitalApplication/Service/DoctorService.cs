using HospitalApplication.WorkWithFiles;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Service
{
    class DoctorService
    {
        private List<Doctor> doctors;
        private FileDoctors fileDoctors = FileDoctors.Instance;

        public DoctorService() {
            doctors = fileDoctors.GetDoctors();
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
