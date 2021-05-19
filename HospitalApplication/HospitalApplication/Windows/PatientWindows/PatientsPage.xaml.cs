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
        private FileSurvey filesSurvey = FileSurvey.Instance;
        private List<Appointment> allExaminations = new List<Appointment>();
        private FileAppointments filesExamination = FileAppointments.Instance;
        List<Survey> surveys = new List<Survey>();

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
            allExaminations = filesExamination.GetAppointments();
            surveys = filesSurvey.GetSurveys();
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
            if (!(lvUsers.SelectedIndex > -1))
                return;
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
            if (!(lvUsers.SelectedIndex > -1))
                return;
            WindowExaminationMove window = new WindowExaminationMove();
            window.Show();
        }

        private void EditExamination_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1))
                return;
            WindowExaminationEdit window = new WindowExaminationEdit();
            window.Show();
        }

        private void RateHospital_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < surveys.Count; i++)
            {
                if (surveys[i].PatientsUsername == mainWindow.PatientsUsername && (surveys[i].DateOfTheSurvey - DateTime.Now).Days < 30)
                {
                    MessageBox.Show("You can rate hospital only once in 30 days.");
                    return;
                }
            }
            WindowRateHospital window = new WindowRateHospital();
            window.Show();
        }

        //provera da li pacijent moze da oceni doktora radi na ovaj nacin
        //da bi se mogao oceniti doktor, pacijent mora da je u proslosti bio kod njega na pregledu
        //takodje ako je pacijent ocenio doktora, ne moze da ga ponovo oceni sve dok ne ode kod njega na pregled
        private void RateDoctor_Click(object sender, RoutedEventArgs e)
        {
            List<string> doctorUsernames = new List<String>();
            surveys = filesSurvey.GetSurveys();
            for (int i = 0; i < allExaminations.Count; i++)
            {
                if (allExaminations[i].PatientsId == mainWindow.PatientsUsername && allExaminations[i].ExaminationStart < DateTime.Now)
                {
                    bool ok = true;
                    for (int j = 0; j < surveys.Count; j++)
                        if (surveys[j].PatientsUsername == mainWindow.PatientsUsername && surveys[j].SurveyIsAbout == allExaminations[i].DoctorsId && surveys[j].DateOfTheSurvey > allExaminations[i].ExaminationStart)
                            ok = false;
                    if (ok) doctorUsernames.Add(allExaminations[i].DoctorsId);
                }
            }
            if (doctorUsernames.Count < 1)
            {
                MessageBox.Show("You must attend examination before rating doctor.");
                return;
            }
            DoctorSurvey window = new DoctorSurvey(doctorUsernames.Distinct().ToList());
            window.Show();
        }
    }
}