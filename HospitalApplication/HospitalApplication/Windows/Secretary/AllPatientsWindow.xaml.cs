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

namespace HospitalApplication.Windows.Secretary
{

    public partial class AllPatientsWindow : Window
    {
        public AllPatientsWindow()
        {
            InitializeComponent();

            FilesPatients sp = FilesPatients.GetInstance();
            PatientManagement pm = new PatientManagement();

            List<Patient> patients = pm.GetAllPatient();
            lvUsers.ItemsSource = patients;

        }
    }
}
