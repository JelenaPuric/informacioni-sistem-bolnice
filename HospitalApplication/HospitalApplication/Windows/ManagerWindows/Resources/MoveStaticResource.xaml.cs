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

namespace HospitalApplication.Windows.Manager.Resources
{
    /// <summary>
    /// Interaction logic for MoveStaticResource.xaml
    /// </summary>
    public partial class MoveStaticResource : Window
    {
        private Resource re;

        public MoveStaticResource(Resource r)
        {
            InitializeComponent();
            RelocationResourceService rr = new RelocationResourceService();
            
            List<Transfer> tr = rr.showAllTransfers();
            rr.CheckTransfers();
            lvDataBinding.ItemsSource = tr;
            re = r;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            AddMoveStaticResource amsr = new AddMoveStaticResource(re);
            amsr.Show();
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            RelocationResourceService rr = new RelocationResourceService();
            List<Transfer> tr = rr.showAllTransfers();
            rr.CheckTransfers();
            lvDataBinding.ItemsSource = tr;
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            Transfer t = (Transfer)lvDataBinding.SelectedItem;
            RelocationResourceService rr = new RelocationResourceService();
            rr.DeleteTransfer(t);

            List<Transfer> tr = rr.showAllTransfers();
            lvDataBinding.ItemsSource = tr;
        }
    }
}
