 using System;
using System.Collections.Generic;
using System.Windows;
using HospitalApplication.Model;
using Model;
using WorkWithFiles;

namespace Logic
{
    public class RoomService
    {
        private List<Room> rooms;
        private List<Appointment> appointments;
        private FilesAppointments filesAppointments = new FilesAppointments();

        public RoomService()
        {
            rooms = FilesRooms.LoadRoom();
            for(int i=0; i<rooms.Count; i++)
            {
                if (rooms[i].Resource == null)
                    rooms[i].Resource = new List<Resource>();
                if (rooms[i].Scheduled == null)
                    rooms[i].Scheduled = new List<DateTime>();
                if (rooms[i].Renovation == null)
                    rooms[i].Renovation = new List<Renovation>();
            }
            appointments = filesAppointments.LoadFromFile();
        }
        public void CreateRoom(Room r)
        {
            rooms.Add(r);
            FilesRooms.EnterRoom(rooms);
        }

        public void CheckIfZero(Room r)
        {
            for(int i=0; i<rooms.Count; i++)
            {
                if(rooms[i].RoomId == r.RoomId)
                {
                    for(int j=0; j<rooms[i].Resource.Count; j++)
                    {
                        if (rooms[i].Resource[j].quantity == 0)
                            rooms[i].Resource.RemoveAt(j);
                    }
                }
            }
            FilesRooms.EnterRoom(rooms);
        }

        public List<Resource> FindItem(string s, int i)
        {
            List<Resource> roo = new List<Resource>();
            for (int k=0; k < rooms.Count; k++)
            {
                for(int j=0; j<rooms[k].Resource.Count; j++)
                {
                    if (rooms[k].Resource[j].name.Equals(s))
                    {
                        if (rooms[k].Resource[j].quantity >= i)
                            roo.Add(rooms[k].Resource[j]);
                    }
                }
            }
            return roo;
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
            FilesRooms.EnterRoom(rooms);
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
            FilesRooms.EnterRoom(rooms);
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
            for (int i = 0; i < appointments.Count; i++)
                if (appointments[i].RoomId == oldRoom.RoomId.ToString()) appointments.RemoveAt(i);
            filesAppointments.WriteInFile(appointments);
            FilesRooms.EnterRoom(rooms);
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
            for (int i = 0; i < appointments.Count; i++)
                if (appointments[i].RoomId == roomid.ToString()) appointments.RemoveAt(i);
            filesAppointments.WriteInFile(appointments);
            FilesRooms.EnterRoom(rooms);
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
            FilesRooms.EnterRoom(rooms);
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
            FilesRooms.EnterRoom(rooms);
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

        //Ratko dodao, ove funkcije pozivam u ExaminationService
        public Tuple<bool, int> IsRoomFree(DateTime date)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                bool roomIsFree = true;
                for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                {
                    if (rooms[i].Scheduled[j] == date)
                        roomIsFree = false;
                }
                if (roomIsFree)
                    return new Tuple<bool, int>(true, i);
            }
            return new Tuple<bool, int>(false, -1);
        }

        public void AddExaminationToRoom(int roomIndex, DateTime date)
        {
            rooms[roomIndex].Scheduled.Add(date);
            FilesRooms.EnterRoom(rooms);
        }

        public void RemoveExaminationFromRoom(String roomId, DateTime date)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomId.ToString() == roomId)
                {
                    for (int j = 0; j < rooms[i].Scheduled.Count; j++)
                    {
                        if (rooms[i].Scheduled[j] == date)
                        {
                            rooms[i].Scheduled.RemoveAt(j);
                            FilesRooms.EnterRoom(rooms);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}