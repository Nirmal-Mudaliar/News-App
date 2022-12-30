using ApiIntegrationProj.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace ApiIntegrationProj.ViewModels
{
    public class ComicViewModel: Conductor<object>
    {
        private int index = 0;
        private BitmapImage imgSource;
        private ComicModel comic;
        private ComicModel selectedComic;
        private ObservableCollection<ComicModel> comics;


        public ComicModel SelectedComic
        {
            get { return selectedComic; }
            set { selectedComic = value; }
        }



        public BitmapImage ImgSource
        {
            get { return imgSource; }
            set { imgSource = value; NotifyOfPropertyChange(nameof(ImgSource)); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(nameof(Title)); }
        }


        public ObservableCollection<ComicModel> Comics
        {
            get { return comics; }
            set { comics = value; }
        }



        //public Image Image
        //{
        //    get { return image; }
        //    set { image = value; NotifyOfPropertyChange(nameof(Image.Source)); }
        //}

        public ComicViewModel()
        {
            ApiHelper.InitializeClient();
            comic = new ComicModel();
            comics = new ObservableCollection<ComicModel>();
            //Task.Run(() => LoadImage());
            //_ = LoadData();
            //Task.Run(() => LoadNextData());

            LoadNextData();
        }

        public static async Task<ComicModel> ComicLoader(int comicNumber = 0)
        {
            string url = "";
            if (comicNumber > 0)
            {
                url = $"https://xkcd.com/{comicNumber}/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }
            using(HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

      
        

        public async Task LoadNextData()
        {
            index++;
           
            comic = await ComicLoader(index);
            
            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            ImgSource = new BitmapImage(uriSource);
            Title = comic.Title;  
        }
        public async Task LoadPreviousData()
        {
            
            index--;

            comic = await ComicLoader(index);

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            ImgSource = new BitmapImage(uriSource);
            Title = comic.Title;
        }

        public void Save()
        {
            if (!Comics.Contains(comic))
            {
                Comics.Add(comic);
            }
            else
            {
                MessageBox.Show("Comic already exist in the list.");
            }
            
        }

        public void Delete(object data)
        {
            if (data is ComicModel comic && comic != null)
            {
                MessageBox.Show(comic.Title);
                Comics.Remove(comic);
                //NotifyOfPropertyChange(nameof(Comics));
            }
            
        }

        public void OnItemClick(object data)
        {
            if (data is ComicModel comic && comic != null)
            {
                MessageBox.Show(comic.Title);
                
            }
            MessageBox.Show(SelectedComic.Title);

        }


    }
}
