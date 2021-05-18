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
        private WindowPatient windowPatient = WindowPatient.Instance;
        private AppointmentController controller = new AppointmentController();

        public WindowExaminationMove()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Appointment examination = (Appointment)windowPatient.lvUsers.SelectedItem;
            DateTime oldDate = examination.ExaminationStart;
            DateTime newDate = GetDateAndTimeFromForm(Date.SelectedDate.Value.Date, Combo);
            if (!IsNewDateValid(oldDate, newDate)) return;
            controller.MoveExamination(examination, newDate);
            windowPatient.UpdateView();
            Close();
        }

        private bool IsNewDateValid(DateTime oldDate, DateTime newDate)
        {
            if (oldDate == newDate) MessageBox.Show("Your examination is already scheduled at this time.", "Info", MessageBoxButton.OK);
            else if ((oldDate - DateTime.Now).TotalDays < 1) MessageBox.Show("You can not move examination that starts in less than 24h.", "Info", MessageBoxButton.OK);
            else if (Math.Abs((oldDate - newDate).TotalDays) > 2) MessageBox.Show("You can not move examination start more than 2 days.", "Info", MessageBoxButton.OK);
            else return true;
            return false;
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
    }
}
