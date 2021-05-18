using Model;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkWithFiles
{
   public class FileNews
   {

        public static string path = "../../../Data/news.json";

        public static List<News> LoadNews()
        {
            //ako ne postoji fajl (jos uvek nista nije sacuvano pri prvom pokretanju aplikacije vrati praznu listu)
            if (!File.Exists(path))
                return new List<News>();

            string json = File.ReadAllText(path);
            List<News> news = new JavaScriptSerializer().Deserialize<List<News>>(json);

            return news;
        }

        public static void EnterNews(List<News> input)
        {
            string json = new JavaScriptSerializer().Serialize(input);
            File.WriteAllText(path, json);
        }

    }
}