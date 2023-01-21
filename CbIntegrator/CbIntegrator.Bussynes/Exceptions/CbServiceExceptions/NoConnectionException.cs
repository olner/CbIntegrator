using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbIntegrator.Bussynes.Exceptions.CbServiceExceptions
{
    /// <summary>
	/// Отсутвует подключение к интернету
	/// </summary>
    public class NoConnectionException : ServiceException
    {
        public NoConnectionException() : base("No Internet Connections")
        {
        }
    }
}
