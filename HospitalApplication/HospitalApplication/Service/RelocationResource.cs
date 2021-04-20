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
        }

        public List<Transfer> showAllTransfers()
        {
            return transfers;
        }

        public bool CheckRoom(Transfer t) {
            int ok = 0;
            for(int i=0; i<rooms.Count; i++)
            {
                if (rooms[i].RoomId == t.idRoomTo)
                    ok++;
            }
            if (ok != 0)
                return true;
            return false;
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

        public void CheckTransfers(List<Transfer> listica)
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
                            for (int k = 0; k < rooms[i].Resource.Count; k++)
                            {
                                if (transfers[i].idRoomFrom == rooms[j].RoomId)
                                {
                                    rooms[j].Resource[k].quantity -= transfers[i].Res[l].quantity;
                                    // transfers.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        for(int j=0; j<rooms.Count; j++) 
                        {
                            if (transfers[i].idRoomTo == rooms[j].RoomId)
                            {
                                for (int k = 0; k < rooms[i].Resource.Count; k++)
                                { 
                                    if (rooms[j].Resource[k].idItem == transfers[i].Res[l].idItem)
                                    {
                                        transfers[i].Res.RemoveAt(l);
                                        rooms[j].Resource[k].quantity += transfers[i].Res[l].quantity;
                                        break;
                                    }
                                    else
                                    {
                                        rooms[j].Resource.Add(transfers[i].Res[l]);
                                        transfers[i].Res.RemoveAt(l);
                                        break;
                                    }
                                }
                            }   
                            
                        }
                    }
                }
            }
            for(int i=0; i<transfers.Count; i++)
            {
                for(int j=0; j<listica.Count; j++)
                {
                    if (transfers[i].Res != listica[j].Res)
                        transfers.RemoveAt(i);
                }
                
            }
            
            ScheduledTransfers.EnterTransfer(transfers);
            SerializationAndDeserilazationOfRooms.EnterRoom(rooms);
        }



    }
}
