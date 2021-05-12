﻿using HospitalApplication.Controller;
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

    public partial class DeletePatientWindow : Window
    {
        private AllPatientsWindow aPw = AllPatientsWindow.GetInstance();

        public DeletePatientWindow()
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


            //PatientManagement pm = new PatientManagement();
            SecretaryController sc = new SecretaryController();

            string id = IdPatient.Text;

            sc.DeletePatient(id);

            aPw.UpdateView();


            Close();

        }
    }
}
