using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace HospitalApplication.Service
{
    class FormService
    {
        public DateTime GetDateAndTimeFromForm(DateTime date, ComboBox combo)
        {
            List<(int, int, int)> times = new List<(int, int, int)>();
            for (int i = 0; i < 13; i++){
                times.Add((7 + i, 0, 0));
                times.Add((7 + i, 30, 0));
            }
            (int, int, int) time = times[combo.SelectedIndex];
            TimeSpan timeSpan = new TimeSpan(time.Item1, time.Item2, time.Item3);
            return date + timeSpan;
        }
    }
}
