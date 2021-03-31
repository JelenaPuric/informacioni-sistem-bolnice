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

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for WindowPatient.xaml
    /// </summary>
    public partial class WindowPatient : Window
    {
        public WindowPatient()
        {
            InitializeComponent();
        }

        private void ScheduleExamination_Click(object sender, RoutedEventArgs e)
        {
            WindowExaminationSchedule window = new WindowExaminationSchedule();
            window.Show();
        }

        private void CancelExamination_Click(object sender, RoutedEventArgs e)
        {
            WindowExaminationCancel window = new WindowExaminationCancel();
            window.Show();
        }

        private void MoveExamination_Click(object sender, RoutedEventArgs e)
        {
            Windows.Patient1.WindowExaminationMove window = new Windows.Patient1.WindowExaminationMove();
            window.Show();
        }

        private void ShowExamination_Click(object sender, RoutedEventArgs e)
        {
            Windows.Patient1.WindowExaminationShow window = new Windows.Patient1.WindowExaminationShow();
            window.Show();
        }
    }
}
