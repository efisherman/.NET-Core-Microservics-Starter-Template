using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Articles
{
	public class AddCategoryViewModel
	{
		public string Title { get; set; }
		public string Importance { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
	}
}
