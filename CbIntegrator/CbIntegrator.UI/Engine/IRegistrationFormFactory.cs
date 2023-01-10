using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CbIntegrator.UI.Froms;

namespace CbIntegrator.UI.Engine
{
    public interface IRegistrationFormFactory
    {
        RegistrationForm Create();
    }
}
