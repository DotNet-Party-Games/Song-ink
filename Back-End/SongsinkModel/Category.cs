using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SongsinkModel
{
	public class Category
	{
		private int _id;
		private string _categoryName;
		private List<Word> _words = new List<Word>();

		public Category ()
		{
		}

		public int Id { get; set; }
		public string CategoryName 
		{ 
			get
			{
				return _categoryName;
			}
			set
			{
				// if (!Regex.IsMatch(value, @"^[A-Za-z .'-]+$"))
				// {
				// 	throw new Exception("Invalid Input [A-Za-z .'-]");
				// }
				_categoryName = value;
			}
		}

        public List<Word> Words { get => _words; set => _words = value; }
    }
}
