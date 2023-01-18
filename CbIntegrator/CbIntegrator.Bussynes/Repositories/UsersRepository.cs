using CbIntegrator.Bussynes.Exceptions;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Options;
using MySqlConnector;
using System.Data.Common;
using System.Data.SqlClient;

namespace CbIntegrator.Bussynes.Repositories
{
	public class UsersRepository : DbConnector, IUsersRepository
	{
		public UsersRepository(DbOptions configuration) : base(configuration)
		{
		}

		/// <inheritdoc/>
		public User GetUser(string login, string password)
		{
			var user = Execute(c => GetUserInternal(c, login, password));
			return user;
		}
		/// <inheritdoc/>
		public User Register(string login, string password)
		{
			var user = Execute(c => RegisterInternal(c, login, password));
			return user;
		}
		/// <inheritdoc/>
		public bool IsUserExists(string login)
        {
			var result = Execute(c => ISUserExistsInternal(c, login));
			return result;
        }

		private User RegisterInternal(DbConnection sqlConnection, string login, string password)
		{
			using var cmd = new MySqlCommand(@$"
					insert into users(id, login, password)
					value(@id, @login, @password)",
					  (MySqlConnection)sqlConnection);

			cmd.Parameters.AddWithValue("id", Guid.NewGuid());
			cmd.Parameters.AddWithValue("login", login);
			cmd.Parameters.AddWithValue("password", password);
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			return GetUserInternal(sqlConnection, login, password);
		}
		private bool ISUserExistsInternal(DbConnection sqlConnection, string login)
        {
			using var cmd = new MySqlCommand(@$"
					select 
						login
					from 
						users 
					where 
						login = @login",
					  (MySqlConnection)sqlConnection);
			cmd.Parameters.AddWithValue("login", login);
			cmd.Connection.Open();
			using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
				cmd.Connection.Close();
				return true;
            }
			cmd.Connection.Close();
			return false;
        }
		private User GetUserInternal(DbConnection sqlConnection, string login, string password)
		{
			using var cmd = new MySqlCommand(@$"
					select 
						login, password
					from 
						users 
					where 
						login = @login and 
						password = @password",
					  (MySqlConnection)sqlConnection);

			cmd.Parameters.AddWithValue("login", login);
			cmd.Parameters.AddWithValue("password", password);
			cmd.Connection.Open();
			using var reader = cmd.ExecuteReader();
			if (!reader.Read())
			{
				throw new UserNotFoundException();
			}
			var user = new User();
			user.Login = reader.GetString(0);
			user.Password = reader.GetString(1);
			cmd.Connection.Close();
			return user;
		}
	}
}