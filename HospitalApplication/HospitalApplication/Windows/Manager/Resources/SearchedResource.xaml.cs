using HospitalApplication.Model;
using Logic;
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

namespace HospitalApplication.Windows.Manager.Resources
{
    /// <summary>
    /// Interaction logic for SearchedResource.xaml
    /// </summary>
    public partial class SearchedResource : Window
    {
        public SearchedResource(string s, int i)
        {
            InitializeComponent();
            RoomManagment rm = new RoomManagment();
            List<Resource> lista = rm.FindItem(s, i);
            lvDataBinding.ItemsSource = lista;

        }
    }
}
