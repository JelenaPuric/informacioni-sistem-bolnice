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
using Logic;
using Model;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowExaminationMove.xaml
    /// </summary>
    public partial class WindowExaminationMove : Window
    {
        private ExaminationManagement m = ExaminationManagement.Instance;
        private WindowPatient w = WindowPatient.Instance;
        private string id;
        private PatientController controller = new PatientController();

        public WindowExaminationMove()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            //int index = w.lvUsers.SelectedIndex;

            Examination e2 = (Examination)w.lvUsers.SelectedItem;
            //string id = e2.ExaminationId;

            //izbrisi termin kod doktora
            //WorkWithFiles.FilesDoctor doc = new WorkWithFiles.FilesDoctor();
            //List<Doctor> doctors = doc.LoadFromFile();
            DateTime oldDate = e2.ExaminationStart;
            DateTime comboDate = Date.SelectedDate.Value.Date;
            List<(int, int, int)> appointment = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++)
            {
                appointment.Add((7 + i, 0, 0));
                appointment.Add((7 + i, 30, 0));
            }
            (int, int, int) a = appointment[Combo.SelectedIndex];
            TimeSpan time = new TimeSpan(a.Item1, a.Item2, a.Item3);
            DateTime newDate = comboDate + time;


            //ne radi provera da li je datum gde se pomera pregled isti kao i prvobitno zakazan
            /*if (date.Date == dt.Date && date.TimeOfDay == dt.TimeOfDay) {
                MessageBoxResult result = System.Windows.MessageBox.Show("Your examination is already scheduled at this time.", "Info", MessageBoxButton.OK);
                return;
            }*/

            /*for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username == e2.DoctorsId)
                {
                    for (int j = 0; j < doctors[i].Scheduled.Count; j++)
                    {
                        if (doctors[i].Scheduled[j] == dt)
                        {
                            doctors[i].Scheduled.RemoveAt(j);
                        }
                    }

                    doc.WriteInFile(doctors);
                    break;
                }
            }*/


            //oldDateLabel.Content = oldDate.ToString();
            //newDateLabel.Content = newDate.ToString();

            if ((oldDate - DateTime.Now).TotalDays < 1)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("You can not move examination that starts in less than 24h.", "Info", MessageBoxButton.OK);
                return;
            }
            if (Math.Abs((oldDate - newDate).TotalDays) > 2)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("You can not move examination start more than 2 days.", "Info", MessageBoxButton.OK);
                return;
            }

            //dodajem nov termin doktoru
            /*for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username == e2.DoctorsId)
                {
                    doctors[i].Scheduled.Add(d);
                    doc.WriteInFile(doctors);
                    break;
                }
            }*/


            //ako je nov termin slobodan za doktora, onda mu skloni stari a doda nov termin, promeni datum pregleda
            controller.updateDoctors();
            if (controller.doctorsExaminationExists(e2.DoctorsId, newDate) == false)
            {
                controller.removeExaminationFromDoctor(e2.DoctorsId, oldDate);
                controller.addExaminationToDoctor(e2.DoctorsId, newDate);
                controller.MoveExamination(e2.ExaminationId, newDate);
                w.UpdateView();
            }

            //ako je nov termin slobodan za doktora, onda mu skloni stari a doda nov termin, promeni datum pregleda
            /*m.updateDoctors();
            if (m.doctorsExaminationExists(e2.DoctorsId, newDate) == false)
            {
                m.removeExaminationFromDoctor(e2.DoctorsId, oldDate);
                m.addExaminationToDoctor(e2.DoctorsId, newDate);
                m.MoveExamination(e2.ExaminationId, newDate);
                w.UpdateView();
            }*/

            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Choosen term is not free. Choose another one.", "Info", MessageBoxButton.OK);
                return;
            }

            //m.Move(index, d);
            //m.MoveExamination(id, newDate);
            //w.UpdateView();
            Close();
        }
    }
}
