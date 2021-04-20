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

        public List<Patient> GetAllPatients()
        {
            
            return patients;

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


                    patients[i].medicalRecord.TypeAcc = p.TypeAcc;
                    patients[i].medicalRecord.FirstName = p.Name;
                    patients[i].medicalRecord.LastName = p.LastName;
                    patients[i].medicalRecord.Jmbg = p.Jmbg;
                    patients[i].medicalRecord.SexType = p.SexType;
                    patients[i].medicalRecord.DateOfBirth = p.DateOfBirth;
                    patients[i].medicalRecord.PlaceOfResidance = p.PlaceOfResidance;
                    patients[i].medicalRecord.PhoneNumber = p.PhoneNumber;
                    


                }
            }
            FilesPatients.EnterPatient(patients);

        }


        public void updateAllergen(Patient p)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(p.Id))
                {
                    patients[i].ListAllergens = p.ListAllergens;
                    
                }
            }
            FilesPatients.EnterPatient(patients);

        }




        public void UpdateMedicalRecord(Patient p)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(p.Id))
                {
                    patients[i].medicalRecord.TypeAcc = p.medicalRecord.TypeAcc;
                    patients[i].medicalRecord.MartialStatus = p.medicalRecord.MartialStatus;
                    patients[i].medicalRecord.FirstName = p.medicalRecord.FirstName;
                    patients[i].medicalRecord.NameParent = p.medicalRecord.NameParent;
                    patients[i].medicalRecord.LastName = p.medicalRecord.LastName;
                    patients[i].medicalRecord.Jmbg = p.medicalRecord.Jmbg;
                    patients[i].medicalRecord.SexType = p.medicalRecord.SexType;
                    patients[i].medicalRecord.DateOfBirth = p.medicalRecord.DateOfBirth;
                    patients[i].medicalRecord.NumberOfHealthCard = p.medicalRecord.NumberOfHealthCard;
                    patients[i].medicalRecord.PlaceOfResidance = p.medicalRecord.PlaceOfResidance;
                    patients[i].medicalRecord.PhoneNumber = p.medicalRecord.PhoneNumber;


                    patients[i].TypeAcc = p.medicalRecord.TypeAcc;
                    patients[i].Name = p.medicalRecord.FirstName;
                    patients[i].LastName = p.medicalRecord.LastName;
                    patients[i].Jmbg = p.medicalRecord.Jmbg;
                    patients[i].SexType = p.medicalRecord.SexType;
                    patients[i].DateOfBirth = p.medicalRecord.DateOfBirth;
                    patients[i].PlaceOfResidance = p.medicalRecord.PlaceOfResidance;
                    patients[i].PhoneNumber = p.medicalRecord.PhoneNumber;

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