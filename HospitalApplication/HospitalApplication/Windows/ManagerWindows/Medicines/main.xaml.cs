using HospitalApplication.Model;
using HospitalApplication.Service;
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

namespace HospitalApplication.Windows.Manager.Medicines
{
    /// <summary>
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Window
    {
        public main()
        {
            InitializeComponent();
            MedicinesService logic = new MedicinesService();
            List<Drugs> list = logic.GetList();
            lvDataBinding.ItemsSource = list;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            AddDrug add = new AddDrug();
            add.Show();
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            MedicinesService logic = new MedicinesService();
            List<Drugs> list = logic.GetList();
            lvDataBinding.ItemsSource = list;
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            MedicinesService logic = new MedicinesService();
            Drugs selected = (Drugs)lvDataBinding.SelectedItem;
            if(selected != null)
            {
                logic.DeleteDrug(selected);
            }
            List<Drugs> list = logic.GetList();
            lvDataBinding.ItemsSource = list;
        }

        private void Edit_Clicked(object sender, RoutedEventArgs e)
        {
            Drugs selected = (Drugs)lvDataBinding.SelectedItem;
            if (selected != null)
            {
                EditDrug edit = new EditDrug(selected);
                edit.Show();
            }
            MedicinesService logic = new MedicinesService();
            List<Drugs> list = logic.GetList();
            lvDataBinding.ItemsSource = list;
        }

        private void Info_Clicked(object sender, RoutedEventArgs e)
        {
            Drugs selected = (Drugs)lvDataBinding.SelectedItem;
            if (selected != null)
            {
                InfoDrug edit = new InfoDrug(selected);
                edit.Show();
            }
        }

        private void Problems_Clicked(object sender, RoutedEventArgs e)
        {
            ReportedDrugs allReports = new ReportedDrugs();
            allReports.Show();
        }
    }
}
