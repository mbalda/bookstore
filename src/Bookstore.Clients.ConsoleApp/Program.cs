using System;

namespace Bookstore.Clients.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Press Enter button to continue...");
			Console.ReadKey();

			new BookInserter().InsertBooksToStore();
		}
	}
}
