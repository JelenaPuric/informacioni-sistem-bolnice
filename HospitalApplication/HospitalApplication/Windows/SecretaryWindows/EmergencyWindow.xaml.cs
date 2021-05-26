using HospitalApplication.Controller;
using HospitalApplication.Service;
using HospitalApplication.WorkWithFiles;
using Logic;
using Model;
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
using WorkWithFiles;

namespace HospitalApplication.Windows.Secretary
{
    public partial class EmergencyWindow : Window
    {
        private RoomService roomService = new RoomService();
        private SecretaryController secretaryController = new SecretaryController();
        private AppointmentController patientController = new AppointmentController();
        private WorkWithFiles.FileDoctors fileDoctors = FileDoctors.Instance;
        private AppointmentService appointmentService = new AppointmentService();
        private DoctorService doctorService = new DoctorService();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Doctor> filteredDoctors = new List<Doctor>();
        private List<Room> rooms = new List<Room>();
        private FileRooms fileRooms = FileRooms.Instance;
        private List<Appointment> examinations = new List<Appointment>();
        private Patient selectedPatient;
        private int idExamination = 100000;
        Tuple<bool, int> isFreeRoom;
        public const int defaultValueOfPostpone = 1000;


        public EmergencyWindow(string idPatient)
        {
            InitializeComponent();
            CenterWindow();
            LoadPatientsDoctorsRoomsAndExaminations(idPatient);
            examinations.Sort();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (ComboFreeTerms.SelectedIndex == -1){
                ScheduleAndMoveAppointment();
                Close();
            }
            else
            {
                if (HasTwoAppointmentAtTheSameDateTime())
                    SheduleFreeAppointment();
            }
            Close();
        }

