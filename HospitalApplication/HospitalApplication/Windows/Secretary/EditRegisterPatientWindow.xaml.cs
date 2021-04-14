﻿using Logic;
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
    /// <summary>
    /// Interaction logic for EditRegisterPatientWindow.xaml
    /// </summary>
    public partial class EditRegisterPatientWindow : Window
    {
        private Patient p;
        private AllPatientsWindow aPw = AllPatientsWindow.GetInstance();


        public EditRegisterPatientWindow(string value)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            FilesPatients sp = FilesPatients.GetInstance();
            PatientManagement pm = new PatientManagement();
            p = pm.EditExistingPatient(value);

            ComboBox1.Text = p.TypeAcc.ToString();
            textBoxFirstName.Text = p.Name;
            textBoxLastName.Text = p.LastName;
            BoxDateTime.Text = p.DateOfBirth.ToString();
            textBoxPlaceOfResidance.Text = p.PlaceOfResidance;
            textBoxEmail.Text = p.Email;
            textBoxPhoneNumber.Text = p.PhoneNumber;
            textBoxUsername.Text = p.Username;
            textBoxPassword.Text = p.Password;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {


            AccountType typeAcc = (AccountType)Enum.Parse(typeof(AccountType), ComboBox1.Text);
            p.TypeAcc = typeAcc;

            p.Name = textBoxFirstName.Text;
            p.LastName = textBoxLastName.Text;

            string date = BoxDateTime.Text;
            string[] entries = date.Split('/');
            int year = Int32.Parse(entries[2]);
            int month = Int32.Parse(entries[0]);
            int day = Int32.Parse(entries[1]);
            DateTime myDate = new DateTime(year, month, day);

            p.DateOfBirth = myDate;

            p.PlaceOfResidance = textBoxPlaceOfResidance.Text;
            p.Email = textBoxEmail.Text;
            p.PhoneNumber = textBoxPhoneNumber.Text;
            p.Username = textBoxUsername.Text;
            p.Password = textBoxPassword.Text;

            aPw.UpdateView();

            Close();

        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}