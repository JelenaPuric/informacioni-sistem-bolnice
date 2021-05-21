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
        private AppointmentService m = AppointmentService.Instance;
        private MoveAppointment w = MoveAppointment.Instance;
        private string id;
        private AppointmentController controller = new AppointmentController();



        public FunMoveAppointmentWindow()
        {
            InitializeComponent();
            CenterWindow();

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



        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Appointment examination = (Appointment)w.lvUsers.SelectedItem;
            DateTime oldDate = examination.ExaminationStart;
            DateTime newDate = GetDateAndTimeFromForm(Date.SelectedDate.Value.Date, Combo);
            if (!IsNewDateValid(oldDate, newDate)) return;
            controller.MoveExamination(examination, newDate);
            //w.UpdateView();
            Close();
        }

        private bool IsNewDateValid(DateTime oldDate, DateTime newDate)
        {
            if (oldDate == newDate) MessageBox.Show("Your examination is already scheduled at this time.", "Info", MessageBoxButton.OK);
            else return true;
            return false;
        }

        private DateTime GetDateAndTimeFromForm(DateTime date, ComboBox Combo)
        {
            List<(int, int, int)> times = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                times.Add((7 + i, 0, 0));
                times.Add((7 + i, 30, 0));
            }
            (int, int, int) time = times[Combo.SelectedIndex];
            TimeSpan timeSpan = new TimeSpan(time.Item1, time.Item2, time.Item3);
            return date + timeSpan;
        }

        //-----------------
        /*
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Appointment examination = (Appointment)w.lvUsers.SelectedItem;
            DateTime oldDate = examination.ExaminationStart;
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


            //prilikom provere da li je soba slobodna, ako takva postoji, vrati se index slobodne sobe
            Tuple<bool, int> roomIsFree = controller.IsRoomFree(newDate);
            controller.UpdateDoctors();
            if (controller.IsDoctorFree(examination.DoctorsId, newDate) == true && roomIsFree.Item1 == true)
            {
                controller.RemoveExaminationFromDoctor(examination.DoctorsId, oldDate);
                controller.AddExaminationToDoctor(examination.DoctorsId, newDate);
                controller.RemoveExaminationFromRoom(examination.RoomId, oldDate);
                controller.AddExaminationToRoom(roomIsFree.Item2, newDate);
                controller.MoveAppointment(examination.ExaminationId, newDate, roomIsFree.Item2);
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }

            Close();
        }

        */
    }
}
