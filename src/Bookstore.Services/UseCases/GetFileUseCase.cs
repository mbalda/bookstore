using System;
using System.IO;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;

namespace Bookstore.Services.UseCases
{
	public class GetFileUseCase : IQueryHandler<GetFileForBookQuery, string>
	{
		private readonly IImageRepository _imageRepository;

		public GetFileUseCase(IImageRepository imageRepository)
		{
			_imageRepository = imageRepository;
		}

		public string Handle(GetFileForBookQuery query)
		{
			var imageEntity = _imageRepository.GetImageByBookId(query.BookId);

			return ReadFile(imageEntity?.Name);
		}

		private string ReadFile(string fileName)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

			var fileLocation = Path.Combine(path, fileName);

			var fileStream = File.Open(fileLocation, FileMode.Open, FileAccess.Read, FileShare.Read);

			return ConvertToBase64(fileStream);
		}

		private string ConvertToBase64(Stream fileStream)
		{
			byte[] bytes;

			using (var memoryStream = new MemoryStream())
			{
				fileStream.CopyTo(memoryStream);
				bytes = memoryStream.ToArray();
			}

			return Convert.ToBase64String(bytes);
		}
	}
}
