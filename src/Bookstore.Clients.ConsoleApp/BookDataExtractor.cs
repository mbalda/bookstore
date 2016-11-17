using System;
using System.IO;
using System.Xml.Serialization;

namespace Bookstore.Clients.ConsoleApp
{
	public class BookDataExtractor
	{
		public BookDataExtractor()
		{
		}

		public Books GetBooks()
		{
			Books books;

			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Books.xml");
			var serializer = new XmlSerializer(typeof(Books));

			using (StreamReader reader = new StreamReader(path))
			{
				books = (Books)serializer.Deserialize(reader);
			}

			return books;
		}
	}
}