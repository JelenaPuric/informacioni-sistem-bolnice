using HospitalApplication.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Model;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HospitalApplication.Windows.ManagerWindows.Renovations;

namespace HospitalApplication.Windows.Manager.Renovationn
{
    /// <summary>
    /// Interaction logic for Renovations.xaml
    /// </summary>
    public partial class Renovations : Window
    {
        public Renovations()
        {
            InitializeComponent();
            RenovationsService logic = new RenovationsService();
            logic.DeleteOldRenovations();
            List<Renovation> renovations = logic.GetList();
            lvDataBinding.ItemsSource = renovations;
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            RenovationsService logic = new RenovationsService();
            Renovation selected = (Renovation)lvDataBinding.SelectedItem;
            if(selected != null)
            {
                logic.RemoveRenovation(selected);
            }

            List<Renovation> renovations = logic.GetList();
            lvDataBinding.ItemsSource = renovations;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            ChooseRenovation newRenovation = new ChooseRenovation();
            newRenovation.Show();
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            RenovationsService logic = new RenovationsService();
            List<Renovation> renovations = logic.GetList();
            logic.DeleteOldRenovations();
            lvDataBinding.ItemsSource = renovations;
        }

        private void Edit_Clicked(object sender, RoutedEventArgs e)
        {
            Renovation selected = (Renovation)lvDataBinding.SelectedItem;
            if (selected != null)
            {
                EditRenovation editWindow = new EditRenovation(selected);
                editWindow.Show();
            }
        }
    }
}
