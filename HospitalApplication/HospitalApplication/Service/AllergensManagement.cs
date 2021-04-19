using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class AllergensManagement
   {

        private List<Allergen> allergens;

        public AllergensManagement()
        {
            allergens = FilesAllergens.LoadAllergens();
        }

        public List<Allergen> GetAllAllergens()
        {
            return allergens;
        }


        public void CreateAllergen(Allergen newAllergen)
        {
            allergens.Add(newAllergen);
            FilesAllergens.EnterAllergen(allergens);
        }




    }
}