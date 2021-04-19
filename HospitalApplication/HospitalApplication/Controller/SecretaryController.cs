using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Controller
{
    public class SecretaryController
    {
        public PatientManagement patientManagement = new PatientManagement();

        public void CreatePatient(Patient newPatient)
        {
            patientManagement.CreatePatient(newPatient);
        }


        public void DeletePatient(string iDPatient)
        {
            patientManagement.DeletePatient(iDPatient);
        }

        public void Update(Patient p)
        {
            patientManagement.Update(p);
        }

        public void UpdateMedicalRecord(Patient p)
        {
            patientManagement.UpdateMedicalRecord(p);
        }

        public Patient getPatient(string iDPatient)
        {
            return patientManagement.getPatient(iDPatient);
        }

        public List<Patient> GetAllPatients()
        {
            return patientManagement.GetAllPatients();
        }
    }
}
