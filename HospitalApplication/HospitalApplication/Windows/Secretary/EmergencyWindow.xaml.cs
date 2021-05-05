using HospitalApplication.Controller;
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
        private SecretaryController secretaryController = new SecretaryController();
        private PatientController patientController = new PatientController();
        private WorkWithFiles.FilesDoctor filesDoctor = new WorkWithFiles.FilesDoctor();
        private ExaminationService examinationService = ExaminationService.Instance;
        private List<Doctor> doctors = new List<Doctor>();
        private List<Doctor> filteredDoctors = new List<Doctor>();
        private List<Room> rooms = new List<Room>();
        private List<Examination> examinations = new List<Examination>();
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
            isFreeRoom = patientController.RoomIsFree(GetTheClosestAppointment());
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
            selectedPatient = secretaryController.getPatient(idPatient);
            doctors = filesDoctor.LoadFromFile();
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
            examinations = examinationService.Examinations;
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
            isFreeRoom = patientController.RoomIsFree(selectedSheduledDateTime);
            ScheduleAppointment(selectedSheduledDateTime);
            Close();
        }

        private void ScheduleAppointment(DateTime selectedSheduledDateTime)
        {
            AddDateTimeInSheduleDoctorAndRoom(selectedSheduledDateTime);
            Examination examination = new Examination(selectedPatient.Username, ComboAvailableDoctors.Text, rooms[isFreeRoom.Item2].RoomId.ToString(),
                                                      selectedSheduledDateTime, (GenerateExaminationId() + 1).ToString(), 0, defaultValueOfPostpone);
            examinationService.ScheduleExamination(examination);
        }

        private void AddDateTimeInSheduleDoctorAndRoom(DateTime selectedDateTime)
        {
            doctors[Int32.Parse(GetDoctorID(ComboAvailableDoctors.Text))].Scheduled.Add(selectedDateTime);
            filesDoctor.WriteInFile(doctors);
            rooms[isFreeRoom.Item2].Scheduled.Add(selectedDateTime);
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }

        private void MoveAppointment(Examination examination, DateTime selectedDateTime)
        {
            DateTime newDate = selectedDateTime.AddDays(examination.PostponeAppointment);
            examination.PostponeAppointment = defaultValueOfPostpone;
            isFreeRoom = patientController.RoomIsFree(newDate);
            patientController.UpdateDoctors();
            if (IsFreeDoctorAndRoom(examination, newDate)){
                AddAndDeleteExaminationFromDoctorAndRoom(examination, newDate);
                patientController.MoveAppointment(examination.ExaminationId, newDate, isFreeRoom.Item2);
            }
        }

        private bool IsFreeDoctorAndRoom(Examination examination, DateTime newDate)
        {
            return (patientController.DoctorIsFree(examination.DoctorsId, newDate) == true && isFreeRoom.Item1 == true);
        }

        private void AddAndDeleteExaminationFromDoctorAndRoom(Examination examination, DateTime newDate)
        {
            patientController.RemoveExaminationFromDoctor(examination.DoctorsId, examination.ExaminationStart);
            patientController.AddExaminationToDoctor(examination.DoctorsId, newDate);
            patientController.RemoveExaminationFromRoom(examination.RoomId, examination.ExaminationStart);
            patientController.AddExaminationToRoom(isFreeRoom.Item2, newDate);
        }

        private void SheduleFreeAppointment()
        {
            AddDateTimeInSheduleDoctorAndRoom(GetTheClosestAppointment());
            Examination examination = new Examination(selectedPatient.Username, ComboAvailableDoctors.Text, rooms[isFreeRoom.Item2].RoomId.ToString(),
                                                      GetTheClosestAppointment(), (GenerateExaminationId() + 1).ToString(), 0, defaultValueOfPostpone);
            examinationService.ScheduleExamination(examination);
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
                    if (doctors[i].DoctorType.Equals(DoctorType.cardiology) && IsAvailableFiltredDoctors(Int32.Parse(doctors[i].DoctorId)))
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
                    if (doctors[i].DoctorType.Equals(DoctorType.surgery) && IsAvailableFiltredDoctors(Int32.Parse(doctors[i].DoctorId)))
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

        private bool IsAvailableFiltredDoctors(int idDoctor)
        {
            for (int i = 0; i < doctors[idDoctor].Scheduled.Count; i++)
            {
                if (doctors[idDoctor].Scheduled[i] == GetTheClosestAppointment()) {
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
                    return idDoctor = doctors[i].DoctorId;
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

        private Examination GetExamination(DateTime dateTime)
        {
            Examination examination = new Examination();
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
