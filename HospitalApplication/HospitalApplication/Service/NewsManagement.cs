using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class NewsManagement
   {

        private List<News> news;

        public NewsManagement()
        {
            news = FilesNews.LoadNews();
        }

        public List<News> GetAllNews()
        {
            return news;
        }

        public void CreateNews(News newNews)
        {
            news.Add(newNews);
            FilesNews.EnterNews(news);
        }

        public void DeleteNews(string iDNews)
        {
            for (int i = 0; i < news.Count; i++)
            {
                if (news[i].Id == iDNews)
                {
                    news.RemoveAt(i); break;
                }
            }
            FilesNews.EnterNews(news);
        }

        public News getNews(string iDNews)
        {
            News n = new News();
            for (int i = 0; i < news.Count; i++)
            {
                if (news[i].Id == iDNews)
                {
                    n = news[i];
                    break;
                }
            }
            return n;
        }
    }
}