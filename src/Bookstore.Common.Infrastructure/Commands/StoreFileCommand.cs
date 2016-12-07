using Bookstore.Common.Infrastructure.Interfaces;
using System.IO;

namespace Bookstore.Common.Infrastructure.Commands
{
	public class StoreFileCommand : ICommandValidator
	{
		public Stream FileContent { get; }

		public string FileName { get; }

		public int BookId { get; }

		public StoreFileCommand(string fileName, Stream fileContent, int bookId)
		{
			FileName = fileName;
			FileContent = fileContent;
			BookId = bookId;
		}

		public bool IsValidCommand()
		{
			return !string.IsNullOrWhiteSpace(FileName) &&
				FileContent != null &&
				BookId > 0;
		}
	}
}
