using Bookstore.Clients.ConsoleApp.DataExtractor;
using System;
using System.Threading.Tasks;

namespace Bookstore.Clients.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKeyInfo keyInfo;

			do
			{
				Console.WriteLine("Press Enter button to continue or Esc to exit.");
				Console.WriteLine("");
				keyInfo = Console.ReadKey();
			} while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);

			if (keyInfo.Key == ConsoleKey.Enter)
			{
				Task.Run(() => UploadBooksToStore()).Wait();

				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("Press any button to exit.");
				Console.ReadKey();
			}
		}

		private async static Task UploadBooksToStore()
		{
			var inserter = new BookInserter();

			var books = BookDataExtractor.GetBooks();

			foreach (var book in books.BookList)
			{
				await Task.Run(() => inserter.InsertBooksToStore(book))
					.ContinueWith((t) => Console.WriteLine(t.Result));
			}
		}
	}
}
