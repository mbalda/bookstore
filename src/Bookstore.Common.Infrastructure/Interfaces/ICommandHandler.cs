namespace Bookstore.Common.Infrastructure.Interfaces
{
	public interface ICommandHandler<T>
	{
		void Handle(T command);
	}
}