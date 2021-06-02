using HospitalApplication.Service.PatientValidation;
using HospitalApplication.Windows.Patient1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace HospitalApplication.Service
{
    public class PatientValidationService
    {
        private IValidateText validateTextStrategy;
        private IValidateDatePicker validateDatePickerStrategy;

        public bool ValidateNotificationMake() {
            //windowNotificationMake = notificationMakeContext.GetWindowNotificationMakeInstance();

            
            /*windowNotificationMake.SetStrategyTxtNotEmpty();
            if(windowNotificationMake.ValidateTxtNotEmpty() == false) return false;
            windowNotificationMake.SetStrategyTxtNotificationTitle();
            if (windowNotificationMake.ValidateNotificationTitle() == false) return false;*/
            return true;
        }

        public void SetValidateTextStrategy(IValidateText strategy)
        {
            validateTextStrategy = strategy;
        }

        public void SetValidateDatePickerStrategy(IValidateDatePicker strategy)
        {
            validateDatePickerStrategy = strategy;
        }

        public bool ValidateTextOnlyNumbers(string inputText)
        {
            if (validateTextStrategy.Validate(inputText) == false) return false;
            return true;
        }

        public bool ValidateDpNotEmpty(DatePicker date) {
            if (validateDatePickerStrategy.Validate(date) == false) return false;
            return true;
        }

        public bool ValidateTxtNotEmpty(string inputText)
        {
            if (validateTextStrategy.Validate(inputText) == false) return false;
            return true;
        }

        public bool ValidateNotificationTitle(string inputText)
        {
            return (validateTextStrategy.Validate(inputText) == false);
        }
    }
}