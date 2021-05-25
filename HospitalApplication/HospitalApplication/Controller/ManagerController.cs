﻿using HospitalApplication.Model;
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
        private RoomService RoomManagment = new RoomService();
        private RelocationResourceService RelocationResource = new RelocationResourceService();
        private RenovationsService RenovationService = new RenovationsService();

        public void CreateRoom(Room room)
        {
            RoomManagment.CreateRoom(room);
        }

        public void AddItem(Resource resource)
        {
            RoomManagment.AddItem(resource);
        }

        public void TransferDynamicItem(Resource resource, int quantity)
        {
            RoomManagment.TransferDynamicItem(resource, quantity);
        }

        public void RemoveRoom(Room oldRoom)
        {
            RoomManagment.RemoveRoom(oldRoom);
        }

        public void RemoveById(int roomid)
        {
            RoomManagment.RemoveById(roomid);
        }

        public void RemoveItem(Resource resource)
        {
            RoomManagment.RemoveItem(resource);
        }

        public void RemoveQuantity(Resource resource, int quantity)
        {
            RoomManagment.RemoveQuantity(resource, quantity);
        }

        public void DeleteTransfer(Transfer transfer)
        {
            RelocationResource.DeleteTransfer(transfer);
        }

        public void TransStatic(Transfer transfer)
        {
            RelocationResource.TransStatic(transfer);
        }

        public void CheckTransfers()
        {
            RelocationResource.CheckTransfers();
        }

        public void RemoveRenovation(Renovation renovation)
        {
            RenovationService.RemoveRenovation(renovation);
        }

        public void AddRenovation(Renovation renovation)
        {
            RenovationService.AddRenovation(renovation);
        }

        public void CheckRenovation(Renovation renovation)
        {
            RenovationService.CheckRenovation(renovation);
        }

        public void IsFinishRenovation()
        {
            RenovationService.DeleteOldRenovations();
        }
    }
}
