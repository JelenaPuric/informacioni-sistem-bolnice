using System;
using System.Collections.Generic;
using Model;

namespace Logic
{
   public class RoomManagment
   {
      public void CreateRoom(string floor, string password, bool occupied, Model.RoomType type)
      {
         // TODO: implement
      }
      
      public void RemoveRoom(string password)
      {
         // TODO: implement
      }
      
      public void izmenaProstorije(string password)
      {
         // TODO: implement
      }
      
      public List<Room> prikaziSveProsotrije()
      {
         // TODO: implement
         return null;
      }
      
      public void prikaziProstoriju()
      {
         // TODO: implement
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