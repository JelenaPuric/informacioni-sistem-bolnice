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
    /// Interaction logic for FunMoveAppointmentWindow.xaml
    /// </summary>
    public partial class FunMoveAppointmentWindow : Window
    {
        private ExaminationManagement m = ExaminationManagement.Instance;
        private MoveAppointment w = MoveAppointment.Instance;
        private string id;
        private PatientController controller = new PatientController();



        public FunMoveAppointmentWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Examination e2 = (Examination)w.lvUsers.SelectedItem;

            DateTime oldDate = e2.ExaminationStart;
            DateTime comboDate = Date.SelectedDate.Value.Date;
            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime newDate = comboDate + time;


            List<Room> rooms = new List<Room>();
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();

            bool roomIsFree = true;
            string roomId = e2.RoomId;
            //proveri da li postoji slobodna soba
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomId.ToString() == roomId)
                {
                    for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                    {
                        if (rooms[i].Scheduled[j] == newDate)
                        {
                            roomIsFree = false;
                        }
                    }
                    break;
                }
            }

            //ako je nov termin slobodan za doktora, onda mu skloni stari a doda nov termin, promeni datum pregleda
            controller.UpdateDoctors();
            if (controller.DoctorIsFree(e2.DoctorsId, newDate) == false && roomIsFree == true)
            {
                controller.RemoveExaminationFromDoctor(e2.DoctorsId, oldDate);
                controller.AddExaminationToDoctor(e2.DoctorsId, newDate);
                //Ratko, dodao sam ti treci parametar jer ga ja koristim u mojoj funkciji, tebi ne menja nista
                controller.MoveExamination(e2.ExaminationId, newDate, 2);
                //skloni stari datum sobi
                for (int i = 0; i < rooms.Count; i++)
                {
                    if (rooms[i].RoomId.ToString() == roomId)
                    {
                        for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                        {
                            if (rooms[i].Scheduled[j] == oldDate)
                            {
                                rooms[i].Scheduled.RemoveAt(j);
                            }
                        }
                        break;
                    }
                }
                //dodaj nov datum sobi
                for (int i = 0; i < rooms.Count; i++)
                {
                    if (rooms[i].RoomId.ToString() == roomId)
                    {
                        rooms[i].Scheduled.Add(newDate);
                        break;
                    }
                }
                SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
                //w.UpdateView();
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }

            Close();
        }
    }
}
