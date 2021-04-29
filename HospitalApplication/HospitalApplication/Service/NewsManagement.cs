using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class NewsManagement
   {
        private List<News> news;

        private static NewsManagement instance;
        public static NewsManagement Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new NewsManagement();
                }
                return instance;
            }
        }

        public NewsManagement()
        {
            instance = this;
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

        public void UpdateNews(News currentNews)
        {
            for (int i = 0; i < news.Count; i++)
            {
                if (news[i].Id.Equals(currentNews.Id))
                {
                    news[i].TypeNews = currentNews.TypeNews;
                    news[i].Title = currentNews.Title;
                    news[i].Description = currentNews.Description;
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