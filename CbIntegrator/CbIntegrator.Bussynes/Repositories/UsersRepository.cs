﻿using CbIntegrator.Bussynes.Exceptions;
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

		public User Register(string login, string password)
		{
			var user = Execute(c => RegisterInternal(c, login, password));
			return user;
		}

		private User RegisterInternal(DbConnection sqlConnection, string login, string password)
		{
			using var cmd = new SqlCommand(@$"
					insert into users(id, login, password)
					value(@id, @login, @password)",
					  (SqlConnection)sqlConnection);

			cmd.Parameters.AddWithValue("id", Guid.NewGuid());
			cmd.Parameters.AddWithValue("login", login);
			cmd.Parameters.AddWithValue("password", password);

			cmd.ExecuteNonQuery();

			return GetUserInternal(sqlConnection, login, password);
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

			return new User
			{
				Login = reader.GetString(0),
				Password = reader.GetString(1)
			};
		}
	}
}