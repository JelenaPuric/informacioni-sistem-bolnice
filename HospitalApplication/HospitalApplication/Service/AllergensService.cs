using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class AllergensService
   {

        private List<Allergen> allergens;

        public AllergensService()
        {
            allergens = FileAllergens.LoadAllergens();
        }

        public List<Allergen> GetAllAllergens()
        {
            return allergens;
        }


        public void CreateAllergen(Allergen newAllergen)
        {
            allergens.Add(newAllergen);
            FileAllergens.EnterAllergen(allergens);
        }


        public string getID(string nameA)
        {

            string idA = new string("test");
            for (int i = 0; i < allergens.Count; i++)
            {
                if (allergens[i].Name.Equals(nameA))
                {
                    idA = allergens[i].Id;
                    break;
                }
            }
            return idA;
        }



    }
}