using CbIntegrator.Bussynes.Exceptions;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Options;
using CbIntegrator.DbContexts;
using MySqlConnector;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CbIntegrator.Bussynes.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		public UsersRepository()
		{
		}

		/// <inheritdoc/>
		public User GetUser(string login, string password)
		{
			var user = GetUserInternal(login, password);
			return user;
		}
		/// <inheritdoc/>
		public User Register(string login, string password)
		{
			var user = RegisterInternal(login, password);
			return user;
		}
		/// <inheritdoc/>
		public bool IsUserExists(string login)
        {
			var result = ISUserExistsInternal(login);
			return result;
        }
		/// <inheritdoc/>
		public List<string> GetUserCurse(string login)
        {
			return GetUserCurseInternal(login);
        }

		private User RegisterInternal(string login, string password)
		{
			using var context = new CbIntegratorDbContextFactory().CreateDbContext(null);
			UsersTable user = new UsersTable();
			user.Id = Guid.NewGuid().ToString();
			user.Login = login;
			user.Password = password;
			context.Users.Add(user);
			context.SaveChanges();
			return GetUserInternal(login, password);
		}

		private bool ISUserExistsInternal(string login)
		{
			using var context = new CbIntegratorDbContextFactory().CreateDbContext(null);
			var users = context.Users.Where(p => p.Login == login ).FirstOrDefault();
			if (users != null)
			{
				return true;
			}
			return false;
		}
		private User GetUserInternal(string login, string password)
		{
			using var context = new CbIntegratorDbContextFactory().CreateDbContext(null);
			var users =  context.Users.Where(p=>p.Login == login && p.Password == password).FirstOrDefault();
			if(users == null)
            {
				throw new UserNotFoundException();
			}
			var user = new User();
			user.Password = users.Password;
			user.Login = users.Login;
			return user;
		}
		private List<string> GetUserCurseInternal(string login)
        {
			//TODO: внешний ключ добавить и запрос сделать
			using var context = new CbIntegratorDbContextFactory().CreateDbContext(null);
			var res = context.UsersCurse.Where(p => p.UsersTable.Login == login).ToList();
			var curs = new List<string>();
			foreach(var d in res)
            {
				curs.Add(d.CurseName);
            }
			return curs;
        }
	}
}