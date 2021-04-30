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
        private string doctorsUsername;
        private WindowPatient windowPatient = WindowPatient.Instance;
        private int idExamination = 100000;
        private MainWindow mainWindow = MainWindow.Instance;
        private List<Doctor> doctors = new List<Doctor>();
        private List<Room> rooms = new List<Room>();
        private List<Examination> examinations = new List<Examination>();
        private int roomIndex = 0;

        public WindowExaminationSchedule()
        {
            InitializeComponent();
            doctors = m.Doctors;
            rooms = m.Rooms;
            examinations = m.Examinations;
            for (int i = 0; i < doctors.Count; i++)
                Combo3.Items.Add(doctors[i].Username.ToString());
        }

        private void ButtonOkFilters_Click(object sender, RoutedEventArgs e)
        {
            Combo4.Items.Clear();
            //ovde ima jedan bug, uvek ce uzimati time iz prvog comba
            DateTime date1 = GetDateAndTimeFromForm(Date.SelectedDate.Value.Date);
            DateTime date2 = GetDateAndTimeFromForm(Date2.SelectedDate.Value.Date);

            List<(int, int, int)> time = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                time.Add((7 + i, 0, 0));
                time.Add((7 + i, 30, 0));
            }

            string selectedDoctorUsername = Combo3.SelectedItem.ToString();
            Doctor selectedDoctor = new Doctor();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (selectedDoctorUsername == doctors[i].Username)
                {
                    selectedDoctor = doctors[i];
                    break;
                }
            }

            List<DateTime> newDates = new List<DateTime>();
            DateTime newDate = new DateTime();

            //prolazim kroz sve dane u opsegu
            for (int i = 0; i < (date2 - date1).TotalDays + 1; i++)
            {
                //prolazim kroz sve termine jednog dana
                for (int j = 0; j < time.Count; j++)
                {
                    newDate = date1.Date.AddDays(i) + new TimeSpan(time[j].Item1, time[j].Item2, time[j].Item3);
                    Tuple<bool, int> roomIsFree = controller.RoomIsFree(newDate);
                    roomIndex = roomIsFree.Item2;
                    controller.UpdateDoctors();
                    if (controller.DoctorIsFree(selectedDoctor.Username, newDate) == true && roomIsFree.Item1 == true && newDate <= date2 && newDate >= date1)
                        newDates.Add(newDate);
                }
            }
            for (int i = 0; i < newDates.Count; i++)
            {
                Combo4.Items.Add(newDates[i].ToString());
            }
            if (newDates.Count > 0) return;

            //alternativni termini u zavisnosti od prioriteta
            //gleda 3 dana unapred i unazad od izabranog opsega i nudi te termine
            if (priorityDoctor.IsChecked == true)
            {
                //3 dana unapred
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < time.Count; i++)
                    {
                        newDate = date2.Date.AddDays(j) + new TimeSpan(time[i].Item1, time[i].Item2, time[i].Item3);
                        Tuple<bool, int> roomIsFree = controller.RoomIsFree(newDate);
                        roomIndex = roomIsFree.Item2;
                        controller.UpdateDoctors();
                        if (controller.DoctorIsFree(selectedDoctor.Username, newDate) == true && roomIsFree.Item1 == true && newDate > date2)
                            newDates.Add(newDate);
                    }
                }
                //3 dana unazad
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < time.Count; i++)
                    {
                        newDate = date2.Date.AddDays(-j) + new TimeSpan(time[i].Item1, time[i].Item2, time[i].Item3);
                        Tuple<bool, int> roomIsFree = controller.RoomIsFree(newDate);
                        roomIndex = roomIsFree.Item2;
                        controller.UpdateDoctors();
                        if (controller.DoctorIsFree(selectedDoctor.Username, newDate) == true && roomIsFree.Item1 == true && newDate < date1 && newDate > DateTime.Now)
                            newDates.Add(newDate);
                    }
                }
                newDates.Sort((x, y) => DateTime.Compare(x, y));
                for (int i = 0; i < newDates.Count; i++)
                {
                    Combo4.Items.Add(newDates[i].ToString());
                }
            }
            else if (priorityTime.IsChecked == true)
            {
                for (int m = 0; m < doctors.Count; m++)
                {
                    selectedDoctor = doctors[m];
                    for (int j = 0; j < (date2 - date1).TotalDays + 1; j++)
                    {
                        //prolazim kroz sve termine jednog dana
                        for (int i = 0; i < time.Count; i++)
                        {
                            newDate = date1.Date.AddDays(j) + new TimeSpan(time[i].Item1, time[i].Item2, time[i].Item3);

                            Tuple<bool, int> roomIsFree = controller.RoomIsFree(newDate);
                            roomIndex = roomIsFree.Item2;
                            controller.UpdateDoctors();
                            if (controller.DoctorIsFree(selectedDoctor.Username, newDate) == true && roomIsFree.Item1 == true && newDate <= date2 && newDate >= date1)
                            {
                                newDates.Add(newDate);
                                Combo4.Items.Add(newDate.ToString() + "," + selectedDoctor.Username);
                            }
                        }
                    }
                }
            }
        }

        private void ButtonOkCombo_Click(object sender, RoutedEventArgs e)
        {
            int doctorsIndex = Combo3.SelectedIndex;
            doctorsUsername = doctors[doctorsIndex].Username;
            string stringDate = Combo4.SelectedItem.ToString();
            string[] splitDate = stringDate.Split(",");
            if (splitDate.Length == 2)
            {
                stringDate = splitDate[0];
                doctorsUsername = splitDate[1];
            }
            DateTime newDate = DateTime.Parse(stringDate);
            GenerateExaminationId();
            controller.AddExaminationToDoctor(doctorsUsername, newDate);
            controller.AddExaminationToRoom(roomIndex, newDate);
            Examination ex = new Examination(mainWindow.PatientsUsername, doctorsUsername, rooms[roomIndex].RoomId.ToString(), newDate, (idExamination + 1).ToString());
            controller.ScheduleExamination(ex);
            windowPatient.UpdateView();
            Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate = GetDateAndTimeFromForm(Date.SelectedDate.Value.Date);
            int selectedDoctorsIndex = Combo3.SelectedIndex;
            GenerateExaminationId();

            Tuple<bool, int> roomIsFree = controller.RoomIsFree(newDate);
            controller.UpdateDoctors();
            if (controller.DoctorIsFree(doctors[selectedDoctorsIndex].Username, newDate) && roomIsFree.Item1)
            {
                controller.AddExaminationToDoctor(doctors[selectedDoctorsIndex].Username, newDate);
                controller.AddExaminationToRoom(roomIsFree.Item2, newDate);
                Examination ex = new Examination(mainWindow.PatientsUsername, doctors[selectedDoctorsIndex].Username, rooms[roomIsFree.Item2].RoomId.ToString(), newDate, (idExamination + 1).ToString());
                controller.ScheduleExamination(ex);
                windowPatient.UpdateView();
                Close();
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }
        }

        private DateTime GetDateAndTimeFromForm(DateTime date)
        {
            //lista svih mogucih termina za pregled, kombijuje se sa date time pickerom, trojke oznacavaju sat/min/sekund
            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            return date + time;
        }

        private int GenerateExaminationId()
        {
            //radi tako sto jednom ucitam sve preglede i nadjem najveci id pa nakon toga samo dodeljujem za po jedan br veci
            //ako je idExamination 100000 znaci da ili ne postoji zakazan pregled ili nije nasao najveci id pregleda koji postoji
            if (idExamination == 100000)
            {
                for (int i = 0; i < examinations.Count; i++)
                {
                    if (Int32.Parse(examinations[i].ExaminationId) > idExamination)
                        idExamination = Int32.Parse(examinations[i].ExaminationId);
                }
            }
            return idExamination;
        }
    }
}
