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
using HospitalApplication.Controller;
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
        private PatientController controller = new PatientController();
        private string s1, s2;
        private WindowPatient w = WindowPatient.Instance;
        private bool ok = false;
        private int idExamination = 100000;
        private Windows.Patient1.WindowPatientLogin l = Windows.Patient1.WindowPatientLogin.Instance;
        private MainWindow mw = MainWindow.Instance;
        private SerializationAndDeserilazationOfRooms r = new SerializationAndDeserilazationOfRooms();
        private WorkWithFiles.FilesDoctor fd = new WorkWithFiles.FilesDoctor();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Room> rooms = new List<Room>();
        private int roomIndex = 0;

        public WindowExaminationSchedule()
        {
            InitializeComponent();
            doctors = fd.LoadFromFile();
            for (int i = 0; i < doctors.Count; i++)
            {
                Combo3.Items.Add(doctors[i].Username.ToString());
            }
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
            debagLabel.Content = rooms[0].Scheduled[rooms[0].Scheduled.Count-1].ToString();
        }

        private void ButtonOkFilters_Click(object sender, RoutedEventArgs e)
        {
            //prvo ocisti predlog pregleda
            Combo4.Items.Clear();
            //nacin zakazivanja za kt3

            //datum1
            DateTime date = Date.SelectedDate.Value.Date;
            //trojke oznacavaju sat/min/sekund
            List<(int, int, int)> appointment1 = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                appointment1.Add((7 + i, 0, 0));
                appointment1.Add((7 + i, 30, 0));
            }
            (int, int, int) a1 = appointment1[Combo.SelectedIndex];
            TimeSpan time1 = new TimeSpan(a1.Item1, a1.Item2, a1.Item3);
            DateTime date1 = date + time1;


            //datum2
            DateTime datee = Date2.SelectedDate.Value.Date;
            //trojke oznacavaju sat/min/sekund
            List<(int, int, int)> appointment2 = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                appointment2.Add((7 + i, 0, 0));
                appointment2.Add((7 + i, 30, 0));
            }
            (int, int, int) a2 = appointment2[Combo2.SelectedIndex];
            TimeSpan time2 = new TimeSpan(a2.Item1, a2.Item2, a2.Item3);
            DateTime date2 = datee + time2;

            //izabrani doktor
            string doctorUsername = Combo3.SelectedItem.ToString();
            Doctor doctor = new Doctor();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctorUsername == doctors[i].Username)
                {
                    doctor = doctors[i];
                    break;
                }
            }

            List<DateTime> newDates = new List<DateTime>();
            DateTime newDate = new DateTime();
            //DateTime dateee = new DateTime(2000, 12, 30, 15, 10, 00);

            //prolazim kroz sve dane u opsegu
            //newDates.Add(date1);
            //newDates.Add(date2);
            for (int j = 0; j < (date2 - date1).TotalDays + 1; j++)
            {
                //newDates.Add(dateee);
                //prolazim kroz sve termine jednog dana
                for (int i = 0; i < appointment1.Count; i++)
                {
                    bool okDate = true;
                    newDate = date1.Date.AddDays(j) + new TimeSpan(appointment1[i].Item1, appointment1[i].Item2, appointment1[i].Item3);
                    //provera da li datum odgovara doktoru
                    for (int k = 0; k < doctor.Scheduled.Count; k++)
                    {
                        if (newDate == doctor.Scheduled[k])
                        {
                            okDate = false;
                        }
                    }
                    //proveri da li datum odgovara sobi
                    bool roomIsFree = true;
                    rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
                    for (int ii = 0; ii < rooms.Count; ii++)
                    {
                        roomIsFree = true;
                        //ako je null znaci da je slobodna i izadji iz petlje
                        if (rooms[ii].Scheduled == null)
                        {
                            roomIndex = ii;
                            break;
                        }
                        for (int jj = 0; jj < rooms[ii].Scheduled.Count; jj++)
                        {
                            if (rooms[ii].Scheduled[jj] == newDate)
                            {
                                roomIsFree = false;
                            }
                        }
                        if (roomIsFree == true)
                        {
                            roomIndex = ii;
                            break;
                        }
                    }
                    if (okDate == true && roomIsFree == true && newDate <= date2 && newDate >= date1) newDates.Add(newDate);
                }
            }


            for (int i = 0; i < newDates.Count; i++)
            {
                Combo4.Items.Add(newDates[i].ToString());
            }

            //altermativni termini u zavisnosti od prioriteta, samo ako nema nijedan termin u prvobitno izabranom opsegu za doktora
            if (newDates.Count == 0)
            {
                //gleda 3 dana unapred i unazad od izabranog opsega i nudi te termine
                if (priorityDoctor.IsChecked == true)
                {
                    //3 dana unapred
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < appointment1.Count; i++)
                        {
                            bool okDate = true;
                            newDate = date2.Date.AddDays(j) + new TimeSpan(appointment1[i].Item1, appointment1[i].Item2, appointment1[i].Item3);
                            //provera da li datum odgovara doktoru
                            for (int k = 0; k < doctor.Scheduled.Count; k++)
                            {
                                if (newDate == doctor.Scheduled[k])
                                {
                                    okDate = false;
                                }
                            }
                            //proveri da li datum odgovara sobi
                            bool roomIsFree = true;
                            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
                            for (int ii = 0; ii < rooms.Count; ii++)
                            {
                                roomIsFree = true;
                                //ako je null znaci da je slobodna i izadji iz petlje
                                if (rooms[ii].Scheduled == null)
                                {
                                    roomIndex = ii;
                                    break;
                                }
                                for (int jj = 0; jj < rooms[ii].Scheduled.Count; jj++)
                                {
                                    if (rooms[ii].Scheduled[jj] == newDate)
                                    {
                                        roomIsFree = false;
                                    }
                                }
                                if (roomIsFree == true)
                                {
                                    roomIndex = ii;
                                    break;
                                }
                            }
                            if (okDate == true && roomIsFree == true && newDate > date2) newDates.Add(newDate);
                        }
                    }
                    //3 dana unazad
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < appointment1.Count; i++)
                        {
                            bool okDate = true;
                            newDate = date2.Date.AddDays(-j) + new TimeSpan(appointment1[i].Item1, appointment1[i].Item2, appointment1[i].Item3);
                            //provera da li datum odgovara doktoru
                            for (int k = 0; k < doctor.Scheduled.Count; k++)
                            {
                                if (newDate == doctor.Scheduled[k])
                                {
                                    okDate = false;
                                }
                            }
                            //proveri da li datum odgovara sobi
                            bool roomIsFree = true;
                            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
                            for (int ii = 0; ii < rooms.Count; ii++)
                            {
                                roomIsFree = true;
                                //ako je null znaci da je slobodna i izadji iz petlje
                                if (rooms[ii].Scheduled == null)
                                {
                                    roomIndex = ii;
                                    break;
                                }
                                for (int jj = 0; jj < rooms[ii].Scheduled.Count; jj++)
                                {
                                    if (rooms[ii].Scheduled[jj] == newDate)
                                    {
                                        roomIsFree = false;
                                    }
                                }
                                if (roomIsFree == true)
                                {
                                    roomIndex = ii;
                                    break;
                                }
                            }
                            if (okDate == true && roomIsFree == true && newDate < date1 && newDate > DateTime.Now) newDates.Add(newDate);
                        }
                    }
                    newDates.Sort((x, y) => DateTime.Compare(x, y));
                    //newDates = newDates.Sort((a, b) => a.CompareTo(b));
                    for (int i = 0; i < newDates.Count; i++)
                    {
                        Combo4.Items.Add(newDates[i].ToString());
                    }
                }
                else if (priorityTime.IsChecked == true)
                {
                    for (int m = 0; m < doctors.Count; m++)
                    {
                        doctor = doctors[m];
                        for (int j = 0; j < (date2 - date1).TotalDays + 1; j++)
                        {
                            //newDates.Add(dateee);
                            //prolazim kroz sve termine jednog dana
                            for (int i = 0; i < appointment1.Count; i++)
                            {
                                bool okDate = true;
                                newDate = date1.Date.AddDays(j) + new TimeSpan(appointment1[i].Item1, appointment1[i].Item2, appointment1[i].Item3);
                                //provera da li datum odgovara doktoru
                                for (int k = 0; k < doctor.Scheduled.Count; k++)
                                {
                                    if (newDate == doctor.Scheduled[k])
                                    {
                                        okDate = false;
                                    }
                                }
                                //proveri da li datum odgovara sobi
                                bool roomIsFree = true;
                                rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
                                for (int ii = 0; ii < rooms.Count; ii++)
                                {
                                    roomIsFree = true;
                                    //ako je null znaci da je slobodna i izadji iz petlje
                                    if (rooms[ii].Scheduled == null)
                                    {
                                        roomIndex = ii;
                                        break;
                                    }
                                    for (int jj = 0; jj < rooms[ii].Scheduled.Count; jj++)
                                    {
                                        if (rooms[ii].Scheduled[jj] == newDate)
                                        {
                                            roomIsFree = false;
                                        }
                                    }
                                    if (roomIsFree == true)
                                    {
                                        roomIndex = ii;
                                        break;
                                    }
                                }
                                if (okDate == true && roomIsFree == true && newDate <= date2 && newDate >= date1) newDates.Add(newDate);
                            }
                        }
                        if (newDates.Count > 0) break;
                    }
                    for (int i = 0; i < newDates.Count; i++)
                    {
                        Combo4.Items.Add(newDates[i].ToString());
                        //Combo4.Items.Add(newDates[i].ToString() + ", " + doctor.Username);
                    }
                }
            }
        }

        private void ButtonOkCombo_Click(object sender, RoutedEventArgs e)
        {
            String stringDate = Combo4.SelectedItem.ToString();
            DateTime dateForExamination = DateTime.Parse(stringDate);

            //generisem unikatan id za pregled
            //radi tako sto jednom ucitam sve preglede i nadjem najveci id pa nakon toga samo dodeljujem za po jedan br veci
            List<Examination> examinations = m.Examinations;
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

            //bool isFree = true;
            WorkWithFiles.FilesDoctor doc = new WorkWithFiles.FilesDoctor();
            //List<Doctor> doctors = doc.LoadFromFile();
            int index = Combo3.SelectedIndex;

            s2 = doctors[index].Username;
            doctors[index].Scheduled.Add(dateForExamination);
            doc.WriteInFile(doctors);
            Examination ex = new Examination(mw.EnteredUsername, s2, "101", dateForExamination, (idExamination + 1).ToString());
            controller.ScheduleExamination(ex);
            w.UpdateView();
            Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            //zakazivanje za kt2
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
            for (int i = 0; i < 13; i++)
            {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime d = date + time;

            //generisem unikatan id za pregled
            //radi tako sto jednom ucitam sve preglede i nadjem najveci id pa nakon toga samo dodeljujem za po jedan br veci
            List<Examination> examinations = m.Examinations;
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
            //bool sched = false;
            WorkWithFiles.FilesDoctor doc = new WorkWithFiles.FilesDoctor();
            List<Doctor> doctors = doc.LoadFromFile();
            /*for (int i = 0; i < doctors.Count; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, doctors.Count);
                isFree = true;
                for (int j = 0; j < doctors[index].Scheduled.Count; j++)
                {
                    if (doctors[index].Scheduled[j] == d)
                    {
                        isFree = false;
                    }
                }
                if (isFree)
                {
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
            }*/

            //provera da li je termin slobodan za pacijenta
            /*FilesExamination fe = new FilesExamination();
            List<Examination> examinationss = fe.LoadFromFile();
            bool patientIsFree = true;
            for (int i = 0; i < examinationss.Count; i++) {
                if (examinationss[i].PatientsId == l.Username.Text && examinationss[i].ExaminationStart == d) {
                    patientIsFree = false;
                    break;
                }
            }*/

            //proveri da li je termin slobodan za izabranog lekara
            int index = Combo3.SelectedIndex;
            for (int j = 0; j < doctors[index].Scheduled.Count; j++)
            {
                if (doctors[index].Scheduled[j] == d)
                {
                    isFree = false;
                }
            }

            bool roomIsFree = false;
            int roomIndex = 0;
            //proveri da li postoji slobodna soba
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
            for (int i = 0; i < rooms.Count; i++) {
                //ako je null znaci da je slobodna i izadji iz petlje
                if (rooms[i].Scheduled == null) {
                    roomIsFree = true;
                    roomIndex = i;
                    break;
                }
                bool ok = true;
                for (int j = 0; j < rooms[i].Scheduled.Count; j++) {
                    if (rooms[i].Scheduled[j] == d) {
                        ok = false;
                    }
                }
                if (ok == true) {
                    roomIsFree = true;
                    roomIndex = i;
                    break;
                }
            }

            if (isFree && roomIsFree)
            {
                //dodavanje termina doktoru
                s2 = doctors[index].Username;
                doctors[index].Scheduled.Add(d);
                doc.WriteInFile(doctors);
                //dodavanje termina sobi, ako je null prvo inicijalizovati niz datuma
                if (rooms[roomIndex].Scheduled == null)
                {
                    rooms[roomIndex].Scheduled = new List<DateTime>();
                }
                //ne znam zasto ali kad se datum doda u Listu datetime u json za rooms, datum se pomeri za 2 sata unazad, pa moram rucno da dodam sate
                rooms[roomIndex].Scheduled.Add(d.AddHours(2));
                SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
                //dodavanje pregleda
                Examination ex = new Examination(mw.EnteredUsername, s2, rooms[roomIndex].RoomId.ToString(), d, (idExamination + 1).ToString());
                controller.ScheduleExamination(ex);
                w.UpdateView();
            }
            else
            {
                MessageBox.Show("There is no free term. Choose another time.");
                Close();
                return;
            }

            Close();
        }
    }
}
