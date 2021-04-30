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
using HospitalApplication.Model;
using HospitalApplication.Repository;
using WorkWithFiles;

namespace HospitalApplication.Windows.Patient1
{
    /// <summary>
    /// Interaction logic for WindowRateHospital.xaml
    /// </summary>
    public partial class WindowRateHospital : Window
    {
        private List<Survey> surveys = new List<Survey>();
        private FilesSurvey filesSurvey = new FilesSurvey();
        private MainWindow mainWindow = MainWindow.Instance;
        int[] numericalAnswers = new int[100]; //nece sigurno biti vise od 100 pitanja
        string writtenAnswer = "helo";

        public WindowRateHospital()
        {
            InitializeComponent();
            surveys = filesSurvey.ReadSurveys();
            //if (surveys == null) surveys = new List<Survey>();
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            //ukloni RadioButton iz imena da bih dobio samo broj, delim ga sa 5 da bih znao koje je to pitanje po redu
            int key = (Int32.Parse(radioButton.Name.ToString().Remove(0, 11)) + 4) / 5;
            int value = Int32.Parse(radioButton.Content.ToString());
            numericalAnswers[key] = value;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Survey survey = new Survey(numericalAnswers, writtenAnswer, mainWindow.PatientsUsername, DateTime.Now);
            surveys.Add(survey);
            filesSurvey.WriteSurveys(surveys);
            Close();
        }
    }
}
