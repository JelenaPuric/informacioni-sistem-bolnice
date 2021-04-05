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
using WorkWithFiles;

namespace HospitalApplication.Windows.Secretary
{
    /// <summary>
    /// Interaction logic for DeletePatientWindow.xaml
    /// </summary>
    public partial class DeletePatientWindow : Window
    {
        public DeletePatientWindow()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            FilesPatients sp = FilesPatients.GetInstance();
            PatientManagement pm = new PatientManagement();

            string id = IdPatient.Text;

            pm.DeletePatient(id);

            sp.WritePatient("patients.txt");

            Close();
        }

    }
}
