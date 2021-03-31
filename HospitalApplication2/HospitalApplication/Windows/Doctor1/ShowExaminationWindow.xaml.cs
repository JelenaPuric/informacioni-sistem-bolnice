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

namespace HospitalApplication.Windows.Doctor1
{
    /// <summary>
    /// Interaction logic for ShowExaminationWindow.xaml
    /// </summary>
    public partial class ShowExaminationWindow : Window
    {
        public ShowExaminationWindow()
        {

            InitializeComponent();
            SerializationAndDeserilaizationOfExaminations sAd = SerializationAndDeserilaizationOfExaminations.GetInstance();
            lvUsers.ItemsSource = sAd.LoadExaminations();
        }
    }
}