using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Model
{
    class Survey
    {
        //key je pitanje a value je odgovor (od 1 do 5)
        public string WrittenAnswer { get; set; }
        public int[] NumericalAnswers { get; set; }
        public string PatientsUsername { get; set; }
        public DateTime DateOfTheSurvey { get; set; }

        public Survey(int[] numericalAnswers, string writtenAnswer, string patientsUsername, DateTime dateOfTheSurvey)
        {
            NumericalAnswers = numericalAnswers;
            WrittenAnswer = writtenAnswer;
            PatientsUsername = patientsUsername;
            DateOfTheSurvey = dateOfTheSurvey;
        }
    }
}