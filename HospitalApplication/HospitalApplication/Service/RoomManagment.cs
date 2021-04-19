 using System;
using System.Collections.Generic;
using HospitalApplication.Model;
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


        public void AddItem(Resource r) {
            for (int i = 0; i < rooms.Count; i++) { 
                if(rooms[i].RoomId == r.roomId)
                {
                    if (rooms[i].Resource == null)
                    {
                        rooms[i].Resource = new List<Resource>();
                    }
                    rooms[i].Resource.Add(r);
                }
            }
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }
      
      public void RemoveRoom(Model.Room oldRoom)
      {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomId == oldRoom.RoomId)
                {
                    rooms.RemoveAt(i); break;
                }
            }

            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }

      public void RemoveById(int roomid)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(rooms[i].RoomId == roomid)
                {
                    rooms.RemoveAt(i); break;
                }
            }
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }

        public void RemoveItem(Resource re)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(rooms[i].RoomId == re.roomId)
                {
                    for(int j = 0; j < rooms[i].Resource.Count; j++)
                    {
                        if(rooms[i].Resource[j].idItem == re.idItem)
                        {
                            rooms[i].Resource.RemoveAt(j);
                        }
                    }
                }
            }
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
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
      
      //public void RemoveRoom(Model.Room oldRoom)
      //{
      //   if (oldRoom == null)
      //      return;
      //   if (this.room != null)
      //      if (this.room.Contains(oldRoom))
      //         this.room.Remove(oldRoom);
      //}
      
      public void RemoveAllRoom()
      {
         if (room != null)
            room.Clear();
      }
   
      private WorkWithFiles.SerializationAndDeserilazationOfRooms RoomLocation;
   
   }
}