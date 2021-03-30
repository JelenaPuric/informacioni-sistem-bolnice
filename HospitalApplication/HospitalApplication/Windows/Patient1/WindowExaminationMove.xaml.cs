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

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowExaminationMove.xaml
    /// </summary>
    public partial class WindowExaminationMove : Window
    {
        private ExaminationManagement m = new ExaminationManagement();
        private string id;

        public WindowExaminationMove()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            id = PatientId.Text;
            DateTime date = new DateTime(Int32.Parse(Year1.Text), Int32.Parse(Month1.Text), Int32.Parse(Day1.Text), Int32.Parse(Hour1.Text), Int32.Parse(Minute1.Text), Int32.Parse(Second1.Text));
            m.MoveExamination(id, date);
        }
    }
}
