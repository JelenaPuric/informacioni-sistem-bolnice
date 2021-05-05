using HospitalApplication.Model;
using HospitalApplication.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace HospitalApplication.Service
{
    public class MedicinesManagment
    {
        private List<Drugs> allMedicines;

        public MedicinesManagment()
        {
            allMedicines = FilesDrugs.LoadDrugs();
        }

        public void CreateDrug (Drugs newDrug)
        {
            int ok = 0;
            if(allMedicines.Count != 0)
                for(int i=0; i<allMedicines.Count; i++)
                {
                    if (newDrug.Name == allMedicines[i].Name && newDrug.Manufacturer == allMedicines[i].Manufacturer)
                        ok++; 
                }
            else
                allMedicines.Add(newDrug);
            if(ok == 0 )
                allMedicines.Add(newDrug);
            else
                MessageBox.Show("That Medicines already exist", "Error");

            FilesDrugs.EnterDrug(allMedicines);
        }

        public List<Drugs> GetList()
        {
            return allMedicines;
        }

        public void DeleteDrug (Drugs forDelete)
        {
            for(int i=0; i<allMedicines.Count; i++)
            {
                if (forDelete.ItemId == allMedicines[i].ItemId)
                    allMedicines.RemoveAt(i);
            }
            FilesDrugs.EnterDrug(allMedicines);
        }

    }
}
