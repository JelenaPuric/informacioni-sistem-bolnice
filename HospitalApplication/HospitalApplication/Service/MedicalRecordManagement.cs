using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class MedicalRecordManagement
    {

        private List<MedicalRecord> medicalRecords;

        public MedicalRecordManagement()
        {
            medicalRecords = FilesMedicalRecords.LoadMedicalRecords();
        }

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            
            return medicalRecords;

        }


    }
}