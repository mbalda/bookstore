﻿using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.WebModels;

namespace Bookstore.Common.Infrastructure.Commands
{
	public class AddNewBookCommand : ICommandValidator
	{
		public string Author { get; }

		public string Title { get; }

		public string Isbn { get; }

		public decimal Price { get; }

		public decimal Discount { get; }

		public int Pages { get; }

		public int Amount { get; }

		public string Description { get; }

		public AddNewBookCommand(NewBook newBook)
		{
			Author = newBook.Author;
			Title = newBook.Title;
			Isbn = newBook.Isbn;
			Pages = newBook.Pages;
			Description = newBook.Description;
			Price = newBook.Price;
			Discount = newBook.Discount;
			Amount = newBook.Amount;
		}

		public bool IsValidCommand()
		{
			return !string.IsNullOrEmpty(this.Author)
					&& !string.IsNullOrEmpty(this.Title)
					&& !string.IsNullOrEmpty(this.Isbn)
					&& Price > 0;
		}
	}
}