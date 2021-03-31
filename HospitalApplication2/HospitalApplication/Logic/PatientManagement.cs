using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class PatientManagement
   {
        public void DeletePatient(string iDPatient)
        {
            FilesPatients sp = FilesPatients.GetInstance();
            List<Patient> patients = sp.GetPatients();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == iDPatient) patients.RemoveAt(i);
            }

        }

        public void CreatePatient(Patient newPatient)
        {
            FilesPatients sp = FilesPatients.GetInstance();

            List<Patient> patients = sp.GetPatients();
            patients.Add(newPatient);
        }

        public Patient EditExistingPatient(string iDPatient)
        {
            FilesPatients sp = FilesPatients.GetInstance();
            List<Patient> patients = sp.GetPatients();

            Patient p = new Patient();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == iDPatient) { 
                    p = patients[i];
                    break;
                }
            }
            return p;
        }


        public List<Patient> GetAllPatient()
        {
            FilesPatients sp = FilesPatients.GetInstance();

            return sp.GetPatients();
        }

    }
}