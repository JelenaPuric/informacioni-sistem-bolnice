using HospitalApplication.Controller;
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
    /// <summary>
    /// Interaction logic for ViewPatientWindow.xaml
    /// </summary>
    public partial class ViewPatientWindow : Window
    {
        private Patient p;
        public ViewPatientWindow(string value)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);


            //PatientManagement pm = new PatientManagement();
            SecretaryController sc = new SecretaryController();
            p = sc.getPatient(value);

            TypeAcc.Content = TypeAcc.Content + p.TypeAcc.ToString();
            FirstName.Content = FirstName.Content + p.Name;
            LastName.Content = LastName.Content + p.LastName;
            Jmbg.Content = Jmbg.Content + p.Jmbg;
            Sex.Content = Sex.Content + p.SexType.ToString();
            DateOfBirth.Content = DateOfBirth.Content + p.DateOfBirth.ToString("dd.MM.yyyy.");
            PlaceOfResidance.Content = PlaceOfResidance.Content + p.PlaceOfResidance;
            Email.Content = Email.Content + p.Email;
            PhoneNumber.Content = PhoneNumber.Content + p.PhoneNumber;
            Username.Content = Username.Content + p.Username;
            Password.Content = Password.Content + p.Password;

        }
    }
}
