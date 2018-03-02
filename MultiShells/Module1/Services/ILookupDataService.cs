using System.Collections.Generic;
using AI.Infrastructure.CommonModels;
using AI.Reports.Entities;

namespace AI.Reports.Module.Services
{
    public interface ILookupDataService
    {
        List<IdNamePair> Regions { get; }
        List<IdNamePair> Countries { get; }
        List<IdNamePair> Bases { get; }
        List<IdNamePair> Statuses { get; }
        List<Date> Dates { get; }      
        int MinDateId { get; }
    }
}
