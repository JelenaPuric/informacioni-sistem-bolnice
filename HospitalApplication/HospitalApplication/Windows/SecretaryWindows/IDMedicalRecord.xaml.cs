﻿using HospitalApplication.Controller;
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
    /// Interaction logic for IDMedicalRecord.xaml
    /// </summary>
    public partial class IDMedicalRecord : Window
    {
        public IDMedicalRecord()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {

            SecretaryController sc = new SecretaryController();

            string idPatient = IdPatient.Text;

            List<Patient> patients = sc.GetAllPatients();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == idPatient)
                {
                    MedicalRecordWindow window = new MedicalRecordWindow(idPatient) { };
                    window.Show();
                }

            }

            Close();



        }


    }
}
