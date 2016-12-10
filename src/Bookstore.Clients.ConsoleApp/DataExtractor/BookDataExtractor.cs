using System;
using System.IO;
using System.Xml.Serialization;

namespace Bookstore.Clients.ConsoleApp.DataExtractor
{
	public static class BookDataExtractor
	{
		public static Books GetBooks() => DeserializeData();

		private static Books DeserializeData()
		{
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Books.xml");
			var serializer = new XmlSerializer(typeof(Books));

			using (var reader = new StreamReader(path))
			{
				return (Books)serializer.Deserialize(reader);
			}
		}
	}
}