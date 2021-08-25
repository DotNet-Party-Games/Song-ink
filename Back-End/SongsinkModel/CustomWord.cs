using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SongsinkModel
{
	public class CustomWord
	{
		public CustomWord()
		{ }

        public int Id { get; set;}
		public int PlayerId { get; set; }
		public string CustomWordName { get; set; }

        public int CustomCategoryId { get; set; }
    }
}
