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

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for WindowExaminationSchedule.xaml
    /// </summary>
    public partial class WindowExaminationSchedule : Window
    {
        private ExaminationManagement m = new ExaminationManagement();
        private string s1, s2;
        private int d1, d2, d3, d4, d5, d6;
        public WindowExaminationSchedule()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            s1 = PatientId.Text;
            s2 = DoctorId.Text;
            /*d1 = Int32.Parse(Goidna1.Text);
            d2 = Int32.Parse(Mesec1.Text);
            d3 = Int32.Parse(Dan1.Text);
            d4 = Int32.Parse(Sat1.Text);
            d5 = Int32.Parse(Sekund1.Text);*/
            //DateTime date = new DateTime(d1, d2, d3, d4, d5, d6);
            DateTime date = new DateTime(2020, 12, 30, 15, 10, 00);
            //id svakog pregleda je unikatan
            int idExamination;
            int n = m.Examinations.Count;
            if (n > 0)
            {
                idExamination = Int32.Parse(m.Examinations[n - 1].ExaminationId) + 1;
            }
            else idExamination = 100000;
            Examination ex = new Examination(s1, s2, "101", date, idExamination.ToString());
            m.ScheduleExamination(ex);
        }
    }
}
