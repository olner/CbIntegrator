using CbIntegrator.Bussynes.Options;
using CbIntegrator.Bussynes.Repositories;
using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Froms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbIntegrator.UI.Engine
{
    internal class RegistrationFormFactory : IRegistrationFormFactory
    {

        private Lazy<RegistrationForm> _form;

        public  RegistrationFormFactory(ApplicationContext context, IMainFormFactory mainFormFactory, IUsersService usersService)
        {
            var dbOptions = new DbOptions
            {
                ConnectionString = System.Configuration.ConfigurationManager.
                                            ConnectionStrings["MySqLConnectionString"].ConnectionString
            };
            _form = new Lazy<RegistrationForm>(() =>
            {
                var form = new RegistrationForm(mainFormFactory,usersService);
                context.MainForm = form;
                return form;
            });
        }
        public RegistrationForm Create()
        {
            return _form.Value;
        }
    }
}
