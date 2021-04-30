using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkWithFiles
{
   public class FilesAllergens
   {

        public static string FileAllergen = "../../../Data/allergens.json";

        public static List<Allergen> LoadAllergens()
        {
            //ako ne postoji fajl (jos uvek nista nije sacuvano pri prvom pokretanju aplikacije vrati praznu listu)
            if (!File.Exists(FileAllergen))
                return new List<Allergen>();

            string json = File.ReadAllText(FileAllergen);
            List<Allergen> allergens = new JavaScriptSerializer().Deserialize<List<Allergen>>(json);

            return allergens;
        }

        public static void EnterAllergen(List<Allergen> input)
        {
            string json = new JavaScriptSerializer().Serialize(input);
            File.WriteAllText(FileAllergen, json);
        }

    }
}