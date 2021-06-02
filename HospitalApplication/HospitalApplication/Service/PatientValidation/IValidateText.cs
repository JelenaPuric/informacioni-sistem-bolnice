using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Service.PatientValidation
{
    interface IValidateText
    {
        public bool Validate(string input);
    }
}
