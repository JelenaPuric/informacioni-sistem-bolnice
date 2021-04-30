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
using Model;
using Logic;
using WorkWithFiles;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading;
using HospitalApplication.Model;
using HospitalApplication.Logic;
using HospitalApplication.Windows.Patient1;
using HospitalApplication.Controller;

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for WindowPatient.xaml
    /// </summary>
    public partial class WindowPatient : Window
    {
        //ideje sta kako treba uraditi
        //da bih prikazao preglede samo ulogovanog pacijenta treba da drugacije implementiram funkcije za crud pregleda
        //mogao bih porediti objekte Examination a ne da radim preko id-a ili selected itema
        //generisanje id za pregled ne radi, ako skontas kako da resis bagove mozes crud raditi preko tog id-a
        //uradjen prikaz pregleda ulogovanog pacijenta
        //dodaj da se ne unosi ime pacijenta pri zakazivanju
        private ExaminationManagement examinationManagement = ExaminationManagement.Instance;
        private MainWindow mainWindow = MainWindow.Instance;
        private PatientController controller = new PatientController();
        public ICollectionView ExaminationsCollectionView { get; }

        private static WindowPatient instance;
        public static WindowPatient Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new WindowPatient();
                }
                return instance;
            }
        }

        public WindowPatient()
        {
            InitializeComponent();
            instance = this;
            List<Examination> examinations = examinationManagement.GetExaminations(mainWindow.PatientsUsername);
            examinations.Sort((x, y) => DateTime.Compare(x.ExaminationStart, y.ExaminationStart));
            lvUsers.ItemsSource = examinations;
            PatientNotifications p = new PatientNotifications(mainWindow.Username.Text);
        }

        public void UpdateView()
        {
            List<Examination> examinations = examinationManagement.GetExaminations(mainWindow.PatientsUsername);
            examinations.Sort((x, y) => DateTime.Compare(x.ExaminationStart, y.ExaminationStart));
            //List<Examination> examinations = m.Examinations;
            //lvUsers.ItemsSource = null;
            //lvUsers.ItemsSource = examinations;
            //lvUsers.Items.Refresh();
            //ICollectionView view = CollectionViewSource.GetDefaultView(examinations);
            //view.Refresh();
            lvUsers.ItemsSource = null;
            lvUsers.ItemsSource = examinations;
            // Update the List containing your elements (lets call it x)
            //lvUsers.ItemsSource = examinations;
            //TestLabela.Content = "vucicupederu";
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
            Examination examination = (Examination)lvUsers.SelectedItem;
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to cancel examination?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    DateTime date = examination.ExaminationStart;
                    //ukloni pregled lekaru i sobi
                    controller.RemoveExaminationFromDoctor(examination.DoctorsId, date);
                    controller.RemoveExaminationFromRoom(examination.RoomId, date);
                    controller.CancelExamination(examination.ExaminationId);
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

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            WindowPatientNotifications window = new WindowPatientNotifications();
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
            WindowRateHospital window = new WindowRateHospital();
            window.Show();
        }
    }
}
