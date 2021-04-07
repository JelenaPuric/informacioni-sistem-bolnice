using HospitalApplication.Windows.Manager;
﻿
using HospitalApplication.Windows.Doctor1;
using HospitalApplication.Windows.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkWithFiles;

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FilesExamination f = new FilesExamination();

        public MainWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            FilesPatients fp = FilesPatients.GetInstance();
            fp.LoadPatient(fp.Path);

        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            Windows.Patient1.WindowPatientLogin window = new Windows.Patient1.WindowPatientLogin();
            window.Show();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            Windows.Doctor1.DoctorWindow window = new DoctorWindow();
            window.Show();
        }

        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            AllPatientsWindow window = new AllPatientsWindow();
            window.Show();

        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            WindowsManager window = new WindowsManager();
            window.Show();
        }
    }
}
