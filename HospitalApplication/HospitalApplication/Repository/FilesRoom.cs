using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace WorkWithFiles
{
   public class FilesRoom
   {
        public static string FileRoom = "../../../Data/rooms.json";

        public static List<Room> LoadRoom()
      {
            //ako ne postoji fajl (jos uvek nista nije sacuvano pri prvom pokretanju aplikacije vrati praznu listu)
            if (!File.Exists(FileRoom))
                return new List<Room>();

            string json = File.ReadAllText(FileRoom);
            List<Room> rooms = new JavaScriptSerializer().Deserialize<List<Room>>(json);

            return rooms;
        }
      
      public static void EnterRoom(List<Room> input)
      {
            string json = new JavaScriptSerializer().Serialize(input);
            File.WriteAllText(FileRoom, json);
        }
   
   }
}