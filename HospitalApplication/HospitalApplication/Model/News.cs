using System;

namespace Model
{
   public class News 
   {
        private string typeNews;
        private string id;
        private string title;
        private string description;
        private DateTime publicationDate;

      public News() { }

      public News(string argId, string argTypeNews, string argTitle, string argDescription, DateTime argPublicationDate)
      {
            id = argId;
            title = argTitle;
            description = argDescription;
            typeNews = argTypeNews;
            publicationDate = argPublicationDate;
      }

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set { publicationDate = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string TypeNews
        {
            get { return typeNews; }
            set { typeNews = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}