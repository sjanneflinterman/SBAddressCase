using System.Threading.Tasks;
using SBData.Entities;

namespace Geolocation
{
    public interface IGeolocationService
    {
        public Task<double> GetDistance(Address start, Address end);
    }
}
