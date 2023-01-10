using CbIntegrator.Bussynes.Services;
using CbIntegrator.UI.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CbIntegrator.UI.Froms
{
    public partial class RegistrationForm : Form
    {
        private readonly IRegistrationFormFactory registrationFormFactory;
        private readonly IUsersService usersService;
        public RegistrationForm(IMainFormFactory mainFormFactory, IUsersService usersService)
        {
            InitializeComponent();
            this.registrationFormFactory = registrationFormFactory;
            this.usersService = usersService;
        }
    }
}
