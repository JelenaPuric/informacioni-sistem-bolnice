using System;

namespace Model
{
   public class Patient : Person
   {
      public Examination examination;

        private AccountType typeAcc;

        public Patient() { }

        public Patient(AccountType typeAccc, string namee, string lastnamee, string idd, DateTime dateOfBirthh, string phoneNumberr, string emaill, string placeOfResidancee,
            TypeOfPerson typeOfPersonn, string usernameee, string passworddd) : base(namee, lastnamee, idd, dateOfBirthh, phoneNumberr, emaill, placeOfResidancee,
             typeOfPersonn, usernameee, passworddd)
        {
            typeAcc = typeAccc;
        }



        public Model.AccountType TypeAcc
        {
            get { return typeAcc; }
            set { typeAcc = value; }
        }








    }
}