using System;
using System.Collections.Generic;
using Model;
using WorkWithFiles;

namespace Logic
{
   public class NewsService
   {
        private List<News> news;
        private FileNews fileNews = FileNews.Instance;
        private static NewsService instance;

        public static NewsService Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new NewsService();
                }
                return instance;
            }
        }

        public NewsService()
        {
            instance = this;
            news = fileNews.GetNews();
        }

        public List<News> GetAllNews()
        {
            return news;
        }

        public void CreateNews(News newNews)
        {
            news.Add(newNews);
            fileNews.Write();
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
            fileNews.Write();
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
            fileNews.Write();
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