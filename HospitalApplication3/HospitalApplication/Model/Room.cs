using System;
using System.Collections.Generic;

namespace Model
{
    public class Room
    {
        public Renovation[] Renovation;
        public int RoomId { get; set; }
        public int NumberOfFloors { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public OperatingRoomType OperationRoomType { get; set; }
        public RoomType RoomType { get; set; }
        public bool Occupied { get; set; }
        //public List<DateTime> Scheduled { get; set; }
    }
}