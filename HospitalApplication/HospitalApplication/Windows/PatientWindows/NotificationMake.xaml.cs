using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HospitalApplication.Model;
using HospitalApplication.Logic;
using HospitalApplication.Controller;
using HospitalApplication.WorkWithFiles;
using HospitalApplication.Windows.PatientWindows;
using HospitalApplication.Service;
using HospitalApplication.Service.PatientValidation;
using HospitalApplication.Service.PatientValidation.ValidateDatePicker;

namespace HospitalApplication.Windows.Patient1
{
    public partial class WindowNotificationMake : Window
    {
        private int notificationId = 100000;
        private FileNotifications fileNotification = FileNotifications.Instance;
        private NotificationsPage notificationsPage = NotificationsPage.Instance;
        private MainWindow mainWindow = MainWindow.Instance;
        private NotificationController controller = new NotificationController();
        private FormService formService = new FormService();
        private PatientValidationService validationService = new PatientValidationService();

        public WindowNotificationMake()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (Validate() == false){
                ExceptionLabel.Content = "Wrong input";
                return;
            }
            DateTime newDate = formService.GetDateAndTimeFromForm(Date.SelectedDate.Value.Date, Combo, 0, 24);
            List<DateTime> dates = new List<DateTime>();
            dates.Add(newDate);
            for (int i = 0; i < Int32.Parse(Repeat.Text); i++){
                newDate = newDate.AddDays(1);
                dates.Add(newDate);
            }
            notificationId = fileNotification.GenerateNotificationId(notificationId);
            Notification notification = new Notification(dates, Title.Text, Description.Text, Repeat.Text, (notificationId + 1).ToString(), mainWindow.PatientsUsername);
            controller.ScheduleNotification(notification);
            notificationsPage.UpdateView();
            Close();
        }

        private bool Validate() {
            validationService.SetValidateTextStrategy(new TxtOnlyNumbers());
            if (validationService.ValidateTextOnlyNumbers(Repeat.Text) == false) return false;
            validationService.SetValidateTextStrategy(new TxtNotEmpty());
            if (validationService.ValidateTxtNotEmpty(Description.Text) == false) return false;
            if (validationService.ValidateTxtNotEmpty(Title.Text) == false) return false;
            if (validationService.ValidateTxtNotEmpty(Repeat.Text) == false) return false;
            validationService.SetValidateTextStrategy(new TxtNotificationTitle());
            if (validationService.ValidateNotificationTitle(Title.Text) == false) return false;
            validationService.SetValidateDatePickerStrategy(new DpNotEmpty());
            if (validationService.ValidateDpNotEmpty(Date) == false) return false;  
            return true;
        }
    }
}