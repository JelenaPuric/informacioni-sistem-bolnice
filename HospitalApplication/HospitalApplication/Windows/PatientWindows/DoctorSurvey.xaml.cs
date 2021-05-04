using HospitalApplication.Model;
using HospitalApplication.Repository;
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

namespace HospitalApplication.Windows.PatientWindows
{
    /// <summary>
    /// Interaction logic for DoctorSurvey.xaml
    /// </summary>
    public partial class DoctorSurvey : Window
    {
        private List<Survey> surveys = new List<Survey>();
        private FilesSurvey filesSurvey = new FilesSurvey();
        private MainWindow mainWindow = MainWindow.Instance;
        private int[] numericalAnswers = new int[100]; //nece sigurno biti vise od 100 pitanja

        public DoctorSurvey(List<string> doctorUsernames)
        {
            InitializeComponent();
            setQuestions();
            for (int i = 0; i < doctorUsernames.Count; i++) {
                ComboDoctors.Items.Add(doctorUsernames[i]);
            }
            surveys = filesSurvey.LoadFromFile();
            if (surveys == null) surveys = new List<Survey>();
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
            Survey survey = new Survey(numericalAnswers, WrittenAnswer.Text, mainWindow.PatientsUsername, DateTime.Now, ComboDoctors.SelectedItem.ToString());
            surveys.Add(survey);
            filesSurvey.WriteInFile(surveys);
            Close();
        }

        private void setQuestions()
        {
            Question1.Text = "1. How happy are you with the doctor’s treatment?";
            Question2.Text = "2. Were the doctor empathetic to your needs?";
            Question3.Text = "3. Were the ambulatory staff quick to respond to your medical care request ?";
            Question4.Text = "4. How often did the doctor describe possible side effects before administering your medicine?";
            Question5.Text = "5. Were you satisfied with the answers provided?";
            Question6.Text = "6. Did doctor listen carefully to you?";
            Question7.Text = "7. How respectfull did the doctor treat you?";
            Question8.Text = "8. Did the doctor and/or medical staff involve you in decisions about your treatment?";
            Question9.Text = "9. Do you believe the doctor is trustworthy?";
            Question10.Text = "10. Would you be happy to see this doctor again?";
            Question11.Text = "11. What are the things you feel doctor should improve upon?";
        }
    }
}
