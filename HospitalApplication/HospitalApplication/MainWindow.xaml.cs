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
using Model;
using Logic;

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FilesExamination f = new FilesExamination();

        PatientManagement m = new PatientManagement();
        string enteredUsername;
        public String EnteredUsername
        {
            get { return enteredUsername; }
            set { enteredUsername = value; }
        }


        private static MainWindow instance;
        public static MainWindow Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new MainWindow();
                }
                return instance;
            }
        }




        public MainWindow()
        {
            InitializeComponent();
            instance = this;
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            //FilesPatients fp = FilesPatients.GetInstance();
            //fp.LoadPatient(fp.Path);

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text.Equals("sekretar") && Password.Password.Equals("123"))
            {
                AllPatientsWindow window = new AllPatientsWindow();
                Close();
                window.Show();
            }
            else if (Username.Text.Equals("upravnik") && Password.Password.Equals("123"))
            {
                WindowsManager window = new WindowsManager();
                Close();
                window.Show();
            }
            else if (Username.Text.Equals("lekar") && Password.Password.Equals("123"))
            {
                Windows.Doctor1.DoctorWindow window = new DoctorWindow();
                Close();
                window.Show();
            }
            else 
            {
                List<Patient> patients = m.Patients;
                    string username;
                    string password;
                    enteredUsername = Username.Text;
                    string enteredPassword = Password.Password;
                    for (int i = 0; i < patients.Count; i++)
                    {
                        username = patients[i].Username;
                        password = patients[i].Password;
                        if (enteredUsername == username && enteredPassword == password)
                        {
                            WindowPatient window = new WindowPatient();
                            Close();
                            window.Show();
                        }
                    }
                    InvalidInfoLabel.Content = "* invalid username or password";

            }

        }


        /*
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
        */




    }
}
