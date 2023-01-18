using CbIntegrator.Bussynes.Exceptions;
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
        private readonly IMainFormFactory mainFormFactory;
        private readonly IUsersService usersService;
        public RegistrationForm(IMainFormFactory mainFormFactory, IUsersService usersService)
        {
            InitializeComponent();
            this.mainFormFactory = mainFormFactory;
            this.usersService = usersService;
        }

        private void RegistartionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var user = usersService.Register(loginTb.Text, passwordTb.Text);
            }
            catch(ServiceException)
            {
                MessageBox.Show("Такой пользователь уже есть");
                return;
            }
            var form = mainFormFactory.Create();
            form.Show();
            this.Close();
        }
    }
}
