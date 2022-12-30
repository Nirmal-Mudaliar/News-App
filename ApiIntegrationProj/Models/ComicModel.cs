using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationProj.Models
{
    public class ComicModel
    {
		private int num;

		public int Num
		{
			get { return num; }
			set { num = value; }
		}

		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}


		private string img;

		public string Img
		{
			get { return img; }
			set { img = value; }
		}



	}
}
