using System;
using System.Collections.Generic;

namespace Model
{
   public class Patient : Person
   {
      public Examination examination;
      public MedicalRecord medicalRecord;


        private AccountType typeAcc;
        private List<Allergen> listAllergens;
        private List<DateTime> scheduleAppointment;

        public Patient() { }

        public Patient(AccountType typeAccc, string namee, string lastnamee, string idd, DateTime dateOfBirthh, string phoneNumberr, string emaill, string placeOfResidancee,
            TypeOfPerson typeOfPersonn, string usernameee, string passworddd, string jmbggg, SexType sexTypeee, MedicalRecord mr, List<Allergen> listAllergenss) : base(namee, lastnamee, idd, dateOfBirthh, phoneNumberr, emaill, placeOfResidancee,
             typeOfPersonn, usernameee, passworddd, jmbggg, sexTypeee)
        {
            typeAcc = typeAccc;
            medicalRecord = mr;
            listAllergens = listAllergenss;
        }





        public List<DateTime> ScheduleAppointment
        {
            get { return scheduleAppointment; }
            set { scheduleAppointment = value; }
        }

        public Model.AccountType TypeAcc
        {
            get { return typeAcc; }
            set { typeAcc = value; }
        }



        public List<Allergen> ListAllergens
        {
            get { return listAllergens; }
            set { listAllergens = value; }
        }







    }
}