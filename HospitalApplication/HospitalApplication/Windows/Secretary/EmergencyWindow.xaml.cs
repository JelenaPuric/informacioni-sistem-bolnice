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
        private SecretaryController sc = new SecretaryController();
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

            //     DateTime today = DateTime.Today;
            // ComboTypeDoctor.Text = "cardiology";

            //DoctorType doctorType = (DoctorType)Enum.Parse(typeof(DoctorType), ComboTypeDoctor.Text);

            //DateTime d = DateTime.Now;


            // TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            // DateTime d = date + time;



        }

        private DateTime TimeForAppointment()
        {
            DateTime dateAndTimeAppointment;
            if (DateTime.Now.Minute < 30)
            {
                // dodaj +30 minuta
                TimeSpan timeAppointment = new TimeSpan(DateTime.Now.Hour, 30, 0);
                return dateAndTimeAppointment = DateTime.Today + timeAppointment;
            }
            else
            {
                // povecaj hour za 1
                TimeSpan timeAppointment = new TimeSpan(DateTime.Now.Hour + 1, 0, 0);
                return dateAndTimeAppointment = DateTime.Today + timeAppointment;
            }
        }

        private void LoadPatientDoctorsAndRooms(string idPatient)
        {
            patient = sc.getPatient(idPatient);
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

        //Uraditi da pacijent ne moze da zakaze u isto vrijeme kod 2 ili vise doktora!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            SheduleAppointment();
            Close();
        }

        private void SheduleAppointment()
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
                                                      TimeForAppointment(), GenerateExaminationId().ToString(), 0, "");
            examinationService.ScheduleExamination(examination);
        }

        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            isFreeRoom = roomIsFree();
            if(isFreeRoom.Item1)
            {
                FilterDoctors();
            }
        }

        private void FilterDoctors()
        {
            ComboAvailableDoctors.Items.Clear();
            ComboFreeTerms.Items.Clear();
            if (ComboTypeDoctor.Text == DoctorType.cardiology.ToString())
            {
                for (int i = 0; i < doctors.Count; i++)
                {
                    if (doctors[i].DoctorType.Equals(DoctorType.cardiology) && IsAvailableFiltredDoctors(Int32.Parse(doctors[i].DoctorId)))
                    {
                        ComboAvailableDoctors.Items.Add(doctors[i].Username.ToString());
                        filteredDoctors.Add(doctors[i]); // nije potrebno ali neka ih za sada
                        ComboFreeTerms.Items.Add(TimeForAppointment().Hour + ":" + TimeForAppointment().Minute);
                    }
                }
            }
            else if (ComboTypeDoctor.Text == DoctorType.surgery.ToString())
            {
                for (int i = 0; i < doctors.Count; i++)
                {
                    if (doctors[i].DoctorType.Equals(DoctorType.surgery) && IsAvailableFiltredDoctors(Int32.Parse(doctors[i].DoctorId)))
                    {
                        ComboAvailableDoctors.Items.Add(doctors[i].Username.ToString());
                        filteredDoctors.Add(doctors[i]); // nije potrebno ali neka ih za sada
                        ComboFreeTerms.Items.Add(TimeForAppointment().Hour + ":" + TimeForAppointment().Minute);
                    }
                }
            }
           // return filteredDoctors; // nije potrebno ali neka ih za sada
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

        private Tuple<bool, int> roomIsFree()
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                bool roomIsFree = true;
                for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                {
                    if (rooms[i].Scheduled[j] == TimeForAppointment())
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
