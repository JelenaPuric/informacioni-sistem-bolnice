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
using Model;
using Logic;
using WorkWithFiles;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HospitalApplication
{
    /// <summary>
    /// Interaction logic for WindowPatient.xaml
    /// </summary>
    public partial class WindowPatient : Window
    {
        FilesExamination f = new FilesExamination();
        ExaminationManagement m = ExaminationManagement.Instance;
        Windows.Patient1.WindowPatientLogin l = Windows.Patient1.WindowPatientLogin.Instance;


        private static WindowPatient instance;
        public static WindowPatient Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new WindowPatient();
                }
                return instance;
            }
        }

        public WindowPatient()
        {
            InitializeComponent();
            instance = this;


            //List<Examination> examinations = m.GetExaminations(l.EnteredUsername);
            List<Examination> examinations = m.Examinations;
            lvUsers.ItemsSource = examinations;
        }

        public void UpdateView() {
            //List<Examination> examinations = m.GetExaminations(l.EnteredUsername);
            List<Examination> examinations = m.Examinations;
            //lvUsers.ItemsSource = null;
            //lvUsers.ItemsSource = examinations;
            //lvUsers.Items.Refresh();
            ICollectionView view = CollectionViewSource.GetDefaultView(examinations);
            view.Refresh();
            //lvUsers.ItemsSource = null;
            //lvUsers.ItemsSource = examinations;
            // Update the List containing your elements (lets call it x)
            //lvUsers.ItemsSource = examinations;
            //TestLabela.Content = "vucicupederu";
        }

        private void ScheduleExamination_Click(object sender, RoutedEventArgs e)
        {
            WindowExaminationSchedule window = new WindowExaminationSchedule();
            window.Show();
        }

        private void CancelExamination_Click(object sender, RoutedEventArgs e)
        {
            //WindowExaminationCancel window = new WindowExaminationCancel();
            //window.Show();
            MessageBoxResult result = MessageBox.Show("Do you want to cancel examination?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    int index = lvUsers.SelectedIndex;
                    m.Cancel(index);
                    UpdateView();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void MoveExamination_Click(object sender, RoutedEventArgs e)
        {
            Windows.Patient1.WindowExaminationMove window = new Windows.Patient1.WindowExaminationMove();
            window.Show();
        }
    }
}
