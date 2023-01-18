using CbIntegrator.Bussynes.Models;

namespace CbIntegrator.Bussynes.Services
{
	public interface IUsersService
	{
		User? Authorize(string username, string password);
		User? Register(string username, string password);
	}
}