using CbIntegrator.Bussynes.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CbIntegrator.Bussynes.Services
{
    public class CbDataService
    {
        CbService.DailyInfoSoapClient service = new CbService.DailyInfoSoapClient(CbService.DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
        public DataTable GetCurs()
        {
            var service = new CbService.DailyInfoSoapClient(CbService.DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap12);
            var curse = service.GetCursOnDate(DateTime.Now);
            var nodes = curse.Nodes;
            var dt = XElementExtensions.ToDataTable(nodes);
            return dt;
            
        }
    }
}
