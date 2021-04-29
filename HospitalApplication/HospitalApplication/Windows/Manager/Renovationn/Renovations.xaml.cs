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
            Renovationss rs = new Renovationss();
            List<Renovation> rv = rs.GetList();
            lvDataBinding.ItemsSource = rv;
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            Renovationss rs = new Renovationss();
            Renovation selected = (Renovation)lvDataBinding.SelectedItem;
            if(selected != null)
            {
                rs.RemoveRenovation(selected);
            }

            List<Renovation> rv = rs.GetList();
            lvDataBinding.ItemsSource = rv;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            AddRenovation ar = new AddRenovation();
            ar.Show();
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            Renovationss rs = new Renovationss();
            List<Renovation> rv = rs.GetList();
            lvDataBinding.ItemsSource = rv;
        }
    }
}
