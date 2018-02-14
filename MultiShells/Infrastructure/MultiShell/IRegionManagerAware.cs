using Prism.Regions;

namespace Infrastructure.MultiShell
{
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}
