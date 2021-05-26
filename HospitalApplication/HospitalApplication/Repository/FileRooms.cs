using HospitalApplication.Repository;
using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace WorkWithFiles
{
    public class FileRooms : IFile
    {
        private static string path = "../../../Data/rooms.json";
        private static List<Room> rooms;
        private static FileRooms instance;

        public static FileRooms Instance
        {
            get
            {
                if (null == instance)
                    instance = new FileRooms();
                return instance;
            }
        }

        private FileRooms()
        {
            Read();
        }

        public static string GetRoomId(int roomIndex)
        {
            //List<Room> rooms = LoadRoom();
            return rooms[roomIndex].RoomId.ToString();
        }

        public void Read()
        {
            string json = File.ReadAllText(path);
            rooms = new JavaScriptSerializer().Deserialize<List<Room>>(json);
        }

        public void Write()
        {
            string json = new JavaScriptSerializer().Serialize(rooms);
            File.WriteAllText(path, json);
        }

        public List<Room> ShowAllRooms()
        {
            return rooms;
        }

        public List<Renovation> ShowAllRenovations()
        {
            List<Renovation> renovations = new List<Renovation>();
            for (int i = 0; i < rooms.Count; i++)
            {
                for (int j = 0; j < rooms[i].Renovation.Count; j++)
                    renovations.Add(rooms[i].Renovation[j]);
            }
            return renovations;
        }
    }
}