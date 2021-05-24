using HospitalApplication.Repository;
using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkWithFiles
{
   public class FileAllergens : IFile
   {
        private static string path = "../../../Data/allergens.json";
        private static List<Allergen> allergens;
        private static FileAllergens instance;

        public static FileAllergens Instance
        {
            get
            {
                if (null == instance)
                    instance = new FileAllergens();
                return instance;
            }
        }

        private FileAllergens()
        {
            Read();
        }

        public void Read()
        {
            string json = File.ReadAllText(path);
            allergens = new JavaScriptSerializer().Deserialize<List<Allergen>>(json);
        }

        public void Write()
        {
            string json = new JavaScriptSerializer().Serialize(allergens);
            File.WriteAllText(path, json);
        }

        public List<Allergen> GetAllergens()
        {
            return allergens;
        }
    }
}