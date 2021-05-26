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
    public class RelocationResourceService
    {
        private List<Transfer> transfers;
        private List<Room> rooms;
        private FileRooms fileRooms = FileRooms.Instance;
        private FileScheduledTransfers fileTransfers = FileScheduledTransfers.Instance;

        public RelocationResourceService()
        {
            transfers = fileTransfers.ShowAllTransfers();
            rooms = fileRooms.ShowAllRooms();
        }

        public void DeleteTransfer(Transfer oldTransfer)
        {
            for(int i=0; i < transfers.Count; i++)
            {
                if(transfers[i].idTransfer == oldTransfer.idTransfer)
                    transfers.RemoveAt(i);
            }
            fileTransfers.Write();
        }

        public void AddStaticTransfer(Transfer newTransfer)
        {
            int ok = 0;
            for(int i=0; i < transfers.Count; i++)
            {
                if (transfers[i].idTransfer == newTransfer.idTransfer || transfers[i].date == newTransfer.date && transfers[i].idRoomTo == newTransfer.idRoomTo)
                {
                    MessageBox.Show("That term for that room is already taken!", "Error");
                    ok++;
                    break;
                }
            }
            if (newTransfer.idRoomFrom == newTransfer.idRoomTo)
            {
                MessageBox.Show("That resource is alredy in that room", "Error");
                ok++;
            }
            if (ok == 0)
                transfers.Add(newTransfer);
            fileTransfers.Write();
        }

        public void CheckTransfers()
        {
            if (transfers == null)
                transfers = new List<Transfer>();
            for (int i=0; i < transfers.Count; i++)
            {
                if(transfers[i].date <= DateTime.Now)
                {
                    for (int l = 0; l < transfers[i].resource.Count; l++)
                    {
                        for (int j = 0; j < rooms.Count; j++)
                        {
                            if (transfers[i].idRoomFrom == rooms[j].RoomId)
                            {
                                if(rooms[j].Resource != null) 
                                { 
                                    for (int k = 0; k < rooms[j].Resource.Count; k++)
                                    {
                                        if (transfers[i].resource[l].idItem == rooms[j].Resource[k].idItem)
                                        {
                                            rooms[j].Resource[k].quantity -= transfers[i].quantity;
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
                                            if (rooms[z].Resource[k].idItem == transfers[i].resource[l].idItem)
                                            {

                                                rooms[z].Resource[k].quantity += transfers[i].quantity;
                                                transfers[i].resource[k].quantity++;
                                                break;
                                            }
                                            else
                                            {
                                                rooms[z].Resource.Add(transfers[i].resource[l]);
                                                transfers[i].resource[k].quantity++;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        rooms[z].Resource.Add(transfers[i].resource[l]);
                                        transfers[i].quantity++;
                                    }
                                }
                                else { rooms[z].Resource = new List<Resource>(); }

                            }   
                            
                        }
                    }
                    transfers.RemoveAt(i);
                }
            }
            fileTransfers.Write();
            fileRooms.Write();
        }

        public bool CheckDoesRoomExist(Transfer newTransfer)
        {
            int ok = 0;
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomId == newTransfer.idRoomTo)
                    ok++;
            }
            if (ok != 0)
                return true;
            return false;
        }
    }
}
