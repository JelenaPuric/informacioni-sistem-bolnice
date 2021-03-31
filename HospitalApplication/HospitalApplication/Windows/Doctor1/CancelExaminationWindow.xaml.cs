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
    /// Interaction logic for CancelExaminationWindow.xaml
    /// </summary>
    public partial class CancelExaminationWindow : Window
    {
        private ExaminationAndOperationCrud eAo = new ExaminationAndOperationCrud();
        private string id;
        public CancelExaminationWindow()
        {
            InitializeComponent();
        }

        private void yesBtn_Click(object sender, RoutedEventArgs e)
        {
            id = examinationIdTxt.Text;
            eAo.CancelScheduledExamination(id);
            Close();
        }

        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
