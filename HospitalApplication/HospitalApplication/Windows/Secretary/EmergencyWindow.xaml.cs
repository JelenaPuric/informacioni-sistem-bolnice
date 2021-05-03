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
        private Patient patient;
        private int idExamination = 100000;
        Tuple<bool, int> isFreeRoom;


        public EmergencyWindow(string idPatient)
        {
            InitializeComponent();
            CenterWindow();
            LoadPatientDoctorsAndRooms(idPatient);
        }

        private DateTime TimeForAppointment()
        {
            if (DateTime.Now.Minute < 30)
            {
                // dodaj +30 minuta
                TimeSpan timeAppointment = new TimeSpan(DateTime.Now.Hour, 30, 0);
                return DateTime.Today + timeAppointment;
            }
            else
            {
                // povecaj hour za 1
                TimeSpan timeAppointment = new TimeSpan(DateTime.Now.Hour + 1, 0, 0);
                return DateTime.Today + timeAppointment;
            }
        }

        private void LoadPatientDoctorsAndRooms(string idPatient)
        {
            patient = secretaryController.getPatient(idPatient);
            doctors = filesDoctor.LoadFromFile();
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
            examinations = examinationService.Examinations;
            examinations.Sort();
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

        //Uraditi da pacijent ne moze da zakaze u isto vrijeme kod 2 ili vise doktora!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (ComboFreeTerms.SelectedIndex == -1) {
                SheduleOnBusyAppointment();
                Close();
            }
            else
            {
                SheduleFreeAppointment();
                Close();
            }

            Close();
        }

        private void SheduleOnBusyAppointment()
        {
            DateTime selectedSheduledDate = DateTime.Parse(ComboSheduledTerms.SelectedItem.ToString());
            //Examination e = GetExamination(selectedSheduledDate);
            MoveExamination(GetExamination(selectedSheduledDate), selectedSheduledDate);
            RoomIsFree(selectedSheduledDate);

            doctors[Int32.Parse(getDoctorID(ComboAvailableDoctors.Text))].Scheduled.Add(selectedSheduledDate);
            filesDoctor.WriteInFile(doctors);

            // pitati kako da izbegnem ovaj if
            if (rooms[isFreeRoom.Item2].Scheduled == null)
            {
                rooms[isFreeRoom.Item2].Scheduled = new List<DateTime>();
            }
          
            rooms[isFreeRoom.Item2].Scheduled.Add(selectedSheduledDate);
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
          
            Examination examination = new Examination(patient.Username, ComboAvailableDoctors.Text, rooms[isFreeRoom.Item2].RoomId.ToString(),
                                                        selectedSheduledDate, GenerateExaminationId().ToString(), 0, 1000);
            examinationService.ScheduleExamination(examination);
            Close();
        }

        private void MoveExamination(Examination examination, DateTime selectedDateTime)
        {
            DateTime oldDate = examination.ExaminationStart;
            DateTime newDate = selectedDateTime.AddDays(examination.PostponeAppointment);
            examination.PostponeAppointment = 1000;

            Tuple<bool, int> roomIsFree = patientController.RoomIsFree(newDate);
            patientController.UpdateDoctors();
            if (patientController.DoctorIsFree(examination.DoctorsId, newDate) == true && roomIsFree.Item1 == true)
            {
                patientController.RemoveExaminationFromDoctor(examination.DoctorsId, oldDate);
                patientController.AddExaminationToDoctor(examination.DoctorsId, newDate);
                patientController.RemoveExaminationFromRoom(examination.RoomId, oldDate);
                patientController.AddExaminationToRoom(roomIsFree.Item2, newDate);
                patientController.MoveExamination(examination.ExaminationId, newDate, roomIsFree.Item2);
            }
            else
            {
                MessageBox("Choosen term is not free. Choose another one.");
                return;
            }
            Close();
        }

        private void SheduleFreeAppointment()
        {
                doctors[Int32.Parse(getDoctorID(ComboAvailableDoctors.Text))].Scheduled.Add(TimeForAppointment());
                filesDoctor.WriteInFile(doctors);

                // pitati kako da izbegnem ovaj if
                if (rooms[isFreeRoom.Item2].Scheduled == null)
                {
                    rooms[isFreeRoom.Item2].Scheduled = new List<DateTime>();
                }

                rooms[isFreeRoom.Item2].Scheduled.Add(TimeForAppointment());
                SerializationAndDeserilazationOfRooms.EnterRoom(rooms);

                Examination examination = new Examination(patient.Username, ComboAvailableDoctors.Text, rooms[isFreeRoom.Item2].RoomId.ToString(),
                                                          TimeForAppointment(), GenerateExaminationId().ToString(), 0, 1000);
                examinationService.ScheduleExamination(examination);
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            //isFreeRoam je stalno true, iako ne bi trebao da bude
            isFreeRoom = RoomIsFree(TimeForAppointment()); 
            if ( isFreeRoom.Item1 && FilterDoctors() ){ MessageBox("Imamo slobodan termin u najblizem roku!"); } 
            else
            {
                if(isFreeRoom.Item1 == false) { MessageBox("Soba je zauzeta!!!"); };
                if(FilterDoctors() == false) { MessageBox("Nema slobodnih doktora za taj termin!!!") };


                ClearComboBoxes();
                DoctorType typeDoctor = (DoctorType)Enum.Parse(typeof(DoctorType), ComboTypeDoctor.Text);
                for (int i = 0; i < examinations.Count; i++)
                {
                    ComboSheduledTerms.Items.Add(examinations[i].ExaminationStart.ToString());
                    if (!ComboAvailableDoctors.Items.Contains(examinations[i].DoctorsId) && getDoctor(examinations[i].DoctorsId).DoctorType.Equals(typeDoctor))
                    {
                        ComboAvailableDoctors.Items.Add(examinations[i].DoctorsId);
                    }
                }
            }
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
                        ComboFreeTerms.Items.Add(TimeForAppointment());
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
                        ComboFreeTerms.Items.Add(TimeForAppointment());
                    }
                }
                return IsEmptyFiltredDoctors();
            }
            return true;
        }

        private bool IsEmptyFiltredDoctors()
        {
            if (filteredDoctors.Count == 0)
            {
                return false;
            }
            return true;
        }

        private bool IsAvailableFiltredDoctors(int idDoctor)
        {
            for (int i = 0; i < doctors[idDoctor].Scheduled.Count; i++)
            {
                if (doctors[idDoctor].Scheduled[i] == TimeForAppointment()) 
                {
                    return false;
                }
            }
            return true;
        }

        private Tuple<bool, int> RoomIsFree(DateTime dateTime)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                bool roomIsFree = true;
                for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                {
                    if (rooms[i].Scheduled[j] == dateTime)
                        roomIsFree = false;
                }
                if (roomIsFree)
                    return new Tuple<bool, int>(true, i);
            }
            return new Tuple<bool, int>(false, -1);
        }

        private string getDoctorID(string doctorUsername)
        {
            string idDoctor = "";
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username.Equals(doctorUsername))
                {
                    return idDoctor = doctors[i].DoctorId;
                }
            }
            return idDoctor;
        }

        private Doctor getDoctor(string idDoctor)
        {
            Doctor doctor = new Doctor();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username.Equals(idDoctor))
                {
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
                if (examinations[i].ExaminationStart.Equals(dateTime))
                {
                    return examination = examinations[i];
                }
            }
            return examination;
        }

        private int GenerateExaminationId()
        {
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
