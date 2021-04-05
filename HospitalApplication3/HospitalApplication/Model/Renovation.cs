using System;

namespace Model
{
   public class Renovation
   {
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
         foreach (Room oRoom in newRoom)
            AddRoom(oRoom);
      }
      
      public void AddRoom(Room newRoom)
      {
         if (newRoom == null)
            return;
         if (this.room == null)
            this.room = new System.Collections.ArrayList();
         if (!this.room.Contains(newRoom))
            this.room.Add(newRoom);
      }
      
      public void RemoveRoom(Room oldRoom)
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
   
      public bool IsForRenovation
      {
         get
         {
            // TODO: implement
            return (bool)true;
         }
         set
         {
            // TODO: implement
         }
      }
      
      /*public DateTime DateOfConstruction
      {
         get
         {
            // TODO: implement
            return (DateTime)null;
         }
         set
         {
            // TODO: implement
         }
      }
      */
      /*public DateTime LastTimeRenovated
      {
         get
         {
            // TODO: implement
            return (DateTime)null;
         }
         set
         {
            // TODO: implement
         }
      }*/
   
   }
}