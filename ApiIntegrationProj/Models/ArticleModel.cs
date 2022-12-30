using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationProj.Models
{
    public class ArticleModel
    {
		private string title;
		private string description;
		private string content;
		private string url;
		private string publishedAt;
		private string image;

		public string Image
		{
			get { return image; }
			set { image = value; }
		}


		public string PublishedAt
		{
			get { return publishedAt; }
			set { publishedAt = value; }
		}



		public string Url
		{
			get { return url; }
			set { url = value; }
		}


		public string Content
		{
			get { return content; }
			set { content = value; }
		}


		public string Description
		{
			get { return description; }
			set { description = value; }
		}


		public string Title
		{
			get { return title; }
			set { title = value; }
		}

	}
}
