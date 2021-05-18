using HospitalApplication.Controller;
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
    /// <summary>
    /// Interaction logic for MakeAppointmentWindow.xaml
    /// </summary>
    public partial class MakeAppointmentWindow : Window
    {

        AppointmentService m = AppointmentService.Instance;
        SecretaryController sc = new SecretaryController();
        string idP;
        string usernamePatient;
        public MakeAppointmentWindow(string idPatient)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

          
            idP = idPatient;
            usernamePatient = sc.getPatient(idP).Username;


            List<Appointment> examinations = m.GetExaminations(sc.getPatient(idP).Username);
            lvUsers.ItemsSource = examinations;

        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment(usernamePatient);
            window.Show();
        }

        private void MoveAppointment_Click(object sender, RoutedEventArgs e)
        {
            MoveAppointment window = new MoveAppointment();
            window.Show();
        }

        private void CancelAppointment_Click(object sender, RoutedEventArgs e)
        {

            if (!(lvUsers.SelectedIndex > -1))
            {
                return;
            }

            Appointment e2 = (Appointment)lvUsers.SelectedItem;
            string id = e2.ExaminationId;

            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to cancel examination?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    int index = lvUsers.SelectedIndex;
                    WorkWithFiles.FileDoctors doc = new WorkWithFiles.FileDoctors();
                    List<Doctor> doctors = FileDoctors.GetDoctors();
                    DateTime dt = e2.ExaminationStart;
                    //skloni datum lekaru
                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (doctors[i].Username == e2.DoctorsId)
                        {
                            for (int j = 0; j < doctors[i].Scheduled.Count; j++)
                            {
                                if (doctors[i].Scheduled[j] == dt)
                                {
                                    doctors[i].Scheduled.RemoveAt(j);
                                }
                            }

                            FileDoctors.Write();
                            break;
                        }
                    }
                    //skloni datum sobi
                    List<Room> rooms = new List<Room>();
                    rooms = FileRooms.LoadRoom();
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        if (rooms[i].Scheduled == null) continue;
                        if (rooms[i].RoomId.ToString() == e2.RoomId)
                        {
                            for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                            {
                                if (rooms[i].Scheduled[j] == dt)
                                {
                                    rooms[i].Scheduled.RemoveAt(j);
                                    break;
                                }
                            }
                            FileRooms.EnterRoom(rooms);
                        }
                    }

                    m.CancelExamination(e2);
                    //m.Cancel(index);
                  
                    break;
                case MessageBoxResult.No:
                    break;
            }



        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            List<Appointment> examinations = m.GetExaminations(sc.getPatient(idP).Username);
            lvUsers.ItemsSource = examinations;
        }

        private void BackHome_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow window = new HomeWindow();
            this.Close();
            window.Show();
        }
    }
}
