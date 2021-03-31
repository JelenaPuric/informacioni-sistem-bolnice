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

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for WindowExaminationCancel.xaml
    /// </summary>
    public partial class WindowExaminationCancel : Window
    {
        private ExaminationManagement m = new ExaminationManagement();
        private string id;
        public WindowExaminationCancel()
        {
            InitializeComponent();
        }


        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            id = IdExamination.Text;
            m.CancelExamination(id);
        }
    }
}
