using HospitalApplication.Service;
using Logic;
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

namespace HospitalApplication.Windows.Manager.Renovationn
{
    /// <summary>
    /// Interaction logic for AddRenovation.xaml
    /// </summary>
    public partial class AddRenovation : Window
    {
        public AddRenovation()
        {
            InitializeComponent();
        }

        public Random a = new Random(DateTime.Now.Ticks.GetHashCode());

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            int roomId = int.Parse(textBoxRoomId.Text);
            List<DateTime> daysBetween = new List<DateTime>();

            DateTime date1 = PickStartDate.SelectedDate.Value.Date;
            DateTime date2 = PickEndDate.SelectedDate.Value.Date;

            DateTime newDate = new DateTime();

            for (int i=0; i<(date2-date1).TotalDays + 1; i++)
            {
                newDate = date1.Date.AddDays(i);
                daysBetween.Add(newDate);
            }

            Renovation newRenovation = new Renovation()
            {
                RoomId = roomId,
                StartDay = (DateTime)PickStartDate.SelectedDate,
                EndDay = (DateTime)PickEndDate.SelectedDate,
                Days = daysBetween,
                IdRenovation = a.Next()
            };

            Renovationss logic = new Renovationss();
            if (logic.CheckRenovation(newRenovation))
            {
                logic.AddRenovation(newRenovation);
                Close();
            }
        }
    }
}
