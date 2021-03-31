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
using Model;
using Logic;
using WorkWithFiles;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowExaminationShow.xaml
    /// </summary>
    public partial class WindowExaminationShow : Window
    {
        public WindowExaminationShow()
        {
            InitializeComponent();

            FilesExamination f = new FilesExamination();
            ExaminationManagement m = new ExaminationManagement();
            List<Examination> examinations = m.Examinations;
            lvUsers.ItemsSource = examinations;
        }
    }
}
