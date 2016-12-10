using Bookstore.Clients.ConsoleApp.DataExtractor;
using Bookstore.Clients.ConsoleApp.Service;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Bookstore.Clients.ConsoleApp
{
	public class BookInserter
	{
		const string ResourceBaseUrl = "books";
		private readonly ServiceProvider _services;

		public BookInserter()
		{
			_services = new ServiceProvider();
		}

		public string InsertBooksToStore(Book book)
		{
			string message;

			var resposne = _services.Post(ResourceBaseUrl, book);
			var responseContent = JsonConvert.DeserializeObject<BookResponse>(resposne.Content.ReadAsStringAsync().Result);

			if (resposne.StatusCode == HttpStatusCode.Created)
			{
				message = $"Book: {book.Title}, has been uploaded to store.";
				message += UploadImage(responseContent.Id, book.ImageName);
			}
			else
			{
				message = $"Some error occured uploading book: {book.Title}. Details: {resposne.ReasonPhrase}.";
			}

			return message;
		}

		private Stream ReadFile(string fileName)
		{
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Images", fileName);
			return File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		}

		private string UploadImage(int bookId, string fileName)
		{
			string resourceImageUrl = $"{ResourceBaseUrl}/{bookId}/image";

			var image = ReadFile(fileName);

			var result = _services.UploadFileForBook(resourceImageUrl, image, fileName);

			if (result.StatusCode == HttpStatusCode.Created)
			{
				return $"File '{fileName}' for book with ID {bookId}, has been uploaded to store.";
			}

			return $"Some error occured uploading image '{fileName}'. Details: {result.ReasonPhrase}.";
		}
	}
}
