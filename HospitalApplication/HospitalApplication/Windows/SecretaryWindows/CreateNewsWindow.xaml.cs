using HospitalApplication.Controller;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkWithFiles;

namespace HospitalApplication.Windows.Secretary
{
    public partial class CreateNewsWindow : Window
    {
        private NewsController newsController = new NewsController();
        private NewsWindow newsWindow = NewsWindow.Instance;

        public CreateNewsWindow()
        {
            InitializeComponent();
            CenterWindow();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            News newNews = new News(IdGenerator(), textBoxTypeNews.Text, textBoxTitle.Text, textBoxDescription.Text, DateTime.Now);
            newsController.CreateNews(newNews);
            newsWindow.UpdateNews();
            Close();
        }

        private string IdGenerator()
        {
            int n = newsController.GetAllNews().Count;
            int idNews;
            if (n > 0){
                idNews = Int32.Parse(newsController.GetAllNews()[n - 1].Id) + 1;
            }
            else idNews = 0;
            return idNews.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CenterWindow()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
