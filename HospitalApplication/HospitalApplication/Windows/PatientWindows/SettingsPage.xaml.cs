﻿using HospitalApplication.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalApplication.Windows.PatientWindows
{
    public partial class SettingsPage : Page
    {
        private MainWindow mainWindow = MainWindow.Instance;
        private FileSurveys fileSurveys = FileSurveys.Instance;

        public SettingsPage()
        {
            InitializeComponent();
            if(Properties.Settings.Default.ColorMode == "Light") ComboTheme.SelectedIndex = 0;
            if(Properties.Settings.Default.ColorMode == "Dark") ComboTheme.SelectedIndex = 1;
            if(Properties.Settings.Default.ColorMode == "NoTheme") ComboTheme.SelectedIndex = 2;
            if(Properties.Settings.Default.Language == "English") ComboLanguage.SelectedIndex = 0;
            if(Properties.Settings.Default.Language == "Serbian") ComboLanguage.SelectedIndex = 1;
        }

        private void ComboTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboTheme.SelectedIndex == 0) Properties.Settings.Default.ColorMode = "Light";
            if(ComboTheme.SelectedIndex == 1) Properties.Settings.Default.ColorMode = "Dark";
            if(ComboTheme.SelectedIndex == 2) Properties.Settings.Default.ColorMode = "NoTheme";
            Properties.Settings.Default.Save();
        }

        private void RateApplication_Click(object sender, RoutedEventArgs e)
        {
            if (fileSurveys.IsApplicationSurveyAllowed(mainWindow.PatientsUsername)){
                SurveyApplication window = new SurveyApplication();
                window.ShowDialog();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Home window = Home.Instance;
            window.Logout();
        }

        //funkciju pozivam u app.xaml.cs jer se ovo ne moze uraditi iz app.xaml.cs, ne znam zasto to tamo ne radi
        public string FindCulture() {
            if (Properties.Settings.Default.Language == "English") return "English";
            else if (Properties.Settings.Default.Language == "Serbian") return "Serbian";
            else return "";
        }

        private void ComboLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboLanguage.SelectedIndex == 0) Properties.Settings.Default.Language = "English";
            if (ComboLanguage.SelectedIndex == 1) Properties.Settings.Default.Language = "Serbian";
            Properties.Settings.Default.Save();
        }
    }
}