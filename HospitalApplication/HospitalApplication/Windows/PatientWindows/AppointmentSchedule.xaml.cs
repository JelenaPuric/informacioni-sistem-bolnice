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
using HospitalApplication.WorkWithFiles;
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
        private AppointmentService examinationService = AppointmentService.Instance;
        private AppointmentController controller = new AppointmentController();
        private string doctorsUsername;
        private WindowPatient windowPatient = WindowPatient.Instance;
        private int idExamination = 100000;
        private MainWindow mainWindow = MainWindow.Instance;
        private List<Doctor> doctors = new List<Doctor>();
        private List<Room> rooms = new List<Room>();
        private List<Appointment> examinations = new List<Appointment>();
        private int roomIndex = 0;
        private List<DateTime> newDates = new List<DateTime>();
        private List<(int, int, int)> term = new List<(int, int, int)>();

        public WindowExaminationSchedule()
        {
            InitializeComponent();
            GenerateTerms();
            doctors = examinationService.Doctors;
            rooms = examinationService.Rooms;
            examinations = examinationService.Examinations;
            for (int i = 0; i < doctors.Count; i++)
                Combo3.Items.Add(doctors[i].Username.ToString());
        }

        private void ButtonOkFilters_Click(object sender, RoutedEventArgs e)
        {
            Combo4.Items.Clear();
            DateTime date1 = GetDateAndTimeFromForm(Date.SelectedDate.Value.Date, Combo);
            DateTime date2 = GetDateAndTimeFromForm(Date2.SelectedDate.Value.Date, Combo2);
            GetFreeAppointments(date1, date2, term);
            if (newDates.Count > 0) return;
            if (priorityDoctor.IsChecked == true) GetAlternativeAppointmentsForDoctor(date1, date2, term);
            else if(priorityTime.IsChecked == true) GetAlternativeAppointmentsForTime(date1, date2, term);
        }

        private void ButtonOkCombo_Click(object sender, RoutedEventArgs e)
        {
            doctorsUsername = doctors[Combo3.SelectedIndex].Username;
            string stringDate = Combo4.SelectedItem.ToString();
            string[] splitDate = stringDate.Split(",");
            if (splitDate.Length == 2)
            {
                stringDate = splitDate[0];
                doctorsUsername = splitDate[1];
            }
            DateTime newDate = DateTime.Parse(stringDate);
            GenerateExaminationId();
            Appointment appointment = new Appointment(mainWindow.PatientsUsername, doctorsUsername, rooms[roomIndex].RoomId.ToString(), newDate, (idExamination + 1).ToString(), 0, Int32.Parse(textBox111.Text));
            controller.ScheduleExamination(appointment);
            windowPatient.UpdateView();
            Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate = GetDateAndTimeFromForm(Date.SelectedDate.Value.Date, Combo);
            GenerateExaminationId();
            Appointment appointment = new Appointment(mainWindow.PatientsUsername, doctors[Combo3.SelectedIndex].Username, "0", newDate, (idExamination + 1).ToString(), 0, Int32.Parse(textBox111.Text));
            controller.ScheduleExamination(appointment);
            windowPatient.UpdateView();
            Close();
        }

        private DateTime GetDateAndTimeFromForm(DateTime date, ComboBox Combo)
        {
            List<(int, int, int)> times = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++){
                times.Add((7 + i, 0, 0)); 
                times.Add((7 + i, 30, 0));
            }
            (int, int, int) time = times[Combo.SelectedIndex];
            TimeSpan timeSpan = new TimeSpan(time.Item1, time.Item2, time.Item3);
            return date + timeSpan;
        }

        //premesti u FIleExamination nakon sto tamo budu podaci
        private int GenerateExaminationId()
        {
            if (idExamination == 100000)
                for (int i = 0; i < examinations.Count; i++)
                    idExamination = Math.Max(idExamination, Int32.Parse(examinations[i].ExaminationId));
            return idExamination;
        }

        private void GetFreeAppointments(DateTime date1, DateTime date2, List<(int, int, int)> term) {
            Doctor selectedDoctor = FileDoctors.GetDoctor(Combo3.SelectedItem.ToString());
            DateTime newDate;
            for (int i = 0; i < (date2 - date1).TotalDays + 1; i++)
            {
                for (int j = 0; j < term.Count; j++)
                {
                    newDate = date1.Date.AddDays(i) + new TimeSpan(term[j].Item1, term[j].Item2, term[j].Item3);
                    Tuple<bool, int> roomIsFree = controller.IsRoomFree(newDate);
                    roomIndex = roomIsFree.Item2;
                    controller.UpdateDoctors();
                    if (controller.IsDoctorFree(selectedDoctor.Username, newDate) == true && roomIsFree.Item1 == true && newDate <= date2 && newDate >= date1){
                        newDates.Add(newDate);
                        Combo4.Items.Add(newDates[i].ToString());
                    }
                }
            }
        }

        private void GetAlternativeAppointmentsForDoctor(DateTime date1, DateTime date2, List<(int, int, int)> term) {
            Doctor selectedDoctor = FileDoctors.GetDoctor(Combo3.SelectedItem.ToString());
            if (priorityDoctor.IsChecked == true)
            {
                DateTime newDate = new DateTime();
                //3 dana unapred
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < term.Count; i++)
                    {
                        newDate = date2.Date.AddDays(j) + new TimeSpan(term[i].Item1, term[i].Item2, term[i].Item3);
                        Tuple<bool, int> roomIsFree = controller.IsRoomFree(newDate);
                        roomIndex = roomIsFree.Item2;
                        controller.UpdateDoctors();
                        if (controller.IsDoctorFree(selectedDoctor.Username, newDate) == true && roomIsFree.Item1 == true && newDate > date2)
                            newDates.Add(newDate);
                    }
                }
                //3 dana unazad
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < term.Count; i++)
                    {
                        newDate = date2.Date.AddDays(-j) + new TimeSpan(term[i].Item1, term[i].Item2, term[i].Item3);
                        Tuple<bool, int> roomIsFree = controller.IsRoomFree(newDate);
                        roomIndex = roomIsFree.Item2;
                        controller.UpdateDoctors();
                        if (controller.IsDoctorFree(selectedDoctor.Username, newDate) == true && roomIsFree.Item1 == true && newDate < date1 && newDate > DateTime.Now)
                            newDates.Add(newDate);
                    }
                }
                newDates.Sort((x, y) => DateTime.Compare(x, y));
                for (int i = 0; i < newDates.Count; i++)
                    Combo4.Items.Add(newDates[i].ToString());
            }
        }

        private void GetAlternativeAppointmentsForTime(DateTime date1, DateTime date2, List<(int, int, int)> time) {
            Doctor doctor;
            DateTime newDate;
            for (int doctorsIndex = 0; doctorsIndex < doctors.Count; doctorsIndex++)
            {
                doctor = doctors[doctorsIndex];
                for (int j = 0; j < (date2 - date1).TotalDays + 1; j++)
                {
                    for (int i = 0; i < time.Count; i++)
                    {
                        newDate = date1.Date.AddDays(j) + new TimeSpan(time[i].Item1, time[i].Item2, time[i].Item3);
                        Tuple<bool, int> roomIsFree = controller.IsRoomFree(newDate);
                        roomIndex = roomIsFree.Item2;
                        controller.UpdateDoctors();
                        if (controller.IsDoctorFree(doctor.Username, newDate) == true && roomIsFree.Item1 == true && newDate <= date2 && newDate >= date1)
                        {
                            newDates.Add(newDate);
                            Combo4.Items.Add(newDate.ToString() + "," + doctor.Username);
                        }
                    }
                }
            }
        }

        private void GenerateTerms() {
            for (int i = 0; i < 13; i++){
                term.Add((7 + i, 0, 0));
                term.Add((7 + i, 30, 0));
            }
        }
    }
}
