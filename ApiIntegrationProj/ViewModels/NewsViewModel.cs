using ApiIntegrationProj.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ApiIntegrationProj.ViewModels
{
    public class NewsViewModel : Conductor<object>
    {

        //public NewsModel newsObj;   
        private ObservableCollection<ArticleModel> articles;
        private BitmapImage image;
        private TopicsModel selectedComboBoxValue;
        private ObservableCollection<TopicsModel> topics;
        private string query = "";
        private ArticleModel selectedArticle;

        public ArticleModel SelectedArticle
        {
            get { return selectedArticle; }
            set { selectedArticle = value; NotifyOfPropertyChange(nameof(SelectedArticle)); }
        }


        public string Query
        {
            get { return query; }
            set { query = value; }
        }


        public ObservableCollection<TopicsModel> Topics
        {
            get { return topics; }
            set { topics = value; }
        }


        public TopicsModel SelectedComboBoxValue
        {
            get { return selectedComboBoxValue; }
            set { selectedComboBoxValue = value; NotifyOfPropertyChange(nameof(SelectedComboBoxValue)); }
        }


        public BitmapImage Image
        {
            get { return image; }
            set { image = value; }
        }


        public ObservableCollection<ArticleModel> Articles
        {
            get { return articles; }
            set { articles = value; }
        }


        public NewsModel news;

        public NewsViewModel()
        {
            //newsObj = new NewsModel();
            ApiHelper.InitializeClient();
            SelectedComboBoxValue = new TopicsModel { Id = 0, Name = "breaking-news" };
            news = new NewsModel();
            Articles = new ObservableCollection<ArticleModel>();

            LoadComboBoxTopics();
            
            GetNews();
        }




        public async Task<NewsModel> NewsLoader(string topic, string query)
        {
            string API_KEY = "160847f668a7ab3532c6a598c09bf695";
            string url = $"https://gnews.io/api/v4/top-headlines?token={API_KEY}&topic={topic}&lang=en&q={query}";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {

                if (response.IsSuccessStatusCode)
                {
                    news = await response.Content.ReadAsAsync<NewsModel>();
                    return news;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }


        }

        public async Task GetNews()
        {
            news = await NewsLoader(SelectedComboBoxValue.Name, Query);

            Articles = news.Articles;

            NotifyOfPropertyChange(nameof(Articles));

        }

        public void OnComboBoxItemPressed()
        {
            if (SelectedComboBoxValue != null)
            {
                GetNews();
            }
        }

        private void LoadComboBoxTopics()
        {
            topics = new ObservableCollection<TopicsModel>
            {
                new TopicsModel { Id = 0, Name = "breaking-news" },
                new TopicsModel { Id = 1, Name = "world" },
                new TopicsModel { Id = 2, Name = "nation" },
                new TopicsModel { Id = 3, Name = "business" },
                new TopicsModel { Id = 4, Name = "technology" },
                new TopicsModel { Id = 5, Name = "entertainment" },
                new TopicsModel { Id = 6, Name = "sports" },
                new TopicsModel { Id = 7, Name = "science" },
                new TopicsModel { Id = 8, Name = "health" }
            };
        }

        public void OnListViewItemClicked() 
        {
            if (SelectedArticle != null)
            {
                System.Diagnostics.Process.Start(SelectedArticle.Url);
            }
        }
       
    }
}
            
            
