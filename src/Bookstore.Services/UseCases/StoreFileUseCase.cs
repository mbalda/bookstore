using Bookstore.Common.Infrastructure.Commands;
using Bookstore.Common.Infrastructure.Interfaces;
using Bookstore.Common.Models.DomainModels;
using System;
using System.IO;

namespace Bookstore.Services.UseCases
{
	public class StoreFileUseCase : ICommandHandler<StoreFileCommand>
	{
		private readonly IImageRepository _imageRepository;

		public StoreFileUseCase(IImageRepository imageRepository)
		{
			_imageRepository = imageRepository;
		}

		public void Handle(StoreFileCommand command)
		{
			var fileLocations = StoreFile(command.FileName, command.FileContent);

			Image image = new Image
			{
				BookId = command.BookId,
				Location = fileLocations,
				Name = command.FileName
			};

			_imageRepository.Insert(image);
		}

		private string StoreFile(string fileName, Stream fileContent)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			var filePath = Path.Combine(path, fileName);

			using (var file = File.Create(filePath))
			{
				fileContent.CopyTo(file);
			}

			return path;
		}
	}
}
