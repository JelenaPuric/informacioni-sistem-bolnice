using HospitalApplication.Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HospitalApplication.Repository
{
    public class FileScheduledTransfers
    {
        public static string FileTransfers = "../../../Data/transfers.json";

        public static List<Transfer> LoadTransfers()
        {
            if (!File.Exists(FileTransfers))
                return new List<Transfer>();

            string json = File.ReadAllText(FileTransfers);
            List<Transfer> transfer = new JavaScriptSerializer().Deserialize<List<Transfer>>(json);

            return transfer;
        }
    

        public static void EnterTransfer(List<Transfer> input)
        {
            string json = new JavaScriptSerializer().Serialize(input);
            File.WriteAllText(FileTransfers, json);
        }
    }
}
