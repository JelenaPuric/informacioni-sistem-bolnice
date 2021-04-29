using System;

namespace Model
{
   public class News 
   {
        private string id;
        private string title;
        private string description;

      public News() { }

      public News(string argId, string argTitle, string argDescription)
        {
            id = argId;
            title = argTitle;
            description = argDescription;
        }


        public string Id
        {
            get { return id; }
            set { id = value; }
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