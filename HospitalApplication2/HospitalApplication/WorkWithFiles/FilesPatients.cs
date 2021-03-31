using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkWithFiles
{
   public class FilesPatients
   {
        private FilesPatients() { }

        private static FilesPatients _instance;

        public static FilesPatients GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FilesPatients();
            }
            return _instance;
        }


        private List<Patient> patients;

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public void LoadPatient(string path)
        {
            patients = new List<Patient>();
            List<String> lines = File.ReadAllLines(path).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                DateTime myDate = DateTime.Parse(entries[4]);



                string typeAcc = entries[0];
                AccountType typeAccc = (AccountType)Enum.Parse(typeof(AccountType), typeAcc);


                string type = entries[8];
                TypeOfPerson typeOfPerson = (TypeOfPerson)Enum.Parse(typeof(TypeOfPerson), type);

                Patient p = new Patient(typeAccc, entries[1], entries[2], entries[3], myDate,
                    entries[5], entries[6], entries[7], typeOfPerson, entries[9], entries[10]);

                patients.Add(p);
            }

        }

        public void WritePatient(string path)
        {
            System.IO.File.WriteAllText(path, string.Empty);

            for (int i = 0; i < patients.Count; i++)
            {
                File.AppendAllText(path, patients[i].TypeAcc + "," + patients[i].Name + "," + patients[i].LastName + "," + patients[i].Id + "," + patients[i].DateOfBirth + "," + patients[i].PhoneNumber + "," + patients[i].Email + "," + patients[i].PlaceOfResidance + "," + patients[i].TypeOfPerson + "," + patients[i].Username + "," + patients[i].Password + "\n"); ;
            }
        }





        public List<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }


    }
}