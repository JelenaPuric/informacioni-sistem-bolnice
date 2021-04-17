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
//da bih koristio forme morao sam u HospitalApplication.csproj da dodam:
//<UseWindowsForms>true</UseWindowsForms>
//using System.Windows.Forms;
//using Tulpep.NotificationWindow;
using System.Threading;
using HospitalApplication.Model;
using HospitalApplication.Logic;
using HospitalApplication.Windows.Patient1;

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
        FilesExamination f = new FilesExamination();
        ExaminationManagement m = ExaminationManagement.Instance;
        Windows.Patient1.WindowPatientLogin l = Windows.Patient1.WindowPatientLogin.Instance;
        MainWindow mw = MainWindow.Instance;
        NotificationManagement ntf = NotificationManagement.Instance;


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

            List<Examination> examinations = m.GetExaminations(mw.EnteredUsername);
            //List<Examination> examinations = m.Examinations;
            lvUsers.ItemsSource = examinations;
            Logic.PatientNotifications p = new Logic.PatientNotifications(mw.Username.Text);
        }

        public void UpdateView()
        {
            List<Examination> examinations = m.GetExaminations(mw.EnteredUsername);
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
            /*PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "info";
            popup.ContentText = "popup";
            popup.Popup();*/
            WindowExaminationSchedule window = new WindowExaminationSchedule();
            window.Show();
        }

        //trenutno otkazujem pregled preko id pregleda
        //uradjeno da kad se pregled otkaze onda se ukloni pregled i doktoru
        private void CancelExamination_Click(object sender, RoutedEventArgs e)
        {
            //WindowExaminationCancel window = new WindowExaminationCancel();
            //window.Show();
            //string id = (string)lvUsers.SelectedItems[lvUsers.SelectedIndex];
            //ListViewItem item = lvUsers.SelectedItems[1];
            //string name = lvUsers.SelectedItems[0].SubItems[0].Text;
            //string id = (string)lvUsers.SelectedItems[0];
            //string id = (string)lvUsers.SelectedItem;

            Examination e2 = (Examination)lvUsers.SelectedItem;
            string id = e2.ExaminationId;

            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to cancel examination?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    int index = lvUsers.SelectedIndex;
                    WorkWithFiles.FilesDoctor doc = new WorkWithFiles.FilesDoctor();
                    List<Doctor> doctors = doc.LoadFromFile();
                    DateTime dt = e2.ExaminationStart;

                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (doctors[i].Username == e2.DoctorsId)
                        {
                            for (int j = 0; j < doctors[i].Scheduled.Count; j++)
                            {
                                if (doctors[i].Scheduled[j] == dt)
                                {
                                    doctors[i].Scheduled.RemoveAt(j);
                                }
                            }

                            doc.WriteInFile(doctors);
                            break;
                        }
                    }

                    m.CancelExamination(id);
                    //m.Cancel(index);
                    UpdateView();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void MoveExamination_Click(object sender, RoutedEventArgs e)
        {
            Windows.Patient1.WindowExaminationMove window = new Windows.Patient1.WindowExaminationMove();
            window.Show();
        }

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            Windows.Patient1.WindowPatientNotifications window = new Windows.Patient1.WindowPatientNotifications();
            window.Show();
        }

        private void EditExamination_Click(object sender, RoutedEventArgs e)
        {
            WindowExaminationEdit window = new WindowExaminationEdit();
            window.Show();
        }
    }
}
