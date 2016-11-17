using System;
using System.Threading.Tasks;

namespace Bookstore.Clients.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Press Enter button to continue...");
			Console.WriteLine("");
			Console.ReadKey();

			Task.Run(() => Do()).Wait();

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Press Enter button to exit.");
			Console.ReadKey();
		}

		private async static Task Do()
		{
			var bookDataExtractor = new BookDataExtractor();
			var inserter = new BookInserter();

			var books = bookDataExtractor.GetBooks();

			foreach (var book in books.BookList)
			{
				await Task.Run(() => inserter.InsertBooksToStore(book))
					.ContinueWith((t) => Console.WriteLine(t.Result));
			}
		}
	}
}
