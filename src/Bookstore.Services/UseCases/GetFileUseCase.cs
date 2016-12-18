using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Infrastructure.Queries;
using System;
using System.IO;

namespace Bookstore.Services.UseCases
{
	public class GetFileUseCase : IQueryHandler<GetFileForBookQuery, Stream>
	{
		private readonly IImageRepository _imageRepository;

		public GetFileUseCase(IImageRepository imageRepository)
		{
			_imageRepository = imageRepository;
		}

		public Stream Handle(GetFileForBookQuery query)
		{
			var imageEntity = _imageRepository.GetImageByBookId(query.BookId);

			return ReadFile(imageEntity?.Name);
		}

		private Stream ReadFile(string fileName)
		{
			//if (string.IsNullOrWhiteSpace(fileLocation))
			//	return null;

			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

			var fileLocation = Path.Combine(path, fileName);

			return File.Open(fileLocation, FileMode.Open, FileAccess.Read, FileShare.Read);
		}
	}
}
