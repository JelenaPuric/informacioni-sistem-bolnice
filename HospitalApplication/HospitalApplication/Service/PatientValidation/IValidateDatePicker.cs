using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace HospitalApplication.Service.PatientValidation
{
    interface IValidateDatePicker
    {
        public bool Validate(DatePicker datePicker);
    }
}
