using HospitalApplication.Controller;
using HospitalApplication.Logic;
using HospitalApplication.Model;
using HospitalApplication.Repository;
using HospitalApplication.Windows.Patient1;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkWithFiles;

namespace HospitalApplication.Windows.PatientWindows
{
    /// <summary>
    /// Interaction logic for PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        private AppointmentService examinationManagement = AppointmentService.Instance;
        private MainWindow mainWindow = MainWindow.Instance;
        private AppointmentController controller = new AppointmentController();

        private static PatientsPage instance;
        public static PatientsPage Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new PatientsPage();
                }
                return instance;
            }
        }

        public PatientsPage()
        {
            InitializeComponent();
            instance = this;
            List<Appointment> appointments = examinationManagement.GetAppointments(mainWindow.PatientsUsername);
            appointments.Sort((x, y) => DateTime.Compare(x.ExaminationStart, y.ExaminationStart));
            lvUsers.ItemsSource = appointments;
            NotificationService notificationService = new NotificationService();
            notificationService.StartNotificationThread(mainWindow.Username.Text);
        }

        public void UpdateView()
        {
            List<Appointment> examinations = examinationManagement.GetAppointments(mainWindow.PatientsUsername);
            examinations.Sort((x, y) => DateTime.Compare(x.ExaminationStart, y.ExaminationStart));
            lvUsers.ItemsSource = null;
            lvUsers.ItemsSource = examinations;
        }

        private void ScheduleExamination_Click(object sender, RoutedEventArgs e)
        {
            WindowExaminationSchedule window = new WindowExaminationSchedule();
            window.Show();
        }

        private void CancelExamination_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            Appointment appointment = (Appointment)lvUsers.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Do you want to cancel examination?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    controller.CancelExamination(appointment);
                    UpdateView();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void MoveExamination_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            WindowExaminationMove window = new WindowExaminationMove();
            window.Show();
        }

        private void EditExamination_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            WindowExaminationEdit window = new WindowExaminationEdit();
            window.Show();
        }
    }
}