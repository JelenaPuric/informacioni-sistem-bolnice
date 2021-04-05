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

        public WindowExaminationMove()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            int index = w.lvUsers.SelectedIndex;

            Examination e2 = (Examination)w.lvUsers.SelectedItem;
            string id = e2.ExaminationId;

            //izbrisi termin kod doktora
            WorkWithFiles.FilesDoctor doc = new WorkWithFiles.FilesDoctor();
            List<Doctor> doctors = doc.LoadFromFile();
            DateTime dt = e2.ExaminationStart;
            for (int i = 0; i < doctors.Count; i++)
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
            }

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

            //dodajem nov termin doktoru
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Username == e2.DoctorsId)
                {
                    doctors[i].Scheduled.Add(d);
                    doc.WriteInFile(doctors);
                    break;
                }
            }

            m.MoveExamination(id, d);
            //m.Move(index, d);
            w.UpdateView();
            Close();
        }
    }
}
