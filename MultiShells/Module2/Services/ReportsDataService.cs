using System.Reflection;
using AI.Infrastructure.Log;
using AI.Reports.Entities;

namespace AI.Reports.Module.Services
{
    public class ReportsDataService : IReportsDataService
    {
        private readonly ILookupDataService _lookupDataService;
        private readonly ILogger _logger = LogManager.GetLogger(Assembly.GetExecutingAssembly());

        public ReportsDataService(ILookupDataService lookupDataService)
        {
            _lookupDataService = lookupDataService;
            Entities = new ReportsEntities();
            Entities.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        #region Public Properties

        public ReportsEntities Entities { get; private set; }

        #endregion Public Properties
    }
}
