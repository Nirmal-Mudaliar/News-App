using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationProj.Models
{
    public class TopicsModel
    {
		private int id;
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		public int Id
		{
			get { return id; }
			set { id = value; }
		}

	}
}
