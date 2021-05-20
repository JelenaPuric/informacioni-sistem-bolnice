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
    /// Interaction logic for AddNewDoctorWindow.xaml
    /// </summary>
    public partial class AddNewDoctorWindow : Window
    {

        private FileDoctors fileDoctors = FileDoctors.Instance;
        private DoctorService doctorService = DoctorService.Instance;
        private AllDoctorsWindow allDoctorsWindow = AllDoctorsWindow.Instance;

        public AddNewDoctorWindow()
        {
            InitializeComponent();
            CenterWindow();
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

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DoctorType doctorType = (DoctorType)Enum.Parse(typeof(DoctorType), ComboBox1.Text);

            int n = fileDoctors.GetDoctors().Count;
            int idDoctor;

            if (n > 0)
            {
                idDoctor = Int32.Parse(fileDoctors.GetDoctors()[n - 1].DoctorId) + 1;
            }
            else idDoctor = 0;

            Doctor newDoctor = new Doctor(textBoxUsername.Text, textBoxPassword.Text, new List<DateTime>(), doctorType, idDoctor.ToString());

            doctorService.CreateDoctor(newDoctor);
            allDoctorsWindow.UpdateDoctors();

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
