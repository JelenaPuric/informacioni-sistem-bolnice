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
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {


        private string s1, s2;
        private MainWindow mw = MainWindow.Instance;
        private PatientController patientController = new PatientController();

        private ExaminationManagement m = ExaminationManagement.Instance;
        private SerializationAndDeserilazationOfRooms r = new SerializationAndDeserilazationOfRooms();
        private WorkWithFiles.FilesDoctor fd = new WorkWithFiles.FilesDoctor();

        private List<Doctor> doctors = new List<Doctor>();
        private List<Room> rooms = new List<Room>();

        private int idExamination = 100000;

        bool ok = false;

        string userNP;

        public AddAppointment(string usernamePatient)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            userNP = usernamePatient;

            doctors = fd.LoadFromFile();
            for (int i = 0; i < doctors.Count; i++)
            {
                Combo3.Items.Add(doctors[i].Username.ToString());
            }
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();


        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {

            ExaminationType examType = (ExaminationType)Enum.Parse(typeof(ExaminationType), ComboTypeApppointment.Text);

            DateTime date = Date.SelectedDate.Value.Date;


            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime d = date + time;





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




            bool isFree = true;

            WorkWithFiles.FilesDoctor doc = new WorkWithFiles.FilesDoctor();
            List<Doctor> doctors = doc.LoadFromFile();

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
            for (int i = 0; i < rooms.Count; i++)
            {
                //ako je null znaci da je slobodna i izadji iz petlje
                if (rooms[i].Scheduled == null)
                {
                    roomIsFree = true;
                    roomIndex = i;
                    break;
                }

                bool ok = true;
                for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                {
                    if (rooms[i].Scheduled[j] == d)
                    {
                        ok = false;
                    }
                }
                if (ok == true)
                {
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
                Examination ex = new Examination(userNP, s2, rooms[roomIndex].RoomId.ToString(), d, (idExamination + 1).ToString(), examType);
                PatientController controller = new PatientController();
                controller.ScheduleExamination(ex);
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
