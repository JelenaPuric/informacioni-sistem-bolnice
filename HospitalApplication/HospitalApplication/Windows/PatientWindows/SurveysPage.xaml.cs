using HospitalApplication.Controller;
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
    public partial class SurveysPage : Page
    {
        private MainWindow mainWindow = MainWindow.Instance;
        private FileSurveys fileSurveys = FileSurveys.Instance;
        private List<Appointment> appointments = new List<Appointment>();
        List<Survey> surveys = new List<Survey>();
        private FileAppointments fileAppointments = FileAppointments.Instance;

        public SurveysPage()
        {
            InitializeComponent();
            appointments = fileAppointments.GetAppointments();
        }

        private void RateDoctor_Click(object sender, RoutedEventArgs e)
        {
            List<string> doctorUsernames = new List<string>();
            surveys = fileSurveys.GetSurveys();
            for (int i = 0; i < appointments.Count; i++){
                if (appointments[i].PatientsId == mainWindow.PatientsUsername && appointments[i].ExaminationStart < DateTime.Now){
                    bool ok = true;
                    for (int j = 0; j < surveys.Count; j++)
                        if (surveys[j].PatientsUsername == mainWindow.PatientsUsername && surveys[j].SurveyIsAbout == appointments[i].DoctorsId && surveys[j].DateOfTheSurvey > appointments[i].ExaminationStart)
                            ok = false;
                    if (ok) doctorUsernames.Add(appointments[i].DoctorsId);
                }
            }
            if (doctorUsernames.Count < 1){
                MessageBox.Show("You must attend examination before rating doctor.");
                return;
            }
            DoctorSurvey window = new DoctorSurvey(doctorUsernames.Distinct().ToList());
            window.Show();
        }

        private void RateHospital_Click(object sender, RoutedEventArgs e)
        {
            surveys = fileSurveys.GetSurveys();
            for (int i = 0; i < surveys.Count; i++){
                if (surveys[i].PatientsUsername == mainWindow.PatientsUsername && (surveys[i].DateOfTheSurvey - DateTime.Now).Days < 30 && surveys[i].SurveyIsAbout == "Hospital"){
                    MessageBox.Show("You can rate hospital only once in 30 days.");
                    return;
                }
            }
            WindowRateHospital window = new WindowRateHospital();
            window.Show();
        }
    }
}
