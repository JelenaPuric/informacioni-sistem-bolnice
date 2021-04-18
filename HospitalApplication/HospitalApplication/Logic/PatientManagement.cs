using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class PatientManagement
   {

        private List<Patient> patients;

        public PatientManagement()
        {
            patients = FilesPatients.LoadPatients();
        }

        public List<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }

        }

        public void CreatePatient(Patient newPatient)
        {
            patients.Add(newPatient);
            FilesPatients.EnterPatient(patients);
        }


        public void DeletePatient(string iDPatient)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == iDPatient)
                {
                    patients.RemoveAt(i); break;
                }
            }
            FilesPatients.EnterPatient(patients);
        }


        public void Update(Patient p)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(p.Id))
                {
                    patients[i].TypeAcc = p.TypeAcc;
                    patients[i].Name = p.Name;
                    patients[i].LastName = p.LastName;
                    patients[i].Jmbg = p.Jmbg;
                    patients[i].SexType = p.SexType;
                    patients[i].DateOfBirth = p.DateOfBirth;
                    patients[i].PlaceOfResidance = p.PlaceOfResidance;
                    patients[i].Email = p.Email;
                    patients[i].PhoneNumber = p.PhoneNumber;
                    patients[i].Username = p.Username;
                    patients[i].Password = p.Password;

                }
            }
            FilesPatients.EnterPatient(patients);

        }


        public Patient getPatient(string iDPatient)
        {

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

    }
}