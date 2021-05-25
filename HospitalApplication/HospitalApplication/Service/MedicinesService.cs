using HospitalApplication.Model;
using HospitalApplication.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace HospitalApplication.Service
{
    public class MedicinesService
    {
        private List<Drugs> allMedicines;

        public MedicinesService()
        {
            allMedicines = FileDrugs.LoadDrugs();
        }

        public void CreateDrug (Drugs newDrug)
        {
            int ok = 0;
            for(int i=0; i < allMedicines.Count; i++)
            {
                if (newDrug.Name == allMedicines[i].Name && newDrug.Manufacturer == allMedicines[i].Manufacturer)
                {
                    MessageBox.Show("That Medicines already exist", "Error");
                    ok++;
                }
            }
            if(ok == 0 )
                allMedicines.Add(newDrug);
            FileDrugs.EnterDrug(allMedicines);
        }

        public List<Drugs> GetList()
        {
            return allMedicines;
        }

        public void DeleteDrug (Drugs oldDrug)
        {
            for(int i=0; i<allMedicines.Count; i++)
            {
                if (oldDrug.ItemId == allMedicines[i].ItemId)
                    allMedicines.RemoveAt(i);
            }
            FileDrugs.EnterDrug(allMedicines);
        }
    }
}
