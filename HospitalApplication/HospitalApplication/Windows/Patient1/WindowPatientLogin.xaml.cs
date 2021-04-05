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
using Model;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowPatientLogin.xaml
    /// </summary>
    public partial class WindowPatientLogin : Window
    {
        PatientManagement m = new PatientManagement();
        string enteredUsername;
        public String EnteredUsername
        {
            get { return enteredUsername; }
            set { enteredUsername = value; }
        }


        private static WindowPatientLogin instance;
        public static WindowPatientLogin Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new WindowPatientLogin();
                }
                return instance;
            }
        }

        public WindowPatientLogin()
        {
            InitializeComponent();
            instance = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Patient> patients = m.GetAllPatient();
            string username;
            string password;
            enteredUsername = Username.Text;
            string enteredPassword = Password.Password;
            for (int i = 0; i < patients.Count; i++)
            {
                username = patients[i].Username;
                password = patients[i].Password;
                if (enteredUsername == username && enteredPassword == password) {
                    WindowPatient window = new WindowPatient();
                    Close();
                    window.Show();
                }
            }
            InvalidInfoLabel.Content = "* invalid username or password";
        }
    }
}
