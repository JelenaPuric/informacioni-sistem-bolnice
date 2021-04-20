﻿using HospitalApplication.Controller;
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

namespace HospitalApplication.Windows.Secretary
{
    /// <summary>
    /// Interaction logic for MakeAppointmentWindow.xaml
    /// </summary>
    public partial class MakeAppointmentWindow : Window
    {

        ExaminationManagement m = ExaminationManagement.Instance;
        SecretaryController sc = new SecretaryController();
        string idP;
        string usernamePatient;
        public MakeAppointmentWindow(string idPatient)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

          
            idP = idPatient;
            usernamePatient = sc.getPatient(idP).Username;


            List<Examination> examinations = m.GetExaminations(sc.getPatient(idP).Username);
            lvUsers.ItemsSource = examinations;

        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment(usernamePatient);
            window.Show();
        }

        private void MoveAppointment_Click(object sender, RoutedEventArgs e)
        {
            MoveAppointment window = new MoveAppointment();
            window.Show();
        }

        private void CancelAppointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            List<Examination> examinations = m.GetExaminations(sc.getPatient(idP).Username);
            lvUsers.ItemsSource = examinations;
        }
    }
}
