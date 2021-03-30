using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class RoomManagment
   {
        private List<Room> rooms;

        public RoomManagment()
        {
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
        }
      public void CreateRoom(Room r)
      {
            rooms.Add(r);
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
      }
      
      public void RemoveRoom(int idroom )
      {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomId == idroom)
                {
                    rooms.RemoveAt(i);
                }
            }
        }
      
      public void editRoom(int password)
      {
         // TODO: implement
      }
      
      public List<Room> showAllRooms()
      {
         return rooms;
      }
      
      public Room showRoom(int roomm)
      {
            Room r = new Room();
            for(int i=0; i<rooms.Count; i++)
            {
                if (rooms[i].RoomId == roomm)
                { r = rooms[i]; break; }
            }

            return r;
      }
   
      public System.Collections.ArrayList room;
      
      public System.Collections.ArrayList GetRoom()
      {
         if (room == null)
            room = new System.Collections.ArrayList();
         return room;
      }
      
      public void SetRoom(System.Collections.ArrayList newRoom)
      {
         RemoveAllRoom();
         foreach (Model.Room oRoom in newRoom)
            AddRoom(oRoom);
      }
      
      public void AddRoom(Model.Room newRoom)
      {
         if (newRoom == null)
            return;
         if (this.room == null)
            this.room = new System.Collections.ArrayList();
         if (!this.room.Contains(newRoom))
            this.room.Add(newRoom);
      }
      
      public void RemoveRoom(Model.Room oldRoom)
      {
         if (oldRoom == null)
            return;
         if (this.room != null)
            if (this.room.Contains(oldRoom))
               this.room.Remove(oldRoom);
      }
      
      public void RemoveAllRoom()
      {
         if (room != null)
            room.Clear();
      }
   
      private WorkWithFiles.SerializationAndDeserilazationOfRooms RoomLocation;
   
   }
}