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

namespace HospitalApplication.Windows.Doctor1
{
    /// <summary>
    /// Interaction logic for ScheduleExaminationWindow.xaml
    /// </summary>
    public partial class ScheduleExaminationWindow : Window
    {
        public ScheduleExaminationWindow()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            SerializationAndDeserilaizationOfExaminations sAd = new SerializationAndDeserilaizationOfExaminations();

            String patientsId = patientIdTxt.Text;
            String DoctorId = doctorIdTxt.Text;
            String RoomId = roomIdTxt.Text;
            String ExaminationId = examIdTxt.Text;
            string date = examDateTxt.Text;
            string[] entries = date.Split('/');
            int year = Int32.Parse(entries[2]);
            int month = Int32.Parse(entries[0]);
            int day = Int32.Parse(entries[1]);
            DateTime date1 = new DateTime(year, month, day);
            int d1 = Int32.Parse(hour1Txt.Text);
            int d2 = Int32.Parse(minutes1Txt.Text);
            int d3 = Int32.Parse(secundes1Txt.Text);
            int d4 = Int32.Parse(hours2Txt.Text);
            int d5 = Int32.Parse(minutes2Txt.Text);
            int d6 = Int32.Parse(secundes2Txt.Text);
            DateTime startDate = new DateTime(year, month, day, d1, d2, d3);
            DateTime endDate = new DateTime(year, month, day, d4, d5, d6);
            bool Specialization = (bool)specialistTxt.IsChecked;
            String comboBox = typeExamTxt.Text;

            int n = sAd.GetExaminations().Count;
            int idExamination;

            if (n > 0)
            {
                idExamination = Int32.Parse(sAd.GetExaminations()[n - 1].ExaminationId + 1);
            }

            else idExamination = 0;

            ExaminationType typeOfExamination = (ExaminationType)Enum.Parse(typeof(ExaminationType), comboBox);

            Examination exam = new Examination(patientsId, DoctorId, RoomId, startDate, endDate, date1, Specialization, idExamination.ToString(), typeOfExamination); ;
            ExaminationAndOperationCrud eAo = new ExaminationAndOperationCrud();

            eAo.ScheduleExamunation(exam);
            Close();
        }

        private void giveUpBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

