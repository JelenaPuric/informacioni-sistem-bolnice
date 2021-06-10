﻿using HospitalApplication.Controller;
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
    public partial class EditNewsWindow : Window
    {
        private NewsController newsController = new NewsController();
        private HomeWindow homeWindow = HomeWindow.Instance;
        private News currentSelectedNews;

        public EditNewsWindow(News selectedNews)
        {
            InitializeComponent();
            CenterWindow();
            currentSelectedNews = selectedNews;
            SetValuesFields(selectedNews);
        }

        private void SetValuesFields(News selectedNews)
        {
            textBoxTypeNews.Text = selectedNews.TypeNews;
            textBoxTitle.Text = selectedNews.Title;
            textBoxDescription.Text = selectedNews.Description;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //VALIDACIJA PRAZNIH POLJA
            if (textBoxTypeNews.Text.Equals("") && textBoxTypeNews.Text.Equals("") && textBoxTitle.Text.Equals("") && textBoxDescription.Text.Equals(""))
            {
                MessageBox.Show("All fields are required", "Info", MessageBoxButton.OK);
                return;
            }

            if (textBoxTypeNews.Text.Equals(""))
            {
                MessageBox.Show("Type news field are required", "Info", MessageBoxButton.OK);
                return;
            }

            if (textBoxTitle.Text.Equals(""))
            {
                MessageBox.Show("Title field are required", "Info", MessageBoxButton.OK);
                return;
            }

            if (textBoxDescription.Text.Equals(""))
            {
                MessageBox.Show("Description field are required", "Info", MessageBoxButton.OK);
                return;
            }
            //--------------------------------

            SetValues();
            newsController.UpdateNews(currentSelectedNews);
            homeWindow.UpdateNews();
            Close();
        }

        private void SetValues()
        {
            currentSelectedNews.TypeNews = textBoxTypeNews.Text;
            currentSelectedNews.Title = textBoxTitle.Text;
            currentSelectedNews.Description = textBoxDescription.Text;
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
