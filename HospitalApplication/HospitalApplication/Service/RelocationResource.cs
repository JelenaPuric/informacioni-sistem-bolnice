using HospitalApplication.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using WorkWithFiles;

namespace HospitalApplication.Service
{
    public class RelocationResource
    {
        private List<Room> rooms;
        //private List<Resource> resource;

        public RelocationResource()
        {
            rooms = SerializationAndDeserilazationOfRooms.LoadRoom();
        }



    }
}
