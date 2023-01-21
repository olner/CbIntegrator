using CbIntegrator.Bussynes.Tools;
using CbIntegrator.Bussynes.Exceptions.CbServiceExceptions;
using System.Data;


namespace CbIntegrator.Bussynes.Services
{
    /// <summary>
    /// Класс для работы с Веб Сервисом DailyInfo ЦБ РФ
    /// </summary>
    public class CbDataService : ICbDataService
    {
        readonly CbService.DailyInfoSoapClient service = new(CbService.DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
        /// <summary>
        /// Возвращает курс на сегодняшний день в ввиде DataTable
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetTodayCurs()
        {
            //var service = new CbService.DailyInfoSoapClient(CbService.DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap12);
            try
            {
                return XElementExtensions.ToDataTable(service.GetCursOnDate(DateTime.Now).Nodes);
            }
            catch
            {
                throw new NoConnectionException();
            }

            return null;
        }
    }
}
