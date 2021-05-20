using HospitalApplication.Model;
using HospitalApplication.Repository;
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
    /// <summary>
    /// Interaction logic for AnamnesisPage.xaml
    /// </summary>
    public partial class AnamnesisPage : Page
    {
        private FileAnamnesis fileAnamnesis = FileAnamnesis.Instance;
        private List<Anamnesis> anamnesis;
        private MainWindow mainWindow = MainWindow.Instance;

        private static AnamnesisPage instance;
        public static AnamnesisPage Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new AnamnesisPage();
                }
                return instance;
            }
        }

        public AnamnesisPage()
        {
            InitializeComponent();
            instance = this;
            anamnesis = fileAnamnesis.GetAnamnesis(mainWindow.Username.Text.ToString());
            lvUsers.ItemsSource = anamnesis;
            //anamnesis.Add(new Anamnesis("a", "b", "c", "d", "e", "f", DateTime.Now));
            //fileAnamnesis.Write();
        }

        private void SubmitComment_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            Anamnesis anamnesis = (Anamnesis)lvUsers.SelectedItem;
            anamnesis.PatientsComment = AnamnesisComment.Text.ToString();
            fileAnamnesis.Write();
            MessageBox.Show("Anamnesis comment is successfully added.");
        }

        private void AnamneseInformation_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) return;
            AnamnesisInfo window = new AnamnesisInfo();
            window.Show();
        }
    }
}
