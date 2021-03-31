using Logic;
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

namespace HospitalApplication.Windows.Doctor1
{
    /// <summary>
    /// Interaction logic for MoveExaminationWindow.xaml
    /// </summary>
    public partial class MoveExaminationWindow : Window
    {
        private ExaminationAndOperationCrud eAm = new ExaminationAndOperationCrud();
        private String id;
        public MoveExaminationWindow()
        {
            InitializeComponent();
        }

        private void yesMoveBtn_Click(object sender, RoutedEventArgs e)
        {
            id = examIdTxt.Text;
            string date = examDateTxt.Text;
            string[] entries = date.Split('/');
            int year = Int32.Parse(entries[2]);
            int month = Int32.Parse(entries[0]);
            int day = Int32.Parse(entries[1]);
            DateTime date1 = new DateTime(year, month, day);

            DateTime dateStart = new DateTime(Int32.Parse(hoursStartTxt.Text), Int32.Parse(minutesStartTxt.Text), Int32.Parse(secundesStartTxt.Text));
            DateTime dateEnd = new DateTime(Int32.Parse(hoursEndTxt.Text), Int32.Parse(minutesEndTxt.Text), Int32.Parse(secundesEndTxt.Text));
            eAm.MoveScheduledExamination(id, date1, dateStart, dateEnd);
        }

        private void noMoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
