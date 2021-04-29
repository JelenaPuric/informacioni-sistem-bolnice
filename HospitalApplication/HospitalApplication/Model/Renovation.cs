using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Model
{
    public class Renovation
    {
        //public int Duration { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDay { get; set; } 
        public DateTime EndDay { get; set; }
        public List<DateTime> Days { get; set; }
        public int IdRenovation { get; set; }
    }
}