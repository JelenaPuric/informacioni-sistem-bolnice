using HospitalApplication.Controller;
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
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {


        private string s1, s2;
        private MainWindow mw = MainWindow.Instance;
        private AppointmentController patientController = new AppointmentController();

        private ExaminationService m = ExaminationService.Instance;
        private FilesRooms r = new FilesRooms();
        private WorkWithFiles.FilesDoctors fd = new WorkWithFiles.FilesDoctors();

        private List<Doctor> doctors = new List<Doctor>();
        private List<Room> rooms = new List<Room>();

        private int idExamination = 100000;

        bool ok = false;

        string userNP;

        public AddAppointment(string usernamePatient)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            userNP = usernamePatient;

            doctors = FilesDoctors.GetDoctors();
            for (int i = 0; i < doctors.Count; i++)
            {
                Combo3.Items.Add(doctors[i].Username.ToString());
            }
            rooms = FilesRooms.LoadRoom();


        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {

            ExaminationType examType = (ExaminationType)Enum.Parse(typeof(ExaminationType), ComboTypeApppointment.Text);

            DateTime date = Date.SelectedDate.Value.Date;


            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime d = date + time;



            List<Appointment> examinations = m.Examinations;
            if (ok == false)
            {
                ok = true;
                for (int i = 0; i < examinations.Count; i++)
                {
                    if (Int32.Parse(examinations[i].ExaminationId) > idExamination)
                    {
                        idExamination = Int32.Parse(examinations[i].ExaminationId);
                    }
                }
            }



            int docIndex = Combo3.SelectedIndex; 
            s2 = doctors[docIndex].Username;
            int roomID = 0;
            bool sucessMakeApp = patientController.MakeAppointment(docIndex, d, userNP, s2, roomID, (idExamination + 1).ToString(), examType, Int32.Parse(textBox111.Text)); 

            if ( sucessMakeApp == false)
            {
                MessageBox.Show("There is no free term. Choose another time.");
                Close();
                return;
            }


         
            Close();
        }
    }
}