        private bool HasTwoAppointmentAtTheSameDateTime()
        {
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationStart.Equals(GetTheClosestAppointment()) && examinations[i].PatientsId.Equals(selectedPatient.Username)){
                    MessageBox("Ne mozete zakazati 2 termina u isto vrijeme!");
                    return false;
                }
            }
            return true;
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            isFreeRoom = roomService.IsRoomFree(GetTheClosestAppointment());
            if (isFreeRoom.Item1 && FilterDoctors()) {
                MessageBox("Imamo slobodan termin u najblizem roku!"); 
            }
            else{
                ClearComboBoxes();
                AddScheduledAppointmentsAndDoctorsInComboBoxes();
            }
        }

        private void AddScheduledAppointmentsAndDoctorsInComboBoxes()
        {
            DoctorType typeDoctor = (DoctorType)Enum.Parse(typeof(DoctorType), ComboTypeDoctor.Text);
            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationStart >= DateTime.Now){
                    ComboSheduledTerms.Items.Add(examinations[i].ExaminationStart.ToString());
                }
                if (!ComboAvailableDoctors.Items.Contains(examinations[i].DoctorsId) && GetDoctor(examinations[i].DoctorsId).DoctorType.Equals(typeDoctor)){
                    ComboAvailableDoctors.Items.Add(examinations[i].DoctorsId);
                }
            }
        }

        private DateTime GetTheClosestAppointment()
        {
            if (DateTime.Now.Minute < 30){
                return DateTime.Today + new TimeSpan(DateTime.Now.Hour, 30, 0);
            }
            else{
                return DateTime.Today + new TimeSpan(DateTime.Now.Hour + 1, 0, 0);
            }
        }

        private void LoadPatientsDoctorsRoomsAndExaminations(string idPatient)
        {
            selectedPatient = secretaryController.GetPatient(idPatient);
            doctors = fileDoctors.GetDoctors();
            rooms = fileRooms.ShowAllRooms();
            examinations = appointmentService.appointments;
        }

        private void CenterWindow()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void ScheduleAndMoveAppointment()
        {
            DateTime selectedSheduledDateTime = DateTime.Parse(ComboSheduledTerms.SelectedItem.ToString());
            MoveAppointment(GetExamination(selectedSheduledDateTime), selectedSheduledDateTime);
            isFreeRoom = roomService.IsRoomFree(selectedSheduledDateTime);
            ScheduleAppointment(selectedSheduledDateTime);
            Close();
        }

        private void ScheduleAppointment(DateTime selectedSheduledDateTime)
        {
            AddDateTimeInSheduleDoctorAndRoom(selectedSheduledDateTime);
            Appointment examination = new Appointment(selectedPatient.Username, ComboAvailableDoctors.Text, rooms[isFreeRoom.Item2].RoomId.ToString(),
                                                      selectedSheduledDateTime, (GenerateExaminationId() + 1).ToString(), 0, defaultValueOfPostpone);
            appointmentService.ScheduleAppointment(examination);
        }

        private void AddDateTimeInSheduleDoctorAndRoom(DateTime selectedDateTime)
        {
            doctors[Int32.Parse(GetDoctorID(ComboAvailableDoctors.Text))].Scheduled.Add(selectedDateTime);
            fileDoctors.Write();
            rooms[isFreeRoom.Item2].Scheduled.Add(selectedDateTime);
            fileRooms.Write();
        }

        private void MoveAppointment(Appointment examination, DateTime selectedDateTime)
        {
            DateTime newDate = selectedDateTime.AddDays(examination.PostponeAppointment);
            examination.PostponeAppointment = defaultValueOfPostpone;
            isFreeRoom = roomService.IsRoomFree(newDate);
            if (IsFreeDoctorAndRoom(examination, newDate)){
                appointmentService.MoveAppointment(examination, newDate);
            }
        }

        private bool IsFreeDoctorAndRoom(Appointment examination, DateTime newDate)
        {
            return (doctorService.IsDoctorFree(examination.DoctorsId, newDate) == true && isFreeRoom.Item1 == true);
        }

        private void AddAndDeleteExaminationFromDoctorAndRoom(Appointment examination, DateTime newDate)
        {
            doctorService.RemoveAppointmentFromDoctor(examination.DoctorsId, examination.ExaminationStart);
            doctorService.AddAppointmentToDoctor(examination.DoctorsId, newDate);
            roomService.RemoveAppointmentFromRoom(examination.RoomId, examination.ExaminationStart);
            roomService.AddAppointmentToRoom(isFreeRoom.Item2, newDate);
        }

        private void SheduleFreeAppointment()
        {
            Appointment examination = new Appointment(selectedPatient.Username, ComboAvailableDoctors.Text, rooms[isFreeRoom.Item2].RoomId.ToString(),
                                                      GetTheClosestAppointment(), (GenerateExaminationId() + 1).ToString(), 0, defaultValueOfPostpone);

            patientController.ScheduleAppointment(examination); 
        }

        private System.Windows.MessageBoxResult MessageBox(string str)
        {
            return System.Windows.MessageBox.Show(str, "Info", MessageBoxButton.OK);
        }

        private void ClearComboBoxes()
        {
            ComboAvailableDoctors.Items.Clear();
            ComboFreeTerms.Items.Clear();
            ComboSheduledTerms.Items.Clear();
        }

        private bool FilterDoctors()
        {
            ClearComboBoxes();
            filteredDoctors.Clear();
            if (ComboTypeDoctor.Text == DoctorType.cardiology.ToString())
            {
                for (int i = 0; i < doctors.Count; i++)
                {
                    if (doctors[i].DoctorType.Equals(DoctorType.cardiology) && IsAvailableFiltredDoctors(doctors[i])) 
                    {
                        ComboAvailableDoctors.Items.Add(doctors[i].Username.ToString());
                        filteredDoctors.Add(doctors[i]); 
                        ComboFreeTerms.Items.Add(GetTheClosestAppointment());
                    }
                }
                return IsEmptyFiltredDoctors();
            }
            else if (ComboTypeDoctor.Text == DoctorType.surgery.ToString())
            {
                for (int i = 0; i < doctors.Count; i++)
                {
                    if (doctors[i].DoctorType.Equals(DoctorType.surgery) && IsAvailableFiltredDoctors(doctors[i]))
                    {
                        ComboAvailableDoctors.Items.Add(doctors[i].Username.ToString());
                        filteredDoctors.Add(doctors[i]); 
                        ComboFreeTerms.Items.Add(GetTheClosestAppointment());
                    }
                }
                return IsEmptyFiltredDoctors();
            }
            return true;
        }

        private bool IsEmptyFiltredDoctors()
        {
            return !(filteredDoctors.Count == 0);
        }

        private bool IsAvailableFiltredDoctors(Doctor selectedDoctor)
        {
            for (int i = 0; i < selectedDoctor.Scheduled.Count; i++)
            {
                if (selectedDoctor.Scheduled[i] == GetTheClosestAppointment()) {
                    return false;
                }
            }
            return true;
        }

        private string GetDoctorID(string doctorUsername)
        {
            string idDoctor = "";
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username.Equals(doctorUsername)){
                    return idDoctor = i.ToString(); 
                }
            }
            return idDoctor;
        }

        private Doctor GetDoctor(string idDoctor)
        {
            Doctor doctor = new Doctor();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username.Equals(idDoctor)){
                    return doctor = doctors[i];
                }
            }
            return doctor;
        }

        private Appointment GetExamination(DateTime dateTime)
        {
            Appointment examination = new Appointment();
            for(int i=0; i < examinations.Count; i++)
            {
                if (examinations[i].ExaminationStart.Equals(dateTime)){
                    return examination = examinations[i];
                }
            }
            return examination;
        }

        private int GenerateExaminationId()
        {
            for (int i = 0; i < examinations.Count; i++)
            {
                if (Int32.Parse(examinations[i].ExaminationId) > idExamination){
                    idExamination = Int32.Parse(examinations[i].ExaminationId);
                }
            }
            return idExamination;
        }
    }
}
