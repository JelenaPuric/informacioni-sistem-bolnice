using System;
using System.Collections.Generic;

namespace Model
{
   public class Room
   {
      public Renovation[] renovation;
   
      private int NumberOfFloors;
      private int RoomNumber;
      private int Capacity;
      private int RoomId;
      private OperatingRoomType OperationRoomType;
      private RoomType RoomType;
      private List<int> Zauzetost;
   
   }
}