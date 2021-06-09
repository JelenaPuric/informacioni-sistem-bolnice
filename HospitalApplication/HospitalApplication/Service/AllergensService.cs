using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class AllergensService
   {
        private FileAllergens fileAllergens = FileAllergens.Instance;
        private FilePatients filePatients = FilePatients.Instance;
        private List<Allergen> allergens;
        private List<Patient> patients;

        public AllergensService()
        {
            allergens = fileAllergens.GetAllergens();
            patients = filePatients.GetPatients();
        }

        public void CreateAllergen(Allergen newAllergen)
        {
            allergens.Add(newAllergen);
            fileAllergens.Write();
        }

        public void UpdateAllergen(Patient p)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(p.Id))
                    patients[i].ListAllergens = p.ListAllergens; break;
            }
            filePatients.Write();
        }
    }
}