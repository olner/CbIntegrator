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
    /// <summary>
    /// Класс для работы с Веб Сервисом DailyInfo ЦБ РФ
    /// </summary>
    public class CbDataService
    {
        CbService.DailyInfoSoapClient service = new CbService.DailyInfoSoapClient(CbService.DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
        /// <summary>
        /// Возвращает курс на сегодняшний день в ввиде DataTable
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetTodayCurs()
        {
            //var service = new CbService.DailyInfoSoapClient(CbService.DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap12);
            return XElementExtensions.ToDataTable(service.GetCursOnDate(DateTime.Now).Nodes);
        }
    }
}
