using HospitalApplication.Controller;
using HospitalApplication.Windows.SecretaryWindows;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalApplication.Windows.Secretary
{
    public partial class HomeWindow : Window
    {
        private NewsController newsController = new NewsController();
        private static HomeWindow instance;
        public static HomeWindow Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new HomeWindow();
                }
                return instance;
            }
        }

        public HomeWindow()
        {
            InitializeComponent();
            CenterWindow();
            instance = this;
            UpdateNews();
        }

        public void UpdateNews()
        {
            lvUsers.ItemsSource = null;
            lvUsers.ItemsSource = newsController.GetAllNews();
        }

        private void CenterWindow()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void CreateNews_Click(object sender, RoutedEventArgs e)
        {
            CreateNewsWindow window = new CreateNewsWindow();
            window.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) { return; }
            News selectedNews = (News)lvUsers.SelectedItem;
            newsController.DeleteNews(selectedNews.Id);
            UpdateNews();
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) { return; }
            News selectedNews = (News)lvUsers.SelectedItem;
            ViewNewsWindow window = new ViewNewsWindow(selectedNews);
            window.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) { return; }
            News selectedNews = (News)lvUsers.SelectedItem;
            EditNewsWindow window = new EditNewsWindow(selectedNews);
            window.Show();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
        }

        private void AllPatients_Click(object sender, RoutedEventArgs e)
        {
            AllPatientsWindow window = new AllPatientsWindow();
            this.Close();
            window.Show();
        }

        private void EmergencyButton_Click(object sender, RoutedEventArgs e)
        {
            PatientAndAppointmentWindow window = new PatientAndAppointmentWindow();
            this.Close();
            window.Show();
        }

        private void MakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            PatientAndAppointmentWindow window = new PatientAndAppointmentWindow();
            this.Close();
            window.Show();
        }

        private void Doctors_Click(object sender, RoutedEventArgs e)
        {
            AllDoctorsWindow window = new AllDoctorsWindow();
            this.Close();
            window.Show();
        }

        private void Demo_Click(object sender, RoutedEventArgs e)
        {
            AllPatientsWindow allPatientWindow = new AllPatientsWindow();
            RegisterOptionWindow registerOptionWindow = new RegisterOptionWindow();
            RegisterPatientWindow registerPatientWindow = new RegisterPatientWindow();

            MessageBox.Show("Demo is started.", "Info", MessageBoxButton.OK);

            var delay = Task.Delay(1000).ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(
                        delegate
                        {
                            //allPatientWindow = new AllPatientsWindow();
                            this.Close();
                            allPatientWindow.Show();

                            Task.Delay(2000).ContinueWith(_ =>
                            {
                                Application.Current.Dispatcher.Invoke(
                                System.Windows.Threading.DispatcherPriority.Normal,
                                new Action(
                                    delegate ()
                                    {
                                        //registerOptionWindow = new RegisterOptionWindow();
                                        registerOptionWindow.Show();

                                        Task.Delay(1500).ContinueWith(_ =>
                                        {
                                            Application.Current.Dispatcher.Invoke(
                                            System.Windows.Threading.DispatcherPriority.Normal,
                                            new Action(
                                                delegate ()
                                                {
                                                    registerOptionWindow.Close();
                                                    //registerPatientWindow = new RegisterPatientWindow();
                                                    registerPatientWindow.Show();

                                                    Task.Delay(1500).ContinueWith(_ =>
                                                    {
                                                        Application.Current.Dispatcher.Invoke(
                                                        System.Windows.Threading.DispatcherPriority.Normal,
                                                        new Action(
                                                            delegate ()
                                                            {
                                                                registerPatientWindow.textBoxFirstName.Text = "Ime";

                                                                Task.Delay(1500).ContinueWith(_ =>
                                                                {
                                                                    Application.Current.Dispatcher.Invoke(
                                                                    System.Windows.Threading.DispatcherPriority.Normal,
                                                                    new Action(
                                                                        delegate ()
                                                                        {
                                                                            registerPatientWindow.textBoxLastName.Text = "Prezime";

                                                                            Task.Delay(1500).ContinueWith(_ =>
                                                                            {
                                                                                Application.Current.Dispatcher.Invoke(
                                                                                System.Windows.Threading.DispatcherPriority.Normal,
                                                                                new Action(
                                                                                    delegate ()
                                                                                    {
                                                                                        registerPatientWindow.textBoxJMBG.Text = "1234567891011";

                                                                                        Task.Delay(1500).ContinueWith(_ =>
                                                                                        {
                                                                                            Application.Current.Dispatcher.Invoke(
                                                                                            System.Windows.Threading.DispatcherPriority.Normal,
                                                                                            new Action(
                                                                                                delegate ()
                                                                                                {
                                                                                                    registerPatientWindow.BoxDateTime.Text = "1/1/1999";

                                                                                                    Task.Delay(1500).ContinueWith(_ =>
                                                                                                    {
                                                                                                        Application.Current.Dispatcher.Invoke(
                                                                                                        System.Windows.Threading.DispatcherPriority.Normal,
                                                                                                        new Action(
                                                                                                            delegate ()
                                                                                                            {
                                                                                                                registerPatientWindow.MSex.IsChecked = true;

                                                                                                                Task.Delay(1500).ContinueWith(_ =>
                                                                                                                {
                                                                                                                    Application.Current.Dispatcher.Invoke(
                                                                                                                    System.Windows.Threading.DispatcherPriority.Normal,
                                                                                                                    new Action(
                                                                                                                        delegate ()
                                                                                                                        {
                                                                                                                            registerPatientWindow.textBoxPlaceOfResidance.Text = "Place Of Residance";


                                                                                                                            Task.Delay(1500).ContinueWith(_ =>
                                                                                                                            {
                                                                                                                                Application.Current.Dispatcher.Invoke(
                                                                                                                                System.Windows.Threading.DispatcherPriority.Normal,
                                                                                                                                new Action(
                                                                                                                                    delegate ()
                                                                                                                                    {
                                                                                                                                        registerPatientWindow.textBoxEmail.Text = "example@gmail.com";

                                                                                                                                        Task.Delay(1500).ContinueWith(_ =>
                                                                                                                                        {
                                                                                                                                            Application.Current.Dispatcher.Invoke(
                                                                                                                                            System.Windows.Threading.DispatcherPriority.Normal,
                                                                                                                                            new Action(
                                                                                                                                                delegate ()
                                                                                                                                                {
                                                                                                                                                    registerPatientWindow.textBoxPhoneNumber.Text = "065123456";

                                                                                                                                                    Task.Delay(1500).ContinueWith(_ =>
                                                                                                                                                    {
                                                                                                                                                        Application.Current.Dispatcher.Invoke(
                                                                                                                                                        System.Windows.Threading.DispatcherPriority.Normal,
                                                                                                                                                        new Action(
                                                                                                                                                            delegate ()
                                                                                                                                                            {
                                                                                                                                                                registerPatientWindow.textBoxUsername.Text = "exampleUsername";

                                                                                                                                                                Task.Delay(1500).ContinueWith(_ =>
                                                                                                                                                                {
                                                                                                                                                                    Application.Current.Dispatcher.Invoke(
                                                                                                                                                                    System.Windows.Threading.DispatcherPriority.Normal,
                                                                                                                                                                    new Action(
                                                                                                                                                                        delegate ()
                                                                                                                                                                        {
                                                                                                                                                                            registerPatientWindow.textBoxPassword.Text = "examplePassword";

                                                                                                                                                                            Task.Delay(1500).ContinueWith(_ =>
                                                                                                                                                                            {
                                                                                                                                                                                Application.Current.Dispatcher.Invoke(
                                                                                                                                                                                System.Windows.Threading.DispatcherPriority.Normal,
                                                                                                                                                                                new Action(
                                                                                                                                                                                    delegate ()
                                                                                                                                                                                    {
                                                                                                                                                                                        
                                                                                                                                                                                       // MedicalRecord newMedicalRecord = new MedicalRecord();

                                                                                                                                                                                       // Patient newPatient = new Patient();

                                                                                                                                                                                       // secretaryController.CreatePatient(newPatient);


                                                                                                                                                                                        

                                                                                                                                                                                    }
                                                                                                                                                                                    ));

                                                                                                                                                                            }
                                                                                                                                                                            );


                                                                                                                                                                        }
                                                                                                                                                                        ));

                                                                                                                                                                }
                                                                                                                                                                );


                                                                                                                                                            }
                                                                                                                                                            ));

                                                                                                                                                    }
                                                                                                                                                    );


                                                                                                                                                }
                                                                                                                                                ));

                                                                                                                                        }
                                                                                                                                        );


                                                                                                                                    }
                                                                                                                                    ));

                                                                                                                            }
                                                                                                                            );


                                                                                                                        }
                                                                                                                        ));

                                                                                                                }
                                                                                                                );


                                                                                                            }
                                                                                                            ));

                                                                                                    }
                                                                                                    );


                                                                                                }
                                                                                                ));

                                                                                        }
                                                                                        );


                                                                                    }
                                                                                    ));

                                                                            }
                                                                            );


                                                                        }
                                                                        ));

                                                                }
                                                                );

                                                            }
                                                            ));

                                                    }
                                                    );


                                                }
                                                ));
                                        }
                                        );

                                    }
                                    ));

                            }
                            );





                        }
                        ));

                //  sw.Stop();
                // return sw.ElapsedMilliseconds;
            });






        }

    }
}
