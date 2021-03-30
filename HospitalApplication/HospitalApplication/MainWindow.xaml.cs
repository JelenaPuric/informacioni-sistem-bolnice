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

            FilesPatients sp = FilesPatients.GetInstance();
            sp.LoadPatient("patients.txt");

        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            WindowPatient window = new WindowPatient();
            window.Show();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorWindow window = new DoctorWindow();
            window.Show();
        }

        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            //FajloviZaRegistracijuNovogPacijenta sp = FajloviZaRegistracijuNovogPacijenta.GetInstance();
            //sp.LoadPatient("patients.txt");
            SecretaryWindow window = new SecretaryWindow();
            window.Show();

        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            WindowsManager window = new WindowsManager();
            window.Show();
        }
    }
}
