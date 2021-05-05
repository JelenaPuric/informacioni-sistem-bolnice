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
    /// Interaction logic for AddDrug.xaml
    /// </summary>
    public partial class AddDrug : Window
    {
        public AddDrug()
        {
            InitializeComponent();
        }

        private Random a = new Random(DateTime.Now.Ticks.GetHashCode());
        private MedicinesManagment logic = new MedicinesManagment();

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Drugs newDrug = new Drugs()
            {
                ItemId = a.Next(),
                Name = textBoxName.Text,
                Manufacturer = textBoxQuantity.Text,
                Replacement = textBoxReplacement.Text,
                Ingredients = textBoxMultiline.Text
            };

            logic.CreateDrug(newDrug);
            Close();
        }
    }
}
