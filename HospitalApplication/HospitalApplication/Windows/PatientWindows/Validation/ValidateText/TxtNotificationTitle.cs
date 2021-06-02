using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Service.PatientValidation
{
    class TxtNotificationTitle : IValidateText
    {
        public bool Validate(string input)
        {
            if (input.Length > 20) return false;
            return true;
        }
    }
}
