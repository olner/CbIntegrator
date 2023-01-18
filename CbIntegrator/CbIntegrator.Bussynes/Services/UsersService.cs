using CbIntegrator.Bussynes.Exceptions;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Repositories;

namespace CbIntegrator.Bussynes.Services
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository repository;

		public UsersService(IUsersRepository repository)
		{
			this.repository = repository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		
		/// <returns></returns>
		public User? Authorize(string username, string password)
		{
			try
			{
				return repository.GetUser(username, password);
			}
			catch (UserNotFoundException)
			{
				return null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>

		/// <returns></returns>
		public User? Register(string username, string password)
		{
            if (repository.IsUserExists(username))
            {
				throw new ServiceException("Такой пользователь уже есть");
            }
			try
			{
				if(password is not { Length: > 6 } x || x.Contains("!"))
				{
					throw new ServiceException("");
				}
				return repository.Register(username, password);
			}
			catch (UserNotFoundException)
			{
				return null;
			}
		}
	}
}
