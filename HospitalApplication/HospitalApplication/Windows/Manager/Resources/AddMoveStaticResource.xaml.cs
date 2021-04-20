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
                dat = DateTime.Parse(selectedDate.Text)
            };

            if(t.Res == null)
            {
                t.Res = new List<Resource>();
                t.Res.Add(re);
            }
            else { t.Res.Add(re); }

            RelocationResource rr = new RelocationResource();
            if (rr.CheckRoom(t) == true)
            {
                rr.TransStatic(t);
                Close();
            }
            else { MessageBox.Show("Room id does not exist", "Error"); }

            
            
        }
    }
}
