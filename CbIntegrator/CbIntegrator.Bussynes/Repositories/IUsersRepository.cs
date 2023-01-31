using CbIntegrator.Bussynes.Models;

namespace CbIntegrator.Bussynes.Repositories
{
    public interface IUsersRepository
    {
		/// <summary>
		/// Добро пожаловать на сервер Шизофрения
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <exception cref="UserNotFoundException">Если пользователь не авторизован ил не найден</exception>
		/// <returns></returns>
		User GetUser(string login, string password);
		User Register(string login, string password);
		bool IsUserExists(string login);
		List<string> GetUserCurse(string login);
		void AddUserCurs(string login, string curseName);
		void DeleteUserCurs(string login, string curseName);
	}
}