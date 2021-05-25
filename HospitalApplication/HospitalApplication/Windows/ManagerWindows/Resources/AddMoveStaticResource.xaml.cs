using HospitalApplication.Controller;
using HospitalApplication.Model;
using HospitalApplication.Service;
using Model;
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
    /// Interaction logic for AddMoveStaticResource.xaml
    /// </summary>
    public partial class AddMoveStaticResource : Window
    {
        private Resource re; 

        public AddMoveStaticResource( Resource r)
        {
            InitializeComponent();
            re = r;
        }

        private void Kalendar(object sender, SelectionChangedEventArgs e)
        {
            selectedDate.Text = PickDate.SelectedDate.ToString();
        }

        public Random a = new Random(DateTime.Now.Ticks.GetHashCode());
        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            Transfer t = new Transfer() {
                idTransfer = a.Next(),
                idRoomFrom = re.roomId,
                idRoomTo = int.Parse(textBoxRoomId.Text),
                date = DateTime.Parse(selectedDate.Text).AddHours(2),
                quantity = int.Parse(textBoxManufacturer.Text)
            };

            //t.dat.AddHours(4);
            
            if(t.quantity > re.quantity)
            {
                MessageBox.Show("That resource does not have that amount", "Error");
            }
            else
            {
                re.roomId = t.idRoomTo;
                re.quantity = t.quantity;
                if (t.resource == null)
                {
                    t.resource = new List<Resource>();
                    t.resource.Add(re);
                }
                else { t.resource.Add(re); }

                ManagerController mc = new ManagerController();
                RelocationResourceService rr = new RelocationResourceService();
                if (rr.CheckDoesRoomExist(t) == true)
                {
                    mc.TransStatic(t);
                    Close();
                }
                else { MessageBox.Show("Room id does not exist", "Error"); }
            }

        }
    }
}
