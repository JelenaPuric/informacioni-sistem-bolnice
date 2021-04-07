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
            List<Patient> patients = sp.Patients;

            Patient p = new Patient();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == iDPatient) patients.RemoveAt(i);

            }
            sp.WritePatient(sp.Path);
        }


        public void CreatePatient(Patient newPatient)
        {
            FilesPatients sp = FilesPatients.GetInstance();

            List<Patient> patients = sp.Patients;
            patients.Add(newPatient);
        }



        public Patient EditExistingPatient(string iDPatient)
        {
            FilesPatients sp = FilesPatients.GetInstance();
            List<Patient> patients = sp.Patients;

            Patient p = new Patient();

            for (int i = 0; i < patients.Count; i++)
            {

                if (patients[i].Id == iDPatient)
                {
                    p = patients[i];
                    break;
                }
            }
            return p;
        }



        public List<Patient> GetAllPatient()
        {
            FilesPatients sp = FilesPatients.GetInstance();

            return sp.Patients;
        }


    }
}