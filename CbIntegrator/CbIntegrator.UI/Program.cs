using CbIntegrator.Bussynes.Options;
using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Engine;
using CbIntegrator.UI.Froms;
using Microsoft.Extensions.Configuration;

namespace CbIntegrator.UI
{
	internal static class Program
	{
		static MainFormFactory mainFactory;
		static RegistrationFormFactory registrationFactory;
		static ApplicationContext context;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			context = new ApplicationContext();
			mainFactory = new MainFormFactory(context);
			

			var dbOptions = new DbOptions { ConnectionString = System.Configuration.ConfigurationManager.
											ConnectionStrings["MySqLConnectionString"].ConnectionString };
			var service = new UsersService(new UsersRepository(dbOptions));
			registrationFactory = new RegistrationFormFactory(context, mainFactory, service);


			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			
			var login = new LoginForm(mainFactory,registrationFactory, service);
			context.MainForm = login;
			Application.Run(context);			
		}
	}
}