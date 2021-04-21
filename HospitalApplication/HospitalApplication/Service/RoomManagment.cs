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

        public void TransferDynamicItem(Resource r, int kk)
        {
            int skr = 0;
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomId == r.roomId)
                {
                    if (rooms[i].Resource == null)
                    {
                        rooms[i].Resource = new List<Resource>();
                        rooms[i].Resource.Add(r);
                    }
                    else { 
                        for(int j = 0; j < rooms[i].Resource.Count; j++)
                        {
                            if(rooms[i].Resource[j].idItem == r.idItem)
                            {
                                rooms[i].Resource[j].quantity += kk;
                                skr += 1;
                            }
                        }
                        if(skr==0)
                            rooms[i].Resource.Add(r);
                    }
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

        public void RemoveQuantity(Resource r, int k)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomId == r.roomId)
                {
                    for (int j = 0; j < rooms[i].Resource.Count; j++)
                    {
                        if (rooms[i].Resource[j].idItem == r.idItem)
                        {
                            rooms[i].Resource[j].quantity -= k;
                        }
                    }
                }
            }
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
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
   }
}