﻿using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Services;
namespace CbIntegrator.UI.Engine
{
	public class MainFormFactory : IMainFormFactory
	{
		
		private Lazy<MainForm> _form;

		public MainFormFactory(ApplicationContext context, IUsersRepository repository, ICbDataService service)
		{
			_form = new Lazy<MainForm>(() =>
			{
				var form = new MainForm(repository,service);
				context.MainForm = form;
				return form;
			});	
		}

		public MainForm Create()
		{
			return _form.Value;
		}
	}
}
