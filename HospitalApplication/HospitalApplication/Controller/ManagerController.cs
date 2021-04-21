using HospitalApplication.Model;
using HospitalApplication.Service;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Controller
{
    public class ManagerController
    {
        private RoomManagment rm = new RoomManagment();
        private RelocationResource rr = new RelocationResource();

        public void CreateRoom(Room r)
        {
            rm.CreateRoom(r);
        }

        public void AddItem(Resource r)
        {
            rm.AddItem(r);
        }

        public void TransferDynamicItem(Resource r, int kk)
        {
            rm.TransferDynamicItem(r, kk);
        }

        public void RemoveRoom(Room oldRoom)
        {
            rm.RemoveRoom(oldRoom);
        }

        public void RemoveById(int roomid)
        {
            rm.RemoveById(roomid);
        }

        public void RemoveItem(Resource re)
        {
            rm.RemoveItem(re);
        }

        public void RemoveQuantity(Resource r, int k)
        {
            rm.RemoveQuantity(r, k);
        }

        public void DeleteTransfer(Transfer t)
        {
            rr.DeleteTransfer(t);
        }

        public void TransStatic(Transfer te)
        {
            rr.TransStatic(te);
        }

        public void CheckTransfers()
        {
            rr.CheckTransfers();
        }



    }
}
