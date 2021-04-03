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
using Logic;
using Model;
using WorkWithFiles;

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for WindowExaminationSchedule.xaml
    /// </summary>
    public partial class WindowExaminationSchedule : Window
    {
        private ExaminationManagement m = ExaminationManagement.Instance;
        private string s1, s2;
        private WindowPatient w = WindowPatient.Instance;
        public WindowExaminationSchedule()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            s1 = PatientId.Text;
            s2 = DoctorId.Text;
            DateTime date = Date.SelectedDate.Value.Date;
            //TimeSpan time = new TimeSpan(Int32.Parse(Hour1.Text), Int32.Parse(Minute1.Text), Int32.Parse(Second1.Text));
            
            //DateTime date = new DateTime(2020, 12, 30, 15, 10, 00);
            //DateTime date = new DateTime(d);
            //DateTime date = new DateTime(Int32.Parse(Year1.Text), Int32.Parse(Month1.Text), Int32.Parse(Day1.Text), Int32.Parse(Hour1.Text), Int32.Parse(Minute1.Text), Int32.Parse(Second1.Text));
            //id svakog pregleda je unikatan
            
            //lista svih mogucih termina za pregled, kombijuje se sa date time pickerom
            //trojke oznacavaju sat/min/sekund
            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++) {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime d = date + time;

            int idExamination = m.Examinations.Count + 100000;
            Examination ex = new Examination(s1, s2, "101", d, idExamination.ToString());
            m.ScheduleExamination(ex);

            
            w.UpdateView();

            Close();
        }
    }
}
