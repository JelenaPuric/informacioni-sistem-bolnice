using HospitalApplication.Model;
using HospitalApplication.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WorkWithFiles;

namespace HospitalApplication.Service
{
   public class RenovationsService
    {
        private List<Room> rooms;
        private List<Transfer> transfers;
        
        public RenovationsService()
        {
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
            transfers = ScheduledTransfers.LoadTransfers();
            CheckIfNullList();
        }

        private void CheckIfNullList()
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Resource == null)
                    rooms[i].Resource = new List<Resource>();
                if (rooms[i].Scheduled == null)
                    rooms[i].Scheduled = new List<DateTime>();
                if (rooms[i].Renovation == null)
                    rooms[i].Renovation = new List<Renovation>();
                for (int j = 0; j < rooms[i].Renovation.Count; j++)
                {
                    if (rooms[i].Renovation[j].Days == null)
                        rooms[i].Renovation[j].Days = new List<DateTime>();
                }
            }
        }

        public List<Renovation> GetList()
        {
            List<Renovation> vrati = new List<Renovation>();
            for (int  i=0; i<rooms.Count; i++)
            {
                for(int j=0; j<rooms[i].Renovation.Count; j++)
                {
                    vrati.Add(rooms[i].Renovation[j]);
                }
            }
            return vrati;
        }

        public void RemoveRenovation(Renovation renovation)
        {
            for(int i=0; i < rooms.Count; i++)
            {
                if(rooms[i].RoomId == renovation.RoomId)
                {
                    for(int j=0; j < rooms[i].Renovation.Count; j++)
                    {
                        if (rooms[i].Renovation[j].IdRenovation == renovation.IdRenovation)
                            rooms[i].Renovation.RemoveAt(j);
                    }
                }
            }
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }

        public void AddRenovation(Renovation newRenovation)
        {
            for(int i=0; i<rooms.Count; i++)
            {
                if(rooms[i].RoomId == newRenovation.RoomId)
                    rooms[i].Renovation.Add(newRenovation);
            }

            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }

        public bool CheckRenovation(Renovation newRenovation)
        {
            return CheckDoesRoomExistAndIsFree(newRenovation);
            return DoesRoomHaveTransfers(newRenovation);
        }

        private bool DoesRoomHaveTransfers(Renovation newRenovation)
        {
            if (transfers.Count != 0)
            {
                for (int t = 0; t < transfers.Count; t++)
                {
                    if (newRenovation.RoomId == transfers[t].idRoomFrom || newRenovation.RoomId == transfers[t].idRoomTo)
                    {
                        for (int daysforcheck = 0; daysforcheck < newRenovation.Days.Count; daysforcheck++)
                        {
                            if (newRenovation.Days[daysforcheck].Date == transfers[t].dat.Date)
                            {
                                MessageBox.Show("That room is already busy, relocation of static equipment is scheduled", "Error");
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool CheckDoesRoomExistAndIsFree(Renovation newRenovation)
        {
            int roomExist = 0;
            for (int i = 0; i < rooms.Count; i++)
            {
                for (int j = 0; j < rooms[i].Renovation.Count; j++)
                {
                    if (rooms[i].Renovation[j].RoomId == newRenovation.RoomId)
                        for (int d = 0; d < rooms[i].Renovation[j].Days.Count; d++)
                        {
                            for (int nd = 0; nd < newRenovation.Days.Count; nd++)
                            {
                                if (rooms[i].Renovation[j].Days[d].Date == newRenovation.Days[nd].Date)
                                {
                                    MessageBox.Show("That room is already busy", "Error");
                                    return false;
                                }
                            }
                        }
                }
                if (rooms[i].RoomId == newRenovation.RoomId)
                {
                    roomExist++;
                }
            }
            if (roomExist == 0)
            {
                MessageBox.Show("That room does not exist", "Error");
                return false;
            }
            return true;
        }

        public void IsFinishRenovation()
        {
            for(int i=0; i<rooms.Count; i++)
            {
                for(int j=0; j<rooms[i].Renovation.Count; j++)
                {
                    if (rooms[i].Renovation[j].EndDay <= DateTime.Now)
                        rooms[i].Renovation.RemoveAt(j);
                }
            }
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }
    }
}
