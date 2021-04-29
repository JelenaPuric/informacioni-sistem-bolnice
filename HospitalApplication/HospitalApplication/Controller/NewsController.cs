
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Controller
{
    public class NewsController
    {
        private NewsManagement newsManagement = NewsManagement.Instance;

        public void CreateNews(News newNews)
        {
            newsManagement.CreateNews(newNews);
        }

        public void DeleteNews(string iDNews)
        {
            newsManagement.DeleteNews(iDNews);
        }

        public List<News> GetAllNews()
        {
            return newsManagement.GetAllNews();
        }
        public void UpdateNews(News currentNews)
        {
            newsManagement.UpdateNews(currentNews);
        }

        public News getNews(string iDNews)
        {
            return newsManagement.getNews(iDNews);
        }
    }
}
