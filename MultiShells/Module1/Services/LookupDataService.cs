using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AI.Infrastructure.CommonModels;
using AI.Infrastructure.Log;
using AI.Reports.Entities;

namespace AI.Reports.Module.Services
{
    public class LookupDataService : ILookupDataService
    {
        private readonly ILogger _logger = LogManager.GetLogger(Assembly.GetExecutingAssembly());

        public LookupDataService()
        {
        }

        #region Public Properties

        private List<IdNamePair> _regions;

        public List<IdNamePair> Regions
        {
            get
            {
                if (_regions == null)
                {
                    Load();
                }
                return _regions;
            }
        }

        private List<IdNamePair> _countries;

        public List<IdNamePair> Countries
        {
            get
            {
                if (_countries == null)
                {
                    Load();
                }
                return _countries;
            }
        }

        private List<IdNamePair> _bases;

        public List<IdNamePair> Bases
        {
            get
            {
                if (_bases == null)
                {
                    Load();
                }
                return _bases;
            }
        }

        private List<IdNamePair> _statuses;

        public List<IdNamePair> Statuses
        {
            get
            {
                if (_statuses == null)
                {
                    Load();
                }
                return _statuses;
            }
        }

        private List<Date> _dates;

        public List<Date> Dates
        {
            get
            {
                if (_dates == null)
                {
                    Load();
                }
                return _dates;
            }
        }

        public int MinDateId { get; private set; }

        #endregion Public Properties

        private void Load()
        {
            using (ReportsEntities entity = new ReportsEntities())
            {
                try
                {
                    //_regions = entity.regions.Select(r => new IdNamePair() { Id = r.region_id, Name = r.region1 }).ToList();
                    //_countries = entity.countries.Select(c => new IdNamePair() { Id = c.country_id, Name = c.country1 }).ToList();
                    //_bases = entity.bases.Select(b => new IdNamePair() { Id = b.base_id, Name = b.base_name }).ToList();
                    //_statuses = entity.reference_base_status.Select(s => new IdNamePair() { Id = s.id, Name = s.name }).ToList();
                    //_dates = entity.dates.OrderByDescending(o => o.date_id).ToList().Select(d => new Date(d.date_id, d.datestamp)).ToList();
                    //MinDateId = entity.dates.Min(d => d.date_id);
                    //_refBaseDataTypes = entity.reference_base_data_types.ToList();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
        }
    }
}
