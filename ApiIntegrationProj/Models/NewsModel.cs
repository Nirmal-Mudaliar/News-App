using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationProj.Models
{
    public class NewsModel
    {
		private int totalArticles;
		private ObservableCollection<ArticleModel> articles;

		public ObservableCollection<ArticleModel> Articles
		{
			get { return articles; }
			set { articles = value;
				
			}
		}

		public int TotalArticles
        {
			get { return totalArticles; }
			set { totalArticles = value; }
		}

	}
}
