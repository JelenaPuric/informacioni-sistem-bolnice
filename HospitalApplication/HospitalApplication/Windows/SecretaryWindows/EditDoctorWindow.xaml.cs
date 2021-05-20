using HospitalApplication.Service;
using HospitalApplication.WorkWithFiles;
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

namespace HospitalApplication.Windows.SecretaryWindows
{
    /// <summary>
    /// Interaction logic for EditDoctorWindow.xaml
    /// </summary>
    public partial class EditDoctorWindow : Window
    {
        private FileDoctors fileDoctors = FileDoctors.Instance;
        private DoctorService doctorService = DoctorService.Instance;
        private AllDoctorsWindow allDoctorsWindow = AllDoctorsWindow.Instance;
        private Doctor currentSelectedDoctor;
        public EditDoctorWindow(Doctor selectedDoctor)
        {
            InitializeComponent();
            CenterWindow();
            currentSelectedDoctor = selectedDoctor;
            SetValuesFields(selectedDoctor);
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

        private void SetValuesFields(Doctor selectedDoctor)
        {
            ComboBox1.Text = selectedDoctor.DoctorType.ToString();
            textBoxUsername.Text = selectedDoctor.Username;
            textBoxPassword.Text = selectedDoctor.Password;
        }

        private void SetValues()
        {
            currentSelectedDoctor.DoctorType = (DoctorType)Enum.Parse(typeof(DoctorType), ComboBox1.Text);
            currentSelectedDoctor.Username = textBoxUsername.Text;
            currentSelectedDoctor.Password = textBoxPassword.Text;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SetValues();
            doctorService.UpdateDoctor(currentSelectedDoctor);
            allDoctorsWindow.UpdateDoctors();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
