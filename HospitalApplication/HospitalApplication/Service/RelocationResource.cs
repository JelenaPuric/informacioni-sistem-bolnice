using HospitalApplication.Model;
using HospitalApplication.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WorkWithFiles;

namespace HospitalApplication.Service
{
    public class RelocationResource
    {
        private List<Transfer> transfers;
        private List<Room> rooms;

        public RelocationResource()
        {
            transfers = ScheduledTransfers.LoadTransfers();
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Resource == null)
                    rooms[i].Resource = new List<Resource>();
                if (rooms[i].Scheduled == null)
                    rooms[i].Scheduled = new List<DateTime>();
                if (rooms[i].Renovation == null)
                    rooms[i].Renovation = new List<Renovation>();
            }
        }

        public void DeleteTransfer(Transfer t)
        {
            for(int i=0; i < transfers.Count; i++)
            {
                if(transfers[i].idTransfer == t.idTransfer)
                {
                    transfers.RemoveAt(i);
                }
            }
            ScheduledTransfers.EnterTransfer(transfers);
        }

        public void TransStatic(Transfer te)
        {
            int ok = 0;

            for(int i=0; i < transfers.Count; i++)
            {
                if (transfers[i].idTransfer == te.idTransfer || transfers[i].dat == te.dat && transfers[i].idRoomTo == te.idRoomTo) {

                    MessageBox.Show("That term for that room is already taken!", "Error");
                    ok++;
                }
               
            }
            if(ok == 0)
                transfers.Add(te);
            ScheduledTransfers.EnterTransfer(transfers);
        }

        public void CheckTransfers()
        {
            if (transfers == null)
            {
                transfers = new List<Transfer>();
            }

            for (int i=0; i < transfers.Count; i++)
            {
                if(transfers[i].dat <= DateTime.Now)
                {
                    
                    for (int l = 0; l < transfers[i].Res.Count; l++)
                    {
                        for (int j = 0; j < rooms.Count; j++)
                        {
                            if (transfers[i].idRoomFrom == rooms[j].RoomId)
                            {
                                if(rooms[j].Resource != null) 
                                { 
                                    for (int k = 0; k < rooms[j].Resource.Count; k++)
                                    {
                                        if (transfers[i].Res[l].idItem == rooms[j].Resource[k].idItem)
                                        {
                                            rooms[j].Resource[k].quantity -= transfers[i].kolicina;
                                            // transfers.RemoveAt(i);
                                            break;
                                        }
                                    
                                    }
                                }
                                else { rooms[j].Resource = new List<Resource>(); }
                            }
                        }
                        for(int z=0; z<rooms.Count; z++) 
                        {
                            if (transfers[i].idRoomTo == rooms[z].RoomId)
                            {
                                if(rooms[z].Resource != null) 
                                { 
                                    if (rooms[z].Resource.Count != 0)
                                    {
                                        for (int k = 0; k < rooms[z].Resource.Count; k++)
                                        {
                                            if (rooms[z].Resource[k].idItem == transfers[i].Res[l].idItem)
                                            {

                                                rooms[z].Resource[k].quantity += transfers[i].kolicina;
                                                transfers[i].Res[k].quantity++;
                                                break;
                                            }
                                            else
                                            {
                                                rooms[z].Resource.Add(transfers[i].Res[l]);
                                                transfers[i].Res[k].quantity++;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        rooms[z].Resource.Add(transfers[i].Res[l]);
                                        transfers[i].kolicina++;
                                    }
                                }
                                else { rooms[z].Resource = new List<Resource>(); }

                            }   
                            
                        }
                    }

                    transfers.RemoveAt(i);
                }
            }
            
            ScheduledTransfers.EnterTransfer(transfers);
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }

        public List<Transfer> showAllTransfers()
        {
            return transfers;
        }

        public bool CheckRoom(Transfer t)
        {
            int ok = 0;
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomId == t.idRoomTo)
                    ok++;
            }
            if (ok != 0)
                return true;
            return false;
        }

    }
}
