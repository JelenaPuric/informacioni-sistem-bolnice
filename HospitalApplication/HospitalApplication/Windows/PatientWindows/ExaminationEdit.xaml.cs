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
using HospitalApplication.Controller;
using HospitalApplication.Logic;
using HospitalApplication.WorkWithFiles;
using Logic;
using Model;
using WorkWithFiles;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowExaminationEdit.xaml
    /// </summary>
    public partial class WindowExaminationEdit : Window
    {
        private FilesDoctor filesDoctor = new FilesDoctor();
        private List<Doctor> doctors = new List<Doctor>();
        private WindowPatient w = WindowPatient.Instance;
        private AppointmentController controller = new AppointmentController();

        public WindowExaminationEdit()
        {
            InitializeComponent();
            doctors = filesDoctor.LoadFromFile();
            for (int i = 0; i < doctors.Count; i++)
            {
                Combo.Items.Add(doctors[i].Username.ToString());
            }
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Appointment examination = (Appointment)w.lvUsers.SelectedItem;
            DateTime date = examination.ExaminationStart;
            string username = Combo.SelectedItem.ToString();

            controller.UpdateDoctors();
            if (controller.DoctorIsFree(username, date) == true)
            {
                controller.AddExaminationToDoctor(username, date);
                controller.RemoveExaminationFromDoctor(examination.DoctorsId, date);
                controller.EditExamination(examination, username);
                w.UpdateView();
            }
            else
            {
                MessageBox.Show("There is no free term. Choose another time.");
            }
            Close();
        }
    }
}
