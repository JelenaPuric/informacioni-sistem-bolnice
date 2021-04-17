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
using Logic;
using Model;
using WorkWithFiles;

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for WindowExaminationSchedule.xaml
    /// </summary>
    public partial class WindowExaminationSchedule : Window
    {
        private ExaminationManagement m = ExaminationManagement.Instance;
        private string s1, s2;
        private WindowPatient w = WindowPatient.Instance;
        private bool ok = false;
        private int idExamination = 100000;
        private Windows.Patient1.WindowPatientLogin l = Windows.Patient1.WindowPatientLogin.Instance;
        private MainWindow mw = MainWindow.Instance;
        private SerializationAndDeserilazationOfRooms r = new SerializationAndDeserilazationOfRooms();
        private WorkWithFiles.FilesDoctor fd = new WorkWithFiles.FilesDoctor();

        public WindowExaminationSchedule()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            //s1 = PatientId.Text;
            //s2 = DoctorId.Text;
            DateTime date = Date.SelectedDate.Value.Date;
            //TimeSpan time = new TimeSpan(Int32.Parse(Hour1.Text), Int32.Parse(Minute1.Text), Int32.Parse(Second1.Text));
            
            //DateTime date = new DateTime(2000, 12, 30, 15, 10, 00);
            //DateTime date = new DateTime(d);
            //DateTime date = new DateTime(Int32.Parse(Year1.Text), Int32.Parse(Month1.Text), Int32.Parse(Day1.Text), Int32.Parse(Hour1.Text), Int32.Parse(Minute1.Text), Int32.Parse(Second1.Text));
            //id svakog pregleda je unikatan
            
            //lista svih mogucih termina za pregled, kombijuje se sa date time pickerom
            //trojke oznacavaju sat/min/sekund
            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++) {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime d = date + time;

            //generisem unikatan id za pregled
            //radi tako sto jednom ucitam sve preglede i nadjem najveci id pa nakon toga samo dodeljujem za po jedan br veci
            List < Examination > examinations = m.Examinations;
            if (ok == false)
            {
                ok = true;
                for (int i = 0; i < examinations.Count; i++)
                {
                    if (Int32.Parse(examinations[i].ExaminationId) > idExamination)
                    {
                        idExamination = Int32.Parse(examinations[i].ExaminationId);
                    }
                }
            }

            /*bool isFree = true;
            List<Room> rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
            for (int i = 0; i < rooms.Count; i++) {
                for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                {
                    if (rooms[i].Scheduled[j] == d)
                    {
                        isFree = false;
                    }
                }
            }*/

            //List<Room> rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
            //rooms[0].Scheduled.Add(d);

            //prolazim kroz zakazane preglede doktora i ako je on slobodan u tom terminu onda moze  da se zakaze
            bool isFree = true;
            bool sched = false;
            WorkWithFiles.FilesDoctor doc = new WorkWithFiles.FilesDoctor();
            List<Doctor> doctors = doc.LoadFromFile();
            for (int i = 0; i < doctors.Count; i++) {
                Random rnd = new Random();
                int index = rnd.Next(0, doctors.Count);
                isFree = true;
                for (int j = 0; j < doctors[index].Scheduled.Count; j++) {
                    if (doctors[index].Scheduled[j] == d) {
                        isFree = false;
                    }
                }
                if (isFree) {
                    s2 = doctors[index].Username;
                    doctors[index].Scheduled.Add(d);
                    doc.WriteInFile(doctors);
                    sched = true;
                    break;
                }
            }

            //u prvoj petlji uzimam doktore na random da ne bih uvek istom doktoru popunio sve termine pa tek onda sledecem
            //ova petlja je da se prodje kroz sve ako nije zakazan pregled u prvoj petlji jer je moguce da je neki doktor izostavljen
            for (int i = 0; i < doctors.Count && sched == false; i++)
            {
                isFree = true;
                for (int j = 0; j < doctors[i].Scheduled.Count; j++)
                {
                    if (doctors[i].Scheduled[j] == d)
                    {
                        isFree = false;
                    }
                }
                if (isFree)
                {
                    s2 = doctors[i].Username;
                    doctors[i].Scheduled.Add(d);
                    doc.WriteInFile(doctors);
                    sched = true;
                    break;
                }
            }
                
            if (sched == false) {
                MessageBox.Show("There is no free term. Choose another time.");
                Close();
            }

            Examination ex = new Examination(mw.EnteredUsername, s2, "101", d, (idExamination+1).ToString());
            m.ScheduleExamination(ex);

            w.UpdateView();
            Close();
        }
    }
}
