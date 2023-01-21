using CbIntegrator.Bussynes.Options;
using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Engine;
using CbIntegrator.UI.Froms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CbIntegrator.DbContexts;

namespace CbIntegrator.UI
{
	internal static class Program
	{
		private static IServiceProvider provider;
		static MainFormFactory mainFactory;
		static RegistrationFormFactory registrationFactory;
		static ApplicationContext context;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			provider = GetProvider();
			context = provider.GetRequiredService<ApplicationContext>();
			//mainFactory = new MainFormFactory(context);
			

			/*var dbOptions = new DbOptions { ConnectionString = System.Configuration.ConfigurationManager.
											ConnectionStrings["MySqLConnectionString"].ConnectionString };*/
			//var service = new UsersService(new UsersRepository());
			//registrationFactory = new RegistrationFormFactory(context, mainFactory, service);
			

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			
			//var login = new LoginForm(mainFactory,registrationFactory, service);
			context.MainForm = provider.GetRequiredService<LoginForm>();
			Application.Run(context);

			
		}
		private static IServiceProvider GetProvider()
        {
			var  services = new ServiceCollection();

			services.AddTransient<LoginForm>(sp =>
			{
				var mainFactory = sp.GetRequiredService<IMainFormFactory>();
				var registrationFactory = sp.GetRequiredService<IRegistrationFormFactory>();
				var userService = sp.GetRequiredService<IUsersService>();
				return new LoginForm(mainFactory,registrationFactory,userService);
			});
			services.AddTransient<MainForm>(sp =>
			{
				var cbService = sp.GetRequiredService<ICbDataService>();
				return new MainForm();
			});
			services.AddTransient<RegistrationForm>(sp =>
			{
				var mainFactory = sp.GetRequiredService<IMainFormFactory>();
				var userService = sp.GetRequiredService<IUsersService>();
				return new RegistrationForm(mainFactory, userService);
			});

			services.AddSingleton<IRegistrationFormFactory, RegistrationFormFactory>();
			services.AddSingleton<IMainFormFactory, MainFormFactory>();
			services.AddSingleton<IUsersService, UsersService>();
			services.AddSingleton<ICbDataService, CbDataService>();
			services.AddSingleton<ApplicationContext>();
			services.AddSingleton<IUsersRepository,UsersRepository>();

			return services.BuildServiceProvider();
        }
	}
}