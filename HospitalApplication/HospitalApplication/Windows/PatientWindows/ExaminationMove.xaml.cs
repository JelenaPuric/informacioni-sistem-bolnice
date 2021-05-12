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

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowExaminationMove.xaml
    /// </summary>
    public partial class WindowExaminationMove : Window
    {
        private WindowPatient w = WindowPatient.Instance;
        private AppointmentController controller = new AppointmentController();

        public WindowExaminationMove()
        {
            InitializeComponent();
        }

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

            if (oldDate == newDate)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Your examination is already scheduled at this time.", "Info", MessageBoxButton.OK);
                return;
            }
            if ((oldDate - DateTime.Now).TotalDays < 1)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("You can not move examination that starts in less than 24h.", "Info", MessageBoxButton.OK);
                return;
            }
            if (Math.Abs((oldDate - newDate).TotalDays) > 2)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("You can not move examination start more than 2 days.", "Info", MessageBoxButton.OK);
                return;
            }

            //prilikom provere da li je soba slobodna, ako takva postoji, vrati se index slobodne sobe
            Tuple<bool, int> roomIsFree = controller.RoomIsFree(newDate);
            controller.UpdateDoctors();
            if (controller.DoctorIsFree(examination.DoctorsId, newDate) == true && roomIsFree.Item1 == true)
            {
                controller.RemoveExaminationFromDoctor(examination.DoctorsId, oldDate);
                controller.AddExaminationToDoctor(examination.DoctorsId, newDate);
                controller.RemoveExaminationFromRoom(examination.RoomId, oldDate);
                controller.AddExaminationToRoom(roomIsFree.Item2, newDate);
                controller.MoveExamination(examination, newDate, roomIsFree.Item2);
                w.UpdateView();
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
