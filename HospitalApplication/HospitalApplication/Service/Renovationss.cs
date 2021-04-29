using HospitalApplication.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WorkWithFiles;

namespace HospitalApplication.Service
{
   public class Renovationss
    {
        private List<Room> rooms;
        
        public Renovationss()
        {
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
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

        public void RemoveRenovation(Renovation rv)
        {
            for(int i=0; i < rooms.Count; i++)
            {
                if(rooms[i].RoomId == rv.RoomId)
                {
                    for(int j=0; j < rooms[i].Renovation.Count; j++)
                    {
                        if (rooms[i].Renovation[j].IdRenovation == rv.IdRenovation)
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
            for(int i=0; i<rooms.Count; i++)
            {
                for(int j=0; j<rooms[i].Renovation.Count; j++)
                {
                    if (rooms[i].Renovation[j].RoomId == newRenovation.RoomId)
                        if (rooms[i].Renovation[j].Days.Equals(newRenovation.Days))
                        {
                            MessageBox.Show("That room is already busy", "Error");
                            return false;
                        }
                }
                if (newRenovation.Days.Equals(rooms[i].Scheduled))
                {
                    MessageBox.Show("That room is already busy", "Error");
                    return false;
                }
            }
            return true;
        }
    }
}
