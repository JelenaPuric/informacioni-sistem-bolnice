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
        public SettingsPage()
        {
            InitializeComponent();
            if(Properties.Settings.Default.ColorMode == "Light") ComboTheme.SelectedIndex = 0;
            if(Properties.Settings.Default.ColorMode == "Dark") ComboTheme.SelectedIndex = 1;
            if (Properties.Settings.Default.ColorMode == "NoTheme") ComboTheme.SelectedIndex = 2;
        }

        private void ComboTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboTheme.SelectedIndex == 0) Properties.Settings.Default.ColorMode = "Light";
            if(ComboTheme.SelectedIndex == 1) Properties.Settings.Default.ColorMode = "Dark";
            if(ComboTheme.SelectedIndex == 2) Properties.Settings.Default.ColorMode = "NoTheme";
            Properties.Settings.Default.Save();
        }
    }
}