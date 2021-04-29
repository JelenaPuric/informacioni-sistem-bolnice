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

namespace HospitalApplication.Windows.Secretary
{
    public partial class NewsWindow : Window
    {
        private NewsManagement newsManagement = new NewsManagement();

        private static NewsWindow instance;
        public static NewsWindow Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new NewsWindow();
                }
                return instance;
            }
        }

        public NewsWindow()
        {
            InitializeComponent();
            CenterWindow();
            instance = this;
            UpdateNews();
        }

        public void UpdateNews()
        {
            lvUsers.ItemsSource = null;
            lvUsers.ItemsSource = newsManagement.GetAllNews();
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

        private void CreateNews_Click(object sender, RoutedEventArgs e)
        {
            CreateNewsWindow window = new CreateNewsWindow();
            window.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvUsers.SelectedIndex > -1)) { return; }
            News selectedNews = (News)lvUsers.SelectedItem;
            newsManagement.DeleteNews(selectedNews.Id);
            UpdateNews();
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
