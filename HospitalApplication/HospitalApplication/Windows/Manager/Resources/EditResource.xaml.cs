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
    /// Interaction logic for EditResource.xaml
    /// </summary>
    public partial class EditResource : Window
    {
        private Resource priv;
        public EditResource(Resource re)
        {
            InitializeComponent();
            textBoxName.Text = re.name;
            textBoxQuantity.Text = re.quantity.ToString();
            checkBoxIsStatic.IsChecked = (bool)re.isStatic;
            textBoxManufacturer.Text = re.manufacturer;
            priv = re;
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Resource r = new Resource() {
                idItem = priv.idItem,
                name = textBoxName.Text,
                quantity = int.Parse(textBoxQuantity.Text),
                isStatic = (bool)checkBoxIsStatic.IsChecked,
                manufacturer = textBoxManufacturer.Text,
                roomId = priv.roomId
            };
            RoomManagment rm = new RoomManagment();
            rm.RemoveItem(priv);
            rm.AddItem(r);
            Close();
        }
    }
}
