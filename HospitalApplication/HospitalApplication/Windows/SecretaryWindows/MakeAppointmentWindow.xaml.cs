﻿using HospitalApplication.Controller;
using HospitalApplication.WorkWithFiles;
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
    public partial class MakeAppointmentWindow : Window
    {
        private FileAppointments fileAppointments = FileAppointments.Instance;
        private AppointmentController appointmentController = new AppointmentController();
        private SecretaryController secretaryController = new SecretaryController();
        private string idPatient;

        public MakeAppointmentWindow(string id)
        {
            InitializeComponent();
            CenterWindow();
            idPatient = id;
            lvUsers.ItemsSource = fileAppointments.GetAppointments(secretaryController.getPatient(idPatient).Username);
        }

        private void CenterWindow()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment window = new AddAppointment(secretaryController.getPatient(idPatient).Username);
            window.Show();
        }

        private void MoveAppointment_Click(object sender, RoutedEventArgs e)
        {
            MoveAppointment window = new MoveAppointment();
            window.Show();
        }

        private void CancelAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1))
                return;
            Appointment appointment = (Appointment)lvUsers.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Do you want to cancel examination?", "Confirmation", MessageBoxButton.YesNo);
            switch (result){
                case MessageBoxResult.Yes:
                    appointmentController.CancelAppointment(appointment);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            List<Appointment> examinations = fileAppointments.GetAppointments(secretaryController.getPatient(idPatient).Username);
            lvUsers.ItemsSource = examinations;
        }

        private void BackHome_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow window = new HomeWindow();
            this.Close();
            window.Show();
        }
    }
}
